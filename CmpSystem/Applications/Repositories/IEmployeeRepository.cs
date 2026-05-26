using CmpSystem.Applications.Domains;
using CmpSystem.Infrastructures.Entities;

namespace CmpSystem.Applications.Repositories;
/// <summary>
/// ドメインオブジェクト:従業員のCRUD操作インターフェイス
/// </summary>
public interface IEmployeeRepository
{
  /// <summary>
  /// すべての従業員を取得する
  /// </summary>
  /// <returns>従業員のリスト</returns>

  List<Employee> FindAll();

  /// <summary>
  /// 従業員を永続化する
  /// </summary>
  /// <param name="employee">永続化対象の従業員</param>
  void Create(Employee employee);
  
}