using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.Entity;
using BusinessLogicLayer.EntityList;
using DataAcessLayer;

namespace BusinessLogicLayer.EntityManager
{
    public class PuplisherManager
    {
        static DBManager manager = new();

        public static PublisherList SelectAllPublishers()
        {
            try
            {
                return DatatabletoPublisherList(manager.ExecuteDataTable("SelectAllPublishers"));
                //throw new NotImplementedException();
            }
            catch
            {
                return new PublisherList();
            }
        }
        #region Mapping Functions
        internal static PublisherList DatatabletoPublisherList(DataTable dt)
        {
            PublisherList publs = new();
            try
            {
                foreach (DataRow row in dt.Rows)
                    publs.Add(DataRowtopublisher(row));

            }
            catch
            {

            }
            return publs;

        }
        internal static Publisher DataRowtopublisher(DataRow dr)
        {
            Publisher t = new Publisher();
            try
            {
                //if (int.TryParse(dr["title_id"]?.ToString()??"-1",out int tempint))
                t.pub_id = dr["pub_id"]?.ToString() ?? "NA";
                t.pub_name = dr["pub_name"]?.ToString() ?? "NA";
                t.country = dr["country"]?.ToString() ?? "NA";
                t.state = dr["state"]?.ToString() ?? "NA";
                t.city = dr["city"]?.ToString() ?? "NA";
               
            }
            catch
            {

            }
            return t;
        }

        #endregion

    }
}
