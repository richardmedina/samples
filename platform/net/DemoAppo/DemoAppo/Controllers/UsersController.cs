using DemoAppo.Models.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAppo.Controllers
{
    [Controller]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private List<UserModel> users = new List<UserModel> {
            new UserModel{ Id = 1, UserName = "Username1", Password = "SillyPasword1" },
            new UserModel{ Id = 2, UserName = "Username2", Password = "SillyPassword2" },
            new UserModel{ Id = 3, UserName = "Username3", Password = "SillyPassword3" },
            new UserModel{ Id = 4, UserName = "Username4", Password = "SillyPassword4" },
        };

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            await Task.CompletedTask;

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(long id)
        {
            await Task.CompletedTask;

            var user = users.FirstOrDefault(user => user.Id == id);

            return user != null
                ? StatusCode(StatusCodes.Status200OK, user)
                : StatusCode(StatusCodes.Status404NotFound, null);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserModel createUserModel)
        {
            await Task.CompletedTask;

            if (createUserModel == null || string.IsNullOrWhiteSpace(createUserModel.UserName) || string.IsNullOrWhiteSpace(createUserModel.Password))
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
