using MusicianMVC.Models;
using System.Collections.Generic;

namespace MusicianMVC.Repositories
{
    public interface IDifficultyRepository
    {
        List<Difficulty> GetAll();
    }
}