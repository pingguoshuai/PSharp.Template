using System.Collections;
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

        public async Task<string> Save(Stream s, string fileName)
        {
            var extension = Path.GetExtension(fileName)?.TrimStart('.');

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

        #region 文件格式

        /// <summary>
        /// 是否为图片
        /// </summary>
        /// <param name="fileExt">文件扩展名，不含“.”</param>
        /// <returns></returns>
        public bool IsImage(string fileExt)
        {
            ArrayList al = new ArrayList { "bmp", "jpeg", "jpg", "gif", "png", "ico" };
            return al.Contains(fileExt.ToLower());
        }

        #endregion
    }
}
