using SystemDuo.Core.Domain.Entities;

namespace SystemDuo.Core.Services.Abstractions
{
    public interface IUserCalendarService
    {
        Task<IEnumerable<UserCalendar>> GetAllUserCalendarAsync(string email);
     
        Task<UserCalendar> GetUserCalendarByIdAsync(Guid userCalendarId);
        Task<bool> CreateUserCalendar(UserCalendar userCalendar);
        Task<bool> DeleteUserCalendar(UserCalendar userCalendar);
        Task<bool> UpdateUserCalendar(UserCalendar userCalendar);
    }
}
