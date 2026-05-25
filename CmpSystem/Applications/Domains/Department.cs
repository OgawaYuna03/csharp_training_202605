using CmpSystem.Exceptions;
namespace CmpSystem.Applications.Domains;
/// <summary>
/// 所属部署を表すドメインオブジェクト
/// </summary>
public class Department
{
    public int? Id { get; private set; }      // 部署Id
    public string? Name { get; private set; } = string.Empty;    // 部署名
    private const int MaxLength = 20; // 部署名の長さ
    public string? Chief { get; private set; } //部長名
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="id">部署Id</param>
    /// <param name="name">部署名</param>
    /// <param name="chief">部長名</param>
    public Department(int? id, string? name, string? chief)
    {
        // 部署名のルール検証
        validateDepartmentName(name);
        Id = id;
        Name = name;
        Chief = chief;
    }
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="name">部署名</param>
    public Department(string? name) : this(null, name, null) { }
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="id">部署Id</param>
    ///  /// <param name="chief">部長名</param>
    /// <returns></returns>
    public Department(int? id,string? chief)
    {
        Id = id;
        Chief = chief;
    }

    /// <summary>
    /// 部署名のルール検証
    /// </summary>
    /// <param name="name"></param>
    private void validateDepartmentName(string? name)
    {
        if (name is not null)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException("部署名は必須です");
            if (name.Length > MaxLength)
                throw new DomainException($"部署名は{MaxLength}文字以内で入力してください");
        }
    }

    /// <summary>
    /// 部署名の変更
    /// </summary>
    /// <param name="name"></param>
    public void ChangeName(string? name)
    {
        // 部署名のルール検証
        validateDepartmentName(name);
        this.Name = name;
    }

    /// <summary>
    /// 等価性の検証
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj)) return true;
        if (obj is not Department other) return false;
        return Id == other.Id;
    }
    public override int GetHashCode() => Id?.GetHashCode() ?? 0;

    public override string ToString() => $"{Id?.ToString() ?? "未登録"}: {Name}";
}