using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Api.Business.Models
{
    public class Enums
    {
        public enum UserType
        {
            Master = 1,
            Patient = 2,
            Supervisor = 4,
            Client = 6,
            Doctor = 9,
            Representative = 10,
            Manager = 11,
            HealthUnit = 12,
            Laboratory = 13,
            Distributor = 14
        }

        public enum Status
        {
            Inactive = 0,
            Active = 1
        }
    }
}
