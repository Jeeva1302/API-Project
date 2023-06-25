using api_project.Data;
using api_project.Models;
using api_project.Repository.AppointmentDatailsservices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentDetailsController : ControllerBase
    {
        private readonly IAppointmentDetailsservice _context;

        public AppointmentDetailsController(IAppointmentDetailsservice context)
        {
            _context = context;
        }

        // GET: api/CourseDetails
        [HttpGet]
        public async Task<ActionResult<List<AppointmentDetail>>> GetAppointmentDetails()
        {
            return await _context.GetAppointmentDetails();
        }

        /*// GET: api/CourseDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AppointmentDetail>> GetAppointmentDetail(int id)
        {
            if (_context.AppointmentDetails == null)
            {
                return NotFound();
            }
            var AppointmentDetail = await _context.AppointmentDetails.FindAsync(id);

            if (AppointmentDetail == null)
            {
                return NotFound();
            }

            return AppointmentDetail;
        }

        // PUT: api/CourseDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppointmentDetail(int id,AppointmentDetail AppointmentDetail)
        {
            if (id != AppointmentDetail.PatientId)
            {
                return BadRequest();
            }

            _context.Entry(AppointmentDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppointmentDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }*/

        // POST: api/CourseDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
       /* [HttpPost]
        public async Task<ActionResult<List<AppointmentDetail>>> PostAppointmentDetail(AppointmentDetail AppointmentDetail)
        {
            return await _context.PostAppointmentDetail(AppointmentDetail);
        }
/*
        // DELETE: api/CourseDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointmentDetail(int id)
        {
            if (_context.AppointmentDetails == null)
            {
                return NotFound();
            }
            var AppointmentDetail = await _context.AppointmentDetails.FindAsync(id);
            if (AppointmentDetail == null)
            {
                return NotFound();
            }

            _context.AppointmentDetails.Remove(AppointmentDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AppointmentDetailExists(int id)
        {
            return (_context.AppointmentDetails?.Any(e => e.PatientId == id)).GetValueOrDefault();
        }*/
    }
}
