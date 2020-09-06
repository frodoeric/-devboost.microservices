using Flunt.Notifications;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Pay.Core
{
    public class ResponseResult
    {
        private IList<Notification> _failureMessages { get; }

        public IReadOnlyCollection<Notification> Fails => _failureMessages.ToList();

        public bool HasFails => _failureMessages.Any();

        public object Data { get; private set; }

        public ResponseResult(object @object) : this()
        {
            AddValue(@object);
        }

        public void AddValue(object @object)
        {
            Data = @object;
        }
        public ResponseResult()
        {
            _failureMessages = new List<Notification>();
        }

        /// <summary>
        /// Adiciona notificações do Flunt
        /// </summary>
        /// <param name="notifications"></param>
        public void AddNotifications(IEnumerable<Notification> notifications)
        {
            foreach (var notification in notifications)
            {
                AddNotification(notification);
            }
        }

        public void AddNotification(Notification notification)
        {
            _failureMessages.Add(notification);
        }
    }
}
