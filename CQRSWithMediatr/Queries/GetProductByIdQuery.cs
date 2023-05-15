using CQRSWithMediatr.Entities;
using MediatR;

namespace CQRSWithMediatr.Queries
{
    public record GetProductByIdQuery(int Id) : IRequest<Product>;
}
