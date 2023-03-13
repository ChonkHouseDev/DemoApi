using System.Collections.Generic;
using WebAPICore.Models;

namespace WebAPICore.Services
{
    public class GetNodeTrueFalse
    {
        public List<LListainfo> GetListTrueFalse(List<LListainfo> listainfos)
        {

            List<LListainfo> ListaTrueFalse = new List<LListainfo>();

            foreach (LListainfo infotrueFalse in listainfos)
            {
                if (infotrueFalse.https == "true" || infotrueFalse.https == "false")
                {
                    ListaTrueFalse.Add(infotrueFalse);
                }
            }

            return ListaTrueFalse;
        }

    }
}
