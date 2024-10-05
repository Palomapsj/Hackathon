using Care.Api.Context;
using Care.Api.Models;
using Care.Api.Repository.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Care.Api.Repository.Repositories;

public class UserRepository : CommonRepository<User>, IUserRepository
{
    private readonly IHealthProgramRepository _healthProgramRepository;
    private readonly IHealthProfessionalRepository _healthProfessionalRepository;
    private readonly IHealthProfessionalByProgramRepository _healthProfessionalbyProgramRepository;
    private readonly string _connectionString;


    public UserRepository(
        CareDbContext careDbContext,
        IHealthProgramRepository healthProgramRepository,
        IHealthProfessionalRepository healthProfessionalRepository,
        IHealthProfessionalByProgramRepository healthProfessionalbyProgramRepository,
        IConfiguration configuration) : base(careDbContext)
    {
        _healthProgramRepository = healthProgramRepository;
        _healthProfessionalRepository = healthProfessionalRepository;
        _healthProfessionalbyProgramRepository = healthProfessionalbyProgramRepository;
        _connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new Exception("ConnecitonString not found!");
    }

    public List<HealthProgram> GetDoctorHealthProgramById(Guid Id)
    {
        List<DoctorByProgram> doctorbyprogram = new List<DoctorByProgram>();
        List<HealthProgram> healthPrograms = new List<HealthProgram>();
        List<DoctorByProgram> Doctor = new List<DoctorByProgram>();

        try
        {
            Doctor = _careDbContext.DoctorByPrograms.Where(dbp => dbp.SystemUserId == Id).ToList();
            if (Doctor is not null)
            {
                if (Doctor is not null)
                {
                    foreach (var entity in Doctor)
                    {
                        doctorbyprogram.Add(new DoctorByProgram
                        {
                            Id = entity.Id,
                            Name = entity.Name,
                            HealthProgram = entity.HealthProgram,
                            HealthProgramId = entity.HealthProgramId,
                        });

                    }

                    for (var size = doctorbyprogram.Count(); size > 0; size--)
                    {
                        var healthprogram = _careDbContext.HealthPrograms.Where(h => h.Id == doctorbyprogram[size - 1].HealthProgramId).FirstOrDefault();
                        healthPrograms.Add(new HealthProgram
                        {
                            Code = healthprogram.Code,
                            Name = healthprogram.Name,
                            Id = healthprogram.Id
                        });
                    }


                }
            }
        }
        catch (Exception ex)
        { Console.WriteLine("Error: " + ex.Message); }
        finally
        { Console.WriteLine("Finally block GetDoctorHealthProgramById executed."); }
        return healthPrograms;
    }


    public User GetUser(string email, string password, string programCode)
    {
        try
        {
            var healthProgramId = _healthProgramRepository.GetValue(_ => _.Code == programCode).Id;
            var user = _careDbContext.Users
                                   .Where(u => u.Email == email && u.Password == password && !u.IsDeleted &&
                                               (u.FriendlyCode == null || u.FriendlyCode.StartsWith($"USR-{programCode}-")))
                                   .Include(p => p.AccessProfiles.Where(a => a.HealthProgramId == healthProgramId))
                                   .FirstOrDefault(u => u.AccessProfiles.FirstOrDefault(a => a.HealthProgramId == healthProgramId) != null);


            if (user == null)
            {
                user = _careDbContext.Users
                                    .Where(u => u.Email == email && u.Password == password && !u.IsDeleted)
                                    .Include(p => p.AccessProfiles.Where(a => a.HealthProgramId == healthProgramId))
                                    .FirstOrDefault();
            }

            if (user != null)
            {
                DoctorByProgram doctorByProgram = new DoctorByProgram();
                doctorByProgram.HealthProgramId = healthProgramId;
                user.DoctorByProgramSystemUsers.Add(doctorByProgram);
                return user;
            }
        }
        catch (Exception ex)
        { }

        return new User();
    }

    public User? GetUser(string email, string programCode)
    {
        try
        {
            var healthProgramId = _healthProgramRepository.GetValue(_ => _.Code == programCode).Id;
            return _careDbContext.Users.Where(u => u.Email == email && !u.IsDeleted).Include(p => p.AccessProfiles.Where(a => a.HealthProgramId == healthProgramId)).FirstOrDefault();
        }
        catch (Exception ex)
        { }

        return null;
    }

    public User GetUserByEmail(string email, string programCode)
    {
        try
        {
            var healthProgramId = _healthProgramRepository.GetValue(_ => _.Code == programCode).Id;
            var user = _careDbContext.Users
                .Where(u => u.Email == email)
                .Include(p => p.AccessProfiles
                .Where(ap => ap.HealthProgramId == healthProgramId))
                .FirstOrDefault();

            if (user is not null) return user;
        }
        catch (Exception ex)
        {
            return null;
        }
        return null;
    }

