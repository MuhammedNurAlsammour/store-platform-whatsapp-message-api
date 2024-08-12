using E = StorePlatform.Domain.Entities;

namespace StorePlatform.Application.Features.Queries.Cart.GetAllCart
{
    public class GetAllCartQueryResponse
    {
        public int TotalCount { get; set; }
        public object Cart { get; set; }
    }
}
