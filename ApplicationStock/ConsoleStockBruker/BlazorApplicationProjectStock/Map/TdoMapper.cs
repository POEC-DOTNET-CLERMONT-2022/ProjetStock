

using ProjectStockLibrary;
using ProjectStockModels.Model;


namespace BlazorApplicationProjectStock.Map
{
    public class TdoMapper : AutoMapper.Profile 
                                                  
    {
        public TdoMapper()
        {
            
            CreateMap<UserModel, Client>().ReverseMap();
            CreateMap<NotificationModel, Notification>().ReverseMap();
            CreateMap<MarketModel, Market>().ReverseMap();
            CreateMap<StockModel, Stock>().ReverseMap();
            CreateMap<Client, UserModel>().ReverseMap();
            CreateMap<Address, AddressModel>().ReverseMap();
            CreateMap<Stock,StockModel>().ReverseMap();   

            CreateMap<Client, UserModel>().ReverseMap();
            CreateMap<Notification, NotificationModel>().ReverseMap();
            CreateMap<Market, MarketModel>().ReverseMap();
            CreateMap<Stock, StockModel>().ReverseMap();

        
 
            CreateMap<OrderModel, Order>().ReverseMap();
            CreateMap<Order, OrderModel>().ReverseMap();

            CreateMap<Notification, NotificationModel>().ReverseMap();
            CreateMap<Order, OrderModel>().ReverseMap();

        }   

    }
}
