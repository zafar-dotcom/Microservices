using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.DAL;
using ProductAPI.Model;
using Serilog;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _repo;
        public OrderController(IOrderRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
      // [Route("Add")]
        public async Task<ActionResult> Add(Order order)
        {
            try
            {
              //  Log.Debug("Order Addition Started");
                //Log.Debug("Order addition input", order);
                int orderid = await _repo.Add(order);
                //Log.Debug("Order Addition output", orderid);
                return Ok(orderid);
            }
            catch (Exception ex)
            {
                // Log.Error("Order Addition Failed", ex);
                throw new Exception("Order Addition Failed", innerException: ex);
            }

        }

       // [HttpGet("customer/{id}")]
       //// [Route("getbycustomerid/{id}")]
       // public async Task<ActionResult> GetByCustomerId(int id)
       // {
       //     var order = await _repo.GetByCustomerId(id);
       //     return Ok(order);
       // }
        [HttpGet("{id}")]
       // [Route("getbyid/{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var order = await _repo.GetById(id);
            return Ok(order);
        }
        [HttpDelete("{id}")]
       // [Route("cancelorder/{id}")]
        public async Task<ActionResult> Cancel(int id)
        {
            string cancel = await _repo.Cancel(id);
            return Ok(cancel);
        }
    }
}
