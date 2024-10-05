namespace Care.Api.Business.Models
{
    public class EyePrescriptionModel
    {
        public RefractionModel? Refraction { get; set; }
    }

    public class RefractionModel
    {
        public EyeDataModel? Spheric { get; set; }
        public EyeDataModel? Cilindric { get; set; }
        public EyeDataModel? Axis { get; set; }
    }

    public class EyeDataModel
    {
        public EyePropertyModel? Left { get; set; }
        public EyePropertyModel? Right { get; set; }
    }

    public class EyePropertyModel
    {
        public double? Far { get; set; }
        public double? Near { get; set; }
    }
}