using Aggregrator.Services.User.DTO;

namespace Aggregrator.IGService
{
    public interface IUserService
    {
        public Task<int> create(CreateUserRequestDto request);
        public Task<int> update(UpdateUserDto request);

        public Task<List<UserResponse>> List();

        public Task<UserResponse> GetOne(int Id);
    }
}
