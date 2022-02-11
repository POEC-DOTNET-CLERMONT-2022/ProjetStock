using ApiApplication.Profil;
using AutoMapper;
using ProjectStockEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Application.Map
{
    public class NotificationEntityProFile : Profile
    {
        public NotificationEntityProFile()
        {
            CreateMap<NotificationEntity, NotificationProfile>().ReverseMap();
        }
    }
}
