public interface IEmployeesRepository
{
    Task<IEnumerable<Employee>> GetEmployeesAsync();
}