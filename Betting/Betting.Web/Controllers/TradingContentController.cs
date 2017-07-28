using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Betting.Core;
using Betting.Interfaces.ModelServices;

namespace Betting.Web.Controllers
{
    public class TradingContentController : Controller
    {
        private readonly IWebTradingContentService webTradingContentService;

        #region Constructor

        public TradingContentController()
        {
            this.webTradingContentService = IoC.Instance.Resolve<IWebTradingContentService>();
        }

        #endregion

        public JsonResult GetPopularPanels()
        {
            var model = this.webTradingContentService.GetPopularPanels();

            return Json(model, JsonRequestBehavior.AllowGet);

        }


        // GET: TradingContent
        public ActionResult Index()
        {
            var model = this.webTradingContentService.GetPopularPanels();

            return View(model);
        }

        // GET: TradingContent/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TradingContent/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TradingContent/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TradingContent/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TradingContent/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TradingContent/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TradingContent/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
