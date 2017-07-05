using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Betting.Cms.ViewModels;
using Betting.Core;
using Betting.Interfaces.ModelServices;
using Betting.ViewModels;

namespace Betting.Cms.Controllers
{
    public class TradingController : Controller
    {
        private readonly ITradingContentService tradingContentService;

        public TradingController()
        {
            this.tradingContentService = IoC.Instance.Resolve<ITradingContentService>();
        }

        // GET: Trading
        public ActionResult Index()
        {
            var model = new TournamentsView
            {
                List = this.tradingContentService.GetTournaments(new SearchTagsView())
            };

            return View(model);
        }

        [HttpGet]
        public ActionResult CreateTournament()
        {
            return View();
        }


        [HttpPost]
        public ActionResult CreateTournament(TournamentModel model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedOn = DateTime.Now;
                var response = this.tradingContentService.CreateOrUpdateTournament(model);
            }
            return View();
        }
        
        // GET: Trading/Details/5
        public ActionResult ViewTournament(string id)
        {
            var model = this.tradingContentService.GetTournamentDetails(id);
            return View(model);
        }

        
        [HttpPost]
        public JsonResult AddContextCategory(ContextCategoryView model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedOn = DateTime.Now;
                var newId = this.tradingContentService.AddOrUpdateContextCategory(model);
                return Json(new {id = newId, name = model.Name}, JsonRequestBehavior.DenyGet);
            }

            return null;
        }
        
        // GET: Trading/Details/5
        public ActionResult ViewCategory(string id)
        {
            var model = this.tradingContentService.GetContextCategoryDetails(id);
            return View(model);
        }

        
        [HttpPost]
        public JsonResult AddContext(ContextModel model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedOn = DateTime.Now;
                var newId = this.tradingContentService.AddOrUpdateContext(model);
                return Json(new {id = newId, label = model.Label}, JsonRequestBehavior.DenyGet);
            }

            return null;
        }
        
        // GET: Trading/Details/5
        public ActionResult ViewContext(string id)
        {
            var model = this.tradingContentService.GetContext(id);
            return View(model);
        }

        // POST: Trading/Create
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

        // GET: Trading/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Trading/Edit/5
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

        // GET: Trading/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Trading/Delete/5
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
