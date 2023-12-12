// Controllers/Api/StaffApiController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/staff/")]
[ApiController]
public class StaffApiController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public StaffApiController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Staff>>> GetStaffs()
    {
        return await _context.Staffs.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Staff>> GetStaff(string id)
    {
        var staff = await _context.Staffs.FindAsync(id);

        if (staff == null)
        {
            return NotFound();
        }

        return staff;
    }

    [HttpPost]
    public async Task<ActionResult<Staff>> PostStaff(Staff staff)
    {
        _context.Staffs.Add(staff);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetStaff", new { id = staff.StaffID }, staff);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutStaff(string id, Staff staff)
    {
        if (id != staff.StaffID)
        {
            return BadRequest();
        }

        _context.Entry(staff).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!StaffExists(id))
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

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStaff(string id)
    {
        var staff = await _context.Staffs.FindAsync(id);
        if (staff == null)
        {
            return NotFound();
        }

        _context.Staffs.Remove(staff);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool StaffExists(string id)
    {
        return _context.Staffs.Any(e => e.StaffID == id);
    }
}
