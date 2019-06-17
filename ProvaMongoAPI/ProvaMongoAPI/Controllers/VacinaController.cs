using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using ProvaMongoAPI.Models;

namespace ProvaMongoAPI.Controllers
{
    public class VacinaController : Controller
    {
        private readonly MongoContext _mongoDBContext = new MongoContext();
        public IActionResult Index()
        {
            return View(_mongoDBContext.Vacinas.Find(s => true).ToList());
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Vacina vacina)
        {
            if (ModelState.IsValid)
            {
                _mongoDBContext.Vacinas.InsertOne(vacina);
                return RedirectToAction("Index");
            }

            return View();
        }


        [HttpGet]
        public IActionResult Delete(string Id)
        {
            var vacinaDel = _mongoDBContext.Vacinas
                .Find(s => s.Id == ObjectId.Parse(Id)).FirstOrDefault();
            return View(vacinaDel);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(string Id)
        {
            var vacinaDel = _mongoDBContext.Vacinas
                .DeleteOne(s => s.Id == ObjectId.Parse(Id));
            return RedirectToAction("Index");
        }


        public ActionResult Edit(string Id)
        {
            var vac = _mongoDBContext.Vacinas.Find(s => s.Id == ObjectId.Parse(Id)).FirstOrDefault();
            return View(vac);
        }

        [HttpPost]
        public ActionResult Edit(Vacina vac, string id)
        {
            if (ModelState.IsValid)
            {
                vac.Id = ObjectId.Parse(id);
                var filter = new BsonDocument("_id", ObjectId.Parse(id));
                //var filter = Builders<Servidor>.Filter.Eq(s => s.Id, servidor.Id);
                _mongoDBContext.Vacinas.ReplaceOne(filter, vac);

                return RedirectToAction("Index");
            }
            return View();
        }
    }
}