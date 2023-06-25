using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api_project.Data;
using api_project.Models;
using api_project.Repository.PatientDetailsservice;

namespace api_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientDetailsController : ControllerBase
    {
        private readonly IPatientdetailsservice _context;

        public PatientDetailsController(IPatientdetailsservice context)
        {
            _context = context;
        }

        // GET: api/PatientDetails
        [HttpGet]
        public async Task<ActionResult<List<PatientDetail>>> GetPatientDetails()
        {

            return await _context.GetPatientDetails();
        }

        // POST: api/PatientDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
     [HttpPost]
        public async Task<ActionResult<List<PatientDetail>>> PostPatientDetail(PatientDetail patientDetail)
        {
            return await _context.PostPatientDetail(patientDetail);
          
        }

        // DELETE: api/PatientDetails/5
        [HttpDelete("{id}")]
        public async Task<String> DeletePatientDetail(int id)
        {
            return await _context.DeletePatientDetail(id);
        }

        /*  // GET: api/PatientDetails/5
          [HttpGet("{id}")]
          public async Task<ActionResult<PatientDetail>> GetPatientDetail(int id)
          {
            if (_context.PatientDetails == null)
            {
                return NotFound();
            }
              var patientDetail = await _context.PatientDetails.FindAsync(id);

              if (patientDetail == null)
              {
                  return NotFound();
              }

              return patientDetail;
          }

          // PUT: api/PatientDetails/5
          // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
          [HttpPut("{id}")]
          public async Task<IActionResult> PutPatientDetail(int id, PatientDetail patientDetail)
          {
              if (id != patientDetail.PatientId)
              {
                  return BadRequest();
              }

              _context.Entry(patientDetail).State = EntityState.Modified;

              try
              {
                  await _context.SaveChangesAsync();
              }
              catch (DbUpdateConcurrencyException)
              {
                  if (!PatientDetailExists(id))
                  {
                      return NotFound();
                  }
                  else
                  {
                      throw;
                  }
              }

              return NoContent();
          }


          // DELETE: api/PatientDetails/5
          [HttpDelete("{id}")]
          public async Task<IActionResult> DeletePatientDetail(int id)
          {
              if (_context.PatientDetails == null)
              {
                  return NotFound();
              }
              var patientDetail = await _context.PatientDetails.FindAsync(id);
              if (patientDetail == null)
              {
                  return NotFound();
              }

              _context.PatientDetails.Remove(patientDetail);
              await _context.SaveChangesAsync();

              return NoContent();
          }

          private bool PatientDetailExists(int id)
          {
              return (_context.PatientDetails?.Any(e => e.PatientId == id)).GetValueOrDefault();
          }*/
    }
}
