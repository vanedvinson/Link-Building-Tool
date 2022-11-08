using Microsoft.AspNetCore.Identity;
using SystemDuo.Core.Domain.Entities;
using SystemDuo.Core.Domain.Repositories;
using SystemDuo.Core.Services.Abstractions;

namespace SystemDuo.Core.Services
{
    public class UserCalendarService : IUserCalendarService
    {
        private readonly IRepositoryManager _repositoryManager;
        private UserManager<User> _userManager;

        public UserCalendarService(IRepositoryManager repositoryManager,UserManager<User> userManager)
        {
            _repositoryManager = repositoryManager;
            _userManager = userManager;
        }


        public async Task<bool> CreateUserCalendar(UserCalendar userCalendar)
        {
            if (userCalendar == null)
                return false;
            var user =await  _userManager.FindByEmailAsync(userCalendar!.User!.Email);
            userCalendar.User = user;
            userCalendar.Date=userCalendar.Date.Value.ToUniversalTime();
            _repositoryManager.UserCalendarRepository.CreateUserCalendar(userCalendar);
            return await _repositoryManager.UnitOfWork.SaveChangesAsync() == 1;
        }

        public async Task<bool> DeleteUserCalendar(UserCalendar userCalendar)
        {
            if (userCalendar == null)
                return false;
            _repositoryManager.UserCalendarRepository.Delete(userCalendar);
            return await _repositoryManager.UnitOfWork.SaveChangesAsync() == 1;

            
        }

        public async Task<IEnumerable<UserCalendar>> GetAllUserCalendarAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var res=await _repositoryManager.UserCalendarRepository.GetAllAsync(user.Id);
            return res;
        }

        public Task<UserCalendar> GetUserCalendarByIdAsync(Guid userCalendarId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateUserCalendar(UserCalendar userCalendar)
        {
            if (userCalendar == null)
                return false;
            _repositoryManager.UserCalendarRepository.UpdateUserCalendar(userCalendar);
            return await _repositoryManager.UnitOfWork.SaveChangesAsync() == 1;
        }
    }
}
