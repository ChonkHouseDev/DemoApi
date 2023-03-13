using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using System.Web;
using WebAPICore.Models;
using WebAPICore.Services;

namespace WebAPICore.Controllers
{


    [ApiController]
    [Route("[controller]")]

    public class Info : ControllerBase
    {
        [HttpGet]
        public List<LListainfo> InfoHttps()
        {
            var model = new LeerAppsettings();
            model.Link =  _configuration.GetValue<string>("LinkValue");
            model.UserAgent = _configuration.GetValue<string>("UserAgent");
            GetInfo listaDatos = new GetInfo();

            var listacategoria = listaDatos.ObtenerInfoAsync(model.Link, model.UserAgent);

            GetNodeTrueFalse listNodeCategory = new GetNodeTrueFalse();

            var listCategory =  listNodeCategory.GetListTrueFalse(listacategoria);


            return listCategory;
        }

        [HttpGet]
        [Route("{name}")]
        public List<ListAllCategory> InfoCategoria()
        {
            var model = new LeerAppsettings();
            model.Link = _configuration.GetValue<string>("LinkValue");
            model.UserAgent = _configuration.GetValue<string>("UserAgent");

            GetInfo listaDatos = new GetInfo();

            var listacategoria = listaDatos.ObtenerInfoOnlyCatAsync(model.Link, model.UserAgent);

            GetListNodeCategory listNodeCategory = new GetListNodeCategory();

            var listCategory = listNodeCategory.GetListCategory(listacategoria);
            
            return listCategory;
        }
        private readonly IConfiguration _configuration;

        public Info(IConfiguration configuration)
        {
            _configuration = configuration;
        }
    }
}