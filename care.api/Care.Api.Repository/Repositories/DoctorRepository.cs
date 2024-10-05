using Care.Api.Context;
using Care.Api.Models;
using Care.Api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Care.Api.Repository.Repositories;

public sealed class DoctorRepository : CommonRepository<Doctor>, IDoctorRepository
{
    public DoctorRepository(CareDbContext careDbContext, IHealthProgramRepository healthProgramRepository) : base(careDbContext)
    {
    }

    public Doctor GetDoctorByLicense(string licensenumber, string licensestate)
    {
        try
        {
            var doctor = _careDbContext.Doctors
                                .Where(_ => _.LicenseNumber == licensenumber && _.LicenseState == licensestate && _.IsDeleted == false)
                                .Include(_ => _.DoctorByPrograms)
                                .Include(_ => _.MedicalSpecialties)
                                .FirstOrDefault();


            return doctor;
        }
        catch (Exception ex)
        {
            return null;
        }
        
    }




}
