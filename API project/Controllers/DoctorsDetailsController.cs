using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api_project.Data;
using api_project.Models;
using api_project.Repository.DoctorDetailsservices;

namespace api_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsDetailsController : ControllerBase
    {
        private readonly IDoctorDetailservice _context;

        public DoctorsDetailsController(IDoctorDetailservice context)
        {
            _context = context;
        }

        // GET: api/DoctorsDetails
        [HttpGet]
        public async Task<ActionResult<List<DoctorsDetail>>> GetDoctorsDetails()
        {
            return await _context.GetDoctorsDetails();

        }
        // POST: api/DoctorsDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<List<DoctorsDetail>>> PostDoctorsDetail(DoctorsDetail doctorsDetail)
        {
            return await _context.PostDoctorsDetail(doctorsDetail);
        }

        // DELETE: api/DoctorsDetails/5
        [HttpDelete("{id}")]
        public async Task<String> DeleteDoctorsDetail(int id)
        {
            return await _context.DeleteDoctorsDetail(id);
            
        }


        /* // GET: api/DoctorsDetails/5
         [HttpGet("{id}")]
         public async Task<ActionResult<DoctorsDetail>> GetDoctorsDetail(int id)
         {
           if (_context.DoctorsDetails == null)
           {
               return NotFound();
           }
             var doctorsDetail = await _context.DoctorsDetails.FindAsync(id);

             if (doctorsDetail == null)
             {
                 return NotFound();
             }

             return doctorsDetail;
         }

         // PUT: api/DoctorsDetails/5
         // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
         [HttpPut("{id}")]
         public async Task<IActionResult> PutDoctorsDetail(int id, DoctorsDetail doctorsDetail)
         {
             if (id != doctorsDetail.DoctorId)
             {
                 return BadRequest();
             }

             _context.Entry(doctorsDetail).State = EntityState.Modified;

             try
             {
                 await _context.SaveChangesAsync();
             }
             catch (DbUpdateConcurrencyException)
             {
                 if (!DoctorsDetailExists(id))
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

        
         // DELETE: api/DoctorsDetails/5
         [HttpDelete("{id}")]
        

         private bool DoctorsDetailExists(int id)
         {
             return (_context.DoctorsDetails?.Any(e => e.DoctorId == id)).GetValueOrDefault();
         }*/
    }
}
