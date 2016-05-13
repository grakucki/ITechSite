using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Xml.Linq;
using System.Dynamic;
using System.Data.Entity.Validation;
using System.IO;
using System.Xml.Serialization;
using System.Text;
using ITechSite.Areas.Testy.Models;


namespace ITechSite.Areas.Testy.Controllers
{
    public class TestController : Controller
    {
        ITechSite.Areas.Testy.Models.TestyEntities db = new TestyEntities();
        private TestKompetencji test = new TestKompetencji();
        private string quantity = ConfigurationManager.AppSettings["TestSize"];
        public ActionResult Index()
        {
            ViewBag.quantity = this.quantity;
            return View();
        }

        private TestKompetencji prepareTest(TestKompetencji test, int resourceId, string accessionNumber, int UserId)
        {
            Test sTest = new Test();
            int ib = 0;
            try
            {
                ib++;
                var allowedCategories = db.AllowedCategories.Where(ac => ac.resourceId == resourceId).ToArray();
                List<Pytania> questions = new List<Pytania>();
                if (allowedCategories != null)
                {
                    for (int i = 0; i < allowedCategories.Length; i++)
                    {
                        int id = allowedCategories[i].categoryId;
                        var quests = db.Pytania.Where(q => q.categoryId == id).OrderBy(q => Guid.NewGuid()).ToList();
                        questions.AddRange(quests);
                    }
                }
                ib++;
                string guid;
                if (accessionNumber == null)
                {
                    guid = Guid.NewGuid().ToString();
                }
                else
                {
                    guid = accessionNumber;
                }
                ib++;
                sTest.accessionNumber = guid;
                List<TestQuestions> testQuestions = new List<TestQuestions>();
                List<Pytania> selectedQuestions = new List<Pytania>();
                ib++;
                Random rand = new Random(DateTime.Now.ToString().GetHashCode());
                ib++;
                for (int i = 0; i < Int32.Parse(this.quantity); i++)
                {
                    int idx = rand.Next(0, questions.Count);

                    if (questions.Count > idx)
                    {
                        selectedQuestions.Add(questions[idx]);
                        questions.RemoveAt(idx);
                    }
                }
                ib++;
                foreach (var q in selectedQuestions)
                {
                    var tQuest = new TestQuestions();
                    tQuest.id = q.id;
                    tQuest.content = q.content;
                    testQuestions.Add(tQuest);
                }
                ib++;
                sTest.questions = testQuestions.ToArray();
                test.accessionNumber = guid;
                ib++;
                // niezakończony
                test.stateId = 1;
                sTest.stateId = 1;
                sTest.userId = test.UserId;
                ib++;

                db.TestKompetencji.Add(test);
                db.SaveChanges();
                
                sTest.id = test.id;
                string xml;
                XmlSerializer serializer = new XmlSerializer(typeof(Test));
                using (StringWriter writer = new StringWriter())
                {
                    serializer.Serialize(writer, sTest);
                    xml = writer.ToString();
                }
                test.xml = xml;
                db.SaveChanges();
                this.test = test;
            }
            catch (Exception /*ex*/)
            {
                throw new Exception("Bład nr " + ib.ToString());            
            }
            return test;
        }


[HttpGet]
        public ActionResult ViewTest(string accessionNumber, int questionId = 0)
        {

            //TODO GR: Żle stosuje się styl dla przeglądania testu.
            //TODO GR: Na zakończenie przeglądania powrót na stronę z zakończonym testem /EndTest?accessionNumbe...

            var test = db.TestKompetencji.Where(t => t.accessionNumber == accessionNumber).FirstOrDefault();
            dynamic model = new ExpandoObject();

            if (test == null)
                return RedirectToAction("Index");

            XmlSerializer serializer = new XmlSerializer(typeof(Test));

            model.test = test;
            if(questionId == 0)
            {
                questionId = test.getFirstQuestionId();
            }

            var question = db.Pytania.Find(questionId);
            model.question = question;
            if (model.question == null)
            {
                model.question = new Pytania();
                model.question.content = "Brak pytań.";
            }


            var sTest = new Test();
        
            using(TextReader reader = new StringReader(test.xml))
            {
                sTest = (Test)serializer.Deserialize(reader);
            }


            List<UserAnswer> answers = new List<UserAnswer>();
            if (sTest.userAnswers!=null)
                answers = sTest.userAnswers.ToList();


            UserAnswer answer = answers.Where(a => a.questionId == questionId).SingleOrDefault();

            ViewBag.userAnswer = (answer!=null)?  answer.answerId : 0;;
            ViewBag.isCorrect = (answer != null) ? answer.isCorrect : true;
            if (question!=null)
                ViewBag.correctAnswer = question.Odpowiedzi.Where(o => o.is_correct == true).SingleOrDefault().id;

            return View(model);
        }

[HttpGet]
public ActionResult Test(int resourceId = 0, int questionId = 0, string accessionNumber = null, int UserId=0)
{
    dynamic myModel = new ExpandoObject();
    XmlSerializer serializer = new XmlSerializer(typeof(Test));

    TestKompetencji test = null;
    if (accessionNumber == null)
    {
        test = new TestKompetencji();
        test.createdAt = DateTime.Now;
        test.UserId = UserId;
        test = this.prepareTest(test, resourceId, accessionNumber, UserId);
    }
    else
    {
        test = db.TestKompetencji.Where(t => t.accessionNumber == accessionNumber).FirstOrDefault();
        if (test == null)
        {
            test = new TestKompetencji();
            test.createdAt = DateTime.Now;
            test.UserId = UserId;
            test = this.prepareTest(test, resourceId, accessionNumber, UserId);
        }
    }
    
    myModel.test = test;

    var sTest = new Test();
    using (TextReader reader = new StringReader(test.xml))
    {
        sTest = (Test)serializer.Deserialize(reader);
    }
    List<UserAnswer> uAnswers;
    if (sTest.userAnswers != null)
    {
        uAnswers = sTest.userAnswers.ToList();
    }
    else
    {
        uAnswers = new List<UserAnswer>();
    }

    if (sTest.questions.Count()==0)
    {
        return RedirectToAction("EndTest", new { accessionNumber = accessionNumber });
    }

    myModel.question = null;
    if (questionId != 0)
    {
        if (uAnswers.Where(u => u.questionId == questionId).SingleOrDefault() != null)
        {
            UserAnswer uAnswer = uAnswers.Where(u => u.questionId == questionId).SingleOrDefault();
            ViewBag.userAnswer = uAnswer.answerId;
        }
        else
        {
            ViewBag.userAnswer = null;
        }
        var question = db.Pytania.Find(questionId);
        myModel.question = question;
        return View(myModel);
    }
    return View(myModel);
}



