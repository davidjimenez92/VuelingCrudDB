using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuelingCrudDB.CrossCutting.Resources
{
    public static class QueryResources
    {
        public static string AddProcedure
        {
            get { return QueryResource.AddProcedure; }
        }
        public static string DeleteProcedure
        {
            get { return QueryResource.DeleteProcedure; }
        }
        public static string GetAllProcedure
        {
            get { return QueryResource.GetAllProcedure; }
        }
        public static string GetByGuidProcedure
        {
            get { return QueryResource.GetByGuidProcedure; }
        }
        public static string UpdateProcedure
        {
            get { return QueryResource.UpdateProcedure; }
        }
        public static string AddQuery
        {
            get { return QueryResource.AddQuery; }
        }
        public static string DeleteQuery
        {
            get { return QueryResource.DeleteQuery; }
        }
        public static string GetAllQuery
        {
            get { return QueryResource.GetAllQuery; }
        }
        public static string GetByGuidQuery
        {
            get { return QueryResource.GetByGuidQuery; }
        }
        public static string UpdateQuery
        {
            get { return QueryResource.UpdateQuery; }
        }
    }
}

