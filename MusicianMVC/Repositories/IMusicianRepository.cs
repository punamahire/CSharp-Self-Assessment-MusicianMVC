using MusicianMVC.Models;
using System.Collections.Generic;

namespace MusicianMVC.Repositories
{
    public interface IMusicianRepository
    {
        List<Musician> GetAll();
    }
}