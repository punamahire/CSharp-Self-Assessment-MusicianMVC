using System.Collections.Generic;

namespace MusicianMVC.Models.ViewModels
{
    public class ManageMusiciansViewModel
    {
        public Instrument Instrument { get; set; }
        public List<int> SelectedMusicianIds { get; set; }
        public List<Musician> AllMusicians { get; set; }
    }
}
