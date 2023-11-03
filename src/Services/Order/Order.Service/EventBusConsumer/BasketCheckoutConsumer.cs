using AutoMapper;
using EventBus.Messages.Event;
using MassTransit;
using Order.Service.Dtos;
using Order.Service.IService;

namespace Order.Service.EventBusConsumer
{
    public class BasketCheckoutConsumer : IConsumer<BasketCheckoutEvent>
    {
        private readonly IMapper _mapper;
        private readonly IOrderService _orderService;

        public BasketCheckoutConsumer(IMapper mapper, IOrderService orderService)
        {
            _mapper = mapper;
            _orderService = orderService;
        }

        public async Task Consume(ConsumeContext<BasketCheckoutEvent> context)
        {
            var order = _mapper.Map<AddOrderDetailsDto>(context);
            await _orderService.AddOrderDetailsAsync(order);
        }
    }
}
