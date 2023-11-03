using AutoMapper;
using Discount.GRPC.Protos;
using Discount.GRPC.Repository;
using Grpc.Core;

namespace Discount.GRPC.Services
{
    public class DiscountService : DiscountProtoService.DiscountProtoServiceBase
    {
        private readonly IDiscountRepository _discountRepository;
        private readonly IMapper _mapper;

        public DiscountService(IDiscountRepository discountRepository, IMapper mapper)
        {
            _discountRepository = discountRepository;
            _mapper = mapper;
        }

        public override async Task<DiscountModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        {
            var bookDiscount = await _discountRepository.GetBookDiscount(request.BookId);

            if (bookDiscount == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, $"Discount with this {request.BookId} is not found."));
            }

            var discount = _mapper.Map<DiscountModel>(bookDiscount);

            return discount;
        }
    }
}
