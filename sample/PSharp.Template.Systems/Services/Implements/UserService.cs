using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using PSharp.Template.Core;
using PSharp.Template.Core.Extensions;
using PSharp.Template.Core.Helper;
using PSharp.Template.Core.Results;
using Util;
using Util.Domains.Repositories;
using Util.Datas.Queries;
using Util.Applications;
using PSharp.Template.UnitOfWork;
using PSharp.Template.Systems.Domains.Models;
using PSharp.Template.Systems.Domains.Repositories;
using PSharp.Template.Systems.Domains.Services.Implements;
using PSharp.Template.Systems.Services.Dtos;
using PSharp.Template.Systems.Services.Queries;
using PSharp.Template.Systems.Services.Abstractions;
using PSharp.Template.Systems.Services.Dtos.Extensions;
using PSharp.Template.Systems.Services.Dtos.Requests;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using Util.Helpers;
using Util.Maps;

namespace PSharp.Template.Systems.Services.Implements {
    /// <summary>
    /// 服务
    /// </summary>
    public class UserService : CrudServiceBase<User, UserDto, UpdateUserRequest, CreateUserRequest, UpdateUserRequest, UserQuery, Guid>, IUserService {
        /// <summary>
        /// 初始化服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="userRepository">仓储</param>
        /// <param name="roleRepository"></param>
        /// <param name="applicationRepository"></param>
        /// <param name="manager"></param>
        /// <param name="signInManager"></param>
        /// <param name="jwtHelper"></param>
        public UserService( IDefaultUnitOfWork unitOfWork, 
            IUserRepository userRepository, 
            IRoleRepository roleRepository,
            IApplicationRepository applicationRepository,
            IdentityUserManager manager, 
            SignInManager<User> signInManager, 
            JwtHelper jwtHelper)
            : base( unitOfWork, userRepository ) {
            UserRepository = userRepository;
            _roleRepository = roleRepository;
            _applicationRepository = applicationRepository;
            Manager = manager;
            SignInManager = signInManager;
            JwtHelper = jwtHelper;
        }

        public IDefaultUnitOfWork UnitOfWork { get; set; }
        /// <summary>
        /// 仓储
        /// </summary>
        public IUserRepository UserRepository { get; set; }

        private readonly IRoleRepository _roleRepository;
        private readonly IApplicationRepository _applicationRepository;
        public readonly IdentityUserManager Manager;
        public readonly SignInManager<User> SignInManager;
        public JwtHelper JwtHelper { get; set; }

