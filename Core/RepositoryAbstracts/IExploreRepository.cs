using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.RepositoryAbstracts
{
    public  interface IExploreRepository
    {
        void Add(Explore explore);
        void Delete(Explore explore);
        Explore Get(Func<Explore,bool> ? func);
        List<Explore> GetAll(Func<Explore, bool>? func);
        int Commit();
    }
}
