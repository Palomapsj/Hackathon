using Care.Api.Context;
using Care.Api.Models;
using Care.Api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Care.Api.Repository.Repositories
{
    public class TreatmentAddressRepository : CommonRepository<TreatmentAddress>, ITreatmentAddressRepository
    {
        public TreatmentAddressRepository(CareDbContext careDbContext) : base(careDbContext)
        {

        }
        public async Task<TreatmentAddress> GetByTreatmentId(Guid id)
        {
            try
            {
                return _careDbContext.TreatmentAddresses
                    .Where(_ => _.TreatmentId == id)
                    .FirstOrDefault();
            }
            catch (Exception ex) { }

            return null;
        }
        public async Task<TreatmentAddress> GetAddressByTreatmentId(Guid id)
        {
            try
            {
                return _careDbContext.TreatmentAddresses
                    .Where(_ => _.TreatmentId == id && _.IsDeleted == false)
                    .Include(_ => _.Treatment)
                    .FirstOrDefault();

            }
            catch (Exception ex) { return null; }
        }
    }

}
