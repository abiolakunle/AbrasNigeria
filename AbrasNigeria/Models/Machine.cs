﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbrasNigeria.Models
{
    public class Machine
    {
        public Machine()
        {
            ProductMachines = new HashSet<ProductMachine>();
            MachineSections = new HashSet<MachineSection>();
            MachineSectionGroups = new HashSet<MachineSectionGroup>();
        }

        public int MachineId { get; set; }

        public string ModelName { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string ThumbUrl { get; set; }

        public string SerialNumber { get; set; }

        public virtual Brand Brand { get; set; }

        public virtual MachineType MachineType { get; set; }

        //public virtual ICollection<Section> Sections { get; set; }

        //public virtual ICollection<SectionGroup> SectionGroups { get; set; }

        public ICollection<ProductMachine> ProductMachines { get; set; }

        public ICollection<MachineSection> MachineSections { get; set; }

        public ICollection<MachineSectionGroup> MachineSectionGroups { get; set; }


    }
}
