using System;
using System.Collections.Generic;
using System.Text;
using Util.Applications.Dtos;

namespace PSharp.Template.Systems.Services.Dtos.Requests
{
    public class RoleUserRequest : RequestBase
    {
        /// <summary>
        /// 用户标识
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// 角色标识列表
        /// </summary>
        public string RoleIds { get; set; }
    }
}
