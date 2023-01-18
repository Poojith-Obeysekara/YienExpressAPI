using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YienExpressAPI.Data;
using YienExpressAPI.DTO;
using YienExpressAPI.Model;
using System.Runtime.InteropServices;

namespace YienExpressAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        public IOrderRepo orderRepo;
        public IMapper mapper;


        public OrdersController(IOrderRepo oRepo, IMapper oMapper)
        {
            orderRepo = oRepo;
            mapper = oMapper;
        }



        [HttpGet]
        public ActionResult<IEnumerable<OrderReadDTO>> GetOrder()
        {
            var orders = orderRepo.GetOrders();
            return Ok(mapper.Map<IEnumerable<OrderReadDTO>>(orders));
        }
        [HttpGet("{code}", Name = "GetOrder")]
        public ActionResult<OrderReadDTO> GetOrder(int code)
        {
            var order = orderRepo.GetOrder(code);
            if (order != null)
                return Ok(mapper.Map<OrderReadDTO>(order));
            else
                return NotFound();

        }

        [HttpPost]

        public ActionResult<OrderCreateDTO> CreateOrder(OrderCreateDTO order)
        {
            var modelOrder = mapper.Map<Order>(order);
            orderRepo.CreateOrder(modelOrder);
            orderRepo.Save();
            var newOrder = mapper.Map<OrderReadDTO>(modelOrder);
            return CreatedAtRoute(nameof(GetOrder),
                new { code = newOrder.Id }, newOrder);
        }


        [HttpPut("{code}")]

        public ActionResult Update(int code, OrderCreateDTO order)
        {
            var orderToUpdate = mapper.Map<Order>(order);
            orderToUpdate.Id = code;
            if (orderRepo.Update(orderToUpdate))
                return Ok();
            else
                return NotFound();
        }

        [HttpDelete("{code}")]

        public ActionResult Delete(int code)
        {
            var orderToDelete = orderRepo.GetOrder(code);

            if (orderToDelete != null)
            {
                orderRepo.Delete(orderToDelete);
                return Ok();
            }
            else
                return NotFound();
        }
    }
}
