using CmpSystem.Infrastructures.Context;
using CmpSystem.Applications.Domains;
using CmpSystem.Applications.Repositories;
using CmpSystem.Infrastructures.Adapters;
using CmpSystem.Exceptions;
using CmpSystem.Infrastructures.Entities;
using Microsoft.EntityFrameworkCore;
namespace CmpSystem.Infrastructures.Repositories;
/// <summary>
/// ドメインオブジェクト:従業員のCRUD操作インターフェイスの実装
/// </summary>
public class EmployeeRepository : IEmployeeRepository
{
    /// <summary>
    /// アプリケーション用DbContext
    /// </summary>
    private readonly AppDbContext _context;
    /// <summary>
    /// ドメインモデル:従業員と従業員エンティティの相互変換インターフェイスの実装
    /// </summary>
    private readonly EmployeeEntityAdapter _adapter;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="context"></param>
    /// <param name="adapter"></param>
    public EmployeeRepository(AppDbContext context, EmployeeEntityAdapter adapter)
    {
        _context = context;
        _adapter = adapter;
    }

    /// <summary>
    /// 従業員を永続化する
    /// </summary>
    /// <param name="employee">永続化対象の従業員</param>
    public void Create(Employee employee)
    {
        try
        {
            var entity = _adapter.Convert(employee);
            _context.Employees.Add(entity);
            _context.SaveChanges();
        }
        catch (Exception e)
        {
            throw new InternalException(
                "従業員の永続化ができませんでした。", e);
        }
    }
    /// <summary>
    /// すべての従業員を取得する
    /// </summary>
    /// <returns>従業員のリスト</returns>
    public List<Employee> FindAll()
    {
        try
        {
            var employees = _context.Employees
            .Include(d =>d.Department)
            .ToList();
            var results = new List<Employee>();
            foreach (var entity in employees)
            {
                var employee = _adapter.Restore(entity);
                results.Add(employee);
            }
            return results;
        }
        catch (Exception e)
        {
            throw new InternalException(
                "すべての社員を取得できませんでした。", e);
        }
    }
    

    }
   