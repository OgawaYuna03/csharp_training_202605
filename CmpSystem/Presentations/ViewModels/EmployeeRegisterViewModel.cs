using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using CmpSystem.Applications.Domains;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using CmpSystem.Infrastructures.Entities;
namespace CmpSystem.Presentations.ViewModels;
/// <summary>
/// 部署登録ViewModelクラス
/// </summary>
public class EmployeeRegisterViewModel
{
    /// <summary>
    /// 部署
    /// </summary>
    [Display(Name = "氏名")]
    [Required(ErrorMessage = "{0}が未入力です")]
    [StringLength(30,MinimumLength =2,ErrorMessage ="{0}は{2}文字以上{1}文字以内で入力してください")]
    public string? Name { get; set; } = string.Empty;


    /// <summary>
    /// 所属部署
    /// </summary>
    [Display(Name = "所属部署")]
    [Required(ErrorMessage = "{0}を選択してください")]
    public int? DeptId { get; set; } = 0;
    /// <summary>
    /// 入社年度
    /// </summary>
    [Display(Name = "入社年度(西暦)")]
    [Required(ErrorMessage = "{0}が未入力です")]
    [Range(1950,2030,ErrorMessage ="1950~2030で入力してください")]
    public int? JoinYear { get; set; }
    /// <summary>
    /// 入社年度
    /// </summary>
    [Display(Name = "メールアドレス")]
    [Required(ErrorMessage = "{0}が未入力です")]
    [EmailAddress(ErrorMessage ="メールアドレスの形式で入力してください")]
    public string? Email { get; set; } = string.Empty;

    /// <summary>
    /// 選択された部署名
    /// </summary>
    [Display(Name = "部署名")]
    public string? DeptName { get; set; } = string.Empty;

    /// <summary>
    /// 部署のリストをSelectListItemのリストに変換してプロパティに設定する
    /// </summary>
    /// <param name="departments"></param>
    public void SetDepartments(List<Department> departments)
    {
        // SelectListItemのリストを作成
        var selectItems = new List<SelectListItem>();
        foreach (var dept in departments)
        {
            if (dept.Id.HasValue)
            {
                var item = new SelectListItem();
                item.Value = dept.Id.Value.ToString();
                item.Text = string.IsNullOrEmpty(dept.Name) ? "(名称未設定)" : dept.Name;
                selectItems.Add(item);
            }
        }
        Departments = selectItems;
    }
    public List<SelectListItem>? Employees { get; set; } = null;

    /// <summary>
    /// 従業員のリストをSelectListItemのリストに変換してプロパティに設定する
    /// </summary>
    /// <param name="employees"></param>
    public void SetEmployees(List<EmployeeEntity> employees)
    {
        // SelectListItemのリストを作成
        var selectItems = new List<SelectListItem>();
        foreach (var emp in employees)
        {
            if (emp.EmpId.HasValue)
            {
                var item = new SelectListItem();
                item.Value = emp.EmpId.Value.ToString();
                item.Text = string.IsNullOrEmpty(emp.EmpName) ? "(名称未設定)" : emp.EmpName;
                selectItems.Add(item);
            }
        }
        Employees = selectItems;
    }

    // 部署のリスト
    public List<SelectListItem>? Departments { get; set; } = null;

    public override string ToString()
    {
        return $"Name={Name} , DeptId={DeptId} , DeptName={DeptName} , Departments={Departments}";
    }
}