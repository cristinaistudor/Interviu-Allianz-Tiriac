using System.ComponentModel.DataAnnotations;
using Interviu.Models;

namespace Interviu.Controllers
{
    public class VerificareCompanie : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var agreement = (Agreement)validationContext.ObjectInstance;

            if (agreement.Cod.Contains("CUI"))
            {
                if (agreement.DenumireCompanie == null || agreement.DenumireCompanie.Length == 0)
                {
                    return new ValidationResult("This field is required");
                }
            }

            return ValidationResult.Success;
        }
    }

    public class VerificarePersoana : ValidationAttribute
    {
        private string _camp;
        public VerificarePersoana(string camp)
        {
            _camp = camp;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var agreement = (Agreement)validationContext.ObjectInstance;


            if (agreement.Cod.Contains("CNP"))
            {
                if (_camp == "nume")
                {

                    if (agreement.Nume == null || agreement.Nume.Length == 0)
                    {
                        return new ValidationResult("This field is required");
                    }
                }

                if (_camp == "prenume")
                {

                    if (agreement.Prenume == null || agreement.Prenume.Length == 0)
                    {
                        return new ValidationResult("This field is required");
                    }
                }


            }
            return ValidationResult.Success;


        }
    }


    public class VerificareComunicare : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var agreement = (Agreement)validationContext.ObjectInstance;
            if (agreement.ComunicareEmail|| agreement.ComunicareSMS|| agreement.ComunicarePosta)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("At least one of ComunicareEmail, ComunicareSMS, ComunicarePosta must be true");

        }
    }
}
