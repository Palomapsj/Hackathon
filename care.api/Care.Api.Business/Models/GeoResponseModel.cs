﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Care.Api.Business.Models
{
    [DataContract]
    public class GeoResponseModel
    {
        [DataMember(Name = "status")]
        public string Status { get; set; }
        [DataMember(Name = "results")]
        public CResult[] Results { get; set; }

        [DataContract]
        public class CResult
        {
            [DataMember(Name = "geometry")]
            public CGeometry Geometry { get; set; }

            [DataContract]
            public class CGeometry
            {
                [DataMember(Name = "location")]
                public CLocation Location { get; set; }

                [DataContract]
                public class CLocation
                {
                    [DataMember(Name = "lat")]
                    public double Lat { get; set; }

                    [DataMember(Name = "lng")]
                    public double Lng { get; set; }
                }
            }
        }

        public GeoResponseModel()
        { }
    }
}
