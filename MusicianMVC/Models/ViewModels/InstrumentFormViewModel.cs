using System.Collections.Generic;

namespace MusicianMVC.Models.ViewModels
{
    public class InstrumentFormViewModel
    {
        public Instrument Instrument { get; set; }
        public List<Difficulty> Difficulties { get; set; }
    }
}
