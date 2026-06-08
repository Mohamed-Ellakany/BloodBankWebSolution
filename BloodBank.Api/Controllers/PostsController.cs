using BloodBank.Application.Common.ModelContracts.Community;
using BloodBank.Application.Services.Community;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloodBank.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PostsController(IPostServices postServices) : ControllerBase
    {
        private readonly IPostServices _postServices = postServices;

        [HttpGet]
        public IActionResult GetAll()
        {
            var response = _postServices.GetAll();

            if(response is null) return Result.Failure(UserErrors.NoPosts).ToProblem();

           return Ok( response);
        }

        [HttpGet("{id}/Details")]
        public IActionResult GetDetails(int id)
        {
           var post =  _postServices.GetDetailsOfPost(id);

            if (post is null) return Result.Failure(UserErrors.NoPosts).ToProblem();

            return Ok(post);
        
        }


        [HttpGet("{BloodTypeId}")]
        public IActionResult GetWithBloodType(int BloodTypeId) 
        {
            var response = _postServices.GetAllFilterd(BloodTypeId);

            if (response is null) return Result.Failure(UserErrors.NoPosts).ToProblem();

            return Ok(response);

        }

        [HttpPost]
        public IActionResult Create(PostRequest request)
        {
          var result = _postServices.AddPost(request);

            if(result == 0) return Result.Failure(UserErrors.FailedOperation).ToProblem();

            return NoContent();

        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
          var result = _postServices.DeletePost(Id);

            if(result == 0) return Result.Failure(UserErrors.FailedOperation).ToProblem();

            return NoContent();

        }




    }
}
