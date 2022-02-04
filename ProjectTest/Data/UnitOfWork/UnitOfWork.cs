using ProjectTest.Data.Context;
using ProjectTest.Data.Repositories;
using ProjectTest.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTest.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private CustomRepository CustomRepo { get; set; }
        private DocumentRepository DocumentRepo { get; set; }
        private ConfigRepository ConfigRepo { get; set; }
        private EmployeeRepository EmployeeRepo { get; set; }

        private readonly ApplicationDbContext _dbContext;

        public UnitOfWork(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public CustomRepository CustomRepository => CustomRepo == null ? new CustomRepository(_dbContext) : CustomRepository;
        public DocumentRepository DocumentRepository => DocumentRepo == null ? new DocumentRepository(_dbContext) : DocumentRepository;
        public ConfigRepository ConfigRepository => ConfigRepo == null ? new ConfigRepository(_dbContext) : ConfigRepository;
        public EmployeeRepository EmployeeRepository => EmployeeRepo == null ? new EmployeeRepository(_dbContext) : EmployeeRepository;

        public int Commit()
        {
            return _dbContext.SaveChanges();
        }
    }
}
