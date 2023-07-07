using Microsoft.AspNetCore.Mvc;
using ppedv.BerlinBytes.Model.Contracts;

namespace ppedv.BerlinBytes.UI.Web.Controllers
{
    public class VersionController : Controller
    {
        private readonly IUnitOfWork uow;

        public VersionController(IUnitOfWork repo)
        {
            this.uow = repo;
        }

        // GET: VersionController
        public ActionResult Index()
        {
            return View(uow.VersionRepo.Query());
        }

        // GET: VersionController/Details/5
        public ActionResult Details(int id)
        {
            return View(uow.VersionRepo.GetById(id));
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
                uow.VersionRepo.Add(version);
                uow.SaveAll();

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
            return View(uow.VersionRepo.GetById(id));
        }

        // POST: VersionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Model.DomainModel.Version version)
        {
            try
            {
                uow.VersionRepo.Update(version);
                uow.SaveAll();
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
            return View(uow.VersionRepo.GetById(id));
        }

        // POST: VersionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Model.DomainModel.Version version)
        {
            try
            {
                uow.VersionRepo.Delete(version);
                uow.SaveAll();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
