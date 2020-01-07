using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

public class NotificationMessage : INotification
{
    public string Message { get; set; }
}

public class RegisterHandler : INotificationHandler<NotificationMessage>
{
    public Task Handle(NotificationMessage notification, CancellationToken cancellationToken)
    {
        return Task.Run(() =>
        {
            Console.WriteLine($"Register Handler got Message {notification}");
        });
    }
}
