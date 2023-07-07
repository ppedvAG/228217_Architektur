using Microsoft.AspNetCore.Mvc;
using ppedv.BerlinBytes.Model.Contracts;

namespace ppedv.BerlinBytes.UI.Web.Controllers
{
    public class VersionController : Controller
    {
        private readonly IRepository repo;

        public VersionController(IRepository repo)
        {
            this.repo = repo;
        }

        // GET: VersionController
        public ActionResult Index()
        {
            return View(repo.Query<Model.DomainModel.Version>());
        }

        // GET: VersionController/Details/5
        public ActionResult Details(int id)
        {
            return View(repo.GetById<Model.DomainModel.Version>(id));
        }

        // GET: VersionController/Create
        public ActionResult Create()
        {
            return View(new Model.DomainModel.Version() { Number = 4 });
        }

        // POST: VersionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Model.DomainModel.Version version)
        {
            try
            {
                repo.Add(version);
                repo.SaveAll();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VersionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(repo.GetById<Model.DomainModel.Version>(id));
        }

        // POST: VersionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Model.DomainModel.Version version)
        {
            try
            {
                repo.Update(version);
                repo.SaveAll();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VersionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(repo.GetById<Model.DomainModel.Version>(id));
        }

        // POST: VersionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Model.DomainModel.Version version)
        {
            try
            {
                repo.Delete(version);   
                repo.SaveAll();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
