public class EmployeesService
{
    private readonly IEmployeesRepository _employeesRepository;

    public EmployeesService(IEmployeesRepository employeesRepository)
    {
        _employeesRepository = employeesRepository;
    }

    public async Task<IEnumerable<Employee>> GetEmployeesAsync()
    {
        return await _employeesRepository.GetEmployeesAsync();
    }
}