using CQRSWithMediatr.Entities;
using MediatR;

namespace CQRSWithMediatr.Notifications
{
    public record ProductAddedNotification(Product Product) : INotification;
}
