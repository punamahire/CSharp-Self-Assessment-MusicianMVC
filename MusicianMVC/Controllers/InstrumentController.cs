using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicianMVC.Models;
using MusicianMVC.Models.ViewModels;
using MusicianMVC.Repositories;

namespace MusicianMVC.Controllers
{
    public class InstrumentController : Controller
    {
        private readonly IInstrumentRepository _instrumentRepository;
        private readonly IDifficultyRepository _difficultyRepository;
        private readonly IMusicianRepository _musicianRepository;

        public InstrumentController(
            IInstrumentRepository instrumentRepository,
            IDifficultyRepository difficultyRepository,
            IMusicianRepository musicianRepository)
        {
            _instrumentRepository = instrumentRepository;
            _difficultyRepository = difficultyRepository;
            _musicianRepository = musicianRepository;
        }

        // GET: InstrumentController
        public ActionResult Index()
        {
            List<Instrument> instruments = _instrumentRepository.GetAll();
            return View(instruments);
        }

        // GET: InstrumentController/Details/5
        public ActionResult Details(int id)
        {
            Instrument instrument = _instrumentRepository.GetById(id);
            return View(instrument);
        }

        // GET: InstrumentController/Create
        public ActionResult Create()
        {
            InstrumentFormViewModel vm = new InstrumentFormViewModel()
            {
                Instrument = new Instrument(),
                Difficulties = _difficultyRepository.GetAll()
            };
            return View(vm);
        }

        // POST: InstrumentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Instrument instrument)
        {
            try
            {
                _instrumentRepository.Add(instrument);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                InstrumentFormViewModel vm = new InstrumentFormViewModel()
                {
                    Instrument = instrument,
                    Difficulties = _difficultyRepository.GetAll()
                };
                return View(vm);
            }
        }

        // GET: InstrumentController/Edit/5
        public ActionResult Edit(int id)
        {
            InstrumentFormViewModel vm = new InstrumentFormViewModel()
            {
                Instrument = _instrumentRepository.GetById(id),
                Difficulties = _difficultyRepository.GetAll()
            };

            return View(vm);
        }

        // POST: InstrumentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Instrument instrument)
        {
            try
            {
                instrument.Id = id;
                _instrumentRepository.Update(instrument);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                InstrumentFormViewModel vm = new InstrumentFormViewModel()
                {
                    Instrument = instrument,
                    Difficulties = _difficultyRepository.GetAll()
                };
                return View(vm);
            }
        }

        // GET: InstrumentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_instrumentRepository.GetById(id));
        }

        // POST: InstrumentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Instrument instrument)
        {
            try
            {
                _instrumentRepository.Remove(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ManageMusicians(int id)
        {
            Instrument instrument = _instrumentRepository.GetById(id);
            List<int> selecteMusicianIds = instrument.Musicians.Select(m => m.Id).ToList();
            List<Musician> allMusicians = _musicianRepository.GetAll();

            ManageMusiciansViewModel vm = new ManageMusiciansViewModel()
            {
                Instrument = instrument,
                SelectedMusicianIds = selecteMusicianIds,
                AllMusicians = allMusicians,
            };

            return View(vm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ManageMusicians(int id, List<int> selectedMusicianIds)
        {
            try
            {
                _instrumentRepository.UpdateMusicians(id, selectedMusicianIds);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                Instrument instrument = _instrumentRepository.GetById(id);
                List<int> selecteMusicianIds = instrument.Musicians.Select(m => m.Id).ToList();
                List<Musician> allMusicians = _musicianRepository.GetAll();

                ManageMusiciansViewModel vm = new ManageMusiciansViewModel()
                {
                    Instrument = instrument,
                    SelectedMusicianIds = selecteMusicianIds,
                    AllMusicians = allMusicians,
                };

                return View(vm);
            }
        }
    }
}
