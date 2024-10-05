using Care.Api.Context;
using Care.Api.Models;
using Care.Api.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Api.Repository.Repositories
{
    public class MedicalSpecialtyRepository : CommonRepository<MedicalSpecialty>, IMedicalSpecialtyRepository
    {

        public MedicalSpecialtyRepository(CareDbContext careDbContext) : base(careDbContext)
        {

        }
    }
}
