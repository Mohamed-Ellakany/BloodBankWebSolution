using BloodBank.Application.Common.ModelContracts.Community;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Services.Community
{
    public class PostServices(IUnitOfWork unitOfWork) : IPostServices
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        //Get All
        public IEnumerable<PostResponse>? GetAll()
        {var result = _unitOfWork.Posts.FindAll(predicate: x=>x.BagsNeeded == x.BagsNeeded , include: x=>x.Include(x=>x.BloodType)).Adapt <IEnumerable< PostResponse>>(); 

            if(!result.Any()) return null;

          return  result;
        }


        //Get All With Blood Type 
        public IEnumerable<PostResponse>? GetAllFilterd(int BloodTypeId)
        {
            var result = _unitOfWork.Posts.FindAll(predicate: x=>x.BloodTypeId == BloodTypeId, include: x => x.Include(x => x.BloodType)).Adapt<IEnumerable<PostResponse>>();


            if (!result.Any()) return null;

            return result;

        }

        
        //Get Details of Post
        public PostDetailsResponse? GetDetailsOfPost(int PostId)
        {
            var result = _unitOfWork.Posts.Find(predicate: x=>x.Id == PostId , include: x => x.Include(x => x.BloodType));

            if (result is null) return null;

            return result.Adapt<PostDetailsResponse>();

        }


        //Add Post
        public  int AddPost(PostRequest request) 
        {
          var types = _unitOfWork.BloodTypes.GetAll().Select(x => x.Id).ToList();

            if (!types.Contains(request.BloodTypeId)) return 0;

            var post = request.Adapt<Post>();

            _unitOfWork.Posts.Add(post);
            var result =  _unitOfWork.Complete();
        
            return result;
        }



        //Delete Post

        public int DeletePost(int PostId)
        {
            var post = _unitOfWork.Posts.Find(x=>x.Id == PostId);

            if (post is null) return 0;

            _unitOfWork.Posts.Remove(post);

            var result = _unitOfWork.Complete();

            return result;
        }


    }
}
