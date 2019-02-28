using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerManagerSystem.Models.Sys
{
    public class SysUserModel
    {
        [Display(Name = "ID")]
        
        public int Id { get; set; }
        [Display(Name = "用户名")]
        [Required(ErrorMessage = "用户名不能为空")]
        public string UserName { get; set; }
        [Display(Name = "密码")]
        [Required(ErrorMessage = "密码不能为空")]
        public string Password { get; set; }
        [Required(ErrorMessage = "真实姓名不能为空")]
        [Display(Name = "真实姓名")]
        public string TrueName { get; set; }
        [Display(Name = "性别")]
        public string Sex { get; set; }
        [Display(Name = "手机号码")]
        public string Phone { get; set; }
        [Display(Name = "电话号码")]
        public string Telephone { get; set; }
        [Display(Name = "邮箱")]
        public string EmailAddress { get; set; }
        [Display(Name = "QQ号码")]
        public string QQ { get; set; }
        [Display(Name = "其它联系方式")]
        public string OtherContact { get; set; }
        [Display(Name = "省份")]
        public string Province { get; set; }
        [Display(Name = "城市")]
        public string City { get; set; }
        [Display(Name = "街道")]
        public string Street { get; set; }
        [Display(Name = "地址")]
        public string Address { get; set; }
        [Display(Name = "是否在职")]
        public bool? State { get; set; }
        [Display(Name = "出生日期")]
        public DateTime? Birthday { get; set; }
        [Display(Name = "婚姻状况")]
        public string Marital { get; set; }
        [Display(Name = "政治面貌")]
        public string Political { get; set; }
        [Display(Name = "国籍")]
        public string Nationality { get; set; }
        [Display(Name = "毕业学校")]
        public string School { get; set; }
        [Display(Name = "所学专业")]
        public string Professional { get; set; }
        [Display(Name = "文化程度")]
        public string Degree { get; set; }
        [Required(ErrorMessage = "部门ID不能为空")]
        [Display(Name = "部门Id")]
        public int DepartmentId { get; set; }
        [Display(Name = "职位")]
        [Required(ErrorMessage = "职位不能为空")]
        public int PostId { get; set; }
        [Display(Name = "就业情况")]
        public string JobState { get; set; }
        [Display(Name = "照片")]
        public string Photo { get; set; }
        [Display(Name = "附件")]
        public string Attach { get; set; }
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
