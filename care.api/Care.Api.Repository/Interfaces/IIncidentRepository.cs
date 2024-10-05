using Care.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Care.Api.Repository.Interfaces
{
    public interface IIncidentRepository : ICommonRepository<Incident>
    {
      
        List<IncidentSubject> GetIncidentSubject(string programcode);
    }
}
