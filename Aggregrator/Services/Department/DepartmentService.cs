using Aggregrator.IGService;
using Aggregrator.Interfaces;
using Aggregrator.Services.Department.DTO;
using Aggregrator.Services.User.DTO;
using Deopartments.Application;
using UserApp.Application;

namespace Aggregrator.Services.Department
{
    public class DepartmentService : IDepartmentService
    {
        private readonly UserItem.UserItemClient _userClient;
        private readonly DepartmentItem.DepartmentItemClient _deptClient;
        private readonly IWorkflowDataHelper helper;
        public async Task<DepartmentResponse> GetOne(int Id)
        {
            var deptId = new ReadDepartmentRequest()
            {
                Id = Id
            };
            var response = _deptClient.ReadOne(deptId);
            if (response == null)
            {
                throw new NotImplementedException();
            }
            var userrequest = new GetAllUserRequest();
            var users = _userClient.ListUser(userrequest);
            var departmentUsers = new List<string>();
            foreach ( var user in users.Users )
            {
                departmentUsers.Add(user.Name);
                
            }
            var department = new DepartmentResponse()
            {
                Id = response.Id,
                Name = response.Name,
                Users = departmentUsers
            };
            
            return department;

        }

        public async Task<List<DepartmentResponse>> List()
        {
            var request = new GetAllDepartmentRequest();
            //get all department
            var list = _deptClient.ListDepartment(request);
            var departments = new List<DepartmentResponse>();
            var userrequest = new GetAllUserRequest();
            var usersList = _userClient.ListUser(userrequest);
            var departmentUsers = new List<string>();

            foreach (var dept in departments)
            {
                foreach (var user in usersList.Users)
                {
                    if (user.DepartemntId == dept.Id)
                    {
                        departmentUsers.Add(user.Name);
                    }
                }
                departments.Add(new DepartmentResponse()
                {
                    Id = dept.Id,
                    Name = dept.Name,
                    Users = departmentUsers
                });
            }

            return departments;
        }
    }   
}
