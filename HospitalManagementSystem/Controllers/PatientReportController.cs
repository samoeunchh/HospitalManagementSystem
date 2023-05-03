using HospitalManagementSystem.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Controllers;

public class PatientReportController : Controller
{
    private readonly ApplicationDbContext _context;
    public PatientReportController(ApplicationDbContext context)
    {
        _context=context;
    }
    public IActionResult Index()
    {
        return View();
    }
    public async Task<JsonResult> GetData(string search)
    => Json(await _context.Patient.Where(x=>x.PatientName.Contains(search)).ToListAsync());
}
