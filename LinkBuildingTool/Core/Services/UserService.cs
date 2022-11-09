using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using LinkBuildingTool.Core.Domain.Entities;
using LinkBuildingTool.Core.Domain.Repositories;
using LinkBuildingTool.Core.Dto;
using LinkBuildingTool.Core.Services.Abstractions;

namespace LinkBuildingTool.Core.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IRepositoryManager _repositoryManager;
        private readonly ITokenService _tokenService;
        private readonly IMailService _mailService;
        public UserService(UserManager<User> userManager, IMailService mailService, ITokenService tokenService, RoleManager<Role> roleManager, IRepositoryManager repositoryManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _repositoryManager = repositoryManager;
            _tokenService = tokenService;
            _mailService = mailService;
        }

        public async Task<AuthDto> Login(LoginDto login)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(login.Email);
                var isInRole = await _userManager.IsInRoleAsync(user, "Candidate");

                if (!isInRole && user.DeletedAt == null)
                {
                    var refreshToken = _tokenService.GenerateRefreshToken();
                    // user.RefreshToken = refreshToken;
                    //  await _repositoryManager.SaveAsync();
                    var checking = await _userManager.CheckPasswordAsync(user, login.Password);
                    var hashPassword = _userManager.PasswordHasher.HashPassword(user, login.Password);
                    //if (user != null && await _userManager.CheckPasswordAsync(user, login.Password))
                    if (user != null && await _userManager.CheckPasswordAsync(user, login.Password))
                    {
                        var claims = GetClaims(user);
                        return await Task.FromResult(new AuthDto
                        {
                            IsAuthenticated = true,
                            AccessToken = _tokenService.GenerateAccessToken(await claims),
                            RefreshToken = refreshToken,
                            Name= user.FirstName!,
                            Surname=user.LastName!
                            


                        });
                    }
                    return await Task.FromResult(new AuthDto { IsAuthenticated = false });
                }
                return await Task.FromResult(new AuthDto { IsAuthenticated = false });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return await Task.FromResult(new AuthDto { IsAuthenticated = false });
            }

            //return await Task.FromResult(new LoginResponse { Error = "Nisi se lepo ulogovao" });
        }

        public async Task<bool> DeleteUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return false;

            user.DeletedAt = DateTime.UtcNow;
            var res = await _userManager.UpdateAsync(user);
            return res.Succeeded;

        }
        public async Task<bool> CreateUser(UserForCreationOrUpdate user)
        {


            var createUser = new User
            {

                UserName = user.Email,
                Email = user.Email,
                City = user.City,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Address = user.Address,
                Country = user.Country,
                MobileNumber = user.MobileNumber,
                PostalCode = user.PostalCode,
                PhoneNumber = user.PhoneNumber,
                Language = user.Language,
                Education = user.Education,

                LongTerm = user.LongTerm,
                ShortTerm = user.ShortTerm,
                Notes = user.Notes,



            };
            if (user.DateOfBirth != null)
                createUser.DateOfBirth = user.DateOfBirth.Value.ToUniversalTime();
            if (user.RoleName!.Where(x => x.Equals("Candidate")).FirstOrDefault() != null)
            {
                createUser.CategoryId = user.CategoryId;
            }
            else
            {
                await _mailService.SendEmailAsync(new Mail
                {
                    Subject = "Access created",
                    Body = "Password :" + user.Password,
                    IsBodyHtml = false,
                    ToEmail = user.Email
                });

            }
            var isCreated = await _userManager.CreateAsync(createUser, user.Password);
            if (isCreated.Succeeded)
            {
                foreach (var roles in user.RoleName!)
                {
                    await _userManager.AddToRoleAsync(createUser, roles.ToString());
                }

            }
            return isCreated.Succeeded;
        }
        private async Task<List<Claim>> GetClaims(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email)
            };
            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;
        }
        public async Task<IEnumerable<User>> GetByRoleAsync(string role)
        {

            var users = await _userManager.GetUsersInRoleAsync(role);
            return users;
        }
        public async Task<IEnumerable<User>> GetFreeCandidatesAsync()
        {
            var freeUsers = new List<User>();
            var users = await _userManager.GetUsersInRoleAsync("Candidate");
            foreach (var item in users)
            {
                if (!item.IsWorking && item.DeletedAt == null)
                {
                    freeUsers.Add(item);
                }
            }
            return freeUsers;
        }

        public async Task<IEnumerable<User>> GetCandidatesAsync(bool employeed)
        {
            try
            {

                var users = await _userManager.GetUsersInRoleAsync("Candidate");
                // var allUser = await _userManager.GetUsersInRoleAsync("Candidate");
                var candidates = new List<User>();
                if (employeed)
                {
                    foreach (var item in users)
                    {

                        if (item.IsWorking && item.DeletedAt == null)
                        {
                            // var user =await _userManager.Users.Include(a => a.Category).FirstOrDefaultAsync(u => u.Id == item.Id);
                            candidates.Add(item);
                        }
                    }
                }
                else
                {
                    foreach (var item in users)
                    {

                        if (!item.IsWorking && item.DeletedAt == null)
                        {
                            // var user = await _userManager.Users.Include(a => a.Category).FirstOrDefaultAsync(u => u.Id == item.Id);
                            candidates.Add(item);
                        }
                    }
                }
                return candidates;
            }
            catch (Exception ex)
            {
                //await _repositoryManager.UnitOfWork.Dispose();
                //var users = await _userManager.GetUsersInRoleAsync("Candidate").ConfigureAwait(true);
                //if (employeed)
                //{
                //    foreach (var item in users)
                //    {

                //        if (item.IsWorking && item.DeletedAt == null)
                //        {
                //            candidates.Add(item);
                //        }
                //    }
                //}
                //else
                //{
                //    foreach (var item in users)
                //    {

                //        if (!item.IsWorking && item.DeletedAt == null)
                //        {
                //            candidates.Add(item);
                //        }
                //    }
                //}
                //return await Task.FromResult(candidates);
                return new List<User>();
            }


        }
        //public async Task<IEnumerable<User>> GetUnemployeeCandidatesAsync()
        //{
        //    var freeUsers = new List<User>();
        //    var users = await _userManager.GetUsersInRoleAsync("Candidate");
        //    foreach (var item in users)
        //    {
        //        if (!item.IsWorking)
        //        {
        //            freeUsers.Add(item);
        //        }
        //    }
        //    return freeUsers;
        //}
        public async Task<IEnumerable<User>> GetAllAgents()
        {
            var test1 = new List<User>();

            //var agents = await _userManager.Users.Where(u=>u.DeletedAt==null).ToListAsync();
            var agents = new List<User>(await _userManager.GetUsersInRoleAsync("Senior Agent"));
            test1 = new List<User>(agents);
            agents.ForEach(x =>
             {
                 if (x.DeletedAt != null)
                     test1.Remove(x);
             });
            //foreach (var u in agents )
            //{
            //    var isSeniorInRole = await _userManager.IsInRoleAsync(u, "Senior Agent");
            //    var isJuniorRole = await _userManager.IsInRoleAsync(u, "Junior Agent");
            //    if ((isJuniorRole || isSeniorInRole) )
            //    {
            //        test1.Add(u);
            //    }
            //}

            // var users = await _userManager.GetUsersInRoleAsync(role);         
            return test1;
        }
        //public async Task<IEnumerable<User>> GetAvailableCandidatesForApplication(Guid jobId)
        //{
        //    var allUser = await _userManager.GetUsersInRoleAsync("Candidate");

        //    var allApplicants = await _repositoryManager.ApplicationRepository.GetAllCandidateApplicationsByJobIdAsync(jobId);

        //    var availableUser = new List<User>();
        //    foreach (var user in allUser)
        //    {
        //        var find = allApplicants.Where(a => a.UserId == user.Id).FirstOrDefault();
        //        if (find == null && !user.IsWorking && user.DeletedAt == null)
        //            availableUser.Add(user);

        //    }
        //    return availableUser;

        //}


        //TODO FINISH for changing password
        public async Task<bool> UpdateUser(UserForCreationOrUpdate user)
        {

            var getUser = await _userManager.FindByIdAsync(user.Id);

            getUser.City = user.City;
            getUser.FirstName = user.FirstName;
            getUser.LastName = user.LastName;
            getUser.Address = user.Address;
            getUser.Country = user.Country;
            getUser.MobileNumber = user.MobileNumber;
            getUser.PostalCode = user.PostalCode;
            getUser.PhoneNumber = user.PhoneNumber;
            getUser.Language = user.Language;
            getUser.Email = user.Email;
            if (user.DateOfBirth != null)
                getUser.DateOfBirth = user.DateOfBirth.Value.ToUniversalTime();
            getUser.Education = user.Education;
            getUser.LongTerm = user.LongTerm;
            getUser.ShortTerm = user.ShortTerm;
            getUser.CategoryId = user.CategoryId;
            getUser.Notes = user.Notes;
            //add category


            var isUpdated = await _userManager.UpdateAsync(getUser);


            if (user.RoleName != null)
            {
                var roles = await _userManager.GetRolesAsync(getUser);
                foreach (var role in user.RoleName)
                {
                    var getRole = roles.Where(x => x.ToString().Equals(role.ToString())).FirstOrDefault();
                    if (getRole == null)
                    {
                        await _userManager.AddToRoleAsync(getUser, role.ToString());
                    }
                }
                foreach (var selectedRoles in roles)
                {
                    var getRole = user.RoleName.Where(x => x.ToString().Equals(selectedRoles.ToString())).FirstOrDefault();
                    if (getRole == null)
                    {
                        await _userManager.RemoveFromRoleAsync(getUser, selectedRoles.ToString());
                    }
                }

            }
            return isUpdated.Succeeded;
        }
        public async Task<IEnumerable<User>> GetAllDeletedCandidatesAsync()
        {
            var allUser = await _userManager.GetUsersInRoleAsync("Candidate");

            var deletedUsers = new List<User>();
            foreach (var user in allUser)
            {

                if (user.DeletedAt != null)
                    deletedUsers.Add(user);

            }
            return deletedUsers;
        }
        public async Task<IEnumerable<User>> GetAllDeletedAgentsAsync()
        {
            var deletedUsers = new List<User>();
            var agents = new List<User>(await _userManager.GetUsersInRoleAsync("Senior Agent"));
            deletedUsers = new List<User>(agents);
            if (agents.Any())
            {
                agents.ForEach(x =>
                {
                    if (x.DeletedAt == null)
                        deletedUsers.Remove(x);
                });
            }

            //foreach (var u in await _userManager.Users.ToListAsync())
            //{
            //    var isSeniorInRole = await _userManager.IsInRoleAsync(u, "Senior Agent");
            //    var isJuniorRole = await _userManager.IsInRoleAsync(u, "Junior Agent");
            //    if ((isJuniorRole || isSeniorInRole) && u.DeletedAt!=null)
            //    {
            //        deletedUsers.Add(u);
            //    }
            //}   

            return deletedUsers;
        }
        public async Task<User> GetUserByIdAsync(string userId)
        {
            var res = await _userManager.FindByIdAsync(userId);
            var roles = await _userManager.GetRolesAsync(res);

            List<string> list = roles.ToList();


            //Cast list to IEnumerable
            res.UserRoles1 = (ICollection<string>)list;



            return res;

        }

        public async Task<IEnumerable<Role>> GetRoleByType(string type)
        {
            var roles = _roleManager.Roles.Where(r => r.Type!.Equals("intern") && r.Name != "Junior Agent").ToList();


            return await Task.FromResult(roles);
        }

        public async Task<bool> UndoDeletedUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return false;

            user.DeletedAt = null;
            var res = await _userManager.UpdateAsync(user);
            return res.Succeeded;
        }

        //TODO check if the role is different then candidate or intern/extern type?
        public async Task<GeneralResponse> SendForgotPasswordEmail(ForgotPassword forgotPassword)
        {
            var findUser = await _userManager.FindByEmailAsync(forgotPassword.Email);
            if (findUser == null)
                return new GeneralResponse { IsSuccess = false, Message = "There is no user with this email" };


            var token = await _userManager.GeneratePasswordResetTokenAsync(findUser);
            findUser.PasswordResetToken = token;
            await _userManager.UpdateAsync(findUser);
            await _mailService.SendEmailAsync(new Mail
            {
                Subject = "Password forgotten",
                Body = "<h3> Hello " + findUser.FirstName + " " + findUser.LastName + " </h3>" +
                "<p>You have requested to reset your password follow this link</p>" +
                //"https://LinkBuildingTool.razorsharpsolutions.net/auth/reset-password?token=" + token + "&email=" + findUser.Email + "",
                "https://localhost:7027/auth/reset-password?token=" + token + "&email=" + findUser.Email + "",

                IsBodyHtml = true,
                ToEmail = findUser.Email
            });
            return new GeneralResponse { IsSuccess = true, Message = "Email sent" };
        }
        public async Task<GeneralResponse> ResetPassword(ResetPassword resetPassword)
        {

            var findUser = await _userManager.FindByEmailAsync(resetPassword.Email);
            if (findUser == null)
                return new GeneralResponse { IsSuccess = false, Message = "User not found" };
            if (findUser.PasswordResetToken!.Equals(resetPassword.ResetPasswordToken!.Trim().Replace(" ", "+")))
            {
                var hashPassword = _userManager.PasswordHasher.HashPassword(findUser, resetPassword.NewPassword);
                findUser.PasswordHash = hashPassword;
                findUser.PasswordResetToken = string.Empty;
                await _userManager.UpdateAsync(findUser);

                return new GeneralResponse { IsSuccess = true, Message = "Password reseted" };
            }
            return new GeneralResponse { IsSuccess = false, Message = "token not valid" };
        }
        public async Task<GeneralResponse> ChangePassword(string email, ChangePassword changePassword)
        {

            var findUser = await _userManager.FindByEmailAsync(email);
            if (findUser == null)
                return new GeneralResponse { IsSuccess = false, Message = "User not found" };

            var checkPass = await _userManager.CheckPasswordAsync(findUser, changePassword.OldPassword);
            if (!checkPass)
                return new GeneralResponse { IsSuccess = false, Message = "Password isn't correct " };

            var hashPassword = await _userManager.ChangePasswordAsync(findUser, changePassword.OldPassword, changePassword.NewPassword);

            if (hashPassword.Succeeded)
                return new GeneralResponse { IsSuccess = true, Message = "Password is changed. " };

            return new GeneralResponse { IsSuccess = false, Message = "Something went wrong." };
        }

        //public async Task<IEnumerable<User>> GetCandidatesByCategoryAsync(Category cat)
        //{
        //    var candidates = new List<User>();
        //    var users = await _userManager.GetUsersInRoleAsync("Candidate");
        //    foreach (var item in users)
        //    {
        //        if (item.Category == cat && item.DeletedAt == null && !item.IsWorking)
        //        {
        //            candidates.Add(item);
        //        }
        //    }
        //    return candidates;
        //}

        //public async Task<IEnumerable<User>> GetCandidatesByTermAsync(Category cat, bool ltc, bool stc)
        //{
        //    var candidates = new List<User>();
        //    var users = await _userManager.GetUsersInRoleAsync("Candidate");

        //    if (ltc == true && stc == true)
        //    {
        //        if (cat.Name == null || cat.Name == "Show All")
        //        {
        //            foreach (var item in users.Where(x => x.LongTerm == true && x.ShortTerm == true && x.DeletedAt == null && !x.IsWorking))
        //            {
        //                candidates.Add(item);
        //            }
        //        }
        //        else
        //        {
        //            foreach (var item in users.Where(x => x.LongTerm == true && x.ShortTerm == true && x.Category == cat && x.DeletedAt == null && !x.IsWorking))
        //            {
        //                candidates.Add(item);
        //            }
        //        }

        //    }

        //    if (ltc == true && stc == false)
        //    {
        //        if (cat.Name == null || cat.Name == "Show All")
        //        {
        //            foreach (var item in users.Where(x => x.LongTerm == true && x.DeletedAt == null && !x.IsWorking))
        //            {
        //                candidates.Add(item);
        //            }
        //        }
        //        else
        //        {
        //            foreach (var item in users.Where(x => x.LongTerm == true && x.Category == cat && x.DeletedAt == null && !x.IsWorking))
        //            {
        //                candidates.Add(item);
        //            }
        //        }

        //    }

        //    if (ltc == false && stc == true)
        //    {
        //        if (cat.Name == null || cat.Name == "Show All")
        //        {
        //            foreach (var item in users.Where(x => x.ShortTerm == true && x.DeletedAt == null && !x.IsWorking))
        //            {
        //                candidates.Add(item);
        //            }
        //        }
        //        else
        //        {
        //            foreach (var item in users.Where(x => x.ShortTerm == true && x.Category == cat && x.DeletedAt == null && !x.IsWorking))
        //            {
        //                candidates.Add(item);
        //            }
        //        }

        //    }

        //    if (ltc == false && stc == false)
        //    {
        //        if (cat.Name == null || cat.Name == "Show All")
        //        {
        //            foreach (var item in users)
        //            {
        //                if (item.DeletedAt == null && !item.IsWorking)
        //                    candidates.Add(item);
        //            }
        //        }
        //        else
        //        {
        //            foreach (var item in users.Where(x => x.Category == cat))
        //            {
        //                if (item.DeletedAt == null && !item.IsWorking)
        //                    candidates.Add(item);
        //            }
        //        }

        //    }

        //    return candidates;

        //}
    }
}
