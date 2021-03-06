﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace PSharp.Template.Core.Files
{
    public interface IFileStore : Util.Files.IFileStore
    {
        Task<string> Save(Stream s, string fileName, Func<string, bool> func = null);
        Task<string> SaveImage(Stream s, string fileName);
        Task<string> SaveVideo(Stream s, string fileName);

        /// <summary>
        /// 是否为图片
        /// </summary>
        /// <param name="fileExt">文件扩展名，不含“.”</param>
        /// <returns></returns>
        bool IsImage(string fileExt);

        /// <summary>
        /// 是否为视频
        /// </summary>
        /// <param name="fileExt">文件扩展名，不含“.”</param>
        /// <returns></returns>
        bool IsVideo(string fileExt);
    }
}
