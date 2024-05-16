using Bussiness.Abstracts;
using Bussiness.Exceptions;
using Data.Models;
using Data.RepositoryAbstracts;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Concreters
{
    public class ExploreService : IExploreService
    {
        readonly IExploreRepository _exploreRepository;
        IWebHostEnvironment _webHostEnvironment;

        public ExploreService(IExploreRepository exploreRepository, IWebHostEnvironment webHostEnvironment )
        {
            _exploreRepository = exploreRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public void Create(Explore explore)
        {
           if(explore == null)
            {
                throw new NotFoundException("","Null ola bilmez!");
            }
            if (!explore.PhotoFile.ContentType.Contains("image/"))
            {
                throw new FileContentTypeException("PhotoFile", "File formati duzgun deyil!");
            }
            string filename=explore.PhotoFile.FileName;
            string path = _webHostEnvironment.WebRootPath + @"\Upload\Explore\" + filename;
            using(FileStream fileStream =new FileStream(path, FileMode.Create))
            {
                explore.PhotoFile.CopyTo(fileStream);
            }
            explore.ImgUrl = filename;
            _exploreRepository.Add(explore);
            _exploreRepository.Commit();
        }

        public void Delete(int id)
        {
           var explore=_exploreRepository.Get(x=>x.Id == id);
            string path = _webHostEnvironment.WebRootPath + @"\Upload\Explore\" + explore.ImgUrl;
            FileInfo fileInfo = new FileInfo(path);
            if (fileInfo.Exists)
            {
                fileInfo.Delete();
            }
            _exploreRepository.Delete(explore);
            _exploreRepository.Commit();
        }

        public List<Explore> GetAllExplore(Func<Explore, bool>? func = null)
        {
           return _exploreRepository.GetAll(func);
        }

        public Explore GetExplore(Func<Explore, bool>? func = null)
        {
           return _exploreRepository.Get(func);
        }

        public void Update(Explore explore)
        {
           var updateExplore=_exploreRepository.Get(x=> x.Id == explore.Id);
            if(updateExplore == null)
            {
                throw new NotFoundException("","Null ola bilmez!");

            }
            if(updateExplore.PhotoFile != null)
            {
                if (!explore.PhotoFile.ContentType.Contains("imgae/"))
                {
                    throw new FileContentTypeException("PhotoFile", "File formati duzgun deyil!");
                }
                string filename = explore.PhotoFile.FileName;
                string path = _webHostEnvironment.WebRootPath + @"\Upload\Explore\" + filename;
                using (FileStream fileStream = new FileStream(path, FileMode.Create))
                {
                    explore.PhotoFile.CopyTo(fileStream);
                }
                updateExplore.ImgUrl = filename;
            }
            else
            {
                explore.ImgUrl=updateExplore.ImgUrl;
            }
            updateExplore.Title=explore.Title;
            updateExplore.SubTitle=explore.SubTitle;
            updateExplore.Description=explore.Description;
            _exploreRepository.Commit();
            
        }
    }
}
