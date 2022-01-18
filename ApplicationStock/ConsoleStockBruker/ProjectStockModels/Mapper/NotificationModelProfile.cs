using AutoMapper;
using ProjectStockLibrary;
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
            CreateMap<NotificationModelProfile, Notification>().ReverseMap();
        }
    }
}
