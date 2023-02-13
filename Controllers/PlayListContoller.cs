using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PlayList.Models;

namespace PlayList.Controllers;
public class PlayListsController : Controller{
    public IActionResult Index()
    {
        return View();
    }
    public PartialViewResult EnterNN(){
        StoreContext context = new StoreContext();
        return PartialView(context.GetNNs());
    }
    public IActionResult ListPLayList(String MaNN){
        if(MaNN!=null){
            StoreContext context = new StoreContext();
            ViewData["ListNN"]=context.GetNNs();
            if(context.GetPlayList(MaNN).Count()==0){
                ViewData["thongbao"] = "Không có PlayList";
                
            }
            else{

                return View(context.GetPlayList(MaNN));
            }
        }
        return View();
    }
    public IActionResult DeletePlayList(string id){
        StoreContext context = new StoreContext();
        if(context.DeletePlayList(id)){
            ViewData["thongbao"] = "Delete  thành công";
        }
        else{
             ViewData["thongbao"] = "Delete  không thành công";
        }
        return View();
    }
    public IActionResult ViewPlayList(string MaPL){
        StoreContext context = new StoreContext();
        
        return View(context.ViewPlayList(MaPL));

    }
}