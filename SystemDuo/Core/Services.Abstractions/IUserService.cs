using SystemDuo.Core.Domain.Entities;
using SystemDuo.Core.Dto;

namespace SystemDuo.Core.Services.Abstractions
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetByRoleAsync(string role);
        Task<AuthDto> Login(LoginDto login);
        Task<IEnumerable<User>> GetFreeCandidatesAsync();
        Task<IEnumerable<User>> GetCandidatesAsync(bool employeed);
        Task<IEnumerable<User>> GetCandidatesByCategoryAsync(Category cat);
        Task<IEnumerable<User>> GetCandidatesByTermAsync(Category cat, bool ltc, bool stc);
        Task<IEnumerable<User>> GetAllAgents();
        Task<bool> DeleteUser(string userId);
        Task<bool> CreateUser(UserForCreationOrUpdate user);
        Task<bool> UpdateUser(UserForCreationOrUpdate user);
        Task<User> GetUserByIdAsync(string userId);
        Task<IEnumerable<Role>> GetRoleByType(string type);
        Task<IEnumerable<User>> GetAvailableCandidatesForApplication(Guid jobId);
        Task<IEnumerable<User>> GetAllDeletedCandidatesAsync();
        Task<IEnumerable<User>> GetAllDeletedAgentsAsync();
        Task<bool> UndoDeletedUser(string userId);
        Task<GeneralResponse> ResetPassword(ResetPassword resetPassword);
        Task<GeneralResponse> ChangePassword(string email, ChangePassword changePassword);
        Task<GeneralResponse> SendForgotPasswordEmail(ForgotPassword forgotPassword);

    }
}
