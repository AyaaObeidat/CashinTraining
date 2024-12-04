using Profolio.Models;
using Profolio.Repositories.Interfaces;
using ProfolioDtos.UserDtos;
using ProfolioDtos.ContactDtos;
using ProfolioDtos.SkillsDtos;
using ProfolioDtos.ExperiencesDtos;
namespace Profolio.Services
{
    public class UserService
    {
        private readonly IUserInterface _userInterface;
        private readonly IContactInterface _contactInterface;

        public UserService(IUserInterface userInterface, IContactInterface contactInterface)
        {
            _userInterface = userInterface;
            _contactInterface = contactInterface;
        }

        public async Task RegisterAsync(RegisterParameters parameters)
        {
            var users = await _userInterface.GetAllAsync();
            var availableUsers = users.ToList().Where(u => u.FullName == parameters.FullName || u.Email == parameters.Email).ToList();
            if (availableUsers.Count == 0)
            {
                var user = User.Create(parameters.FullName, parameters.Email, parameters.Password);
                await _userInterface.AddAsync(user);
                var contact = Contact.Create(user.Email, user.Id);
                await _contactInterface.AddAsync(contact);
                user.SetContactId(contact.Id);
                await _userInterface.UpdateAsync(user);
            }
            else
            {
                throw new Exception("The user already exist");
            }
        }

        public async Task<UserDetails> LoginAsync(LoginParameters parameters)
        {
            var users = await _userInterface.GetAllAsync();
            var currentUser = users.ToList().FirstOrDefault(u => u.Email == parameters.Email && u.Password == parameters.Password);
            if (currentUser == null) { throw new ArgumentNullException("Can not found user"); }
            else
            {
                var userContact = await _contactInterface.GetByIdAsync(currentUser.ContactId);
                return new UserDetails
                {
                    Id = currentUser.Id,
                    FullName = currentUser.FullName,
                    Email = currentUser.Email,
                    Password = currentUser.Password,
                    About = currentUser.About,
                    PhoneNumber = currentUser.PhoneNumber,
                    Education = currentUser.Education,
                    ImageUrl = currentUser.ImageUrl,
                    JobTitle = currentUser.JobTitle,
                    CvUrl = currentUser.CvUrl,
                    ProfileStatus = currentUser.ProfileStatus,
                    Contact = userContact
                    != null ? new ContactDetails
                    {
                        Id = userContact.Id,
                        Email = userContact.Email,
                        PhoneNumber = userContact.PhoneNumber,
                        LinkedinUrl = userContact.LinkedinUrl,
                        GitHubUrl = userContact.GitHubUrl,
                    } : null,
                    Skills = currentUser.Skills.Select(c => new SkillsDetails
                    {
                        Id = c.Id,
                        Title = c.Title,
                        Description = c.Description,
                    }).ToList(),
                    Experiences = currentUser.Experiences.Select(e => new ExperienceDetails
                    {
                        Id = e.Id,
                        Title = e.Title,
                        CompanyName = e.CompanyName,
                        Description = e.Description,
                        StartDate = e.StartDate,
                        EndDate = e.EndDate,
                        AttachmentUrl = e.AttachmentUrl
                    }).ToList()

                };
            }

        }
        public async Task<List<UserDetails>> GetAllPublicUsersAsync()
        {
            var publicUsers = await _userInterface.GetAllPublicUsersAsync();
            var contacts = await _contactInterface.GetAllAsync();
            return publicUsers.ToList().Select(u => {
                var userContact = contacts.ToList().FirstOrDefault(c => c.Id == u.ContactId);
                return new UserDetails
                {
                    Id = u.Id,
                    FullName = u.FullName,
                    Email = u.Email,
                    Password = u.Password,
                    About = u.About,
                    PhoneNumber = u.PhoneNumber,
                    Education = u.Education,
                    ImageUrl = u.ImageUrl,
                    JobTitle = u.JobTitle,
                    CvUrl = u.CvUrl,
                    ProfileStatus = u.ProfileStatus,
                    Contact = userContact
                    != null ? new ContactDetails
                    {
                        Id = userContact.Id,
                        Email = userContact.Email,
                        PhoneNumber = userContact.PhoneNumber,
                        LinkedinUrl = userContact.LinkedinUrl,
                        GitHubUrl = userContact.GitHubUrl,
                    } : null,
                    Skills = u.Skills.Select(c => new SkillsDetails
                    {
                        Id = c.Id,
                        Title = c.Title,
                        Description = c.Description,
                    }).ToList(),
                    Experiences = u.Experiences.Select(e => new ExperienceDetails
                    {
                        Id = e.Id,
                        Title = e.Title,
                        CompanyName = e.CompanyName,
                        Description = e.Description,
                        StartDate = e.StartDate,
                        EndDate = e.EndDate,
                        AttachmentUrl = e.AttachmentUrl
                    }).ToList()
                };

            }).ToList();

        }
        public async Task<UserDetails> GetByIdAsync(UserGetByParameters parameters)
        {
            var currentUser = await _userInterface.GetByIdAsync(parameters.Id);
            if (currentUser == null) throw new ArgumentNullException("the user not found");
            var userContact = await _contactInterface.GetByIdAsync(currentUser.ContactId);
            return new UserDetails
            {
                Id = currentUser.Id,
                FullName = currentUser.FullName,
                Email = currentUser.Email,
                Password = currentUser.Password,
                About = currentUser.About,
                PhoneNumber = currentUser.PhoneNumber,
                Education = currentUser.Education,
                ImageUrl = currentUser.ImageUrl,
                JobTitle = currentUser.JobTitle,
                CvUrl = currentUser.CvUrl,
                ProfileStatus = currentUser.ProfileStatus,
                Contact = userContact
                    != null ? new ContactDetails
                    {
                        Id = userContact.Id,
                        Email = userContact.Email,
                        PhoneNumber = userContact.PhoneNumber,
                        LinkedinUrl = userContact.LinkedinUrl,
                        GitHubUrl = userContact.GitHubUrl,
                    } : null,
                Skills = currentUser.Skills.Select(c => new SkillsDetails
                {
                    Id = c.Id,
                    Title = c.Title,
                    Description = c.Description,
                }).ToList(),
                Experiences = currentUser.Experiences.Select(e => new ExperienceDetails
                {
                    Id = e.Id,
                    Title = e.Title,
                    CompanyName = e.CompanyName,
                    Description = e.Description,
                    StartDate = e.StartDate,
                    EndDate = e.EndDate,
                    AttachmentUrl = e.AttachmentUrl
                }).ToList()

            };
        }
        public async Task ModifyFullNameAsync(UserUpdateParameters parameters)
        {
            var user = await _userInterface.GetByIdAsync(parameters.Id);
            if (user == null) throw new ArgumentNullException("the user not found");
            var users = await _userInterface.GetAllAsync();
            var availableUsers = users.ToList().Where(u => u.FullName == parameters.NewFullName);
            if (availableUsers.Count() > 0) throw new Exception("this user name already used");
            else
            {
                user.SetFullName(parameters.NewFullName);
                await _userInterface.UpdateAsync(user);
            }
        }

