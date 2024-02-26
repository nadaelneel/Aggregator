using Aggregrator.Dots;
using Aggregrator.Services.User.DTO;

namespace Aggregrator.Interfaces
{
    public interface IWorkflowDataHelper
    {
        public List<DepartmentResponse> GetDepartments(params int[] Ids);
        public List<UserResponse> GetUsers(params int[] Ids);
    }
}
