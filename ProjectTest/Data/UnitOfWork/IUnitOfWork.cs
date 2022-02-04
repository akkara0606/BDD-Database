using Microsoft.AspNetCore.Mvc;
using ProjectTest.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTest.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        CustomRepository CustomRepository { get; }
        DocumentRepository DocumentRepository { get; }
        ConfigRepository ConfigRepository { get; }
        EmployeeRepository EmployeeRepository { get; }
        int Commit();
    }
}
