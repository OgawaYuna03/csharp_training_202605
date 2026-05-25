using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CmpSystem.Infrastructures.Entities;
/// <summary>
/// 部署テーブル(department)を扱うEntity Framework Coreのエンティティクラス
/// </summary>
[Table("department")]
public class DepartmentEntity
{
    /// <summary>
    /// 部署Id(主キー)
    /// </summary> 
    [Key]
    [Column("dept_id")]
    public int DeptId { get; set; }
    /// <summary>
    /// 部署名
    /// </summary> 
    [Column("dept_name")]
    public string DeptName { get; set; } = string.Empty;
    /// <summary>
    /// 部長名
    /// </summary> 
    [Column("chief")]
    public string? Chief { get; set; }
}