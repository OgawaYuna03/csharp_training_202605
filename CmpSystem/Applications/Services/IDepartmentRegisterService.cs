using CmpSystem.Applications.Domains;
namespace CmpSystem.Applications.Services;
/// <summary>
/// 従業員登録サービスインターフェイス
/// </summary>
public interface IDepartmentRegisterService 
{
    /// <summary>
    /// すべての部署を取得する
    /// </summary>
    /// <returns></returns>
    List<Department> GetDepartments();

    /// <summary>
    /// 新しい部署を登録する
    /// </summary>
    /// <param name="department"></param>
    void Register(Department department);
}