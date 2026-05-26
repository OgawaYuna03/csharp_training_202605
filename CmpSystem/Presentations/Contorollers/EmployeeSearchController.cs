using Microsoft.AspNetCore.Mvc;
using CmpSystem.Applications.Services;
using CmpSystem.Presentations.ViewModels;
using CmpSystem.Applications.Domains;
using Microsoft.VisualBasic;
using CmpSystem.Infrastructures.Entities;
namespace CmpSystem.Presentations.Controllers;
/// <summary>
/// 部署登録コントローラ
/// </summary>
[Route("EmployeeRegister")]
public class EmployeeSearchController : Controller
{
    /// <summary>
    /// ロガー
    /// </summary>
    private readonly ILogger<EmployeeRegisterController> _logger;
    /// <summary>
    /// 部署登録サービスインターフェイス
    /// </summary>
    private readonly IEmployeeRegisterService _employeeRegisterService;
    /// <summary>
    /// 部署登録ViewModelをDepartmentに変換するアダプター
    /// </summary>
    private readonly EmployeeSearchViewModelAdapter _adapter;
    /// <summary>
    /// TempDataを通じて一時的にViewModelを保存・復元するためのクラス
    /// </summary>
    private readonly TempDataStore<EmployeeRegisterViewModel> _empDataStore;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="logger">ロガー</param>
    /// <param name="employeeRegisterService">部署登録サービスインターフェイス</param>
    /// <param name="employeeRegisterViewModelAdapter">部署登録ViewModelをDepartmentに変換するアダプター</param>
    /// <param name="empDataStore">TempDataを通じて一時的にViewModelを保存・復元するためのクラス</param>
    public EmployeeSearchController(
        ILogger<EmployeeRegisterController> logger,
        IEmployeeRegisterService employeeRegisterService,
        EmployeeSearchViewModelAdapter employeeSearchViewModelAdapter,
        TempDataStore<EmployeeRegisterViewModel> empDataStore)
    {
        _logger = logger;
        _employeeRegisterService = employeeRegisterService;
        _adapter = employeeSearchViewModelAdapter;
        _empDataStore = empDataStore;
    }

    /// <summary>
    /// 部署登録(入力)画面表示 アクションメソッド
    /// </summary>
    /// <returns></returns>
    [HttpGet("Search")]
    public IActionResult Search()
    {
        EmployeeRegisterViewModel? viewModel = null;
        var employees = _employeeRegisterService.GetEmployees();
        //List<Employee>からList<EmployeeSearchViewModel>に変換//

        //List<EmployeeSearchViewModel>を用意(new)
        List<EmployeeSearchViewModel> searchViewModels = new();
        //employeesの繰り返し処理
        foreach (Employee? employee in employees)
        {
            var temp = _adapter.Convert(employee);
            searchViewModels.Add(temp);
        }

        ///     departmentsから要素を取り出し、Converする

        ///     Convertされて出来たviewModelを/List<DepartmentSearchViewModel>に追加（Add)
        return View(searchViewModels);


    }


    /// <summary>
    /// 確認画面の[戻る]ボタンクリックアクションメソッド
    /// </summary>
    /// <returns></returns> 
    [HttpPost("Back")]
    public IActionResult Back(EmployeeRegisterViewModel viewModel)
    {
        _logger.LogInformation("[戻る]ボタンクリック:{0}", viewModel!.ToString());
        // DepartmentRegisterViewModelをシリアライズして、TempDataに保存する
        _empDataStore.Save(this, viewModel);
        // 入力画面を出力するアクションメソッドにリダイレクトする
        return RedirectToAction("Enter");
    }

    /// <summary>
    /// 部署一覧を取得してViewModelに設定する(SelectListItem形式)
    /// </summary>
    ///private void PopulateEmployees(EmployeeRegisterViewModel viewModel)
    ///{
    // 部署登録サービスから部署一覧を取得する
    /// var employees = _employeeRegisterService.GetEmployees();
    // 部署一覧をEmployeeRegisterViewModelに登録する
    /// viewModel.SetEmployees(employees);
    ///_logger.LogInformation("従業員リストを設定");
    ///}
}