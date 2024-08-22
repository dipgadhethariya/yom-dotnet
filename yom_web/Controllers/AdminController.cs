using Microsoft.AspNetCore.Mvc;
using System.Data;
using yom_web.Models;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace yom_web.Controllers
{
    public class AdminController : Controller
    {
        private readonly IWebHostEnvironment _environment;

        public AdminController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        [HttpGet]
        public IActionResult login()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Login(adminmodel am)
        {
            DataSet ds = am.select(am.email, am.password);
            ViewBag.login_data = ds.Tables[0];





            foreach (System.Data.DataRow dr in ViewBag.login_data.Rows)
            {
                var id = dr["id"].ToString();
                TempData["id"] = id;
                return RedirectToAction("dashboard");
            }
            return RedirectToAction("login");
        }
        [HttpGet]
        public IActionResult slider()
        {
            return View();
        }
       
        [HttpPost]
        public async Task<ActionResult> slider(slidermodel sm)
        {
            string title = sm.title;
            string discription = sm.des;

            if (sm.img != null && sm.img.Length > 0)
            {
                string filename = Path.GetFileName(sm.img.FileName);
                string fileupload = Path.Combine(_environment.WebRootPath, "img", filename);

                using (var str = new FileStream(fileupload, FileMode.Create))
                {
                    await sm.img.CopyToAsync(str);
                }

                sm.insert(title, discription, filename);
            }

            return RedirectToAction("slider");
        }

        public IActionResult view_slider(slidermodel sm)
        {
            DataSet ds = sm.select();
            ViewBag.ds = ds.Tables[0];
            return View();
        }
        public IActionResult delete(slidermodel sm, int id)
        {
            sm.delete(id);
            return RedirectToAction("view_slider");
        }
        [HttpGet]
        public IActionResult update_slider(slidermodel sm, int id)
        {
            DataSet ds = sm.update(id);
            ViewBag.ds = ds.Tables[0];
            foreach (System.Data.DataRow dr in ViewBag.ds.Rows)
            {
                TempData["old_image_name"] = dr["img"].ToString();
            }
                return View();
        }

        

        [HttpPost]
        public async Task<ActionResult> update_slider(slidermodel sm,int id,int a=0)
        {
            string title = sm.title;
            string discription = sm.des;

            var filename = "";

            if (sm.img != null && sm.img.Length > 0)
            {
                filename = Path.GetFileName(sm.img.FileName);
                string fileupload = Path.Combine(_environment.WebRootPath, "img", filename);
                using (var str = new FileStream(fileupload, FileMode.Create))
                {
                    await sm.img.CopyToAsync(str);
                }
            }

            if (filename == "")
            {
                filename = TempData.Peek("old_image_name").ToString();
            }

            sm.update_data(id, title, discription, filename);

            return RedirectToAction("view_slider");
        }
        [HttpGet]
        public IActionResult icon()
        {
            return View();
        }
        [HttpPost]
        public IActionResult icon(iconmodel im)
        {

            string icon = im.icon;
            string title = im.title;
            string des = im.des;
            im.insert(icon, title, des);
            return RedirectToAction("icon");
        }

        public IActionResult icon_delete(iconmodel im, int id)
        {
            im.icon_delete(id);
            return RedirectToAction("view_icon");
        }
        public IActionResult view_icon(iconmodel im)
        {
            DataSet ds = im.select();
            ViewBag.data = ds.Tables[0];
            return View();
        }
        [HttpGet]
        public IActionResult update_icon(iconmodel im, int id)
        {
            DataSet ds = im.update(id);
            ViewBag.data = ds.Tables[0];
            return View();
        }
        [HttpPost]
        public IActionResult update_icon(iconmodel im, int id, int a = 0)
        {
            string icon = im.icon;
            string title = im.title;
            string discription = im.des;

            im.update_data(id, icon, title, discription);
            return RedirectToAction("view_icon");
        }

        public IActionResult dashboard()
        {
            return View();
        }

        [HttpGet]
        public IActionResult theme()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> theme(thememodel tm)
        {
            string title = tm.title;
            string lorem = tm.lorem;
            string discription = tm.des;

            if (tm.img != null && tm.img.Length > 0)
            {
                string filename = Path.GetFileName(tm.img.FileName);
                string fileupload = Path.Combine(_environment.WebRootPath, "img", filename);

                using (var str = new FileStream(fileupload, FileMode.Create))
                {
                    await tm.img.CopyToAsync(str);
                }

                tm.insert(title,lorem, discription, filename);
            }

            return RedirectToAction("theme");
        }


        //========================================================================

     


        public IActionResult view_theme(thememodel tm)
        {
            DataSet ds = tm.select();
            ViewBag.ds1 = ds.Tables[0];

            return View();
        }
        //update theme

        [HttpGet]
        public IActionResult update_theme(thememodel tm, int id)
        {
            DataSet ds = tm.update(id);
            ViewBag.ds1 = ds.Tables[0];
            foreach (System.Data.DataRow dr in ViewBag.ds1.Rows)
            {
                TempData["old_image_name"] = dr["img"].ToString();
            }
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> update_theme(thememodel tm, int id, int a = 0)
        {

            string title = tm.title;
            string lorem = tm.lorem;
            string des = tm.des;

            var filename = "";

            if (tm.img != null && tm.img.Length > 0)
            {
                filename = Path.GetFileName(tm.img.FileName);
                string fileupload = Path.Combine(_environment.WebRootPath, "img", filename);
                using (var str = new FileStream(fileupload, FileMode.Create))
                {
                    await tm.img.CopyToAsync(str);
                }
            }

            if (filename == "")
            {
                filename = TempData.Peek("old_image_name").ToString();
            }


            tm.update_data(id, title, lorem, des, filename);

            return RedirectToAction("view_theme");

        }
        

        public IActionResult delete_theme(thememodel tm, int id)
        {
            tm.delete(id);
            return RedirectToAction("view_theme");
        }


		//==============================================================

		[HttpGet]
		public IActionResult add_image()
		{

			return View();
		}
		[HttpPost]
		public async Task<ActionResult> add_image(imageslidermodel ism)
		{
			string title = ism.title;
			string description = ism.des;
			string category = ism.category;

			if (ism.img != null && ism.img.Length > 0)
			{
				string filename = Path.GetFileName(ism.img.FileName);
				string fileupload = Path.Combine(_environment.WebRootPath, "img", filename);

				using (var str = new FileStream(fileupload, FileMode.Create))
				{
					await ism.img.CopyToAsync(str);
				}
				ism.insert(filename, title, description, category);

			}


			return RedirectToAction("view_image");
		}
		public IActionResult view_image(imageslidermodel ism)
		{
			DataSet ds = ism.select();
			ViewBag.ds2 = ds.Tables[0];

			return View();
		}
		[HttpGet]
		public IActionResult update_image(imageslidermodel ism, int id)
		{
			DataSet ds = ism.update(id);
			ViewBag.ds2 = ds.Tables[0];
			foreach (System.Data.DataRow dr in ViewBag.ds2.Rows)
			{
				TempData["old_image_name"] = dr["img"].ToString();
			}
			return View();
		}
		[HttpPost]
		public async Task<ActionResult> update_image(imageslidermodel ism, int id, int a = 0)
		{

			string title = ism.title;
			string description = ism.des;
			string category = ism.category;

			var filename = "";

			if (ism.img != null && ism.img.Length > 0)
			{
				filename = Path.GetFileName(ism.img.FileName);
				string fileupload = Path.Combine(_environment.WebRootPath, "image", filename);
				using (var str = new FileStream(fileupload, FileMode.Create))
				{
					await ism.img.CopyToAsync(str);
				}
			}

			if (filename == "")
			{
				filename = TempData.Peek("old_image_name").ToString();
			}


			ism.update_data(id, filename, title, description, category);

			return RedirectToAction("view_image");

		}
		//===================================================Delete====================================


		public IActionResult delete_image(imageslidermodel ism, int id)
		{
			ism.delete(id);
			return RedirectToAction("view_image");
		}



		//==============================================================

		[HttpGet]
		public IActionResult add_profile()
		{

			return View();
		}
		[HttpPost]
		public async Task<ActionResult> add_profile(profilemodel pm)
		{
			string title = pm.title;
			string description = pm.des;

			if (pm.img != null && pm.img.Length > 0)
			{
				string filename = Path.GetFileName(pm.img.FileName);
				string fileupload = Path.Combine(_environment.WebRootPath, "img", filename);

				using (var str = new FileStream(fileupload, FileMode.Create))
				{
					await pm.img.CopyToAsync(str);
				}
				pm.insert(filename, title, description);

			}


			return RedirectToAction("view_profile");
		}
		public IActionResult view_profile(profilemodel pm)
		{
			DataSet ds = pm.select();
			ViewBag.ds5 = ds.Tables[0];

			return View();
		}
		[HttpGet]
		public IActionResult update_profile(profilemodel pm, int id)
		{
			DataSet ds = pm.update(id);
			ViewBag.ds5 = ds.Tables[0];
			foreach (System.Data.DataRow dr in ViewBag.ds5.Rows)
			{
				TempData["old_image_name"] = dr["img"].ToString();
			}
			return View();
		}
		[HttpPost]
		public async Task<ActionResult> update_profile(profilemodel pm, int id, int a = 0)
		{

			string title = pm.title;
			string description = pm.des;

			var filename = "";

			if (pm.img != null && pm.img.Length > 0)
			{
				filename = Path.GetFileName(pm.img.FileName);
				string fileupload = Path.Combine(_environment.WebRootPath, "image", filename);
				using (var str = new FileStream(fileupload, FileMode.Create))
				{
					await pm.img.CopyToAsync(str);
				}
			}

			if (filename == "")
			{
				filename = TempData.Peek("old_image_name").ToString();
			}


			pm.update_data(id, filename, title, description);

			return RedirectToAction("view_profile");

		}
		//===================================================Delete====================================


		public IActionResult delete_profile(profilemodel pm, int id)
		{
			pm.delete(id);
			return RedirectToAction("view_profile");
		}
		//=======================================================================================

		[HttpGet]
        public IActionResult content()
        {
            return View();
        }
        [HttpPost]
        public IActionResult content(contentslidermodel csm)
        {

            string des= csm.des;
            string name= csm.name;
            string city= csm.city;
            string country= csm.country;
            csm.insert(des,name,city,country);
            return RedirectToAction("content");
        }

        public IActionResult content_delete(contentslidermodel csm, int id)
        {
            csm.content_delete(id);
            return RedirectToAction("view_content");
        }
        public IActionResult view_content(contentslidermodel csm)
        {
            DataSet ds = csm.select();
            ViewBag.ds3 = ds.Tables[0];
            return View();
        }
        [HttpGet]
        public IActionResult update_content(contentslidermodel csm, int id)
        {
            DataSet ds = csm.update(id);
            ViewBag.ds3 = ds.Tables[0];
            return View();
        }
        [HttpPost]
        public IActionResult update_content(contentslidermodel csm, int id, int a = 0)
        {
            string des = csm.des;
            string name = csm.name;
            string city = csm.city;
            string country = csm.country;

            csm.update_data(id, des, name, city, country);
            return RedirectToAction("view_content");
        }


		//==============================================================

		[HttpGet]
		public IActionResult last_home()
		{

			return View();
		}
		[HttpPost]
		public async Task<ActionResult> last_home(last_homemodel lhm)
		{
			string title = lhm.title;
			string name = lhm.name;
			string date = lhm.date;
			string category = lhm.category;
			string des = lhm.des;

			if (lhm.img != null && lhm.img.Length > 0)
			{
				string filename = Path.GetFileName(lhm.img.FileName);
				string fileupload = Path.Combine(_environment.WebRootPath, "img", filename);

				using (var str = new FileStream(fileupload, FileMode.Create))
				{
					await lhm.img.CopyToAsync(str);
				}
				lhm.insert(filename, title,name,date,category,des);

			}


			return RedirectToAction("view_last_home");
		}
		public IActionResult view_last_home(last_homemodel lhm)
		{
			DataSet ds = lhm.select();
			ViewBag.ds4 = ds.Tables[0];

			return View();
		}
		[HttpGet]
		public IActionResult update_last_home(last_homemodel lhm, int id)
		{
			DataSet ds = lhm.update(id);
			ViewBag.ds4 = ds.Tables[0];
			foreach (System.Data.DataRow dr in ViewBag.ds4.Rows)
			{
				TempData["old_image_name"] = dr["img"].ToString();
			}
			return View();
		}
		[HttpPost]
		public async Task<ActionResult> update_last_home(last_homemodel lhm, int id, int a = 0)
		{

			string title = lhm.title;
			string name = lhm.name;
			string date = lhm.date;
			string category = lhm.category;
			string des = lhm.des;

			var filename = "";

			if (lhm.img != null && lhm.img.Length > 0)
			{
				filename = Path.GetFileName(lhm.img.FileName);
				string fileupload = Path.Combine(_environment.WebRootPath, "image", filename);
				using (var str = new FileStream(fileupload, FileMode.Create))
				{
					await lhm.img.CopyToAsync(str);
				}
			}

			if (filename == "")
			{
				filename = TempData.Peek("old_image_name").ToString();
			}


			lhm.update_data(id,filename, title, name, date, category, des);

			return RedirectToAction("view_last_home");

		}
		//===================================================Delete====================================


		public IActionResult delete_last_home(last_homemodel lhm, int id)
		{
			lhm.delete(id);
			return RedirectToAction("view_last_home");
		}


	}
}
