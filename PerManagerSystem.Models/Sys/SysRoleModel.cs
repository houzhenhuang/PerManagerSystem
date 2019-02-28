using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerManagerSystem.Models.Sys
{
    public class SysRoleModel
    {
        [Display(Name = "ID")]
        public int Id { get; set; }
        [Display(Name = "角色名")]
        public string RoleName { get; set; }
        [Display(Name = "描述")]
        public string Description { get; set; }
        [Display(Name = "是否删除")]
        public bool? IsDelete { get; set; }
        [Display(Name = "创建时间")]
        public DateTime? Created { get; set; }
        [Display(Name = "创建人")]
        public int? Creator { get; set; }
        public string CreatePerson { get; set; }
    }
}
