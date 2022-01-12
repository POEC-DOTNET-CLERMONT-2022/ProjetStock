using ProjectStockEntity;
using ProjectStockRepository.Context;
using ProjectStockRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStockRepository.Repository
{
    internal class NotificationRepository  : INotificationRepository
    {
        private SqlDbContext SqlContext { get; }

        public NotificationRepository(SqlDbContext sqlContext)
        {
            SqlContext = sqlContext;
        }

        public NotificationEntity? Add(NotificationEntity notificationEntity)
        {
            NotificationEntity entity = SqlContext.Add(notificationEntity).Entity;
            SqlContext.SaveChanges();

            return entity;
        }

        public NotificationEntity? Update(NotificationEntity notificationEntity)
        {
            NotificationEntity? entity = GetSingle(notificationEntity._id);
            if (entity == null)
            {
                return null;
            }


            entity.sendAt = notificationEntity.sendAt;
            entity._textRappel = notificationEntity._textRappel;
            SqlContext.Update(entity);
            SqlContext.SaveChanges();

            return entity;
        }

        public bool Delete(Guid id)
        {
            NotificationEntity? entity = GetSingle(id);
            if (entity == null)
            {
                return false;
            }
            SqlContext.Set<NotificationEntity>().Remove(entity);
            return SqlContext.SaveChanges() == 1;
        }

        public NotificationEntity? GetSingle(Guid id)
        {
            return SqlContext.Set<NotificationEntity>()
                             .SingleOrDefault(notif => notif._id == id);
        }
    }
}
