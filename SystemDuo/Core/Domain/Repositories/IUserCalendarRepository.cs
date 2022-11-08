using SystemDuo.Core.Domain.Entities;

namespace SystemDuo.Core.Domain.Repositories
{
    public interface IUserCalendarRepository:IRepositoryBase<UserCalendar>
    {
        Task<IEnumerable<UserCalendar>> GetAllAsync(string userId);
        Task<UserCalendar> GetByIdAsync(Guid userCalendarId);
        void CreateUserCalendar(UserCalendar userCalendar);
        void DeleteUserCalendar(UserCalendar userCalendar);
        void UpdateUserCalendar(UserCalendar userCalendar);
    }
}
