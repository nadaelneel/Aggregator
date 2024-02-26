using Aggregrator.IGService;
using Aggregrator.Services.User.DTO;
using Aggregrator.Services.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Aggregrator.Services.Department.DTO;

namespace Aggregrator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            this.departmentService = departmentService;
        }
        [HttpGet("department/getone")]
        public async Task<DepartmentResponse> GetOne(int ID)
        {
            return await departmentService.GetOne(ID);
        }
        [HttpGet("department/getAll")]
        public async Task<List<DepartmentResponse>> GetAll()
        {
            return await departmentService.List();
        }
    }
}