        /// <summary>
        /// 创建查询对象
        /// </summary>
        /// <param name="param">查询参数</param>
        protected override IQueryBase<User> CreateQuery( UserQuery param )
        {
            var query = new Query<User>(param);
            query.WhereIfNotEmpty(t => t.UserName.Contains(param.UserName));
            query.WhereIfNotEmpty(t => t.NickName.Contains(param.NickName));
            query.WhereIfNotEmpty(t => t.Name.Contains(param.Name));
            query.WhereIfNotEmpty(t => t.PhoneNumber.Equals(param.PhoneNumber));
            return query;
        }

        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="request">创建用户参数</param>
        public override async Task<string> CreateAsync(CreateUserRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));
            var entity = ToEntityFromCreateRequest(request);
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            entity.Init();
            entity.Enabled = true;
            var result = await Manager.CreateAsync(entity,request.Password);
            result.ThrowIfError();
            entity.SetPassword(request.Password, true);
            await UnitOfWork.CommitAsync();
            return entity.Id.ToString();
        }

        public override async Task UpdateAsync(UpdateUserRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));
            request.Validate();

            var entity = ToEntityFromUpdateRequest(request);
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var oldEntity = FindOldEntity(entity.Id);
            if (oldEntity == null)
                throw new ArgumentNullException(nameof(oldEntity));

            if (request.Password.IsEmpty())
            {
                entity.Password = oldEntity.Password;
            }
            else
            {
                entity.SetPassword(request.Password, true);
            }
            await Manager.UpdateAsync(entity);
            if (!request.Password.IsEmpty())
            {
                await Manager.UpdatePasswordAsync(oldEntity, request.Password);
            }
        }

        protected override User ToEntityFromUpdateRequest(UpdateUserRequest request)
        {
            var oldEntity = FindOldEntity(request.Id.ToGuid());
            if (oldEntity == null)
            {
                return base.ToEntityFromUpdateRequest(request);
            }

            request.MapTo(oldEntity);
            oldEntity.Version = request.Version;
            return oldEntity;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="request">登录参数</param>
        public async Task<Core.Results.SignInResult> SignInAsync(LoginRequest request)
        {
            var application = await _applicationRepository.GetByCodeAsync(request.ApplicationCode);
            if (application == null)
            {
                return new Core.Results.SignInResult(SignInState.Failed, null, DefaultResource.InvalidApplication);
            }
            var user = await GetUser(request);
            if (user == null)
                return new Core.Results.SignInResult(SignInState.Failed, null, DefaultResource.InvalidAccountOrPassword);

            var signInResult = await SignInManager.PasswordSignInAsync(user, request.Password, request.Remember.SafeValue(), true);
            await UnitOfWork.CommitAsync();
            var userDto = user.ToDto();

            return GetSignInResult(userDto, signInResult, application);
        }

        /// <summary>
        /// 生成令牌
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="purpose">用途</param>
        /// <param name="application">应用程序</param>
        /// <param name="provider">令牌提供器</param>
        public async Task<string> GenerateTokenAsync(User user, string purpose, string application = "", string provider = "")
        {
            user.CheckNull(nameof(user));
            purpose = GetPurpose(purpose, application);
            if (provider.IsEmpty())
                provider = TokenOptions.DefaultPhoneProvider;
            return await Manager.GenerateUserTokenAsync(user, provider, purpose);
        }

        /// <summary>
        /// 获取用途
        /// </summary>
        private string GetPurpose(string purpose, string application)
        {
            return $"{purpose}_{application}";
        }

        /// <summary>
        /// 获取登录结果
        /// </summary>
        private Core.Results.SignInResult GetSignInResult(UserDto user,
            Microsoft.AspNetCore.Identity.SignInResult signInResult, Application application)
        {
            if (signInResult.IsNotAllowed)
                return new Core.Results.SignInResult(SignInState.Failed, null, DefaultResource.UserIsDisabled);
            if (signInResult.IsLockedOut)
                return new Core.Results.SignInResult(SignInState.Failed, null, DefaultResource.LoginFailLock);
            if (signInResult.Succeeded)
            {
                var roles = _roleRepository.GetRolesAsync(user.Id.ToGuid()).Result;
                var roleIds = roles.Select(t => t.Id).ToList();
                var roleCodes = roles.Select(t => t.Code);
                IEnumerable<Claim> claims = new[]
                {
                    new Claim(Util.Security.Claims.ClaimTypes.UserId, user.Id),
                    new Claim(JwtClaimTypes.Name, user.UserName),
                    new Claim(Util.Security.Claims.ClaimTypes.RoleIds, Util.Helpers.String.Join(roleIds)),
                    new Claim(Util.Security.Claims.ClaimTypes.RoleName, Json.ToJson(roleCodes)),
                    new Claim(Util.Security.Claims.ClaimTypes.ApplicationId, application.Id.ToString()),
                    new Claim(Util.Security.Claims.ClaimTypes.ApplicationCode, application.Code),
                    new Claim(Util.Security.Claims.ClaimTypes.ApplicationName, application.Name)
                };
                user.Token = JwtHelper.IssueJwt(claims);
                return new Core.Results.SignInResult(SignInState.Succeeded, user);
            }

            if (signInResult.RequiresTwoFactor)
                return new Core.Results.SignInResult(SignInState.TwoFactor, user);
            return new Core.Results.SignInResult(SignInState.Failed, null, DefaultResource.InvalidAccountOrPassword);
        }

        /// <summary>
        /// 获取用户
        /// </summary>
        private async Task<User> GetUser(LoginRequest request)
        {
            if (request.UserName.IsEmpty() == false)
                return await Manager.FindByNameAsync(request.UserName);
            if (request.PhoneNumber.IsEmpty() == false)
                return await UserRepository.SingleAsync(t => t.PhoneNumber == request.PhoneNumber);
            if (request.Email.IsEmpty() == false)
                return await Manager.FindByEmailAsync(request.Email);
            if (request.Account.IsEmpty())
                return null;
            var user = await Manager.FindByNameAsync(request.Account);
            if (user == null)
                user = await UserRepository.SingleAsync(t => t.PhoneNumber == request.PhoneNumber);
            if (user == null)
                user = await Manager.FindByEmailAsync(request.Account);
            return user;
        }

        /// <summary>
        /// 用户指定角色
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task AddUsersToRoleAsync(RoleUserRequest request)
        {
            await UserRepository.AddRolesToUserAsync(request.UserId, request.RoleIds.ToGuidList());
            await UnitOfWork.CommitAsync();
        }
    }
}