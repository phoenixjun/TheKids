using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;
using TheKids.Domain.Interfaces;
using TheKids.WebApi.Models.Kids;

namespace TheKids.WebApi.Controllers
{

    public class ChildController : ApiController
    {
        private readonly IRepository _repository;

        public ChildController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IHttpActionResult GetKids([FromUri] SearchKidsRequestModel request)
        {
            return new OkNegotiatedContentResult<SearchKidsReponseModel>(new SearchKidsReponseModel()
            {
                Kids = new List<KidModel>()
                {
                    new KidModel() {FirstName = "TestKids", Gender = "Male", KidId = 1, LastName = "Last Name"},
                    new KidModel() {FirstName = "TestKids", Gender = "Male", KidId = 1, LastName = "Last Name"},
                }
            }, this);
        }

        [HttpPost]
        public IHttpActionResult CreateKids()
        {
            return Ok();
        }
    }
}
