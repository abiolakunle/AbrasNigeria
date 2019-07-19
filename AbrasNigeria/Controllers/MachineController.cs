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


namespace AbrasNigeria.Controllers
{
    [Route("api/[controller]")]
    public class MachineController : Controller
    {
        private readonly IMachineRepository _machineRepository;

        public MachineController(IMachineRepository machineRepository)
        {
            _machineRepository = machineRepository;
        }

        [HttpGet("[action]")]
        public async Task<JsonResult> List()
        {
            IEnumerable<MachineDTO> machines = await _machineRepository.LoadAllWithBrand();

            return Json(machines, JsonHelper.SerializerSettings);
        }

        [HttpGet("[action]")]
        public JsonResult Machine(int id)
        {
            MachineDTO machine = _machineRepository.LoadWithBrandSection(id);

            return Json(machine, JsonHelper.SerializerSettings);
        }
    }
}
