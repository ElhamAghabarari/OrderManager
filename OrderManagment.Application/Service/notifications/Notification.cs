using MediatR;
using OrderManagment.Application.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagment.Application.Service.notifications
{
    public record Notification(string message):INotification;
}
