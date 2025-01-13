using MediatR;
using OrderManagment.Application.Interface;
using OrderManagment.Application.Service.notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagment.Application.Service.handlers
{
    public class NotificationHandlers : INotificationHandler<Notification>
    {

        public async Task Handle(Notification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine(notification.message);
            await Task.CompletedTask;
        }
    }
}
