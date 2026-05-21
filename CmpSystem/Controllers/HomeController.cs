using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CmpSystem.Models;

namespace WebApp_Exercise.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    /// <summary>
    /// 演習-02 プレーンテキストとJSONを返すアクションメソッドを実装する
    /// </summary>
    /// <returns>プレーンテキスト</returns>
    public IActionResult ViewContent()
    {
        return Content("テキスト文字列");
    }

    /// <summary>
    /// 演習-02 プレーンテキストとJSONを返すアクションメソッドを実装する
    /// </summary>
    /// <returns>JSON</returns>
    public IActionResult ViewJson()
    {
        // 匿名型で商品データを定義（IDと名前）
        var product = new { Id = 1, Name = "ノートPC" };
        // JSONシリアライズ時のオプションを設定
        var options = new JsonSerializerOptions
        {
            // 日本語などの全Unicode文字をそのまま出力（エスケープしない）
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
            // 出力サイズを小さくするため整形（インデント）は行わない
            WriteIndented = false
        };
        // オブジェクトをJSON文字列にシリアライズ
        string json = JsonSerializer.Serialize(product, options);
        // MIMEタイプ指定してJSONレスポンスを返す
        return Content(json, "application/json");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
