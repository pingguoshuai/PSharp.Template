using System;
using PSharp.Template.Systems.Domains.Models;
using PSharp.Template.UnitOfWork;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using Util.Datas.Ef.Core;
using Util.Dependency;
using Util.Helpers;
using Util.Logs;

namespace PSharp.Template.ApiHost
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            DbSeed(host);
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new ServiceProviderFactory())
                .ConfigureServices(services => services.AddHttpContextAccessor())
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static void DbSeed(IHost host)
        {
            var log = Ioc.Create<ILog>();
            try
            {
                var context = Ioc.Create<IDefaultUnitOfWork>() as UnitOfWorkBase;
                if (context == null) return;
                context.Database.EnsureCreated();

                #region 初始数据

                if (!context.Set<Application>().Any())
                {
                    var applications = new[]
                    {
                    new Application(new Guid("9b5ab867-7f0d-4f41-9462-4af2281bf514"))
                    {
                        Code = "admin",
                        Name = "管理后台",
                        Enabled = true,
                        RegisterEnabled = false,
                    }
                };

                    foreach (Application s in applications)
                    {
                        context.Set<Application>().Add(s);
                    }
                    context.SaveChanges();
                }

                if (!context.Set<Role>().Any())
                {
                    var roles = new[]
                    {
                    new Role(new Guid("121f0ffd-cf17-419c-95dd-9be5fe769c3c"),"121f0ffd-cf17-419c-95dd-9be5fe769c3c,",1)
                    {
                        Enabled = true,
                        SortId = 1,
                        Code = "admin",
                        Name = "超级管理员",
                        NormalizedName = "超级管理员",
                        Type = "admin",
                        IsAdmin = true,
                        PinYin = "cjgly"
                    }
                };

                    foreach (Role s in roles)
                    {
                        context.Set<Role>().Add(s);
                    }
                    context.SaveChanges();
                }

                if (!context.Set<User>().Any())
                {
                    var users = new[]
                    {
                    new User(new Guid("190caf2d-17b3-4a4d-9364-2225404a8528"))
                    {
                        UserName = "admin",
                        NormalizedUserName = "ADMIN",
                        NickName = "",
                        Name = "",
                        Email = "user@example.com",
                        NormalizedEmail = "USER@EXAMPLE.COM",
                        EmailConfirmed = true,
                        PhoneNumber = "15111111111",
                        PhoneNumberConfirmed = true,
                        PasswordHash =
                            "AQAAAAEAACcQAAAAEEfFx3g/pwgCKtj1adE4hT3+i55XUULHZ8Ip5EXownMc0FbBXdFlEvSn0qo34A/8MA==",
                        LockoutEnabled = true,
                        AccessFailedCount = 0,
                        TwoFactorEnabled = false,
                        Enabled = true,
                        SecurityStamp = "WGN5X44MARGXGTWOYJSRX4LGVJJE3VMZ"
                    }
                };

                    foreach (User user in users)
                    {
                        context.Set<User>().Add(user);
                    }
                    context.SaveChanges();
                }

                if (!context.Set<UserRole>().Any())
                {
                    var userRoles = new[]
                    {
                    new UserRole(new Guid("190caf2d-17b3-4a4d-9364-2225404a8528"), new Guid("121f0ffd-cf17-419c-95dd-9be5fe769c3c"))
                };

                    foreach (var userRole in userRoles)
                    {
                        context.Set<UserRole>().Add(userRole);
                    }
                    context.SaveChanges();
                }

                #endregion
            }
            catch (Exception e)
            {
                log.Error($"Error occured seeding the Database.\n{e.Message}");
                throw;
            }
        }
    }
}
