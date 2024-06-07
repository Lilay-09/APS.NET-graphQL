using Microsoft.AspNetCore.Mvc;
using sync.Core.Items;

namespace sync.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroupController:ControllerBase
    {
        private readonly IGroupService _groupService;
        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }
        [HttpGet]
        public async Task<IActionResult> GetGroups()
        {
            var list = await _groupService.GetGroupList();
            return new JsonResult(list);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGroup(Guid id)
        {
            var details = await _groupService.GetGroup(id);
            return new JsonResult(details);
        }
    }
}
