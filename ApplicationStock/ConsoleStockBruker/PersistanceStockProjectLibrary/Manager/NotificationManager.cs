using AutoFixture;
using System;
using System.Collections.Generic;
using System.Text;
using ProjectStockDTOS;
using AutoFixture;
using ProjectStockLibrary;

namespace PersistanceStockProjectLibrary.Manager
{
    public class NotificationManager : INotificationManager
    {
        private readonly Fixture _fixture = new Fixture();
        private List<NotificationDto> alerts { get; set; } = new List<NotificationDto>();
        /// <summary>
        /// Gets the creatures from the codex
        /// </summary>
        /// <returns></returns>
        public IEnumerable<NotificationDto> GetNotifications()
        {
            var creatures = new List<Notification>() { new Notification("mon_rappel", DateTime.Now) };

            foreach (var creature in creatures)
            {

                yield return new NotificationDto() { Id = creature.Id,textRappel = creature._textRappel,sendAt = creature._sendAt };
            }
        }
        public IEnumerable<Notification> GetAllNotifications()
        {
            var creatures = new List<Notification>() { new Notification("mon_rappel", DateTime.Now) };
            return creatures;

        }

        public NotificationDto GetById(int id)
        {
            return alerts[id];
        }


        public void Update(int id, NotificationDto notifDto)
        {

            try
            {
                alerts[id] = notifDto;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Erreur update " + ex.ToString());
            }

        }


        public void Add(NotificationDto notifDto)
        {

            try
            {
                alerts.Add(notifDto);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Erreur Add" + ex.ToString());
            }

        }


        public void Delete(NotificationDto notifDto)
        {
            try
            {
                alerts.Remove(notifDto);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Erreur delete" + ex.ToString());
            }
        }
    }
}
