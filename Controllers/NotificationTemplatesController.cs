using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotificationTemplateManager.Data;
using NotificationTemplateManager.Models;

namespace NotificationTemplateManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationTemplatesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public NotificationTemplatesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/NotificationTemplates
        //[HttpGet]
        [HttpGet("[action]")]
        public IEnumerable<NotificationTemplate> GetTemplates()
        {
            return _context.Templates;
        }

        // GET: api/NotificationTemplates/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNotificationTemplate([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var notificationTemplate = await _context.Templates.FindAsync(id);

            if (notificationTemplate == null)
            {
                return NotFound();
            }

            return Ok(notificationTemplate);
        }

        // PUT: api/NotificationTemplates/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNotificationTemplate([FromRoute] int id, [FromBody] NotificationTemplate notificationTemplate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != notificationTemplate.Id)
            {
                return BadRequest();
            }

            _context.Entry(notificationTemplate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotificationTemplateExists(id))
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

        // POST: api/NotificationTemplates
        [HttpPost]
        public async Task<IActionResult> PostNotificationTemplate([FromBody] NotificationTemplate notificationTemplate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Templates.Add(notificationTemplate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNotificationTemplate", new { id = notificationTemplate.Id }, notificationTemplate);
        }

        // DELETE: api/NotificationTemplates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotificationTemplate([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var notificationTemplate = await _context.Templates.FindAsync(id);
            if (notificationTemplate == null)
            {
                return NotFound();
            }

            _context.Templates.Remove(notificationTemplate);
            await _context.SaveChangesAsync();

            return Ok(notificationTemplate);
        }

        private bool NotificationTemplateExists(int id)
        {
            return _context.Templates.Any(e => e.Id == id);
        }
    }
}