using System;
using System.Collections.Generic;
using AutoMapper;
using Interviu.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Interviu.Controllers
{

    [Route("api/agreements")]
    [ApiController]
    public class AgreementController : ControllerBase
    {

        private readonly IAgreementRepo _repository;
        private readonly IMapper _mapper;
        private FileController _file; 

        public AgreementController(IAgreementRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _file = new FileController();
        }

        //GET api/agreements
        [HttpGet]
        public ActionResult<IEnumerable<Agreement>> GetAllAgreements()
        {
            var agreement = _repository.GetAllAgreements();
            return Ok(agreement);
        }

        //GET api/agrements/{Cod}
        [HttpGet("{cod}", Name = "GetAgreementById")]
        public ActionResult<Agreement> GetAgreementById(String cod)
        {
          
            try
            {
                var agreement = _repository.GetAgreementByCode(cod);
                if (agreement != null)
                {
                    
                    return Ok(agreement);

                }

                _file.ErrorLogging("Agreement not found!");
                return NotFound("Agreement not found!");
            }
            catch(Exception ex)
            {
                _file.ErrorLogging(ex.Message);
                return StatusCode(500);
            }
            


        }

        //POST api/agreements
        [HttpPost]
        public ActionResult<Agreement> CreateAgreement(Agreement agreement)
        {
            
            _repository.CreateAgreement(agreement);
            try
            {
                _repository.SaveChanges();

            }
            catch (SqlException ex)
            {
                
                if (ex.Number == 2627) 
                {
                    _file.ErrorLogging(ex.Message);
                    return BadRequest("Agreement already exists!");
                }

            }
            catch(Exception ex)
            {
                _file.ErrorLogging(ex.Message);
                return StatusCode(500);
            }

            return CreatedAtRoute(nameof(GetAgreementById), new {Cod = agreement.Cod }, agreement);
        }

        //PUT api/agreements/{cod}
        [HttpPut("{cod}")]
        public ActionResult UpdateAgreement(String cod, Agreement agreement)
        {
            try
            {

                var agreementModelFromRepo = _repository.GetAgreementByCode(cod);
                if (agreementModelFromRepo == null)
                {
                    _file.ErrorLogging("Agreement not found!");
                    return NotFound("Agreement not found!");
                }
                _repository.UpdateAgreement(agreementModelFromRepo, agreement);

                _repository.SaveChanges();
                return Ok(agreement);
            }
            catch(SqlException ex)
            {
                _file.ErrorLogging(ex.Message);
                return BadRequest("Agreement update failed!");
            }
            catch (Exception ex)
            {
                _file.ErrorLogging(ex.Message);
                return StatusCode(500);
            }


        }

        

        //DELETE api/agreements/{cod}
        [HttpDelete("{cod}")]
        public ActionResult DeleteAgreement(String cod)
        {
            
            try
            {
                var commandModelFromRepo = _repository.GetAgreementByCode(cod);
                if (commandModelFromRepo == null)
                {
                    _file.ErrorLogging("Agreement not found!");
                    return NotFound("Agreement not found!");
                }

                _repository.DeleteAgreement(commandModelFromRepo);
                _repository.SaveChanges();

            }catch(SqlException ex)
            {
                _file.ErrorLogging(ex.Message);
                return BadRequest("Agreement delete failed!");
            }
            catch (Exception ex)
            {
                _file.ErrorLogging(ex.Message);
                return StatusCode(500);
            }

            return Ok();
        }
    }
}