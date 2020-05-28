using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Faker.Solution.Authorization.Roles;
using Faker.Solution.Authorization.Users;
using Faker.Solution.MultiTenancy;

namespace Faker.Solution.EntityFrameworkCore
{
    public class SolutionDbContext : AbpZeroDbContext<Tenant, Role, User, SolutionDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public SolutionDbContext(DbContextOptions<SolutionDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 代码生成器生成的表配置类添加到SetUserTablePrefix方法中
            this.SetUserTablePrefix(modelBuilder);
            // 设置内置表前缀
            modelBuilder.ChangeAbpTablePrefix<Tenant, Role, User>(SolutionConsts.TABLE_PREFIX);
            // 调用基类方法
            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        ///  配置用户表
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected void SetUserTablePrefix(ModelBuilder modelBuilder)
        {
            // 代码生成器生成的表实体配置全部添加到这里
        }
    }
}
