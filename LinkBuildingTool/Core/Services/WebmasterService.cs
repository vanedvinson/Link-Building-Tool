using LinkBuildingTool.Core.Domain.Entities;
using LinkBuildingTool.Core.Domain.Repositories;
using LinkBuildingTool.Core.Services.Abstractions;
using System.ComponentModel.Design;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace LinkBuildingTool.Core.Services
{
    public class WebmasterService : IWebmasterService
    {
        private readonly IRepositoryManager _repositoryManager;

        public WebmasterService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        public async Task<bool> CreateWebmaster(Webmaster webmaster)
        {
            _repositoryManager.WebmasterRepository.CreateWebmaster(webmaster);
            return await _repositoryManager.UnitOfWork.SaveChangesAsync() == 1;
        }

        public async Task<bool> DeleteWebmaster(Guid webmasterId)
        {
            var webmaster = await _repositoryManager.WebmasterRepository.GetWebmasterByIdAsync(webmasterId);
            if (webmaster == null)
                return false;

            webmaster.DeletedAt = DateTime.UtcNow;
            _repositoryManager.WebmasterRepository.Update(webmaster);

            return await _repositoryManager.UnitOfWork.SaveChangesAsync() == 1;
        }

        public async Task<IEnumerable<Webmaster>> GetAllDeletedWebmastersAsync()
        {
            return await _repositoryManager.WebmasterRepository.GetAllDeletedWebmastersAsync();
        }

        public async Task<IEnumerable<Webmaster>> GetAllWebmastersAsync()
        {
            return await _repositoryManager.WebmasterRepository.GetAllWebmastersAsync();
        }

        public async Task<Webmaster> GetWebmasterByIdAsync(Guid webmasterId)
        {
            var webmaster = await _repositoryManager.WebmasterRepository.GetWebmasterByIdAsync(webmasterId);
            return webmaster;
        }

        public async Task<bool> UndoDeletedWebmaster(Guid webmasterId)
        {
            var webmaster = await _repositoryManager.WebmasterRepository.GetWebmasterByIdAsync(webmasterId);
            if (webmaster == null)
                return false;

            webmaster.DeletedAt = null;
            _repositoryManager.WebmasterRepository.Update(webmaster);

            return await _repositoryManager.UnitOfWork.SaveChangesAsync() == 1;
        }

        public async Task<bool> UpdateWebmaster(Webmaster webmaster)
        {
            _repositoryManager.WebmasterRepository.UpdateWebmaster(webmaster);

            return await _repositoryManager.UnitOfWork.SaveChangesAsync() == 1;
        }
    }
}
