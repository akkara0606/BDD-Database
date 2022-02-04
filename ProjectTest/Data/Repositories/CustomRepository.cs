using Microsoft.AspNetCore.Mvc;
using ProjectTest.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTest.Data.Repositories
{
    public class CustomRepository
    {
        private readonly ApplicationDbContext _context;


        public CustomRepository(ApplicationDbContext context)
        {
            _context = context;

        }



    }
}
