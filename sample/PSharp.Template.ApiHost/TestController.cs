using Microsoft.AspNetCore.Mvc;
using PSharp.Template.Systems.Domains.Models;
using PSharp.Template.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Util.Datas.Ef.Core;
using Util.Webs.Controllers;

namespace PSharp.Template.ApiHost
{
    [AllowAnonymous]
    public class TestController : WebApiControllerBase
    {
        private readonly UnitOfWorkBase _defaultUnitOfWork;

        public TestController(IDefaultUnitOfWork defaultUnitOfWork)
        {
            _defaultUnitOfWork = (UnitOfWorkBase)defaultUnitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var data = _defaultUnitOfWork.Set<Application>().ToList();
            return Success(data);
        }
    }
}
