using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using PSharp.Template.Common.Domains.Models;
using PSharp.Template.Common.Domains.Repositories;
using PSharp.Template.Common.Domains.Services.Abstractions;
using Microsoft.EntityFrameworkCore;
using Util;
using Util.Datas.Queries;
using Util.Domains.Services;

namespace PSharp.Template.Common.Domains.Services.Implements
{
    public class AreaManager : DomainServiceBase, IAreaManager
    {
        private readonly IAreaRepository _areaRepository;

        public AreaManager(IAreaRepository areaRepository)
        {
            _areaRepository = areaRepository;
        }

        public async Task<List<Area>> GetListByPid(int parentId)
        {
            var query = new Query<Area>();
            query.Where(t => t.ParentId.Equals(parentId));
            query.OrderBy(t => t.SortId);
            query.OrderBy(t => t.CreationTime);
            var list = await _areaRepository.Find().Where(query).OrderBy(query.GetOrder()).ToListAsync();
            return list;
        }
    }
}
