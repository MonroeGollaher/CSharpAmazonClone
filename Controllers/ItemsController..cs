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

namespace Amazen.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly ItemsService _is;

        public ItemsController(ItemsService itemsService)
        {
            _is = itemsService;
        }
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Item>> CreateItem([FromBody] Item newItem)
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                newItem.CreatorId = userInfo.Id;
                Item created = _is.CreateItem(newItem);
                created.Creator = userInfo;
                return Ok(created);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<string> DeleteItem(int id)
        {
        try
        {
            return Ok(_is.DeleteItem(id));
        }
        catch (System.Exception error)
        {
            return BadRequest(error.Message);
        }
        }

        [HttpGet]
        public ActionResult<IEnumerable<Item>> GetItems()
        {
            try
            {
                return Ok(_is.GetItems());
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}