using Care.Api.Models;

namespace Care.Api.Repository.Interfaces;

    public interface IRepresentativeDoctorByProgramRepository : ICommonRepository<RepresentativeDoctorByProgram>
    {
        RepresentativeDoctorByProgram GetRepresentativeDoctorByProgram(Guid representativeId, Guid doctorId, Guid healthProgramId);
    }

