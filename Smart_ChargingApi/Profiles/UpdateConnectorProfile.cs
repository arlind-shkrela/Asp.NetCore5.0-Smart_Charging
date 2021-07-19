using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Smart_ChargingApi.DTO.Requests;
using Smart_ChargingApi.Models;

namespace Smart_ChargingApi.Profiles
{
    public class UpdateConnectorProfile : Profile
    {
        public UpdateConnectorProfile()
        {
            CreateMap<Connector, ConnectorDTOUpdate>()
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Max_Current, opt => opt.MapFrom(src => src.Max_Current))
                .ForMember(dest => dest.ChargeStationsId, opt => opt.MapFrom(src => src.ChargeStationsId)).ReverseMap();
        }
    }
}
