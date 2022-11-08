using Mapster;
using Microsoft.AspNetCore.Identity;
using SystemDuo.Core.Domain.Entities;
using SystemDuo.Core.Domain.Repositories;
using SystemDuo.Core.Dto;
using SystemDuo.Core.Services.Abstractions;

namespace SystemDuo.Core.Services
{
    public class JobService : IJobService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly UserManager<User> _userManager;


        public JobService(IRepositoryManager repositoryManager,UserManager<User> userManager)
        {
            _repositoryManager = repositoryManager;
            _userManager = userManager;
        }

        public async Task<bool> CreateJob(JobForCreationDto job)
        {
            int isSuccess=0;
            var jobForCreation = job.Adapt<Job>();
            jobForCreation.IsActive = true;
            jobForCreation.StartDate=job.StartDate.Value.ToUniversalTime();
            _repositoryManager.JobsRepository.CreateJob(jobForCreation);
            var res = await _repositoryManager.UnitOfWork.SaveChangesAsync();
            if (res != 1)
                return false;

            foreach (var skills in job.Skills!)
            {
                _repositoryManager.JobsSkillsRepository.CreateJobSkills(new JobSkills
                {
                    SkillId = skills.Id,
                    JobId = jobForCreation.Id
                });
               isSuccess=await _repositoryManager.UnitOfWork.SaveChangesAsync();
            }
            if (isSuccess != 1)
                return false;
            return true;
        }
        public async Task<bool> AcceptApplication(Application application)
        {
            application.IsAcceptedForInterview = true; //Accept application

            _repositoryManager.ApplicationRepository.UpdateCandidateApplication(application);
           
            return await _repositoryManager.UnitOfWork.SaveChangesAsync()==1;
        }
        public async Task<bool> DeleteJob(Guid jobId)
        {
            var job=await _repositoryManager.JobsRepository.GetJobByIdAsync(jobId);
            if (job == null)
                return false;

            job.IsActive = false;
            _repositoryManager.JobsRepository.UpdateJob(job);
           
            return await _repositoryManager.UnitOfWork.SaveChangesAsync() == 1; 
           
        }
        public async Task<bool> UndoDeleteJob(Guid jobId)
        {
            var job = await _repositoryManager.JobsRepository.GetJobByIdAsync(jobId);
            if (job == null)
                return false;

            job.IsActive = true;

            _repositoryManager.JobsRepository.UpdateJob(job);

            return await _repositoryManager.UnitOfWork.SaveChangesAsync() == 1;

        }
        public async Task<IEnumerable<Job>> GetAllJobsAsync()
        {

            var jobs=await _repositoryManager.JobsRepository.GetAllJobsAsync();
            return jobs;
        }
        public async Task<IEnumerable<Job>> GetAllInactiveJobsAsync()
        {

            var jobs = await _repositoryManager.JobsRepository.GetAllInactiveJobsAsync();
            return jobs;
        }

        public async Task<IEnumerable<Job>> GetAllJobsByCompanyIdAsync(Guid companyId)
        {
            var jobs = await _repositoryManager.JobsRepository.GetAllJobsByCompanyIdAsync(companyId);

            return jobs;
        }

        public async Task<bool> UpdateJob(JobForCreationDto job)
        {
            //var jobToUpdate = await _repositoryManager.JobsRepository.GetJobByIdAsync(job.Id);
            //if (jobToUpdate == null)
            //    return false;
            if (job == null)
                return false;
            var jobForCreation = job.Adapt<Job>();
            jobForCreation.IsActive = true;
            jobForCreation.StartDate = job.StartDate.Value.ToUniversalTime();
            _repositoryManager.JobsRepository.UpdateJob(jobForCreation);
            await _repositoryManager.UnitOfWork.SaveChangesAsync();
           
            var jobSkills = await _repositoryManager.JobsSkillsRepository.GetAllJobsSkillsAsync(job.Id);

            
            foreach (var skill in job.Skills)
            {
                var getSkills = jobSkills.Where(x => x.SkillId.Equals(skill.Id)).FirstOrDefault();
                if (getSkills == null)
                {

                    _repositoryManager.JobsSkillsRepository.CreateJobSkills(new JobSkills { 
                    SkillId= skill.Id,
                    JobId= job.Id
                    
                    });

                    await _repositoryManager.UnitOfWork.SaveChangesAsync();
                }
            }

            if (jobSkills != null)
            {
                foreach (var selectedSkills in jobSkills)
                {
                    var getSkills = job.Skills.Where(x => x.Id.Equals(selectedSkills.SkillId)).FirstOrDefault();
                    if (getSkills == null)
                    {
                        _repositoryManager.JobsSkillsRepository.DeleteJobSkills(selectedSkills);
                        await _repositoryManager.UnitOfWork.SaveChangesAsync();
                    }
                }
            }


            return true;
        }

