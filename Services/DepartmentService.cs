using Crud.Models;
using System.Net.Http.Json;
namespace Crud.Services
{
    public class DepartmentService : IDepartmentService
    {

        private readonly HttpClient _httpClient;
        private readonly List<Department> _departments = new List<Department>();

        private const string BaseUrl = "https://stagging-blazorhybrid.arcapps.org/library-api/department";
        private const string BaseUrlGet = "https://stagging-blazorhybrid.arcapps.org/library-api/departments";

        public DepartmentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Department>> GetDepartmentsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Department>>(BaseUrlGet);
        }


        public async Task<Department> CreateDepartmentAsync(Department department)
        {
            var response = await _httpClient.PostAsJsonAsync(BaseUrl, department);
            return await response.Content.ReadFromJsonAsync<Department>();
        }
        public async Task<Department> EditDepartmentAsync(Department department)
        {
            var response = await _httpClient.PutAsJsonAsync($"{BaseUrl}/{department.oid}", department);
            return await response.Content.ReadFromJsonAsync<Department>();
        }
        public async Task<Department> DeleteDepartmentAsync(Department department)
        {
            var response = await _httpClient.DeleteAsync($"{BaseUrl}/{department.oid}");
            response.EnsureSuccessStatusCode();
            return null; // Placeholder return statement, you may need to adjust this based on your application logic
        }

        public async Task<Department> GetDepartmentByIdAsync(int departmentId)
        {
            var singleDeparment = await _httpClient.GetFromJsonAsync<Department>($"{BaseUrl}/{departmentId}");
            return singleDeparment;
        }


        // public async Task<Department> GetDepartmentByIdAsync(Department department)
        // {
        //     var departmentId = department.Oid; // Assuming "Oid" is the property representing the department ID
        //     var department = await HttpClient.GetFromJsonAsync<Department>($"{BaseUrl}/{departmentId}");
        //     return department;
        // }

    }
}
