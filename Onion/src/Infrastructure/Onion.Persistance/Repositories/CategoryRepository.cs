using Onion.Application.Interfaces.Repositories;
using Onion.Domain.Entities;
using Onion.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Persistance.Repositories
{
    public class CategoryRepository:GenericRepository<Category>
    {
        private readonly ProniaDbContext _context;

        public CategoryRepository(ProniaDbContext context):base(context)
        {
            _context = context;
        }
    }
}