        public void LogTest(int questionId, int testId, string answers = null)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Test));
            var log = new TestKompetencjiLog();
            var context = System.Web.HttpContext.Current;
            answers = context.Request["answers[]"];
            var test = db.TestKompetencji.Find(testId);
            var sTest = new Test();
            using (TextReader reader = new StringReader(test.xml))
            {
                sTest = (Test)serializer.Deserialize(reader);
            }
            List<UserAnswer> uAnswers;
            if (sTest.userAnswers != null)
            {
                uAnswers = sTest.userAnswers.ToList();
            }
            else
            {
                uAnswers = new List<UserAnswer>();
            }
            
            if (answers != null)
            {
                var ans = db.Odpowiedzi.Find(Int32.Parse(answers));
                if (uAnswers.Where(u => u.questionId == questionId).SingleOrDefault() != null)
                {
                    UserAnswer uAnswer = uAnswers.Where(u => u.questionId == questionId).Single();
                    uAnswer.answerId = Int32.Parse(answers);
                    uAnswer.isCorrect = ans.is_correct;
                }
                else
                {
                    var uAnswer = new UserAnswer();
                    uAnswer.answerId = Int32.Parse(answers);
                    uAnswer.questionId = questionId;
                    uAnswer.isCorrect = ans.is_correct;
                    uAnswers.Add(uAnswer);
                }
            }
            sTest.userAnswers = uAnswers.ToArray();
            log.loggedAt = DateTime.Now;
            log.questionId = questionId;
            log.TestId = testId;
            if (answers != null)
            {
                log.answers = answers;
            }
            else
            {
                log.answers = "brak";
            }
            string xml;
            using (StringWriter writer = new StringWriter())
            {
                serializer.Serialize(writer, sTest);
                xml = writer.ToString();
            }
            test.xml = xml;
            db.TestKompetencjiLog.Add(log);
            db.SaveChanges();
        }

        [HttpGet]
        public ActionResult EndTest(string accessionNumber)
        {
            var test = db.TestKompetencji.Where(t => t.accessionNumber == accessionNumber).FirstOrDefault();
            if (test==null)
                return View();

            int score = 0;

            XmlSerializer serializer = new XmlSerializer(typeof(Test));

            var sTest = new Test();

            using(TextReader reader = new StringReader(test.xml))
            {
                sTest = (Test)serializer.Deserialize(reader);
            }

            List<UserAnswer> uAnswers;

            if (sTest.userAnswers != null)
            {
                uAnswers = sTest.userAnswers.ToList();
            }
            else
            {
                uAnswers = new List<UserAnswer>();
            }

            if(uAnswers.Count() != 0)
            {
                foreach(var answer in uAnswers)
                {
                    if(answer.isCorrect)
                    {
                        score++;
                    }
                }
            }

            sTest.score = score;
            StanTestu state;
            //if (score == Int32.Parse(this.quantity))
            if (score == sTest.questions.Count())
            {
                state = db.StanTestu.Where(s => s.name == "Zdany").FirstOrDefault();
            }
            else
            {
                state = db.StanTestu.Where(s => s.name == "Niezdany").FirstOrDefault();
            }
            sTest.stateId = state.id;
            string xml;
            using (StringWriter writer = new StringWriter())
            {
                serializer.Serialize(writer, sTest);
                xml = writer.ToString();
            }
            test.xml = xml;
            test.stateId = state.id;
            if (!test.finishedAt.HasValue)
                test.finishedAt = DateTime.Now;
            test.score = score;
            db.SaveChanges();

            ViewBag.score = score;
            ViewBag.quantity = sTest.questions.Count();
            ViewBag.state = state.name;
            ViewBag.accessionNumber = accessionNumber;
            return View();
        }

[HttpGet]
        public FileContentResult getTestResult(string accessionNumber)
        {
            var test = db.TestKompetencji.Where(t => t.accessionNumber == accessionNumber).FirstOrDefault();

            XmlSerializer serializer = new XmlSerializer(typeof(TestResult));
            var testResult = new TestResult();

            StanTestu state = db.StanTestu.Find(test.stateId);

            testResult.accessionNumber = accessionNumber;
            testResult.id = test.id;
            testResult.score = test.score;
            testResult.state = state.name;

            string xml;
            using(StringWriter writer = new StringWriter())
            {
                serializer.Serialize(writer, testResult);
                xml = writer.ToString();
            }

            var contentType = "text/xml";
            var bytes = Encoding.UTF8.GetBytes(xml);
            var result = new FileContentResult(bytes, contentType);
            result.FileDownloadName = accessionNumber + ".xml";
            return result;
        }
    }
}
