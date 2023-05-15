using CQRSWithMediatr.Entities;
using MediatR;

namespace CQRSWithMediatr.Commands
{
    public record AddProductCommand(Product Product) : IRequest<Product>;
}
