using System;
using System.IO;
using System.Threading.Tasks;
using Util;
using Util.Maps;
using Util.Domains.Repositories;
using Util.Datas.Queries;
using Util.Applications;
using PSharp.Template.UnitOfWork;
using PSharp.Template.Common.Domains.Models;
using PSharp.Template.Common.Domains.Repositories;
using PSharp.Template.Common.Services.Dtos;
using PSharp.Template.Common.Services.Queries;
using PSharp.Template.Common.Services.Abstractions;
using PSharp.Template.Common.Services.Dtos.Requests;
using PSharp.Template.Core.Files;
using PSharp.Template.Core.Helper;

namespace PSharp.Template.Common.Services.Implements
{
    /// <summary>
    /// 服务
    /// </summary>
    public class SysFileService : CrudServiceBase<SysFile, SysFileDto, CreateSysFileRequest, SysFileQuery, Guid>, ISysFileService
    {
        /// <summary>
        /// 初始化服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="sysFileRepository">仓储</param>
        /// <param name="fileStore"></param>
        public SysFileService(IDefaultUnitOfWork unitOfWork, ISysFileRepository sysFileRepository, IFileStore fileStore)
            : base(unitOfWork, sysFileRepository)
        {
            UnitOfWork = unitOfWork;
            SysFileRepository = sysFileRepository;
            FileStore = fileStore;
        }

        public IDefaultUnitOfWork UnitOfWork { get; }

        /// <summary>
        /// 仓储
        /// </summary>
        public ISysFileRepository SysFileRepository { get; set; }

        public IFileStore FileStore { get; }

        /// <summary>
        /// 创建查询对象
        /// </summary>
        /// <param name="param">查询参数</param>
        protected override IQueryBase<SysFile> CreateQuery(SysFileQuery param)
        {
            var query = new Query<SysFile>(param);
            if (!string.IsNullOrEmpty(param.OldName))
            {
                query.Where(t => t.OldName.Contains(param.OldName));
            }
            if (!string.IsNullOrEmpty(param.NewName))
            {
                query.Where(t => t.NewName.Contains(param.NewName));
            }
            if (!string.IsNullOrEmpty(param.Extension))
            {
                query.Where(t => t.Extension.Contains(param.Extension));
            }
            if (!string.IsNullOrEmpty(param.Src))
            {
                query.Where(t => t.Src.Equals(param.Src));
            }
            if (!string.IsNullOrEmpty(param.Md5))
            {
                query.Where(t => t.Md5.Equals(param.Md5));
            }
            query.OrderBy(t => t.CreationTime, true);
            return query;
        }

        protected override SysFile ToEntityFromUpdateRequest(CreateSysFileRequest request)
        {
            var oldEntity = FindOldEntity(request.Id.ToGuid());
            if (oldEntity == null)
            {
                return base.ToEntityFromUpdateRequest(request);
            }

            request.MapTo(oldEntity);
            return oldEntity;
        }

        /// <summary>
        /// 根据md5查询文件
        /// </summary>
        /// <param name="md5"></param>
        /// <returns></returns>
        public async Task<SysFileDto> GetByMd5Async(string md5)
        {
            md5.CheckNull(nameof(md5));
            SysFile entity = await SysFileRepository.SingleAsync(t => t.Md5.Equals(md5));
            return entity?.MapTo<SysFileDto>();
        }

        /// <summary>
        /// 文件上传
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="oldName"></param>
        /// <returns></returns>
        public async Task<SysFileDto> UploadByStream(Stream stream, string oldName)
        {
            stream.CheckNull(nameof(stream));
            int length = (int)stream.Length;
            var b = await Util.Helpers.File.ToBytesAsync(stream);
            var fileMd5 = Encrypt.Md5By32(b);

            var entityDto = await GetByMd5Async(fileMd5);
            if (entityDto != null) return entityDto;

            var path = await FileStore.Save(stream, oldName);

            //var path = func.Invoke();

            var newName = path.Substring(path.LastIndexOf('/') + 1, path.Length - path.LastIndexOf('/') - 1);

            var request = new CreateSysFileRequest
            {
                OldName = string.IsNullOrEmpty(oldName) ? newName : oldName,
                NewName = path.Substring(path.LastIndexOf('/') + 1, path.Length - path.LastIndexOf('/') - 1),
                Size = length,
                //Type = file.ContentType,
                Md5 = fileMd5,
                Extension = Path.GetExtension(path)?.TrimStart('.'),
                Src = path
            };
            var id = await CreateAsync(request);
            var result = await GetByIdAsync(id);
            await UnitOfWork.CommitAsync();

            return result;
        }
    }
}