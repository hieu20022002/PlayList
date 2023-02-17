using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PlayList.Models;

namespace PlayList.Controllers;
public class CaSiController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult ListCaSi(DateTime ns)
    {
        StoreContext context = new StoreContext();

        if (ns != new DateTime())
        {
            if (context.GetCaSis(ns).Count() == 0)
            {
                ViewData["thongbao"] = "Không có ca sĩ nào";

            }
            else
            {
                return View(context.GetCaSis(ns));
            }
        }

        return View();
    }
}