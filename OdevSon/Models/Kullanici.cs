using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OdevSon.Models
{
    public class Kullanici
    {
        public int KullaniciId { get; set; }
        [Required]
        public string KullaniciAd{ get; set; }
        [Required]
        public string Sifre { get; set; }
    }
}