using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatientMedication.Api.Data;
using PatientMedication.Api.Models;

namespace PatientMedication.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SchedulesController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public SchedulesController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<MedicationSchedule>> Create(MedicationSchedule schedule)
    {
        var patientExists = await _context.Patients.AnyAsync(p => p.Id == schedule.PatientId);
        if (!patientExists)
        {
            return BadRequest(new { message = "患者不存在" });
        }

        _context.MedicationSchedules.Add(schedule);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = schedule.Id }, schedule);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MedicationSchedule>> GetById(int id)
    {
        var schedule = await _context.MedicationSchedules.FindAsync(id);
        if (schedule is null)
        {
            return NotFound();
        }
        return Ok(schedule);
    }
}