        public async Task ModifyPasswordAsync(UserUpdateParameters parameters)
        {
            var user = await _userInterface.GetByIdAsync(parameters.Id);
            if (user == null) throw new ArgumentNullException("the user not found");
            var users = await _userInterface.GetAllAsync();
            var availableUsers = users.ToList().Where(u => u.Password == parameters.NewPassword);
            if (availableUsers.Count() > 0) throw new Exception("this user password already used");
            else
            {
               if(user.Password == parameters.CurrentPassword)
                {
                    user.SetPassword(parameters.NewPassword);
                    await _userInterface.UpdateAsync(user);
                }
            }
        }

        public async Task ModifyPhoneNumberAsync(UserUpdateParameters parameters)
        {
            var user = await _userInterface.GetByIdAsync(parameters.Id);
            if (user == null) throw new ArgumentNullException("the user not found");
            else
            {
                user.SetPhoneNumber(parameters.NewPhoneNumber);
                await _userInterface.UpdateAsync(user);
            }
        }

        public async Task ModifyAboutAsync(UserUpdateParameters parameters)
        {
            var user = await _userInterface.GetByIdAsync(parameters.Id);
            if (user == null) throw new ArgumentNullException("the user not found");
            else
            {
                user.SetAbout(parameters.NewAbout);
                await _userInterface.UpdateAsync(user);
            }
        }

        public async Task ModifyEducationAsync(UserUpdateParameters parameters)
        {
            var user = await _userInterface.GetByIdAsync(parameters.Id);
            if (user == null) throw new ArgumentNullException("the user not found");
            else
            {
                user.SetEducation(parameters.NewEducation);
                await _userInterface.UpdateAsync(user);
            }
        }

        public async Task ModifyJobTitleAsync(UserUpdateParameters parameters)
        {
            var user = await _userInterface.GetByIdAsync(parameters.Id);
            if (user == null) throw new ArgumentNullException("the user not found");
            else
            {
                user.SetJobTitle(parameters.NewJobTitle);
                await _userInterface.UpdateAsync(user);
            }
        }

        public async Task ModifyImageUrlAsync(UserUpdateParameters parameters)
        {
            var user = await _userInterface.GetByIdAsync(parameters.Id);
            if (user == null) throw new ArgumentNullException("the user not found");
            else
            {
                user.SetImageUrl(parameters.NewImageUrl);
                await _userInterface.UpdateAsync(user);
            }
        }
        public async Task ModifyCVUrlAsync(UserUpdateParameters parameters)
        {
            var user = await _userInterface.GetByIdAsync(parameters.Id);
            if (user == null) throw new ArgumentNullException("the user not found");
            else
            {
                user.SetCvUrl(parameters.NewCvUrl);
                await _userInterface.UpdateAsync(user);
            }
        }
    }
}
