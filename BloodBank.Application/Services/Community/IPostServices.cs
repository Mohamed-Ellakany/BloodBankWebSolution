using BloodBank.Application.Common.ModelContracts.Community;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Services.Community
{
    public interface IPostServices
    {
        IEnumerable<PostResponse>? GetAll();

        IEnumerable<PostResponse>? GetAllFilterd(int BloodTypeId);

        PostDetailsResponse? GetDetailsOfPost(int PostId);

        int AddPost(PostRequest request);

        int DeletePost(int PostId);
    }
}
