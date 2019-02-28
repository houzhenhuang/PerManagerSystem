using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerManagerSystem.Models.Sys
{
    public class SysOperationModel
    {
        [Display(Name = "ID")]
        public int Id { get; set; }
        [Display(Name = "操作名称")]
        public string OperationName { get; set; }
        [Display(Name = "标识码")]
        public string Code { get; set; }
        [Display(Name = "图标")]
        public string Icon { get; set; }
        [Display(Name = "排序")]
        public int? Sort { get; set; }
        [Display(Name = "描述")]
        public string Description { get; set; }
        [Display(Name = "是否删除")]
        public bool? IsDelete { get; set; }
        [Display(Name = "创建时间")]
        public DateTime? Created { get; set; }
        [Display(Name = "创建人")]
        public int? Creator { get; set; }
    }
}
