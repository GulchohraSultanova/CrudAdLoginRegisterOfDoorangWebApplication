using Data.DAL;
using Data.Models;
using Data.RepositoryAbstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.RepositoryConcreters
{
    public class ExploreRepository : IExploreRepository
    {
        AppDbContext _appDbContext;

        public ExploreRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Add(Explore explore)
        {
           _appDbContext.Add(explore);
        }

        public int Commit()
        {
            return _appDbContext.SaveChanges();
        }

        public void Delete(Explore explore)
        {
            _appDbContext.Remove(explore);
        }

        public Explore Get(Func<Explore, bool>? func)
        {
            return func == null ?
                _appDbContext.Explores.FirstOrDefault() :
                _appDbContext.Explores.FirstOrDefault(func);
        }

        public List<Explore> GetAll(Func<Explore, bool>? func)
        {
            return func==null?
                _appDbContext.Explores.ToList():
                _appDbContext.Explores.Where(func).ToList();
        }
    }
}
