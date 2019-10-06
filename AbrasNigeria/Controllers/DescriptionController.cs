using AbrasNigeria.Data.DTO;
using AbrasNigeria.Data.Interfaces;
using AbrasNigeria.Data.Utils;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbrasNigeria.Controllers
{
    [Route("api/[controller]")]
    public class DescriptionController : Controller
    {
        private readonly IDescriptionRepository _descriptionRepository;

        public DescriptionController(IDescriptionRepository descriptionRepository)
        {
            _descriptionRepository = descriptionRepository;
        }

        [HttpGet("[action]")]
        public JsonResult Search(string searchQuery)
        {
            IEnumerable<DescriptionDTO> products = _descriptionRepository.Search(searchQuery);

            return Json(products, JsonHelper.SerializerSettings);
        }
    }
}
