using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using PSharp.Template.Core.Datas;
using Util.Datas.Ef.SqlServer;
using Util.Datas.Sql;
using Util.Domains;
using Util.Helpers;
using Util.Reflections;

namespace PSharp.Template.UnitOfWork.SqlServer {
    /// <summary>
    /// 工作单元
    /// </summary>
    public class DefaultUnitOfWork : Util.Datas.Ef.SqlServer.UnitOfWork,IDefaultUnitOfWork {
        /// <summary>
        /// 初始化工作单元
        /// </summary>
        /// <param name="options">配置项</param>
        /// <param name="dbContextFactory"></param>
        public DefaultUnitOfWork( DbContextOptions<DefaultUnitOfWork> options, DbContextFactory dbContextFactory) : base( options )
        {
            dbContextFactory.SetConnectionString(this);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var finder = new Finder();
            var referencedAssemblies = finder.GetAssemblies();

            #region Data Annotation配置映射

            var types = finder.Find<IEntity>(referencedAssemblies);
            types.ForEach(t =>
            {
                if (modelBuilder.Model.FindEntityType(t) == null)
                    modelBuilder.Model.AddEntityType(t);


                #region 映射表注释、说明

                var entityType = modelBuilder.Model.FindEntityType(t);
                var descAttr = t.GetCustomAttribute<DescriptionAttribute>();
                entityType.SetComment(descAttr?.Description);//表注释、说明

                var properties = t.GetTypeInfo().GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (var p in properties)
                {
                    if (p.GetCustomAttribute<NotMappedAttribute>() != null || p.GetCustomAttribute<IgnoreAttribute>() != null)
                    {
                        entityType.AddIgnored(p.Name);
                        continue;
                    }

                    var comment = p.GetCustomAttribute<DisplayNameAttribute>();

                    var hasProperty = entityType.FindProperty(p);
                    hasProperty?.SetComment(comment?.DisplayName);
                }

                #endregion
            });

            #endregion

            #region Fluent API配置映射

            ConcurrentDictionary<Type, IEnumerable<IMap>> maps = new ConcurrentDictionary<Type, IEnumerable<IMap>>();

            //获取映射实例列表
            IEnumerable<IMap> imaps = Reflection.GetInstancesByInterface<IMap>(referencedAssemblies.ToArray());
            List<IMap> result = new List<IMap>();
            result.AddRange(imaps);

            var map = maps.GetOrAdd(GetType(), result);

            //配置映射
            foreach (IMap mapper in map)
                mapper.Map(modelBuilder);
            #endregion
        }
    }
}