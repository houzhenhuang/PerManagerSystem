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
    
    public partial class SysOperations
    {
        public SysOperations()
        {
            this.SysModuleOperations = new HashSet<SysModuleOperations>();
            this.SysRoleModuleOperations = new HashSet<SysRoleModuleOperations>();
        }
    
        public int Id { get; set; }
        public string OperationName { get; set; }
        public string Code { get; set; }
        public string Icon { get; set; }
        public Nullable<int> Sort { get; set; }
        public string Description { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public Nullable<System.DateTime> Created { get; set; }
        public Nullable<int> Creator { get; set; }
    
        public virtual ICollection<SysModuleOperations> SysModuleOperations { get; set; }
        public virtual ICollection<SysRoleModuleOperations> SysRoleModuleOperations { get; set; }
    }
}
