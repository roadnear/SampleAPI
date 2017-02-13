using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SampleAPI.Repository;
using SampleAPI.Models;
using System.Threading.Tasks;

namespace SampleAPI.Controllers
{
    /*This controller has the services for entity User.
    Route template: /api/user/{action}/{id} where id is optional
    Sample get: /api/user/GetAllUsers or /api/user/GetUserByID/3
    Sample post: /api/user/CreateUser use application/json
    */
    public class UserController : ApiController
    {
        private IUserRepository<User> _userRepository = null;
        
        public UserController()
        {
            this._userRepository = new UserRepository<User>();
        }

        //Get all users
        [HttpGet]
        public Task<IEnumerable<User>> GetAllUsers()
        {
            return _userRepository.GetAllUser();
        }

        //Create new user
        //Uses application/json
        [HttpPost]
        public IHttpActionResult CreateUser([FromBody]User user)
        {
            if (ModelState.IsValid)
            {
                if(!_userRepository.IsExistByUsername(user.username))
                {
                    _userRepository.AddUser(user);
                    _userRepository.SaveUser();
                    return Ok(user);
                }
            }
            return BadRequest(ModelState);
        }

        // GET api/<controller>/<action>/<parameter>
        [HttpGet]
        public Task<User> GetUserByID(int id)
        {
            return _userRepository.GetUserByID(id);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

    }
}