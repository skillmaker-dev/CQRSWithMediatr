using CQRSWithMediatr.Entities;
using MediatR;

namespace CQRSWithMediatr.Queries
{
    public record GetProductsQuery : IRequest<IEnumerable<Product>>;
}
