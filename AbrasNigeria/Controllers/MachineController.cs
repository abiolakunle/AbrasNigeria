using AbrasNigeria.Data.Interfaces;
using AbrasNigeria.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbrasNigeria.Data.Utils;
using AbrasNigeria.Data.DTO;
using AbrasNigeria.Data.Models;
using AutoMapper;
using AbrasNigeria.Data.Extensions;

namespace AbrasNigeria.Controllers
{
    [Route("api/[controller]")]
    public class MachineController : Controller
    {
        private readonly IMachineRepository _machineRepository;

        public MachineController(IMachineRepository machineRepository, IMapper mapper)
        {
            _machineRepository = machineRepository;
        }

        [HttpGet("[action]")]
        public JsonResult List(int page)
        {
            IEnumerable<Machine> machines = _machineRepository.LoadAllWithBrand();

            PagingInfo pagingInfo = new PagingInfo
            {
                CurrentPage = page,
                TotalItems = machines.Count()
            };

            machines = machines.Skip((page - 1) * pagingInfo.ItemsPerPage).Take(pagingInfo.ItemsPerPage);

            HttpContext.Response.Headers.Add("Paging", JsonConvert.SerializeObject(pagingInfo));

            return Json(machines.ToDTO(), JsonHelper.SerializerSettings);
        }

        [HttpGet("[action]")]
        public JsonResult Machine(long id)
        {
            MachineDTO machine = _machineRepository.LoadWithBrandSection(id).ToDTO();

            return Json(machine, JsonHelper.SerializerSettings);
        }

        [HttpGet("[action]")]
        public JsonResult Search(string searchQuery)
        {
            IEnumerable<MachineDTO> machines = _machineRepository.Search(searchQuery).ToDTO();

            return Json(machines, JsonHelper.SerializerSettings);
        }
    }
}
