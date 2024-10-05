using Care.Api.Models;

namespace Care.Api.Repository.Interfaces;

public interface IDoctorRepository : ICommonRepository<Doctor>
{
    Doctor GetDoctorByLicense(string licensenumber, string licensestate);
}
