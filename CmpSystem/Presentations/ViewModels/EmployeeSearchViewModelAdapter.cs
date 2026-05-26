using CmpSystem.Applications.Adapters;
using CmpSystem.Applications.Domains;
namespace CmpSystem.Presentations.ViewModels;
/// <summary>
/// EmployeeRegisterViewModel(従業員登録ViewModel)を
/// ドメインオブジェクト:Employeeに変換するアダプターインターフェイスの実装
/// </summary>
/// <typeparam name="TDomain">Employee</typeparam>
/// <typeparam name="TTarget">EmployeeRegisterForm</typeparam>
public class EmployeeSearchViewModelAdapter : IRestorer<Employee, EmployeeSearchViewModel>
{

    public EmployeeSearchViewModel Convert(Employee domain)
    {
        var viewModel = new EmployeeSearchViewModel();
        viewModel.Name = domain.Name;
        viewModel.Id = domain.Id;
        viewModel.DeptName = domain.Department.Name;
        viewModel.JoinYear = domain.JoinYear;
        viewModel.Email = domain.Email;



        return viewModel;

    }
    /// <summary>
    /// EmployeeRegisterViewModelをドメインオブジェクト:Employeeに変換する
    /// </summary>
    /// <param name="target">EmployeeRegisterViewModel</param>
    /// <returns>ドメインオブジェクト:Employee</returns>
    public Employee Restore(EmployeeSearchViewModel target)
    {
        // Department(部署)を作成する
        var department = new Department(target.DeptId!.Value, target.DeptName);
        // 登録するEmployee(従業員)を作成する
        var employee = new Employee(target.Name!, department, target.JoinYear, target.Email);
        return employee;
    }
}