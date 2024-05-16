using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Abstracts
{
    public  interface IExploreService
    {
        void Create(Explore explore);
        void Delete(int id);
        void Update(Explore explore);
        Explore GetExplore(Func<Explore,bool>? func=null);
        List<Explore> GetAllExplore(Func<Explore,bool> ? func=null);
    }
}
