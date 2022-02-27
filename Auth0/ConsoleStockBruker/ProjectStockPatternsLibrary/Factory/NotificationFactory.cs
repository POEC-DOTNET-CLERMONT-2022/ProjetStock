using ProjectStockDTOS;
using ProjectStockLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectStockPatternsLibrary
{
    public static class NotificationFactory
    {
        public static IEnumerable<NotificationDto> ToDto(this IEnumerable<Notification> notifications)
        {
            foreach (var notif in notifications)
            {
                yield return notif.ToDtoStock();
            }
        }


        public static NotificationDto ToDtoStock(this Notification notif)
        {
            return new NotificationDto() { Id = notif.Id,sendAt = notif._sendAt, textRappel = notif._textRappel };
        }

        public static IEnumerable<Market> ToDto(this IEnumerable<MarketDto> markets)
        {
            foreach (var market in markets)
            {
                yield return market.ToModelStock();
            }
        }

        public static Notification ToModelStock(this NotificationDto notif)
        {
            return new Notification(notif.textRappel,notif.sendAt) { Id = notif.Id};
        }
    }
}