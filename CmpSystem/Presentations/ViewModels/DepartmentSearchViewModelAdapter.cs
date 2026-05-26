using System.Runtime;
using CmpSystem.Applications.Adapters;
using CmpSystem.Applications.Domains;
namespace CmpSystem.Presentations.ViewModels;
/// <summary>
/// DeparmentRegisterViewModel(部署登録ViewModel)を
/// ドメインオブジェクト:Departmentに変換するアダプターインターフェイスの実装
/// </summary>
/// <typeparam name="TDomain">Department</typeparam>
/// <typeparam name="TTarget">DepartmentSearchForm</typeparam>
public class DepartmentSearchViewModelAdapter : IRestorer<Department, DepartmentSearchViewModel>,IConverter<Department, DepartmentSearchViewModel>
{
    public DepartmentSearchViewModel Convert(Department domain)
    {
        var viewModel = new DepartmentSearchViewModel();
        viewModel.DeptName = domain.Name;
        viewModel.DeptId = domain.Id;

        return viewModel;

    }

    /// <summary>
    /// DepartmentRegisterViewModelをドメインオブジェクト:Departmentに変換する
    /// </summary>
    /// <param name="target">DepartmentSearchViewModel</param>
    /// <returns>ドメインオブジェクト:Department</returns>
    public Department Restore(DepartmentSearchViewModel target)
    {
       
        // 登録するDepartment(部署)を作成する
        var department = new Department(target.DeptName!);
        return department;
    }
    
}