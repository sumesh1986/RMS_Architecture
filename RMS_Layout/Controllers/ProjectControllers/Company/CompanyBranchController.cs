using Microsoft.AspNetCore.Mvc;

namespace RMS_Layout.Controllers.ProjectControllers.Company
{
    [Route("company/companybranch")]
    [ApiController]
    public class CompanyBranchController : Controller
    {
        // GET: api/<CompanyBranchController>
        [HttpGet]
        public ActionResult Index()
        {
            return View("~/Views/Company/Branch/BranchSetup.cshtml");
        }

        // GET api/<CompanyBranchController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CompanyBranchController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CompanyBranchController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CompanyBranchController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
