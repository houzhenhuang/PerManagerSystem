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
    
    public partial class SysException
    {
        public int Id { get; set; }
        public Nullable<int> UserId { get; set; }
        public string HelpLink { get; set; }
        public string Message { get; set; }
        public string Source { get; set; }
        public string StackTrace { get; set; }
        public string TargetSite { get; set; }
        public string Data { get; set; }
        public Nullable<System.DateTime> OperateTime { get; set; }
    
        public virtual SysUser SysUser { get; set; }
    }
}
