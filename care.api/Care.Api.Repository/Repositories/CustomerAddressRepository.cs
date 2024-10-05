using Care.Api.Context;
using Care.Api.Models;
using Care.Api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Care.Api.Repository.Repositories
{
    public class CustomerAddressRepository : CommonRepository<CustomerAddress>, ICustomerAddressRepository
    {
        public CustomerAddressRepository(CareDbContext careDbContext) : base(careDbContext)
        {
        }

        public List<CustomerAddress> GetAddressByDoctor(Guid userId, string programcode)
        {
            var healthProgramId = _careDbContext.HealthPrograms.FirstOrDefault(_ => _.Code == programcode).Id;
            var doctor = _careDbContext.DoctorByPrograms.FirstOrDefault(_ => _.SystemUserId == userId && _.HealthProgramId == healthProgramId && _.IsDeleted == false);

            var diagnosticsDoctor = _careDbContext.Diagnostics.Where(_ => _.DoctorId == doctor.DoctorId && _.IsDeleted == false).ToList();
            var patientList = diagnosticsDoctor.Where(_ => _.PatientId.HasValue).Select(_ => _.PatientId);

            var customerAddresses = _careDbContext.CustomerAddresses.Where(_ => patientList.Any(d => d == _.PatientId) && _.IsDeleted == false).ToList();

            return customerAddresses;
        }
    }
}
