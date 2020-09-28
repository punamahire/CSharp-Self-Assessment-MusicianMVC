using MusicianMVC.Models;
using System.Collections.Generic;

namespace MusicianMVC.Repositories
{
    public interface IInstrumentRepository
    {
        List<Instrument> GetAll();
        Instrument GetById(int id);
        void Add(Instrument instrument);
        void Update(Instrument instrument);
        void Remove(int id);
        void UpdateMusicians(int instrumentId, List<int> musicianIds);
    }
}