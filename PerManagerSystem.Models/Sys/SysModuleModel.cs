using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerManagerSystem.Models.Sys
{
    public class SysModuleModel
    {
        [Display(Name = "ID")]
        public int Id { get; set; }
        [Display(Name = "名称")]
        public string ModuleName { get; set; }
        [Display(Name = "父级ID")]
        public int ParentId { get; set; }
        [Display(Name = "标识")]
        public string Code { get; set; }
        [Display(Name = "地址")]
        public string Url { get; set; }
        [Display(Name = "图标")]
        public string Icon { get; set; }
        [Display(Name = "排序")]
        public int? Sort { get; set; }
        [Display(Name = "是否启用")]
        public bool Enable { get; set; }
        [Display(Name = "描述")]
        public string Description { get; set; }
        [Display(Name = "是否删除")]
        public bool? IsDelete { get; set; }
        [Display(Name = "创建时间")]
        public DateTime? Created { get; set; }
        [Display(Name = "创建人")]
        public int? Creator { get; set; }
        public string CreatePerson { get; set; }
        public string state { get; set; }//treegrid
        public string iconCls { get; set; }
    }
}
