//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace PerManagerSystem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SysUser
    {
        public SysUser()
        {
            this.SysException = new HashSet<SysException>();
            this.SysLoginLog = new HashSet<SysLoginLog>();
            this.SysUserOperateLog = new HashSet<SysUserOperateLog>();
            this.SysUserRole = new HashSet<SysUserRole>();
        }
    
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string TrueName { get; set; }
        public string Sex { get; set; }
        public string Phone { get; set; }
        public string Telephone { get; set; }
        public string EmailAddress { get; set; }
        public string QQ { get; set; }
        public string OtherContact { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Address { get; set; }
        public Nullable<bool> State { get; set; }
        public Nullable<System.DateTime> Birthday { get; set; }
        public string Marital { get; set; }
        public string Political { get; set; }
        public string Nationality { get; set; }
        public string School { get; set; }
        public string Professional { get; set; }
        public string Degree { get; set; }
        public int DepartmentId { get; set; }
        public int PostId { get; set; }
        public string JobState { get; set; }
        public string Photo { get; set; }
        public string Attach { get; set; }
        public string Description { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public Nullable<System.DateTime> Created { get; set; }
        public Nullable<int> Creator { get; set; }
    
        public virtual ICollection<SysException> SysException { get; set; }
        public virtual ICollection<SysLoginLog> SysLoginLog { get; set; }
        public virtual ICollection<SysUserOperateLog> SysUserOperateLog { get; set; }
        public virtual ICollection<SysUserRole> SysUserRole { get; set; }
    }
}
