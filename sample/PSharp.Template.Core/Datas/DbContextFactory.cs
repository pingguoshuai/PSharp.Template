using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PSharp.Template.UnitOfWork;
using PSharp.Template.UnitOfWork.MySql;
using Util.Datas.Ef.Core;
using Util.Datas.UnitOfWorks;

namespace PSharp.Template.Core.Datas
{
    public class DbContextFactory
    {
        public string MasterConnectionString;
        public string SlaveConnectionString;

        public DbContextFactory()
        {

        }

        public IUnitOfWork CreateReadDbContext()
        {
            IDefaultUnitOfWork unitOfWork = new DefaultUnitOfWork(new DbContextOptions<DefaultUnitOfWork>());
            return unitOfWork;
        }
    }
}
