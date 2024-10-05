using Care.Api.Context;
using Care.Api.Models;
using Care.Api.Models.Models;
using Care.Api.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationResult = Care.Api.Repository.Validation.ValidationResult;

namespace Care.Api.Repository.Repositories
{
    public class CaregiverTreatmentRepository : CommonRepository<CaregiverTreatment>, ICaregiverTreatmentRepository
    {
        public CaregiverTreatmentRepository(CareDbContext careDbContext) : base(careDbContext)
        { 
        
        }
        public ValidationResult Add(Guid caregiverId, Guid treatmentId)
        {
            var validationResult = new ValidationResult();

            try
            {
                var caregiverTreatment = new CaregiverTreatment
                {
                    CaregiverId = caregiverId,
                    TreatmentId = treatmentId
                };

                _careDbContext.Set<CaregiverTreatment>().Add(caregiverTreatment);
                _careDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                validationResult.Add(ex.Message);
            }

            return validationResult;
        }


    }
}
