using Crud.Models;

namespace Crud.Services
{
    public interface IDepartmentService
    {
        Task<List<Department>> GetDepartmentsAsync();
        Task<Department> CreateDepartmentAsync(Department department);
        Task<Department> DeleteDepartmentAsync(Department Department);
        Task<Department> EditDepartmentAsync(Department department);
        Task<Department> GetDepartmentByIdAsync(int departmentId);
    }
}
