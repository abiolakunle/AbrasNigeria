using AbrasNigeria.Data.DTO;
using AbrasNigeria.Data.Interfaces;
using AbrasNigeria.Data.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace AbrasNigeria.Controllers
{
    [Route("api/[controller]")]
    public class SectionGroupController : Controller
    {
        private readonly ISectionGroupRepository _sectionGroupRepository;

        public SectionGroupController(ISectionGroupRepository sectionGroupRepository)
        {
            _sectionGroupRepository = sectionGroupRepository;
        }

        [HttpGet("[action]")]
        public JsonResult Search(string searchQuery)
        {
            IEnumerable<SectionGroupDTO> sectionGroups = _sectionGroupRepository.Search(searchQuery);

            return Json(sectionGroups, JsonHelper.SerializerSettings);
        }
    }
}
