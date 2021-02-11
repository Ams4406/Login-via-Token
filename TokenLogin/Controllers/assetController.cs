using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using TokenLogin.DAL;
using TokenLogin.Models;

namespace TokenLogin.Controllers
{
    public class assetController : ApiController
    {
        private AssetRepository _ourAssetRepository;
        public assetController()
        {
            _ourAssetRepository = new AssetRepository();
        }

        //GET: api/login
        [Authorize(Roles = "admin, user")]
        [HttpGet]
        [Route("api/login")]
        public IHttpActionResult GetLogin()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var roles = identity.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value);
            return Ok("Name : " + identity.Name + " & Role : " + string.Join(",", roles.ToList()));
        }

        // GET: api/assets
        [Route("api/assets")]
        [HttpGet]
        public List<asset> DisplayAll()
        {
            return _ourAssetRepository.DisplayAssets();
        }

        // GET: api/assets/10
        [Route("api/assets/{ID}")]
        [HttpGet]
        public asset Get(int ID)
        {
            return _ourAssetRepository.SearchAssetByID(ID);
        }

        // GET: api/assets/Ams
        /*[Route("api/assets/{Name}")]
        [HttpGet]
        public asset GetName(string Name)
        {
            return _ourAssetRepository.SearchAssetByName(Name);
        }*/

        //GET: api/assets?registration_date[gt]={Date}
        /*[Route("api/assets?registration_date[gt] = {RegistrationDate}")]
        [HttpGet]
        public asset GetRegistrationDate(DateTime RegistrationDate)
        {
            return _ourAssetRepository.SearchAssetByDate(RegistrationDate);
        }
        */

        // POST: api/assets
        [Route("api/assets")]
        [HttpPost]
        public bool Post([FromBody] asset ourAsset)
        {
            return _ourAssetRepository.InsertAsset(ourAsset);
        }

        // PUT: api/assets
        [Route("api/assets")]
        [HttpPut]
        public bool Put([FromBody] asset ourAsset)
        {
            return _ourAssetRepository.UpdateAsset(ourAsset);
        }

        // DELETE: api/assets/10
        [Route("api/assets/{ID}")]
        [HttpDelete]
        public bool Delete(int ID)
        {
            return _ourAssetRepository.DeleteAsset(ID);
        }
    }
}
