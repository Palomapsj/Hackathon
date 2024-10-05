namespace Care.Api.Business.Models
{
    public class StepModel
    {
        public int PatientsAwaitingRegistration { get; set; }
        public int PatientsAwaitingPlanApproval { get; set; }
        public int PatientsWaitingExamSchedule { get; set; }
        public int PatientsWaitingTheExam { get; set; }
        public int PatientsExamPerformed { get; set; }
        public int PatientsAwaitingDrugRelease { get; set; }
        public int PatientsWaitingInfusion { get; set; }
        public int PatientsInfusionPerformed { get; set; }
    }
}
