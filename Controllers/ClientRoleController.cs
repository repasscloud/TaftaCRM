using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaftaCRM.Data;
using TaftaCRM.Models.Client.Permissions;

namespace TaftaCRM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientRoleController : ControllerBase
    {
        private readonly TaftaDbContext _context;

        public ClientRoleController(TaftaDbContext context)
        {
            _context = context;
        }

        // GET: api/ClientRole
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientRole>>> GetRoles()
        {
            return await _context.ClientRoles.Include(cr => cr.UserAccounts).ToListAsync();
        }

        // GET: api/ClientRole/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientRole>> GetClientRole(int id)
        {
            var clientRole = await _context.ClientRoles.FindAsync(id);

            if (clientRole == null)
            {
                return NotFound();
            }

            return clientRole;
        }

        // PUT: api/ClientRole/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClientRole(int id, ClientRole clientRole)
        {
            if (id != clientRole.Id)
            {
                return BadRequest();
            }

            _context.Entry(clientRole).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientRoleExists(id))
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

        // POST: api/ClientRole
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClientRole>> PostClientRole(ClientRole clientRole)
        {
            _context.ClientRoles.Add(clientRole);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClientRole", new { id = clientRole.Id }, clientRole);
        }

        // DELETE: api/ClientRole/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClientRole(int id)
        {
            var clientRole = await _context.ClientRoles.FindAsync(id);
            if (clientRole == null)
            {
                return NotFound();
            }

            _context.ClientRoles.Remove(clientRole);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClientRoleExists(int id)
        {
            return _context.ClientRoles.Any(e => e.Id == id);
        }
    }
}
