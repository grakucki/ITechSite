using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using ITechSite.Areas.Testy.Models;



namespace ITechSite.Areas.Testy.Controllers
{
    public class TestEditorController : Controller
    {
        private TestyEntities db = new TestyEntities();

        public ActionResult Index(int? page)
        {
            var x = db.Pytania.ToList();
            var questions = db.Pytania.ToArray();

            int pageSize = 20;
            int pageNo = (page ?? 1);
            return View(questions.ToPagedList(pageNo, pageSize));
        }
[HttpGet]
        public ActionResult Create()
        {
            var quest = new Pytania();
            IList<Kategorie> kategorie = db.Kategorie.ToList();
            IEnumerable<SelectListItem> selectList = from k in kategorie
                                                     select new SelectListItem
                                                         {
                                                             Selected = (k.id == 1),
                                                             Text = k.name,
                                                             Value = k.id.ToString()
                                                         };
            var quests = db.Pytania.Count();

            string code = "Pytanie " + (quests + 1);
            ViewBag.select = selectList;
            var model = new PytaniaViewModel(code) { Pytania = quest, Kategorie = selectList };
            return View(model);
        }

[HttpPost]
        public ActionResult Create(PytaniaViewModel model)
        {

                if (ModelState.IsValid)
                {
                    Pytania quest = new Pytania();
                    quest.content = model.content;
                    quest.code = model.code;
                    quest.answer_type = 1;
                    quest.categoryId = model.categoryId;
                    quest.keywords = model.keywords;
                    db.Pytania.Add(quest);
                    db.SaveChanges();

                    for (int i = 0; i < 4; i++)
                    {
                        Odpowiedzi answer = new Odpowiedzi();
                        answer.content = model.answerContent[i];
                        answer.questionId = quest.id;
                        answer.is_correct = (model.isCorrectRatio == i);
                        db.Odpowiedzi.Add(answer);
                    }
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            IList<Kategorie> kategorie = db.Kategorie.ToList();
            IEnumerable<SelectListItem> selectList = from k in kategorie
                                                     select new SelectListItem
                                                     {
                                                         Selected = (k.id == 1),
                                                         Text = k.name,
                                                         Value = k.id.ToString()
                                                     };
            model.Kategorie = selectList;
            return View(model);
        }

[HttpGet]
        public ActionResult Edit(int id)
        {
            var question = db.Pytania.Find(id);
            IList<Kategorie> kategorie = db.Kategorie.ToList();
            IEnumerable<SelectListItem> selectList = from k in kategorie
                                                     select new SelectListItem
                                                     {
                                                         Selected = (k.id == question.categoryId),
                                                         Text = k.name,
                                                         Value = k.id.ToString()
                                                     };
            var model = new PytaniaViewModel() { Pytania = question, Kategorie = selectList };
            model.answer_type = question.answer_type;
            model.categoryId = question.categoryId;
            model.id = question.id;
            model.code = question.code;
            model.content = question.content;
            model.keywords = question.keywords;
            var answers = db.Odpowiedzi.Where(a => a.questionId == id).ToList();
            model.answerContent = new List<string>();
            model.isCorrect = new List<bool>();
            model.answerIds = new List<int>();
            if (answers != null)
            {
                int i = 0;
                foreach (var answer in answers)
                {
                    model.answerContent.Add(answer.content);
                    model.isCorrect.Add(answer.is_correct);
                    if (answer.is_correct)
                        model.isCorrectRatio = i;
                    model.answerIds.Add(answer.id);
                    i++;
                }
            }
            return View(model);
        }

[HttpPost]
        public ActionResult Edit(PytaniaViewModel model)
        {
            if(ModelState.IsValid)
            {
                var question = db.Pytania.Find(model.id);
                question.keywords = model.keywords;
                question.answer_type = 1;
                question.categoryId = model.categoryId;
                question.code = model.code;
                question.content = model.content;
                db.SaveChanges();

                for(int i=0;i<4;i++)
                {
                    // TODO:GR A co jeśli zmienimy ilośc pytań Find nie zda egzaminu
                    var answer = db.Odpowiedzi.Find(model.answerIds[i]);
                    answer.content = model.answerContent[i];
                    answer.is_correct = (model.isCorrectRatio == i);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }

            return View(model);
        }

[HttpPost]
        public JsonResult removeAnswer(int id)
        {
            var answer = db.Odpowiedzi.Find(id);
            bool result = false;
            if(answer != null)
            {
                db.Odpowiedzi.Remove(answer);
                db.SaveChanges();
                result = true;
            }

            return Json(new
            {
                result = result
            });
        }

[HttpGet]
        public RedirectResult deleteQuestion(int id)
        {
            var question = db.Pytania.Find(id);

            if(question != null)
            {
                var answers = question.Odpowiedzi;
                db.Odpowiedzi.RemoveRange(answers);
                db.Pytania.Remove(question);
                db.SaveChanges();
            }

            return Redirect("/");
        }

[HttpGet]
        public ActionResult Categories(int? page)
        {
            var categories = db.Kategorie.ToArray();

            int pageSize = 10;
            int pageNo = (page ?? 1);

            return View(categories.ToPagedList(pageNo, pageSize));
        }

[HttpGet]
        public ActionResult CreateCategory()
        {
            var category = new Kategorie();
            return View(category);
        }

[HttpPost]
        public ActionResult CreateCategory(Kategorie category)
        {
            if(ModelState.IsValid)
            {
                db.Kategorie.Add(category);
                db.SaveChanges();

                return RedirectToAction("Categories");
            }

            return View(category);
        }

[HttpGet]
        public ActionResult EditCategory(int id)
        {
            var category = db.Kategorie.Find(id);
            return View(category);
        }

[HttpPost]
        public ActionResult EditCategory(int id, Kategorie category)
        {
            var dbCategory = db.Kategorie.Find(id);

            if (ModelState.IsValid)
            {
                dbCategory.name = category.name;
                db.SaveChanges();

                return RedirectToAction("Categories");
            }

            return View(category);
        }

        public RedirectResult deleteCategory(int id)
        {
            var category = db.Kategorie.Find(id);

            if(category.Pytania.Count() == 0)
            {
                db.Kategorie.Remove(category);
                db.SaveChanges();
                return Redirect("/Editor/Categories");
            }

            TempData["WarningMessage"] = "Nie można usunąc kategorii, ponieważ należą do niej pytania!";
            return Redirect("/Editor/Categories");
        }

[HttpGet]
        public ActionResult Resources(int? page)
        {
            var resources = db.Resource.ToList();

            int pageSize = 10;
            int pageNo = (page ?? 1);

            return View(resources.ToPagedList(pageNo, pageSize));
        }
[HttpGet]
        public ActionResult CreateResource()
        {
            var model = new ResourceViewModel();
            ViewBag.kategorie = db.Kategorie.ToList();
            return View(model);
        }

[HttpPost]
        public ActionResult CreateResource(ResourceViewModel model, int[] allowedCat)
        {
            if(ModelState.IsValid)
            {
                Resource resource = new Resource();
                resource.Name = model.name;
                resource.Type = 1;
                resource.Enabled = true;
                db.Resource.Add(resource);
                db.SaveChanges();

                if (allowedCat != null)
                {
                    foreach (var cat in allowedCat)
                    {
                        AllowedCategories allowed = new AllowedCategories();
                        allowed.categoryId = cat;
                        allowed.resourceId = resource.Id;
                        db.AllowedCategories.Add(allowed);
                        db.SaveChanges();
                    }
                }

                return RedirectToAction("Resources");
            }

            return View(model);
        }

[HttpGet]
        public ActionResult EditResource(int id)
        {
            var resource = db.Resource.Find(id);
            var model = new ResourceViewModel();
            model.name = resource.Name;
            ViewBag.kategorie = db.Kategorie.ToList();
            var categories = db.AllowedCategories.Where(ac => ac.resourceId == id).ToList();
            List<Kategorie> allowed = new List<Kategorie>();
            if(categories != null)
            {
                foreach(var c in categories)
                {
                    Kategorie cat = db.Kategorie.Find(c.categoryId);
                    allowed.Add(cat);
                }
            }
            model.categories = allowed;

            return View(model);
        }

[HttpPost]
        public ActionResult EditResource(int id, ResourceViewModel model, int[] allowedCat)
        {
            if(ModelState.IsValid)
            {
                var resource = db.Resource.Find(id);
                //resource.Name = model.name;
                List<AllowedCategories> allowed = new List<AllowedCategories>();
                allowed = db.AllowedCategories.Where(ac => ac.resourceId == id).ToList();
                db.AllowedCategories.RemoveRange(allowed);
                db.SaveChanges();
                if(allowedCat != null)
                {
                    foreach(var cat in allowedCat)
                    {
                        if(db.AllowedCategories.Where(ac => ac.resourceId == id && ac.categoryId == cat).SingleOrDefault() == null)
                        {
                            AllowedCategories a = new AllowedCategories();
                            a.resourceId = id;
                            a.categoryId = cat;
                            db.AllowedCategories.Add(a);
                            db.SaveChanges();
                        }
                        else
                        {
                            continue;
                        }
                    }
                }

                return RedirectToAction("Resources");
            }

            return View(model);
        }

        public RedirectResult deleteResource(int id)
        {
            var resource = db.Resource.Find(id);

            db.Resource.Remove(resource);
            db.SaveChanges();

            return Redirect("/Editor/Resources");
        }
    }
}
