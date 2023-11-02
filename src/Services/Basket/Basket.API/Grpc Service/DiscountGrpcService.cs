using Discount.GRPC.Protos;

namespace Basket.API.Grpc_Service
{
    public class DiscountGrpcService
    {
        private readonly DiscountProtoService.DiscountProtoServiceClient _client;

        public DiscountGrpcService(DiscountProtoService.DiscountProtoServiceClient client)
        {
            _client = client;
        }

        public async Task<DiscountModel> GetDiscount(string bookId)
        {
            var dicountRequest = new GetDiscountRequest { BookId = bookId };
            return await _client.GetDiscountAsync(dicountRequest);
        }
    }
}
