using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using WebAPICore.Models;

namespace WebAPICore.Services
{
    public class GetListNodeCategory
    {
        public List<ListAllCategory> GetListCategory(List<ListAllCategory> listainfos)
        {

            List<ListAllCategory> listCategoryall= new List<ListAllCategory>();

            List<ListAllCategory> ListaCategoria = listainfos
            .GroupBy(m => new { m.category })
            .Select(group => group.First())
            .ToList();

            foreach (ListAllCategory infolistcategory in ListaCategoria)
            {

               listCategoryall.Add(infolistcategory); 

            }

            return listCategoryall;
        }


    }
}
