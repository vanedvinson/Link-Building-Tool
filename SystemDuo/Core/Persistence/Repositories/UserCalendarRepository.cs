using Microsoft.EntityFrameworkCore;
using SystemDuo.Core.Domain.Entities;
using SystemDuo.Core.Domain.Repositories;

namespace SystemDuo.Core.Persistence.Repositories
{
    public class UserCalendarRepository : RepositoryBase<UserCalendar>, IUserCalendarRepository
    {
        public UserCalendarRepository(RepositoryDbContext dbContext) : base(dbContext)
        {

        }

        public void CreateUserCalendar(UserCalendar userCalendar)
        {
            Create(userCalendar);
        }

        public void DeleteUserCalendar(UserCalendar userCalendar)
        {
            Delete(userCalendar);
        }

        public async Task<IEnumerable<UserCalendar>> GetAllAsync(string userId)
        {
            var res = await FindByCondition(uc => uc.UserId!.Equals(userId)).ToListAsync();
            return res;
        }

        public Task<UserCalendar> GetByIdAsync(Guid userCalendarId)
        {
            throw new NotImplementedException();
        }

        public void UpdateUserCalendar(UserCalendar userCalendar)
        {
            Update(userCalendar);
        }
    }
}
