using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;
using WebAPICore.Models;

namespace WebAPICore.Services
{
    public class GetInfo
    {
        public List<LListainfo> ObtenerInfoAsync(string Link, string Agent)
        {
            
                HttpWebRequest myWebRequest = (HttpWebRequest)WebRequest.Create(Link);

                myWebRequest.UserAgent = Agent;

                myWebRequest.Credentials = CredentialCache.DefaultCredentials;
                myWebRequest.Proxy = null;

                HttpWebResponse myWebResponse = (HttpWebResponse)myWebRequest.GetResponse();

                Stream stream = myWebResponse.GetResponseStream();

                StreamReader reader = new StreamReader(stream);

                string line = HttpUtility.HtmlDecode(reader.ReadToEnd());
                
                dynamic json = JsonConvert.DeserializeObject(line);

                var infogud = JsonConvert.DeserializeObject<List<LListainfo>>(json.entries.ToString());

                List<LListainfo> mylista = new List<LListainfo>();

                foreach(var info in infogud)
                {
                    mylista.Add(info);
                }

                return mylista;

        }

        public List<ListAllCategory> ObtenerInfoOnlyCatAsync(string Link, string Agent)
        {

                HttpWebRequest myWebRequest = (HttpWebRequest)WebRequest.Create(Link);


                myWebRequest.UserAgent = Agent;

                myWebRequest.Credentials = CredentialCache.DefaultCredentials;
                myWebRequest.Proxy = null;

                HttpWebResponse myWebResponse = (HttpWebResponse)myWebRequest.GetResponse();

                Stream stream = myWebResponse.GetResponseStream();

                StreamReader reader = new StreamReader(stream);

                string line = HttpUtility.HtmlDecode(reader.ReadToEnd());

                dynamic json = JsonConvert.DeserializeObject(line);

                var infogud = JsonConvert.DeserializeObject<List<ListAllCategory>>(json.entries.ToString());

                List<ListAllCategory> mylista = new List<ListAllCategory>();

                foreach (var info in infogud)
                {
                    mylista.Add(info);
                }

                return mylista;
        }

    }
}