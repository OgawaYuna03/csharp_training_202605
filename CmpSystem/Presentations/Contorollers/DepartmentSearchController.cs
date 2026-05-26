using Microsoft.AspNetCore.Mvc;
using CmpSystem.Applications.Services;
using CmpSystem.Presentations.ViewModels;
using CmpSystem.Applications.Domains;
using Microsoft.VisualBasic;
namespace CmpSystem.Presentations.Controllers;
/// <summary>
/// 部署登録コントローラ
/// </summary>
[Route("DepartmentRegister")]
public class DepartmentSearchController : Controller
{
    /// <summary>
    /// ロガー
    /// </summary>
    private readonly ILogger<DepartmentRegisterController> _logger;
    /// <summary>
    /// 部署登録サービスインターフェイス
    /// </summary>
    private readonly IDepartmentRegisterService _departmentRegisterService;
    /// <summary>
    /// 部署登録ViewModelをDepartmentに変換するアダプター
    /// </summary>
    private readonly DepartmentSearchViewModelAdapter _adapter;
    /// <summary>
    /// TempDataを通じて一時的にViewModelを保存・復元するためのクラス
    /// </summary>
    private readonly  TempDataStore<DepartmentRegisterViewModel> _dptDataStore;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="logger">ロガー</param>
    /// <param name="departmentRegisterService">部署登録サービスインターフェイス</param>
    /// <param name="departmentRegisterViewModelAdapter">部署登録ViewModelをDepartmentに変換するアダプター</param>
    /// <param name="dptDataStore">TempDataを通じて一時的にViewModelを保存・復元するためのクラス</param>
    public DepartmentSearchController(
        ILogger<DepartmentRegisterController> logger,
        IDepartmentRegisterService departmentRegisterService,
        DepartmentSearchViewModelAdapter departmentSearchViewModelAdapter,
        TempDataStore<DepartmentRegisterViewModel> dptDataStore)
    {
        _logger = logger;
        _departmentRegisterService = departmentRegisterService;
        _adapter = departmentSearchViewModelAdapter;
        _dptDataStore = dptDataStore;
    }

    /// <summary>
    /// 部署登録(入力)画面表示 アクションメソッド
    /// </summary>
    /// <returns></returns>
    [HttpGet("Search")]
    public IActionResult Search()
    {
        DepartmentRegisterViewModel? viewModel = null;
        var departments = _departmentRegisterService.GetDepartments();
        //List<Department>からList<DepartmentSearchViewModel>に変換//

        //List<DepartmentSearchViewModel>を用意(new)
        List<DepartmentSearchViewModel> searchViewModels = new();
        //departmentsの繰り返し処理
        foreach(Department? department in departments)
        {
           var temp = _adapter.Convert(department);
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
    public IActionResult Back(DepartmentRegisterViewModel viewModel)
    {
        _logger.LogInformation("[戻る]ボタンクリック:{0}", viewModel!.ToString());
        // DepartmentRegisterViewModelをシリアライズして、TempDataに保存する
        _dptDataStore.Save(this, viewModel);
        // 入力画面を出力するアクションメソッドにリダイレクトする
        return RedirectToAction("Enter");
    }

    /// <summary>
    /// 部署一覧を取得してViewModelに設定する(SelectListItem形式)
    /// </summary>
    private void PopulateDepartments(DepartmentRegisterViewModel viewModel)
    {
        // 部署登録サービスから部署一覧を取得する
        var departments = _departmentRegisterService.GetDepartments();
        // 部署一覧をEmployeeRegisterViewModelに登録する
        viewModel.SetDepartments(departments);
        _logger.LogInformation("部署リストを設定");
    }
}