using Care.Api.Models;

namespace Care.Api.Repository.Interfaces;

public interface IUserRepository : ICommonRepository<User>
{
    User GetUser(string email, string password, string programCode);
    User GetUserByEmail(string email, string programCode);
    User GetUserById(Guid id, string healthProgramCode);
    List<AccessProfile> GetUserProfileById(Guid Id);
    List<AccessProfile> GetUserProfileByIdAndHealthProgramName(Guid Id, string programCode);
    User? GetUserByEmailAndHealthProgramId(string email, Guid healthProgramId);
    List<HealthProgram> GetDoctorHealthProgramById(Guid Id);
    List<HealthProgram> GetHealthProfessionalHealthProgramById(Guid Id);
    User GetUserSanofi(string email, string password);
    void DeleteUser(User user);
    User? GetUser(string email, string programCode);
    User GetUserByLogin(string login, string password);

}
