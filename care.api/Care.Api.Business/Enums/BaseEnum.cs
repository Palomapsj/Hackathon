using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProFarma.Care.Domain.Entities
{
    public class EnumGuid : Attribute
    {
        public Guid Guid;

        public EnumGuid(string guid)
        {
            Guid = new Guid(guid);
        }
    }

    public class AtributoStringEnum : Attribute
    {
        public string ValorString { get; protected set; }
        public string ValorCodigo { get; protected set; }
        public AtributoStringEnum(string value, string valueCod)
        {
            ValorString = value;
            ValorCodigo = valueCod;
        }
    }

    public static class StringValueAttributeExtention
    {

        public static string GetStringValue(this System.Enum value)
        {
            try
            {
                var type = value.GetType();
                var fieldInfo = type.GetField(value.ToString());
                var attribs = fieldInfo.GetCustomAttributes(
                    typeof(AtributoStringEnum), false) as AtributoStringEnum[];
                return attribs != null && attribs.Length > 0 ? attribs[0].ValorString : null;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        public static string GetCodigoValue(this System.Enum value)
        {
            var type = value.GetType();
            var fieldInfo = type.GetField(value.ToString());
            var attribs = fieldInfo.GetCustomAttributes(
                typeof(AtributoStringEnum), false) as AtributoStringEnum[];
            return attribs != null && attribs.Length > 0 ? attribs[0].ValorCodigo : null;
        }
    }

    public static class BaseEnumHelper
    {
        public static Guid GetEnumGuid(this Enum e)
        {
            try
            {
                var type = e.GetType();

                MemberInfo[] memberInfo = type.GetMember(e.ToString());

                if (memberInfo != null && memberInfo.Length > 0)
                {
                    object[] attrs = memberInfo[0].GetCustomAttributes(typeof(EnumGuid), false);
                    if (attrs != null && attrs.Length > 0)
                        return ((EnumGuid)attrs[0]).Guid;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return Guid.Empty;
        }

        public static T GetEnumByGuid<T>(Guid guid) where T : Enum
        {
            foreach (T value in Enum.GetValues(typeof(T)))
            {
                var enumGuid = value.GetEnumGuid();
                if (enumGuid == guid)
                {
                    return value;
                }
            }
            throw new ArgumentException("No enum found with the given GUID.");
        }
    }
    public class BaseEnum
    {

        public enum ActionsSubjectTypes
        {
            Benefit_Offer = 1,
            Benefit_Schedule = 2,
            Benefits_Confirm = 3,
            FollowUp_Rule = 4,
            Other_Subject = 5
        }

        public enum ActionStatus
        {
            [AtributoStringEnum("Não iniciado", "1")]
            NotStarted = 1,
            [AtributoStringEnum("Completo", "2")]
            Completed = 2,
            [AtributoStringEnum("Cancelado", "3")]
            Cancelled = 3
        }

        public enum ActionReceiver
        {
            Patient = 1,
            HealthProfessional = 2,
            Doctor = 3,
            Account = 4
        }

        public enum PhoneCallDirection
        {
            Active = 1,
            Received = 2
        }

        public enum Phases
        {
            [EnumGuid("1A9BB431-A434-E411-992D-00155DFB9409")]
            [AtributoStringEnum("PRÉ-CADASTRO","1")]
            PreRegister,
            [EnumGuid("1FE6CC28-A434-E411-992D-00155DFB9409")]
            [AtributoStringEnum("CADASTRO", "2")]
            Register,
            [EnumGuid("7BCD9C0E-A434-E411-992D-00155DFB9409")]
            [AtributoStringEnum("ACESSO", "3")]
            Access,
            [EnumGuid("7CCD9C0E-A434-E411-992D-00155DFB9409")]
            [AtributoStringEnum("ADESÃO", "4")]
            Adherence
        }

        public enum TreatmentSituations
        {
            [EnumGuid("87DEAFE3-A334-E411-992D-00155DFB9409")]
            Active,
            [EnumGuid("631DA1EE-A334-E411-992D-00155DFB9409")]
            Inactive
        }

        public enum TreatmentStatus
        {
            //PreRegister
            [EnumGuid("1F56071A-A534-E411-992D-00155DFB9409")]
            PreRegister,
            [EnumGuid("28793436-A534-E411-992D-00155DFB9409")]
            ProgramOut,

            //Register
            [EnumGuid("A38DE261-A434-E411-992D-00155DFB9409")]
            RegisterSuccessfull,

            // Access
            [EnumGuid("9412E000-A534-E411-992D-00155DFB9409")]
            TreatmentNotStarted,

            // Adhesion
            [EnumGuid("1DF58CA4-A434-E411-992D-00155DFB9409")]
            InTreatment,
            [EnumGuid("92F0D70E-A534-E411-992D-00155DFB9409")]
            TherapeuticBreak,

            [EnumGuid("838BF9C2-FCC2-4FCA-A513-B8211007DBBC")]
            InactiveContactDifficulty,

            [EnumGuid("AE09F656-8818-4DBC-94F2-142137D9E748")]
            UnsentPrescription,

            [EnumGuid("9F07B6D1-B78C-4241-B690-24CD8F0EEB44")]
            InactiveTreatmentNotStarted,

            [EnumGuid("4B31970B-E2B8-44BD-881E-0E154127D44B")]
            NoMedicament,

            [EnumGuid("D0658CE6-B46B-496E-9866-86754980D859")]
            NoProfile,

            [EnumGuid("BA97AC4B-F8E0-4155-9138-426486BF8884")]
            PatientRefusal,

            [EnumGuid("888B7372-E61C-457B-9098-964674CF8E4D")]
            SupportRequested,

            [EnumGuid("3F86D9BC-445B-40DC-8036-E42CE7D5DB54")]
            PublicCenter,

            [EnumGuid("33594D38-1D48-40C9-BA41-39ECC86B375D")]
            AccreditedClinic,

            [EnumGuid("CCA1D4CC-20E2-445D-ADF2-86669284C0E8")]
            HomeInfusion,

            [EnumGuid("EAFCA4AA-763B-4E12-95DF-50D935F8303B")]
            PrivateClinic,

            [EnumGuid("89c579c2-0cc1-4a3b-87ca-9100591d1457")]
            JanssenPro,

            [EnumGuid("137BF1FA-95A9-4446-9174-C4DD92D7343A")]
            JudicialAccess,
        }

        public enum TreatmentStatusDetail
        {
            //PreRegister
            [EnumGuid("1A5E74BE-0435-E411-992D-00155DFB9409")]
            MissingData,
            [EnumGuid("DAB87176-0935-E411-992D-00155DFB9409")]
            NoProgramProfile,
            [EnumGuid("379C700B-0935-E411-992D-00155DFB9409")]
            NoConsent,
            [EnumGuid("4A2520C7-F9BA-4DC0-9898-5DA9A5BA1A38")]
            NoConsentByDoctor,
            [EnumGuid("297AE6C2-8E94-4E16-9C7D-4C412A9A5F97")]
            PendingCustomData,

            //Register
            [EnumGuid("B4B9896E-0835-E411-992D-00155DFB9409")]
            AccessNotIndicated,
            [EnumGuid("899FC15C-E712-E611-96C2-00155D005102")]
            TreatmentNotStarted,

            // Access
            [EnumGuid("CAE0AE81-0835-E411-992D-00155DFB9409")]
            AccessIndicated,
            [EnumGuid("5ED94E88-0835-E411-992D-00155DFB9409")]
            TryingAccess,
            [EnumGuid("50AE4495-0835-E411-992D-00155DFB9409")]
            GotAccessButNotStartTreatment,
            [EnumGuid("B9BCBB90-0935-E411-992D-00155DFB9409")]
            AccessDificulty,

            // Adhesion
            [EnumGuid("8053139D-0835-E411-992D-00155DFB9409")]
            InTreatment,
            [EnumGuid("0CAB9CA5-0835-E411-992D-00155DFB9409")]
            TherapeuticBreak,

            // Inactive Status Details
            [EnumGuid("02F1228E-3112-E611-96C2-00155D005102")]
            UnsuccessfullyContact,

            [EnumGuid("DAF335D6-988B-4CA9-B19E-034A01CF1BBE")]
            InactiveContactDifficulty,

            [EnumGuid("DCC225FD-B498-4E46-AFD6-B30CE5B857BF")]
            UnsentPrescription,

            [EnumGuid("ED6F0C90-5A8B-4809-8681-DF9BE32F30F9")]
            InactiveTreatmentNotStarted,

            [EnumGuid("731A4A0C-2FD9-41F5-B50B-ABBF63B9BC0F")]
            UnsuccessfullAccess,

            [EnumGuid("A2B67D89-A476-424B-8353-AD88DB745C6D")]
            OutOfLeafletDisease,

            [EnumGuid("69DC8E8A-9E96-4E1F-9E58-506E035391AE")]
            OutOfLeafletAge,

            [EnumGuid("794E0FAD-EC31-4962-AF5B-DC3B77420017")]
            ProgramParticipationRefusal,

            [EnumGuid("07EC70EE-F8D8-443E-B36A-2C119189C7E3")]
            ProgramPhoneCallRefusal,

            [EnumGuid("0878739D-636A-409C-9A2D-C28E4B6C7262")]
            PrescriptionReceived,

            [EnumGuid("F8D47A4B-A2A3-448E-9D5E-5A5C4304C127")]
            InputsDonation,

            [EnumGuid("B56A4DE2-9FA6-4A20-80BF-C100C35C6CAC")]
            AccreditedClinicInfusionSubsidy,

            [EnumGuid("74D9E679-6F03-4E38-BA13-62563D65D71D")]
            HomeCareInfusionSubsidy,

            [EnumGuid("714AD0BF-2763-46C1-9B3C-11F15B64BFA2")]
            PublicCenter,

            [EnumGuid("7C40C2DA-3F54-4825-9FD4-F0F6C914351E")]
            AccreditedClinic,

            [EnumGuid("0DC3F3FD-2B7C-4274-A5DB-8D9BCCD44DEE")]
            HomeInfusion,

            [EnumGuid("BA2CD5D8-C482-4D29-95E5-776539D83D7E")]
            PrivateClinic
        }

        public enum StatusCode
        {
            [EnumGuid("2DDD5B4B-4172-446A-BFA0-AED9E778363C")]
            Active,
            [EnumGuid("29FD8D07-4C9D-46B2-9DB0-1FFD8C70A24C")]
            Inactive
        }

        public enum Disease
        {
            [EnumGuid("296FEE46-9C3F-E511-B02E-00155D001F02")]
            DiseaseOutOfLeaflet

        }

        public enum PeriodSubject
        {
            Morning = 1,
            Afternoon = 2
        }

        public enum CreatedBy
        {
            [EnumGuid("6B93EA3E-0AC5-4B4D-8E88-06A77736C785")]
            Admin

        }

        public enum TreatmentStatusCode
        {
            [EnumGuid("A59D8A5E-D935-425E-A3BC-9901EBB2FD52")]
            Active,
            [EnumGuid("DAA559A9-B6F6-43F2-A3E3-CC77A14B4131")]
            Inactive
        }

        public enum TreatmentCustomDataStatusCode
        {
            [EnumGuid("9D1907BE-2F1F-464F-ADD1-41788E17919A")]
            Active,
            [EnumGuid("44CBE0F7-E88D-49E2-AFBF-0FBCD72CF092")]
            Inactive
        }

        public enum PatientStatusCode
        {
            [EnumGuid("DFF98E04-D857-4035-95C9-78B44F8B6319")]
            Active,
            [EnumGuid("7E82FB03-CFD8-4B22-9FA2-CC2F52295B22")]
            Inactive
        }

        public enum ProgramIdDefault
        {
            [EnumGuid("6FF88F55-C993-412A-A8E8-2CBBE9B9CFB5")]
            ProgramIdDefault

        }


    }

    public static class EnumExtensions
    {
        public static T? GetEnumValueFromGuid<T>(Guid guid) where T : struct
        {
            var enumType = typeof(T);
            if (!enumType.IsEnum)
            {
                throw new ArgumentException("T deve ser um tipo enumerado.");
            }

            foreach (var enumValue in Enum.GetValues(enumType))
            {
                var memberInfos = enumType.GetMember(enumValue.ToString());
                var enumGuidAttribute = memberInfos[0].GetCustomAttributes(typeof(EnumGuid), false).FirstOrDefault() as EnumGuid;

                if (enumGuidAttribute != null && enumGuidAttribute.Guid == guid)
                {
                    return (T)enumValue;
                }
            }

            return null;
        }
    }

}
