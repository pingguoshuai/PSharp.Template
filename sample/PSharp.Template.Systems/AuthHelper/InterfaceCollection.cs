using System;
using PSharp.Template.Core.Dependency;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using PSharp.Template.Core.Enums;
using PSharp.Template.Systems.Services.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Routing;
using Enum = Util.Helpers.Enum;

namespace PSharp.Template.Systems.AuthHelper
{
    public class InterfaceCollection : IISingletonDependency
    {
        private readonly ApplicationPartManager _partManager;

        public List<InterfaceDto> Tree;
        public List<InterfaceDto> List;

        public InterfaceCollection(ApplicationPartManager partManager)
        {
            _partManager = partManager;
            GetTree();
        }

        /// <summary>
        /// 获取tree形
        /// </summary>
        /// <returns></returns>
        private void GetTree()
        {
            List = GetAllInterfaceByController();
            Tree = new Core.Results.TreeResult<InterfaceDto>(List).GetResult();
        }

        #region 获取所有控制器、action

        /// <summary>
        /// 获取控制器所有Action
        /// </summary>
        /// <returns></returns>
        private List<InterfaceDto> GetAllInterfaceByController()
        {
            List<InterfaceDto> list = new List<InterfaceDto>();

            var controllerFeature = new ControllerFeature();
            _partManager.PopulateFeature(controllerFeature);
            var controllerTypes = controllerFeature.Controllers.ToList();

            controllerTypes.ForEach(controller =>
            {
                if (controller.GetCustomAttribute(typeof(AllowAnonymousAttribute)) != null) return;

                var controllerName = controller.Name.Replace("Controller", "");
                var descAttr = (DescriptionAttribute)controller.GetCustomAttribute(typeof(DescriptionAttribute));
                var description = descAttr != null ? descAttr.Description : controllerName;

                var moduleAttr = (ApiExplorerSettingsAttribute)controller.GetCustomAttribute(typeof(ApiExplorerSettingsAttribute));
                var moduleCode = moduleAttr == null ? "api" : moduleAttr.GroupName;

                var parentId = Guid.NewGuid().ToString();
                var controllerDto = new InterfaceDto
                {
                    Id = parentId,
                    Name = description,
                    ModuleCode = moduleCode,
                    Contorller = controllerName,
                    Path = parentId + ","
                };
                list.Add(controllerDto);

                foreach (var methodInfo in controller.GetMethods(BindingFlags.Public | BindingFlags.Instance))
                {
                    var httpMethods = methodInfo.GetCustomAttributes(typeof(HttpMethodAttribute), true);
                    if (!httpMethods.Any()) continue;

                    foreach (var item in httpMethods)
                    {
                        var httpMethod = (HttpMethodAttribute)item;

                        var thisId = Guid.NewGuid().ToString();
                        var action = new InterfaceDto
                        {
                            Id = thisId,
                            ParentId = parentId,
                            ModuleCode = moduleCode,
                            Contorller = controllerName,
                            Action = methodInfo.Name,
                            Route = httpMethod.Template,
                            HttpMethod = httpMethod.HttpMethods.FirstOrDefault(),
                            Name = GetDescription(methodInfo),
                            Code =
                                $"{moduleCode}_{controllerName}_{methodInfo.Name}_{httpMethod.HttpMethods.FirstOrDefault()}",
                            Path = parentId + "," + thisId + ","
                        };

                        list.Add(action);
                    }
                }
            });

            return list;
        }

        /// <summary>
        /// 获取action名称描述
        /// </summary>
        /// <param name="methodInfo"></param>
        /// <returns></returns>
        private string GetDescription(MethodInfo methodInfo)
        {
            var result = string.Empty;
            var descAttr = (DescriptionAttribute)methodInfo.GetCustomAttribute(typeof(DescriptionAttribute));
            if (descAttr != null)
            {
                result = result + descAttr.Description;
            }
            else
            {
                result = result + Enum.GetDescription<BaseActionEnum>(methodInfo.Name);
            }
            return result;
        }

        #endregion
    }
}
