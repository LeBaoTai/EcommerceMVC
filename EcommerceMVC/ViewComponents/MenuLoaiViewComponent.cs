using EcommerceMVC.Data;
using EcommerceMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceMVC.ViewComponents
{
    public class MenuLoaiViewComponent : ViewComponent
    {
        public readonly HshopContext db;
        public MenuLoaiViewComponent(HshopContext context) => db = context;

        public IViewComponentResult Invoke()
        {
            var data = db.Loais.Select(lo => new MenuLoaiViewModel
                {
                    MaLoai = lo.MaLoai,
                    TenLoai = lo.TenLoai,
                    SoLuong = lo.HangHoas.Count
                }
            ).OrderBy(p => p.TenLoai);
            return View( data );
        }
    }
}
