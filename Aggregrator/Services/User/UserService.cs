using Aggregrator.IGService;
using Aggregrator;
using Aggregrator.Interfaces;
using Grpc.Net.Client;
using Aggregrator.Services.User.DTO;
using UserApp.Application;
using Deopartments.Application;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Aggregrator.Services.User
{
    public class UserService  : IUserService
    {

        private readonly UserItem.UserItemClient _userClient;
        private readonly DepartmentItem.DepartmentItemClient _deptClient;
        private readonly IWorkflowDataHelper helper;

        public async Task<int> create(CreateUserRequestDto request)
        {
            var deptId = new ReadDepartmentRequest
            {
                Id = request.DepartemntId
            };
            var dept = _deptClient.ReadOne(deptId);
            if (dept == null)
            {
                throw new NotImplementedException();
            }

            var user = new createUserRequest
            {
                Name = request.Name,
                DepartemntId = request.DepartemntId,
            };
            var respone = _userClient.createUser(user);
            return respone.Id;

        }


        public async Task<UserResponse> GetOne(int Id)
        {
            var userId = new ReadUserRequest()
            {
                Id = Id
            };
            var response=  _userClient.ReadOne(userId);
            if(response == null)
            {
                throw new NotImplementedException();
            }
            var deptId = new ReadDepartmentRequest()
            {
                Id = response.DepartemntId
            };
            var dept = _deptClient.ReadOne(deptId);
            var user = new UserResponse()
            {
                Id = Id,
                Name = response.Name,
                DepartmentName = dept.Name
            };
            return user;
           
        }


        public async Task<List<UserResponse>> List()
        {
            var request = new GetAllUserRequest();
            var list =  _userClient.ListUser(request);
            var users = new List<UserResponse>();
            var deptIds = new List<ReadDepartmentRequest>();
           
            foreach (var user in list.Users) 
            {
                deptIds.Add(new ReadDepartmentRequest()
                {
                    Id = user.DepartemntId
                }) ;
                var Id = new ReadDepartmentRequest()
                {
                    Id = user.DepartemntId
                };
                var department = _deptClient.ReadOne(Id);
                users.Add(new UserResponse()
                {
                    Id = user.Id,
                    Name = user.Name,
                    DepartmentName = department.Name
                }) ;
              
            };
         
            return users;

        }

        public async Task<int> update(UpdateUserDto request)
        {
            var userId = new ReadUserRequest()
            {
                Id = request.Id
            };
            var user =  _userClient.ReadOne(userId);
            if(user == null)
            {
                throw new NotImplementedException();
            }
            user.Name = request.Name;
            user.DepartemntId = request.DepartemntId;
            var request2 = new UpdateUserRequest()
            {
                Id = user.Id,
                DepartemntId = user.DepartemntId,
                Name = user.Name,

            };
             var response = _userClient.UpdateUser(request2);

            return response.Id;
        }

        // public UserService(UserServiceProto.UserServiceProtoClient userService ,HttpClient userClient , IWorkflowDataHelper helper)
        //{
        //    _user = userService;
        //    this.helper = helper;
        //    _userClient = userClient;
        //}


    }
}
