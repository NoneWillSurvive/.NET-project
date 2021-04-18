using AutoMapper;
using Client.DTO;
using Client.Requests.Create;
using Client.Requests.Update;
using Domain.Models;

namespace WebAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            this.CreateMap<DataAccess.Entities.Person, Domain.Person>();
            this.CreateMap<DataAccess.Entities.Operator, Domain.Operator>();
            this.CreateMap<DataAccess.Entities.PhoneNumber, Domain.PhoneNumber>();
            this.CreateMap<Domain.Person, PersonDTO>();
            this.CreateMap<Domain.Operator, OperatorDTO>();
            this.CreateMap<Domain.PhoneNumber, PhoneNumberDTO>();
            this.CreateMap<PersonCreateDTO, PersonUpdateModel>();
            this.CreateMap<PersonUpdateDTO, PersonUpdateModel>();
            this.CreateMap<PersonUpdateModel, DataAccess.Entities.Person>();

            this.CreateMap<OperatorCreateDTO, OperatorUpdateModel>();
            this.CreateMap<OperatorUpdateDTO, OperatorUpdateModel>();
            this.CreateMap<OperatorUpdateModel, DataAccess.Entities.Operator>();
        }
    }
}