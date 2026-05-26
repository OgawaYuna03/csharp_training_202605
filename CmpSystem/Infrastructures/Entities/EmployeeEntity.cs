using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CmpSystem.Infrastructures.Entities;
/// <summary>
/// 従業員テーブル(employee)を扱うEntity Framework Coreのエンティティクラス
/// </summary>
[Table("employee")]
public class EmployeeEntity
{
    /// <summary>
    /// 従業員Id(主キー)
    /// </summary>
    [Key]
    [Column("id")]
    public int? EmpId { get; set; }
    [Column("name")]
    /// <summary>
    /// 従業員名
    /// </summary>
    public string EmpName { get; set; } = string.Empty;
    /// <summary>
    /// 所属部署Id(外部キー)
    /// </summary>
    [Column("dept_id")]
    public int? DeptId { get; set; }
     /// <summary>
    /// 入社年度
    /// </summary>
    [Column("join_of_year")]
    public int? JoinYear { get; set; }
     /// <summary>
    /// メールアドレス
    /// </summary>
    [Column("email")]
    public string? Email { get; set; }
    [ForeignKey("DeptId")]
    public DepartmentEntity? Department { get; set; }

    public override string? ToString()
    {
        return $"従業員Id:{EmpId},従業員名:{EmpName},部署Id{DeptId},入社年度:{JoinYear},メールアドレス:{Email}";
    }
}