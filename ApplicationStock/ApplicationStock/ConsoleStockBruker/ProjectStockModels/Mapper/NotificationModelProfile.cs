using AutoMapper;
using ProjectStockDTOS;
using ProjectStockEntity;
using ProjectStockLibrary;
using ProjectStockModels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStockModels.Mapper
{
    public class NotificationModelProfile : Profile
    {
        public NotificationModelProfile()
        {
            CreateMap<NotificationModel, Notification>().ReverseMap();
            CreateMap<NotificationEntity, NotificationDto>().ReverseMap();
        }
    }
}
