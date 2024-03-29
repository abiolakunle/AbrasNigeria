﻿using AbrasNigeria.Data.DbContexts;
using AbrasNigeria.Data.DTO;
using AbrasNigeria.Data.Interfaces;
using AbrasNigeria.Models;
using System.Collections.Generic;
using System.Linq;

namespace AbrasNigeria.Data.Repositories
{
    public class SectionRepository : Repository<Section>, ISectionRepository
    {
        public SectionRepository(AppDbContext context) : base(context)
        {
        }

        public IEnumerable<SectionDTO> Search(string searchQuery)
        {
            return _context.Sections
                 .Where(s => s.SectionName.Contains(searchQuery))
                 .Select(s => new SectionDTO
                 {
                     SectionName = s.SectionName
                 });
        }
    }
}
