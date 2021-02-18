using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
using System.Data.Entity;
//using System.Data;
//using System.Threading.Tasks;

namespace Test_CompanyEmployees
{
    class SqlServerContext : DbContext
    {
        public SqlServerContext() : base("SqlServerDB")
        {
        }

        public DbSet<ModelDepartments> Departments { get; set; }
        public DbSet<ModelEmployees> Employees { get; set; }
        public DbSet<ModelDepartContent> DepartContent { get; set; }
    }
}
