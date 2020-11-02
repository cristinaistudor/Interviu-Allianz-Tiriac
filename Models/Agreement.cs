using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Interviu.Controllers;

namespace Interviu.Models
{





    public class Agreement
    {
        [Key]
        [StringLength(7)]
        [RegularExpression(@"^CNP[0-9]{4}|CUI[0-9]{4}")]
        public String Cod { get; set; }

        [VerificarePersoana("nume")]
        public String Nume { get; set; }

        [VerificarePersoana("prenume")]
        public String Prenume  { get; set; }


        [VerificareCompanie]
        public String DenumireCompanie { get; set; }

        [Required]
        public String CodJudet { get; set; }

        [Required]
        [RegularExpression(@"^555[0-9]{6}$")]
        public int Phone { get; set; }

        [Required]
        [EmailAddress]
        public String Email { get; set; }

        [Required]
        [Range(typeof(bool), "true", "true", ErrorMessage = "You must accept the Terms")]
        public Boolean AcordPrelucrareDate { get; set; }

        [Required]
        public Boolean ComunicareMarketing { get; set; }

        [Required]
        [VerificareComunicare]
         public Boolean ComunicareEmail { get; set; }

        [Required]
        [VerificareComunicare]
        public Boolean ComunicareSMS { get; set;  }

        [Required]
        [VerificareComunicare]
        public Boolean ComunicarePosta { get; set; }

    }
}
