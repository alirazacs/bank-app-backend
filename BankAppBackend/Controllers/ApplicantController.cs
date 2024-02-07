﻿using Microsoft.AspNetCore.Mvc;
using BankAppBackend.Models;
using Microsoft.EntityFrameworkCore;
using BankAppBackend.Service.Interfaces;
using BankAppBackend.Exceptions;

namespace BankAppBackend.Controllers
{
    [Route("api/applicant")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {
        private readonly IApplicantService applicantService;
        
        public ApplicantController(IApplicantService applicantService)
        {
            this.applicantService = applicantService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Applicant>> GetAllApplicants()
        {
            // Logic to fetch data and return a response
            return Ok(applicantService.GetAllApplicantList());
        }

        [HttpGet("{id}")]
        public  ActionResult<Applicant> FindApplicantById(long id)
        {
            try
            {
                var applicant = applicantService.GetApplicantById(id);
                return Ok(applicant);
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception.ToString());
                if (exception.GetType().Equals(typeof(EntityNotFound)))
                {
                    return NotFound(exception.Message);
                }
                return BadRequest(exception.Message);   
            }
        }

        [HttpPost]
        public ActionResult<Applicant> AddApplicant([FromBody] Applicant applicant)
        {
            try
            {
                Applicant savedApplicant = applicantService.AddApplicant(applicant);
                return Ok(savedApplicant);
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception.ToString());
                if (exception.GetType().Equals (typeof(EntityAlreadyExist)))
                {
                    return Conflict(exception.Message);
                }
                return BadRequest(exception.Message);
            }
        }

    }
}
