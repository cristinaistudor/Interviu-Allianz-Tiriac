using Interviu.Models;
using System;
using System.Collections.Generic;

namespace Interviu.Controllers
{
    public interface IAgreementRepo
    {
        void SaveChanges();

        IEnumerable<Agreement> GetAllAgreements();
        Agreement GetAgreementByCode(String Cod);
        void CreateAgreement(Agreement ag);
        void UpdateAgreement(Agreement source,Agreement target);
        void DeleteAgreement(Agreement ag);
    }
}