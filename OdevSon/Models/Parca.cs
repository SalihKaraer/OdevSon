using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OdevSon.Models
{
    public class Parca
    {
        public int  ParcaId { get; set; }
        [Required]
        public string ParcaAd { get; set; }
        [Required]
        public string ParcaTur { get; set; }

    }
}