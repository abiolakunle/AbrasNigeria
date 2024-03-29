﻿using System.Collections.Generic;
using AbrasNigeria.Data.DTO;
using AbrasNigeria.Models;

namespace AbrasNigeria.Data.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        IEnumerable<Category> LoadAllWithProducts();
        IEnumerable<CategoryDTO> Search(string searchQuery);
    }
}
