using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly EmployeesService _employeesService;

    public EmployeesController(EmployeesService employeesService)
    {
        _employeesService = employeesService;
    }

    [HttpGet]
    public async Task<IActionResult> GetEmployeesAsync()
    {
        var employees = await _employeesService.GetEmployeesAsync();
        if (employees == null || !employees.Any())
        {
            return NotFound();
        }

        return Ok(employees);
    }
}
