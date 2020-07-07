using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PSharp.Template.Common.Domains.Models;
using Util.Domains.Services;

namespace PSharp.Template.Common.Domains.Services.Abstractions
{
    public interface IDicInfoManager : IDomainService
    {
        /// <summary>
        /// 通过编号获取
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<DicInfo> GetById(Guid? key);
        Task<DicInfo> GetByCodeAndValue(string typecode, string value);
        Task<List<DicInfo>> GetListByTypeCode(string typeCode);
    }
}
