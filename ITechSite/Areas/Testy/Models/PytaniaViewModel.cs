using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;


namespace ITechSite.Areas.Testy.Models
{
    public class PytaniaViewModel
    {
        public PytaniaViewModel() { }
        public PytaniaViewModel(string code)
        {
            this.code = code;
        }
        public int id { get; set; }
        [Display(Name = "Kod")]
        [Required(ErrorMessage = "Pole 'Kod' jest wymagane!")]
        //[UniqueCode]
        public string code { get; set; }
        [Display(Name = "Tekst")]
        [Required(ErrorMessage = "Pole 'Tekst' jest wymagane!")]
        public string content { get; set; }
        [Display(Name = "Typ odpowiedzi")]
        [Required(ErrorMessage = "Musisz wybrać typ odpowiedzi!")]
        public int answer_type { get; set; }
        [Display(Name = "Kategoria")]
        [Required(ErrorMessage = "Musisz wybrać kategorię pytania!")]
        public int categoryId { get; set; }
        [Display(Name = "Słowa kluczowe")]
        //[Required(ErrorMessage = "Pole 'Słowa kluczowe jest wymagane!")]
        public string keywords { get; set; }
        public Pytania Pytania { get; set; }
        public IEnumerable<SelectListItem> Kategorie { get; set; }
        [Display(Name = "Odpowiedź")]
        public List<string> answerContent { get; set; }
        [Display(Name="Odpowiedź poprawna")]
        public List<bool> isCorrect { get; set; }
        [Display(Name = "Odpowiedź poprawna")]
        public int isCorrectRatio { get; set; }

        public List<int> answerIds { get; set; }
    }
}