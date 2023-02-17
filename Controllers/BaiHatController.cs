using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PlayList.Models;

namespace PlayList.Controllers;
public class BaiHatController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult EnterBaiHat()
    {
        return View();
    }
    public IActionResult InsertBaiHat(BaiHat bh)
    {

        StoreContext context = new StoreContext();

        if (context.InsertBaiHat(bh))
            ViewData["thongbao"] = "Insert  thành công";
        else
            ViewData["thongbao"] = "Insert không thành công";
        return View();
    }
}