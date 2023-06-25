using api_project.Data;
using api_project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class feedbackDetailsController : ControllerBase
    {
        private readonly RjHospitalContext _context;

        public feedbackDetailsController(RjHospitalContext context)
        {
            _context = context;
        }

        // GET: api/PatientDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FeedbackDetail>>> GetPatientDetails()
        {
            if (_context.PatientDetails == null)
            {
                return NotFound();
            }
            return await _context.FeedbackDetails.ToListAsync();
        }
        // DELETE: api/PatientDetails/5
        [HttpDelete("{id}")]
        public async Task<String>DeleteFeedbackDetail(int id)

        {
            return await _context.DeleteFeedbackDetail(id);
        }


        /* // GET: api/feedbackDetails/5
         [HttpGet("{id}")]
         public async Task<ActionResult<FeedbackDetail>> GetfeedbackDetail(int id)
         {
             if (_context.PatientDetails == null)
             {
                 return NotFound();
             }
             var patientDetail = await _context.FeedbackDetails.FindAsync(id);

             if (patientDetail == null)
             {
                 return NotFound();
             }

             return patientDetail;
         }

         // PUT: api/FeedbackDetails/5
         // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
         [HttpPut("{id}")]
         public async Task<IActionResult> PutPatientDetail(int id, FeedbackDetail FeedbackDetail)
         {
             if (id != FeedbackDetail.PatientId)
             {
                 return BadRequest();
             }

             _context.Entry(FeedbackDetail).State = EntityState.Modified;

             try
             {
                 await _context.SaveChangesAsync();
             }
             catch (DbUpdateConcurrencyException)
             {
                 if (!FeedbackDetailExists(id))
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

         // POST: api/PatientDetails
         // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
         [HttpPost]
         public async Task<ActionResult<FeedbackDetail>> PostFeedbackDetail(FeedbackDetail FeedbackDetail)
         {
             if (_context.FeedbackDetails == null)
             {
                 return Problem("Entity set 'RjHospitalContext.FeedbackDetails'  is null.");
             }
             _context.FeedbackDetails.Add(FeedbackDetail);
             await _context.SaveChangesAsync();

             return CreatedAtAction("GetFeedbackDetail", new { id = FeedbackDetail.PatientId }, FeedbackDetail);
         }


         private bool FeedbackDetailExists(int id)
         {
             return (_context.PatientDetails?.Any(e => e.PatientId == id)).GetValueOrDefault();
         }*/
    }
}
