using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Amazen.Models;
using Amazen.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore;
namespace Amazen.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ListItemsController : ControllerBase
    {
        private readonly ListItemsService _lis;
        public ListItemsController(ListItemsService lis)
        {
            _lis = lis;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ListItem>> CreateListItem([FromBody] ListItem newLi)
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                newLi.CreatorId = userInfo.Id;
                return Ok(_lis.CreateListItem(newLi));
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}