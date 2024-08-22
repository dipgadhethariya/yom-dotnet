using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Diagnostics;
using yom_web.Models;

namespace yom_web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(slidermodel sm,iconmodel im,thememodel tm,imageslidermodel ism,contentslidermodel csm,last_homemodel lhm)
        {
            DataSet dataSet = sm.select();
            ViewBag.ds = dataSet.Tables[0];

			DataSet dataSeticon = im.select();
			ViewBag.data = dataSeticon.Tables[0];

            DataSet dataSettheme = tm.select();
            ViewBag.ds1 = dataSettheme.Tables[0];

            DataSet dataSetimg = ism.select();
            ViewBag.ds2 = dataSetimg.Tables[0];

            DataSet dataSetcontent = csm.select();
            ViewBag.ds3 = dataSetcontent.Tables[0];


            DataSet dataSetlasthome = lhm.select();
            ViewBag.ds4 = dataSetlasthome.Tables[0];

            return View();
        }
		public IActionResult services(iconmodel im,thememodel tm)
		{
			DataSet dataSeticon = im.select();
			ViewBag.data = dataSeticon.Tables[0];

			DataSet dataSettheme = tm.select();
			ViewBag.ds1 = dataSettheme.Tables[0];

			return View();
		}

		public IActionResult clients()
		{
			return View();
		}
		public IActionResult blog(last_homemodel lhm)
		{
			DataSet dataSetlasthome = lhm.select();
			ViewBag.ds4 = dataSetlasthome.Tables[0];
			return View();
		}
		public IActionResult blog_grid(last_homemodel lhm)
		{
			DataSet dataSetlasthome = lhm.select();
			ViewBag.ds4 = dataSetlasthome.Tables[0];

			return View();
		}
		
		public IActionResult blog_single(last_homemodel lhm,int a =0)
		{
			DataSet dataSetlasthome = lhm.select();
			ViewBag.ds4 = dataSetlasthome.Tables[0];
			return View();
		}
		[HttpPost]
		public IActionResult blog_single(contentslidermodel csm)
		{
			string des = csm.des;
			string name = csm.name;
			string city = csm.city;
			string country = csm.country;
			csm.insert(des, name, city, country);
			return RedirectToAction("blog_single");
			
		}

		public IActionResult about(contentslidermodel csm,profilemodel pm)
		{
			DataSet dataSetcontent = csm.select();
			ViewBag.ds3 = dataSetcontent.Tables[0];

            DataSet dsprofile = pm.select();
            ViewBag.ds5 = dsprofile.Tables[0];

            return View();
		}
		public IActionResult three_columns(imageslidermodel ism)
		{
			DataSet dataSetimg = ism.select();
			ViewBag.ds2 = dataSetimg.Tables[0];

			return View();
		}
		public IActionResult four_columns(imageslidermodel ism)
		{
			DataSet dataSetimg = ism.select();
			ViewBag.ds2 = dataSetimg.Tables[0];

			return View();
		}
		public IActionResult single_project(imageslidermodel ism,last_homemodel lhm)
		{
			DataSet dataSetimg = ism.select();
			ViewBag.ds2 = dataSetimg.Tables[0];

			DataSet dataSetlasthome = lhm.select();
			ViewBag.ds4 = dataSetlasthome.Tables[0];

			return View();
		}

		public IActionResult contact()
		{
			return View();
		}

		public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Login(yommodel ym)
        {
            DataSet ds = ym.select(ym.email, ym.password);
            ViewBag.login_data = ds.Tables[0];





            foreach (System.Data.DataRow dr in ViewBag.login_data.Rows)
            {
                var id = dr["id"].ToString();
                TempData["id"] = id;
                return RedirectToAction("index");
            }
            return RedirectToAction("login");
        }
        [HttpGet]
        public IActionResult register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult register(yommodel ym)
        {
            string name = ym.name;
            string email = ym.email;
            string password = ym.password;
            ym.insert(name, email, password);

            return RedirectToAction("login");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
