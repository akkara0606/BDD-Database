using Microsoft.AspNetCore.Mvc;
using ProjectTest.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectTest.Models;

namespace ProjectTest.Data.Repositories
{
    public class UpfileRepository : GenericRepository<Uploadfile>
    {
        private readonly ApplicationDbContext _context;
        public UpfileRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

    }
}
