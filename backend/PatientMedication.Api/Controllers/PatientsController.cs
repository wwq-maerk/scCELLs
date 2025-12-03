using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatientMedication.Api.Data;
using PatientMedication.Api.Models;

namespace PatientMedication.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public PatientsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Patient>>> GetPatients()
    {
        var patients = await _context.Patients.AsNoTracking().ToListAsync();
        return Ok(patients);
    }

    [HttpGet("{id}/schedules")]
    public async Task<ActionResult<IEnumerable<MedicationSchedule>>> GetSchedules(int id)
    {
        var schedules = await _context.MedicationSchedules
            .Where(s => s.PatientId == id)
            .AsNoTracking()
            .ToListAsync();
        return Ok(schedules);
    }
}
