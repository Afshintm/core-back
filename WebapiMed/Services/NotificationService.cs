using MediatR;

public class NotificationService : INotificationSerevice
{
    private readonly IMediator _mediator;
    public NotificationService(IMediator mediator)
    {
        _mediator = mediator;
    }
    public void Notify(string message)
    {
        _mediator.Publish(new NotificationMessage { Message = "Notify All." });
    }
}