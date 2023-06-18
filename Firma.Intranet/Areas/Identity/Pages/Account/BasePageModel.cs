using Firma.Data.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Firma.PortalWWW.Areas.Identity.Pages.Account
{
	public class BasePageModel : PageModel
	{
        protected AlmondContext _context;
        public BasePageModel(AlmondContext context) : base()
        {
            _context = context;
        }

		// public void ImportGlobalData()
		// {
		// 	ViewData["ModelStrony"] = (
		// 		from strona in _context.Page
		// 		orderby strona.Position
		// 		select strona
		// 	).ToList();
		//
		// 	ViewData["FooterText"] = (
		// 		from tekst in _context..
		// 		select tekst
		// 		).Where(tekst => tekst.TextLocation.Key == "footer")
		// 		.ToList();
		//
		// 	ViewData["BannerText"] = (
		// 		from tekst in _context.Text
		// 		select tekst
		// 		).Where(tekst => tekst.TextLocation.Key == "banner")
		// 		.ToList();
		// }
	}
}
