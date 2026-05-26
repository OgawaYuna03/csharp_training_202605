using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using CmpSystem.Applications.Domains;
namespace CmpSystem.Presentations.ViewModels;

public class EmployeeSearchViewModel
{
    [Display(Name = "氏名")]
    public string? Name { get; set; } = string.Empty;
    [Display(Name = "従業員ID")]

    public int? Id { get; set; } = 0;
    [Display(Name = "入社年度")]

    public int? JoinYear { get; set; }
    [Display(Name = "メールアドレス")]

    public string? Email { get; set; } = string.Empty;
    [Display(Name = "部署名")]

    public string? DeptName { get; set; } 
    [Display(Name = "部署ID")]

    public int? DeptId { get; set; }
}