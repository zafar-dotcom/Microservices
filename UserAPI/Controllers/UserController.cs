using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserAPI.DAL;
using UserAPI.Model;

namespace UserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userservicel;
        public UserController(IUserService userservice)
        {
            _userservicel= userservice;
        }
        [HttpGet]
        public IEnumerable<User> GetUserList()
        {
           var list= _userservicel.GetUSerList();
            return list;
        }
        [HttpGet("{id}")]
        public User GetUserById(int id)
        {
           return _userservicel.GetUserByID(id);
        }
        [HttpPost]
        public User AddUser(User user)
        {
          var response=  _userservicel.AddUuser(user);
            return response;

        }
        [HttpPut]
        public User UpdateUser(User user)
        {
           var response= _userservicel.UpdateUuser(user);
            return response;

        }
        [HttpDelete("{id}")]
        public bool DeleteUser(int id)
        {
           return _userservicel.DeleteUser(id);
        }
    }
}