    public User GetUserSanofi(string email, string password)
    {
        try
        {
            //Programas Viva
            var programs = _careDbContext.HealthPrograms.Where(p => p.Code == "978" || p.Code == "979" || p.Code == "980" || p.Code == "000").ToList();

            var programsIds = programs.Select(x => x.Id).ToList();

            var user = new User();

            user = _careDbContext.Users.Where(u => (u.Email == email || u.UserName == email) && u.Password == password).Include(p => p.AccessProfiles.Where(a => programsIds.Contains(a.HealthProgramId.Value))).FirstOrDefault();

            return user;
        }
        catch (Exception ex)
        { }

        return new User();
    }

    public User GetUserById(Guid id, string healthProgramCode)
    {
        try
        {
            HealthProgram healthProgram = _healthProgramRepository.GetValue(h => h.Code == healthProgramCode);

            if (healthProgram is not null)
            {
                if (!string.IsNullOrEmpty(healthProgram.Name))
                {
                    var user = _careDbContext.Users.Where(u => u.Id == id).Include(p => p.AccessProfiles.Where(a => a.HealthProgramId == healthProgram.Id)).FirstOrDefault();

                    if (user is not null)
                        return user;
                }
            }
        }
        catch (Exception ex)
        { }



        return null;
    }

    public List<HealthProgram> GetHealthProfessionalHealthProgramById(Guid Id)
    {

        var healthProfessional = _careDbContext.HealthProfessionals.Where(h => h.UserId == Id).Include(h => h.HealthProfessionalByPrograms).FirstOrDefault();
        List<HealthProfessionalByProgram> hpByProgram = new List<HealthProfessionalByProgram>();
        List<HealthProgram> healthPrograms = new List<HealthProgram>();
        try
        {

            var hpByProgramList = healthProfessional.HealthProfessionalByPrograms.ToList();

            if (hpByProgramList is not null)
            {

                foreach (var entity in hpByProgramList)
                {
                    hpByProgram.Add(new HealthProfessionalByProgram
                    {
                        HealthProfessionalId = entity.Id,
                        HealthProfessional = entity.HealthProfessional,
                        HealthProgramId = entity.HealthProgramId,
                    });

                }
                for (var size = hpByProgram.Count(); size > 0; size--)
                {
                    var healthprogram = _careDbContext.HealthPrograms.Where(h => h.Id == hpByProgram[size - 1].HealthProgramId).FirstOrDefault();
                    healthPrograms.Add(new HealthProgram
                    {
                        Code = healthprogram.Code,
                        Name = healthprogram.Name,
                        Id = healthprogram.Id
                    });
                }
            }
        }
        catch (Exception ex)
        { Console.WriteLine("Error: " + ex.Message); }
        finally
        { Console.WriteLine("Finally block GetDoctorHealthProgramById executed."); }
        return healthPrograms;
    }

    public User? GetUserByEmailAndHealthProgramId(string email, Guid healthProgramId)
    {
        try
        {
            var user = _careDbContext.Users
                .Include(p => p.AccessProfiles)
                .Where(u => u.Email == email && !u.IsDeleted && u.AccessProfiles.Any(a => a.HealthProgramId == healthProgramId))
                .FirstOrDefault();

            return user;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public List<AccessProfile> GetUserProfileById(Guid Id)
    {
        throw new NotImplementedException();
    }

    public List<AccessProfile> GetUserProfileByIdAndHealthProgramName(Guid Id, string programCode)
    {
        throw new NotImplementedException();
    }

    public void DeleteUser(User user)
    {
        try
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                var accessProfile = user.AccessProfiles.FirstOrDefault(x => x.Users?.FirstOrDefault(y => y.Id == user.Id)?.Id == user.Id);
                parameters.Add("UserId", user.Id);

                if (accessProfile != null)
                {
                    parameters.Add("AccessProfileId", accessProfile.Id);
                    connection.Execute("DELETE accessprofileuser WHERE UserId = @UserId AND AccessProfileId = @AccessProfileId", parameters);
                }

                connection.Execute("DELETE [user] WHERE Id = @UserId", parameters);
            }
        }
        catch (Exception ex)
        { }
    }

    public User GetUserByLogin(string login, string password)
    {
        try
        {
            var user = _careDbContext.Users.Where(u => u.UserName == login && u.Password == password && !u.IsDeleted).FirstOrDefault();

            if (user is not null)
                return user;
        }
        catch (Exception ex)
        { }

        return null;
    }
}
