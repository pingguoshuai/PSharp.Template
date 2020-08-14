﻿using Microsoft.EntityFrameworkCore;
using Util.Datas.UnitOfWorks;

namespace PSharp.Template.Data.UnitOfWorks.PgSql {
    /// <summary>
    /// 工作单元
    /// </summary>
    public class DefaultUnitOfWork : Util.Datas.Ef.PgSql.UnitOfWork,IDefaultUnitOfWork {
        /// <summary>
        /// 初始化工作单元
        /// </summary>
        /// <param name="options">配置项</param>
        public DefaultUnitOfWork( DbContextOptions<DefaultUnitOfWork> options ) : base( options ) {
        }
    }
}