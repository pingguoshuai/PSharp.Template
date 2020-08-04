using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Util.Exceptions;
using Util.Files;
using Util.Files.Paths;
using Util.Helpers;

namespace PSharp.Template.Core.Files
{
    public class FileStore : DefaultFileStore, IFileStore
    {
        private readonly IPathGenerator _pathGenerator;

        public FileStore(IPathGenerator pathGenerator) : base(pathGenerator)
        {
            _pathGenerator = pathGenerator;
        }

        public async Task<string> Save(Stream s, string fileName, Func<string, bool> func = null)
        {
            var extension = Path.GetExtension(fileName)?.TrimStart('.');
            func?.Invoke(extension);

            var name = $"{Time.GetDateTime():yyyyMMddHHmmss}.{extension}";

            //var path = $"UserHead/{Time.GetDateTime():yyyyMMdd}/{name}";
            var path = _pathGenerator.Generate(name);

            var physicalPath = Common.GetWebRootPath(path);
            var directory = Path.GetDirectoryName(physicalPath);

            if (string.IsNullOrEmpty(directory))
                throw new Warning("上传失败");
            if (Directory.Exists(directory) == false)
                Directory.CreateDirectory(directory);

            if(s.CanSeek) s.Seek(0, SeekOrigin.Begin);
            await using (var stream = new FileStream(physicalPath, FileMode.Create))
            {
                await s.CopyToAsync(stream);
            }

            s.Close();

            return path;
        }

        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="s"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public async Task<string> SaveImage(Stream s, string fileName)
        {
            return await Save(s, fileName, IsImage);
        }

        /// <summary>
        /// 上传视频
        /// </summary>
        /// <param name="s"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public async Task<string> SaveVideo(Stream s, string fileName)
        {
            return await Save(s, fileName, IsVideo);
        }

        #region 文件格式

        /// <summary>
        /// 是否为图片
        /// </summary>
        /// <param name="fileExt">文件扩展名，不含“.”</param>
        /// <returns></returns>
        public bool IsImage(string fileExt)
        {
            ArrayList al = new ArrayList { "bmp", "jpeg", "jpg", "gif", "png", "ico" };
            bool result = al.Contains(fileExt.ToLower());
            if (!result) throw new Warning("文件格式不正确");
            return true;
        }

        /// <summary>
        /// 是否视频
        /// </summary>
        /// <param name="fileExt">文件扩展名，不含“.”</param>
        /// <returns></returns>
        public bool IsVideo(string fileExt)
        {
            var videos = new List<string> { "rmvb", "mkv", "ts", "wma", "avi", "rm", "mp4", "flv", "mpeg", "mov", "3gp", "mpg" };
            bool result = videos.Contains(fileExt.ToLower());
            if (!result) throw new Warning("文件格式不正确");
            return true;
        }

        #endregion
    }
}