        public async Task<bool> RejectApplication(Application application)
        {
            application.IsRejected = true; //Accept application

            _repositoryManager.ApplicationRepository.Update(application);

            return await _repositoryManager.UnitOfWork.SaveChangesAsync() == 1;
        }
        public async Task<bool> UndoRejectionApplication(Application application)
        {
            application.IsRejected = false; //Accept application
            application.IsAcceptedForInterview = false;
            application.IsHired = false;
            _repositoryManager.ApplicationRepository.Update(application);

            return await _repositoryManager.UnitOfWork.SaveChangesAsync() == 1;
        }
        public async Task<IEnumerable<Location>> GetAllJobLocationsAsync()
        {
            var jobLocations = await _repositoryManager.JobLocationRepository.GetAllJobLocationsAsync();
            return jobLocations;
        }
        public async Task<IEnumerable<Location>> GetAllDeletedLocationsAsync()
        {
            var jobLocations = await _repositoryManager.JobLocationRepository.GetAllDeletedJobLocationsAsync();
            return jobLocations;
        }
        public async Task<bool> HireApplicant(Application application)
        {
            application.IsHired = true; //Hire application

            _repositoryManager.ApplicationRepository.Update(application);
            await _repositoryManager.UnitOfWork.SaveChangesAsync();

            _repositoryManager.EmployeeJobRepository.CreateEmployeeJob(new EmployeeJob
            {
                User = application.User!,
                Job = application.Job,
                StartDate = application.Job.StartDate,
                
            });
            await _repositoryManager.UnitOfWork.SaveChangesAsync();

            application.User!.IsWorking = true;
            var res= await _userManager.UpdateAsync(application.User!);
            return res.Succeeded;
        }

        public async Task<bool> CreateLocation(Location location)
        {
            _repositoryManager.JobLocationRepository.CreateJobLocation(location);
            var res = await _repositoryManager.UnitOfWork.SaveChangesAsync();
            if (res != 1)
                return false;
            return true;

        }

        public async Task<bool> DeleteLocation(Guid locationId)
        {
            var location = await _repositoryManager.JobLocationRepository.GetJobLocationByIdAsync(locationId);
            if (location == null)
                return false;
            
            location.DeletedAt = DateTime.UtcNow;
            _repositoryManager.JobLocationRepository.UpdateJobLocation(location); //soft delete

            return await _repositoryManager.UnitOfWork.SaveChangesAsync() == 1;
        }
        public async Task<bool> UndoDeletedLocation(Guid locationId)
        {
            var location = await _repositoryManager.JobLocationRepository.GetJobLocationByIdAsync(locationId);
            if (location == null)
                return false;

            location.DeletedAt = null;
            _repositoryManager.JobLocationRepository.UpdateJobLocation(location); //soft delete

            return await _repositoryManager.UnitOfWork.SaveChangesAsync() == 1;
        }

        public async Task<bool> UpdateLocation(Location location)
        {
            var locationToUpdate = await _repositoryManager.JobLocationRepository.GetJobLocationByIdAsync(location.Id);
            if (locationToUpdate == null)
                return false;
            if (location == null)
                return false;
            _repositoryManager.JobLocationRepository.UpdateJobLocation(location);
            return await _repositoryManager.UnitOfWork.SaveChangesAsync() == 1;
        }
        public async Task<Job> GetJobByIdAsync(Guid jobId)
        {
            var job = await _repositoryManager.JobsRepository.GetJobByIdAsync(jobId);
            return job;
        }

        public async Task<IEnumerable<Job>> GetJobsByCategoryAsync(Category cat)
        {
            var jobs = await _repositoryManager.JobsRepository.GetJobsByCategoryAsync(cat);
            return jobs;
        }
    }
}
