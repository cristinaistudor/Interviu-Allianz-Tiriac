using Interviu.Controllers;
using Interviu.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interviu.Data
{
    public class SqlAgreementRepo : IAgreementRepo
    {
        private readonly AgreementsContext _context;

        public SqlAgreementRepo(AgreementsContext context)
        {
            _context = context;
        }

        public void CreateAgreement(Agreement ag)
        {
            if (ag == null)
            {
                throw new ArgumentNullException(nameof(ag));
            }

            _context.Agreements.Add(ag);
        }

        public void DeleteAgreement(Agreement ag)
        {
            if (ag == null)
            {
                throw new ArgumentNullException(nameof(ag));
            }
            _context.Agreements.Remove(ag);
        }

        public IEnumerable<Agreement> GetAllAgreements()
        {
            

            return _context.Agreements.ToList();


        }

        public Agreement GetAgreementByCode(String cod)
        {
            Agreement agreement;
            try
            {
                agreement =  _context.Agreements.FirstOrDefault(p => p.Cod.Equals(cod));
            }
            catch(Exception ex)
            {
                throw;
            }
            return agreement;
        }

        public void SaveChanges()
        {
            
            try
            {
                _context.SaveChanges();

            }
            catch(Exception ex)
            {
                throw ex.InnerException;
            }
            
        }

        public void UpdateAgreement(Agreement source,Agreement target)
        {
            _context.Entry(source).CurrentValues.SetValues(target);

        }


    }
}