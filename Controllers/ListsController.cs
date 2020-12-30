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
    public class ListsController : ControllerBase
    {
        private readonly ListsService _ls;
        private readonly ListItemsService _lis;
        public ListsController(ListsService ls, ListItemsService lis)
        {
            _ls = ls;
            _lis = lis;
        }

        [HttpGet]
        public ActionResult<IEnumerable<List>> GetLists()
        {
            try
            {
                return Ok(_ls.GetLists());
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Item>> GetById(int id)
        {
            try
            {
              return Ok(_ls.GetById(id));  
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}/listitems")]
        public ActionResult<IEnumerable<List>> GetItemsByList(int id)
        {
            try
            {
                return Ok(_lis.GetItemsByList(id));
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<List>> CreateList([FromBody] List newList)
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                newList.CreatorId = userInfo.Id;
                List created = _ls.CreateList(newList);
                created.Creator = userInfo;
                return Ok(created);

            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<List>> EditList(int id, [FromBody] List editedList)
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                editedList.Id = id;
                return Ok(_ls.EditList(userInfo, editedList));
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<string> DeleteList(int id)
        {
            try
            {
               return Ok(_ls.DeleteList(id)); 
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}