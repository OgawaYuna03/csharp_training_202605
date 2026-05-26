using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using CmpSystem.Applications.Domains;
namespace CmpSystem.Presentations.ViewModels;

/// <summary>
/// 部署登録ViewModelクラス
/// </summary>
public class DepartmentSearchViewModel
{
    [Display(Name = "部署名")]
    public string? DeptName { get; set; } = string.Empty;
    [Display(Name = "部署ID")]
    public int? DeptId { get; set; } = 0;

}
