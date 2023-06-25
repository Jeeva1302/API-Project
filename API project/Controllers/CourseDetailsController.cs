using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api_project.Data;
using api_project.Models;
using api_project.Repository.CourseDetailsservice;
using Microsoft.AspNetCore.Authorization;

namespace api_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CourseDetailsController : ControllerBase
    {
        private readonly ICoursedetailsservice _context;

        public CourseDetailsController(ICoursedetailsservice context)
        {
            _context = context;
        }

        // GET: api/CourseDetails
        [HttpGet]
        public async Task<ActionResult<List<CourseDetail>>> GetCourseDetails()
        {
          return await _context.GetCourseDetails();
        }
        // POST: api/CourseDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<List<CourseDetail>>> PostCourseDetail(CourseDetail courseDetail)
        {
            return await _context.PostCourseDetail(courseDetail);
        }

        // DELETE: api/CourseDetails/5
        [HttpDelete("{id}")]
        public async Task<String> DeleteCourseDetail(int id)
        {
            return await _context.DeleteCourseDetail(id);

        }
        // PUT: api/CourseDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<List<CourseDetail>> PutCourseDetail(int id, CourseDetail Coursedetails)
        {
            return await _context.PutCourseDetail(id, Coursedetails);
        }

        /* // GET: api/CourseDetails/5
         [HttpGet("{id}")]
         public async Task<ActionResult<CourseDetail>> GetCourseDetail(int id)
         {
           if (_context.CourseDetails == null)
           {
               return NotFound();
           }
             var courseDetail = await _context.CourseDetails.FindAsync(id);

             if (courseDetail == null)
             {
                 return NotFound();
             }

             return courseDetail;
         }

        


        
         private bool CourseDetailExists(int id)
         {
             return (_context.CourseDetails?.Any(e => e.CourseId == id)).GetValueOrDefault();
         }*/
    }
}
