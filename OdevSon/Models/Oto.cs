using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OdevSon.Models
{
    public class Oto
    {
        [Key]
        public int AracId { get; set; }

        [Display(Name = "Arac Marka")]
        [Required(ErrorMessage = "Arac Marka Giriniz", AllowEmptyStrings = false)] //Required Islemi yaptiriyoruz
        public string Marka { get; set; }
        [Display(Name = "Arac Model")]
        [Required(ErrorMessage = "Arac Model Giriniz", AllowEmptyStrings = false)] 
        public string Model { get; set; }
      

    }
}