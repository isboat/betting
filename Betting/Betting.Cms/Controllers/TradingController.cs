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
        
        [HttpPost]
        public JsonResult UpdateCategory(ContextCategoryView model)
        {
            if (ModelState.IsValid)
            {
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
        
        [HttpPost]
        public JsonResult UpdateContext(ContextModel model)
        {
            if (ModelState.IsValid)
            {
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

        [HttpPost]
        public JsonResult AddSelection(SelectionModel model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedOn = DateTime.Now;
                var newId = this.tradingContentService.AddOrUpdateSelection(model);
                return Json(new { id = newId, label = model.Label }, JsonRequestBehavior.DenyGet);
            }

            return null;
        }

        [HttpPost]
        public JsonResult UpdateSelection(SelectionModel model)
        {
            if (ModelState.IsValid)
            {
                var newId = this.tradingContentService.AddOrUpdateSelection(model);
                return Json(new { id = newId, label = model.Label }, JsonRequestBehavior.DenyGet);
            }

            return null;
        }

        // GET: Trading/Delete/5
        public JsonResult DeleteSelection(string id)
        {
            return Json(!string.IsNullOrEmpty(id) && this.tradingContentService.DeleteSelection(id), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddTeam(TeamModel model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedOn = DateTime.Now;
                var newId = this.tradingContentService.AddOrUpdateTeam(model);
                return Json(new { id = newId, name = model.Name }, JsonRequestBehavior.DenyGet);
            }

            return null;
        }

        [HttpPost]
        public JsonResult UpdateTeam(TeamModel model)
        {
            if (ModelState.IsValid)
            {
                var newId = this.tradingContentService.AddOrUpdateTeam(model);
                return Json(new { id = newId, name = model.Name }, JsonRequestBehavior.DenyGet);
            }

            return null;
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
