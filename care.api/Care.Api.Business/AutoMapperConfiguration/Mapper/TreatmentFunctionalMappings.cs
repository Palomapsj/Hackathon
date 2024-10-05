using Care.Api.Business.Enums.Functional;
using Care.Api.Business.Models.Message.Request;
using Care.Api.Business.Models.Viva;
using Care.Api.Models;
using Care.Api.Repository.Interfaces;
using ProFarma.Care.Domain.Entities;

namespace Care.Api.Business.AutoMapperConfiguration.Mapper
{
    public class TreatmentFunctionalMappings : AutoMapper.Profile
    {
        private readonly IStringMapRepository _stringMapRepository;
        private readonly ITreatmentCustomDataRepository _treatmentCustomDataRepository;
        private readonly ITreatmentAddressRepository _treatmentAddressRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IHealthProgramRepository _healthProgramRepository;
        private readonly ICaregiverRepository _caregiverRepository;

        public TreatmentFunctionalMappings(IStringMapRepository stringMapRepository,
            ITreatmentCustomDataRepository treatmentCustomDataRepository,
            ITreatmentAddressRepository treatmentAddressRepository,
            IDoctorRepository doctorRepository,
            IHealthProgramRepository healthProgramRepository,
            ICaregiverRepository caregiverRepository)
        {
            _stringMapRepository = stringMapRepository;
            _treatmentCustomDataRepository = treatmentCustomDataRepository;
            _treatmentAddressRepository = treatmentAddressRepository;
            _doctorRepository = doctorRepository;
            _healthProgramRepository = healthProgramRepository;
            _caregiverRepository = caregiverRepository;

            CreateMap<Treatment, PostUpdatePacientRequestDto>()
                .ForMember(dest => dest.Cpf, opt => opt.MapFrom(src => src.Cpf))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.DataNascimento, opt => opt.MapFrom(src => src.Birthdate))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.EmailAddress1))
                .ForMember(dest => dest.Senha, opt => opt.MapFrom(src => src.Password))

                .ForMember(dest => dest.Sexo, opt => opt.MapFrom(src => SexoMapper(src.GenderStringMapId)))
                .ForMember(dest => dest.MelhorHoraContato, opt => opt.MapFrom(src => MelhorHorarioContatoMapper(src)))
                .ForMember(dest => dest.DataCadastroFuncional, opt => opt.MapFrom(src => DataCadastroFuncionalMapper(src)))
                .ForMember(dest => dest.Responsavel, opt => opt.MapFrom(src => ResponsavelFuncionalMapper(src)))
                .ForMember(dest => dest.Telefones, opt => opt.MapFrom(src => TelefoneFuncionalMapper(src)))
                .ForMember(dest => dest.Endereco, opt => opt.MapFrom(src => EnderecoFuncionalMapper(src)))
                .ForMember(dest => dest.ComoConheceu, opt => opt.MapFrom(src => ComoConheceuMapper(src)))
                .ForMember(dest => dest.Medicamentos, opt => opt.MapFrom(src => MedicamentoMapper(src)))
                .ForMember(dest => dest.MotivoInscricao, opt => opt.MapFrom(src => MotivoInscricaoMapper(src)))

                .ForMember(dest => dest.PossuiResponsavel, opt => opt.MapFrom(src => src.CustomBoolean))
                .ForMember(dest => dest.CodUsuario, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.AceitaEmail, opt => opt.MapFrom(src => src.ConsentToReceiveEmail))
                .ForMember(dest => dest.AceitaSms, opt => opt.MapFrom(src => src.ConsentToReceiveSms))
                .ForMember(dest => dest.AceitaMensagem, opt => opt.MapFrom(src => src.ConsentToReceivePhonecalls))
                .ForMember(dest => dest.AceitaContato, opt => opt.MapFrom(src => src.ConsentToReceiveDiagnosticPhonecalls == true ? 1 : 0))
                .ForMember(dest => dest.AceitaCorrespondencia, opt => opt.MapFrom(src => src.ConsentToReceiveVisit));
            
        }

        private ResponsibleFunctionalRequest ResponsavelFuncionalMapper(Treatment treatment)
        {
            try
            {
                if (!string.IsNullOrEmpty(treatment.FullNameCaregiver))
                {
                    var caregiver = _caregiverRepository.GetValue(c =>
                    ((!string.IsNullOrEmpty(c.Cpf) && c.Cpf.Replace(".", "").Replace("-", "") == treatment.CpfCaregiver.Replace(".", "").Replace("-", ""))
                    || c.CustomString1 == treatment.Id.ToString())
                    && c.HealthProgramId == treatment.HealthProgramId);

                    if (caregiver != null && caregiver.Id != Guid.Empty)
                    {
                        return new ResponsibleFunctionalRequest(
                                    caregiver.Name,
                                    RelacaoResponsavelMapper(caregiver),
                                    caregiver.Birthdate,
                                    TelefoneResponsavelFuncionalMapper(treatment),
                                    caregiver.Cpf,
                                    SexoMapper(caregiver.GenderStringMapId)
                                );
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private AddressFunctionalRequest EnderecoFuncionalMapper(Treatment treatment)
        {
            try
            {
                var address = _treatmentAddressRepository.GetByTreatmentId(treatment.Id).Result;
                int tipoEndereco = 0;

                if (address != null)
                {

                    if (address.AddressTypeStringMapId.HasValue)
                    {
                        EAddressType eAddressType = BaseEnumHelper.GetEnumByGuid<EAddressType>(address.AddressTypeStringMapId.Value);
                        tipoEndereco = (int)eAddressType;
                    }

                    return new AddressFunctionalRequest(
                        address.AddressName,
                        address.AddressNumber,
                        address.AddressDistrict,
                        address.AddressCity,
                        address.AddressPostalCode,
                        address.AddressState,
                        address.AddressComplement,
                        address.AddressReference,
                        tipoEndereco,
                        address.ReceiveMail == true ? 1 : 0);
                }

                return null;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        private List<TelephonesFunctionalRequest> TelefoneResponsavelFuncionalMapper(Treatment treatment)
        {
            var telefones = new List<TelephonesFunctionalRequest>();

            try
            {
                if (!string.IsNullOrWhiteSpace(treatment.Telephone1Caregiver))
                {
                    DefinirTelefoneFuncional(telefones, treatment.Telephone1Caregiver, (int)EPhoneType.Residencial);
                }
                if (!string.IsNullOrWhiteSpace(treatment.Mobilephone1Caregiver))
                {
                    DefinirTelefoneFuncional(telefones, treatment.Mobilephone1Caregiver, (int)EPhoneType.Celular);
                }

                return telefones;
            }
            catch (Exception ex)
            {
                return telefones;
            }            
        }

        private List<TelephonesFunctionalRequest> TelefoneFuncionalMapper(Treatment treatment)
        {
            var telefones = new List<TelephonesFunctionalRequest>();

            try
            {
                if (!string.IsNullOrWhiteSpace(treatment.Telephone1))
                {
                    DefinirTelefoneFuncional(telefones, treatment.Telephone1, (int)EPhoneType.Residencial);
                }
                if (!string.IsNullOrWhiteSpace(treatment.Telephone2))
                {
                    DefinirTelefoneFuncional(telefones, treatment.Telephone2, (int)EPhoneType.Residencial);
                }
                if (!string.IsNullOrWhiteSpace(treatment.Telephone3))
                {
                    DefinirTelefoneFuncional(telefones, treatment.Telephone3, (int)EPhoneType.Residencial);
                }

                if (!string.IsNullOrWhiteSpace(treatment.Mobilephone1))
                {
                    DefinirTelefoneFuncional(telefones, treatment.Mobilephone1, (int)EPhoneType.Celular);
                }
                if (!string.IsNullOrWhiteSpace(treatment.Mobilephone2))
                {
                    DefinirTelefoneFuncional(telefones, treatment.Mobilephone2, (int)EPhoneType.Celular);
                }
                if (!string.IsNullOrWhiteSpace(treatment.Mobilephone3))
                {
                    DefinirTelefoneFuncional(telefones, treatment.Mobilephone3, (int)EPhoneType.Celular);
                }

                return telefones;
            }
            catch(Exception ex)
            {
                return telefones;
            }            
        }

        private void DefinirTelefoneFuncional(List<TelephonesFunctionalRequest> telefones, string telefone, int tipoTelefone)
        {
            telefones.Add(new TelephonesFunctionalRequest(ExtractDDDPhone(telefone), ExtractNumberPhone(telefone), tipoTelefone));
        }

        private string ExtractDDDPhone(string phone)
        {
            string number = phone.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
            string ddd = number.Substring(0, 2);

            return ddd;
        }

        private string ExtractNumberPhone(string phone)
        {
            string numberReplace = phone.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
            string number = numberReplace.Substring(2);

            return number;
        }

        private int MelhorHorarioContatoMapper(Treatment treatment)
        {
            try
            {
                if (treatment.PreferredTimeStringMapId.HasValue)
                {
                    var preferedTimeStringMap = _stringMapRepository.GetValue(s => s.StringMapId == treatment.PreferredTimeStringMapId);

                    if (!string.IsNullOrEmpty(preferedTimeStringMap.Flag))
                    {
                        var ePreferredTime = Enums.EnumExtensions.GetEnumValueFromDescription<EPreferredTime>(preferedTimeStringMap.Flag);
                        return (int)ePreferredTime;
                    }
                }

                return (int)EPreferredTime.Integral;
            }
            catch(Exception ex)
            {
                return (int)EPreferredTime.Integral;
            }
        }

        private int RelacaoResponsavelMapper(Caregiver caregiver)
        {
            try
            {
                if (caregiver.KinshipStringMapId.HasValue)
                {
                    var kinshipStringMap = _stringMapRepository.GetValue(s => s.StringMapId == caregiver.KinshipStringMapId);

                    if (!string.IsNullOrEmpty(kinshipStringMap.Flag))
                    {
                        var eResponsibleRelationship = Enums.EnumExtensions.GetEnumValueFromDescription<EResponsibleRelationship>(kinshipStringMap.Flag);
                        return (int)eResponsibleRelationship;
                    }
                }

                return (int)EResponsibleRelationship.NaoInformado;
            }
            catch (Exception)
            {
                return (int)EResponsibleRelationship.NaoInformado;
            }
        }

        private int SexoMapper(Guid? genderStringMapId)
        {
            try
            {
                if (genderStringMapId.HasValue)
                {

                    var genderStringMap = _stringMapRepository.GetValue(s => s.StringMapId == genderStringMapId);

                    if (!string.IsNullOrEmpty(genderStringMap.Flag))
                    {
                        var eGender = Enums.EnumExtensions.GetEnumValueFromDescription<EGender>(genderStringMap.Flag);
                        return (int)eGender;
                    }
                }

                return (int)EGender.NaoInformado;
            }
            catch (Exception ex)
            {
                return (int)EGender.NaoInformado;
            }
        }

        private int ComoConheceuMapper(Treatment treatment)
        {
            try
            {
                if (treatment.Custom3StringMapId.HasValue)
                {
                    var howMeetProgramStringMap = _stringMapRepository.GetValue(s => s.StringMapId == treatment.Custom3StringMapId);

                    if (!string.IsNullOrEmpty(howMeetProgramStringMap.Flag))
                    {
                        var eHowMeetProgram = Enums.EnumExtensions.GetEnumValueFromDescription<EHowMeetProgram>(howMeetProgramStringMap.Flag);
                        return (int)eHowMeetProgram;
                    }
                }

                return (int)EHowMeetProgram.Outros;
            }
            catch (Exception)
            {
                return (int)EHowMeetProgram.Outros;
            }
        }

        private DateTime? DataCadastroFuncionalMapper(Treatment treatment)
        {
            try
            {
                if (treatment.TreatmentCustomDataId.HasValue)
                {
                    var treatmentCustomData = _treatmentCustomDataRepository.GetValue(t => t.Id == treatment.TreatmentCustomDataId);

                    return treatmentCustomData.CustomDateTime1;
                }

                return null;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        private List<MedicamentFunctionalRequest> MedicamentoMapper(Treatment treatment)
        {
            try
            {
                var medicaments = new List<MedicamentFunctionalRequest>();

                var treatmentCustomData = _treatmentCustomDataRepository.GetValue(t => t.Id == treatment.TreatmentCustomDataId);
                var doctor = _doctorRepository.GetValue(d => d.Id == treatment.DoctorId);
                var medico = new DoctorFunctionalRequest(doctor?.LicenseNumber, doctor?.LicenseState, doctor?.FullName);

                var eMedicament = Enums.EnumExtensions.ConvertToEnumByMedicamentId<EHealthProgramMedicament>($"{treatment.MedicamentId}");
                var medicamentFuncionalCode = Convert.ToInt32(eMedicament.GetMedicationFuncionalCode());

                var newMedicament = new MedicamentFunctionalRequest(treatmentCustomData?.SupportFieldInt3 ?? medicamentFuncionalCode, treatmentCustomData?.SupportFieldInt, treatment.Dosage, medico, treatmentCustomData?.SupportFieldInt2 ?? 0);
                medicaments.Add(newMedicament);

                return medicaments;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private IEnumerable<int> MotivoInscricaoMapper(Treatment treatment)
        {
            var motivos = new List<int>();

            try
            {
                var healthProgramDupixent = _healthProgramRepository.GetValue(h => h.Code == "980");

                if (treatment.HealthProgramId == healthProgramDupixent.Id)
                {
                    if (treatment.DiseaseId.HasValue)
                        MotivoPorIndicacaoDupixentMapper(treatment.DiseaseId.Value, EIndication.Primeira, motivos);

                    if (treatment.Disease2Id.HasValue)
                        MotivoPorIndicacaoDupixentMapper(treatment.Disease2Id.Value, EIndication.Segunda, motivos);

                    if (treatment.Disease3Id.HasValue)
                        MotivoPorIndicacaoDupixentMapper(treatment.Disease3Id.Value, EIndication.Terceira, motivos);
                }

                return motivos;
            }
            catch(Exception ex)
            {
                return motivos;
            }
        }

        private void MotivoPorIndicacaoDupixentMapper(Guid diseaseId, EIndication eIndicacao, List<int> motivos)
        {
            var diseaseMotivosMap = new Dictionary<Guid?, (int primeiraIndicacao, int segundaIndicacao, int terceiraIndicacao)>
            {
                {
                    BaseEnumHelper.GetEnumGuid(EDisease.Polipos),
                    ((int)EReasonRegistration.PoliposNasaisPrimeiraIndicacao,
                    (int)EReasonRegistration.PoliposNasaisSegundaIndicacao,
                    (int)EReasonRegistration.PoliposNasaisTerceiraIndicacao)
                },
                {
                    BaseEnumHelper.GetEnumGuid(EDisease.Asma),
                    ((int)EReasonRegistration.AsmaPrimeiraIndicacao,
                    (int)EReasonRegistration.AsmaSegundaIndicacao,
                    (int)EReasonRegistration.AsmaTerceiraIndicacao)
                },
                {
                    BaseEnumHelper.GetEnumGuid(EDisease.DermatiteAtopica),
                    ((int)EReasonRegistration.DermatiteAtopicaPrimeiraIndicacao,
                    (int)EReasonRegistration.DermatiteAtopicaSegundaIndicacao,
                    (int)EReasonRegistration.DermatiteAtopicaTerceiraIndicacao)
                },
            };

            if (diseaseMotivosMap.TryGetValue(diseaseId, out var motivosIndicacao))
            {
                switch (eIndicacao)
                {
                    case EIndication.Primeira:
                        motivos.Add(motivosIndicacao.primeiraIndicacao);
                        break;
                    case EIndication.Segunda:
                        motivos.Add(motivosIndicacao.segundaIndicacao);
                        break;
                    case EIndication.Terceira:
                        motivos.Add(motivosIndicacao.terceiraIndicacao);
                        break;
                }
            }
        }
    }
}
