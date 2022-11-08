using System.Collections.ObjectModel;
using System.ComponentModel;
using SystemDuo.Core.Domain.Entities;
using SystemDuo.Core.Dto;

namespace SystemDuo.ViewModels.Interfaces
{
    public interface IJobsViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        ObservableCollection<Job> Jobs { get; set; }       
        Task GetAllJobs();  
        Task<bool> DeleteJobs(Guid jobId);
     

    }
}
