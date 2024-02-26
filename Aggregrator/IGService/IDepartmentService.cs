using Aggregrator.Services.Department.DTO;

namespace Aggregrator.IGService
{
    public interface IDepartmentService
    {

        public Task<List<DepartmentResponse>> List();

        public Task<DepartmentResponse> GetOne(int Id);
    }
}
