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
    public class TitleManager
    {
        static DBManager manager= new();


        public static bool UpdateTitle(string title_id, string title,string type,string pub_id,decimal? price,decimal? advance, int? royalty,int? ytd_sales,string notes,DateTime pubdate)
        {
            try
            {
                //["@title_id"] = title_id,
                Dictionary<string,object> data = new() { ["@title_id"] = title_id, ["@title"] = title, ["@type"]= type, ["@pub_id"]= pub_id, ["@price"] = price, ["advance"] = advance, ["@royalty"]= royalty, ["@ytd_sales"]= ytd_sales, ["@ytd_sales"]= ytd_sales, ["@notes"]= notes, ["@pubdate"]= pubdate };
                return manager.ExecuteNonQuery("UpdateTitle",data) > 0;

            }
            catch
            {

            }
            return false;

        }

        public static bool spInsertTitle(string title_id, string title, string type, string pub_id, decimal? price, decimal? advance, int? royalty, int? ytd_sales, string notes, DateTime pubdate)
        {
            try
            {
                Dictionary<string, object> data1 = new() { ["@title_id"] = title_id, ["@title"] = title, ["@type"] = type, ["@pub_id"] = pub_id, ["@price"] = price, ["advance"] = advance, ["@royalty"] = royalty, ["@ytd_sales"] = ytd_sales, ["@ytd_sales"] = ytd_sales, ["@notes"] = notes, ["@pubdate"] = pubdate };
                return manager.ExecuteNonQuery("spInsertTitle", data1) > 0;
                //UpdateTitle(title_id, title, type, pub_id, price, advance, royalty, ytd_sales, notes, pubdate);

            }
            catch
            {

            }

            return false;


        }

        public static bool DeleteTitle(string title_id)
        {
            try
            {
                Dictionary<string, object> data1 = new() {["@title_id"] = title_id};
                return manager.ExecuteNonQuery("DeleteTitle", data1)>0;
            }
            catch
            {

            }
            return false;
        }


        public static TitleList SelectAllTitles()
        {
            try{
                return DatatabletoTitleList(manager.ExecuteDataTable("SelectAllTitles"));
                //throw new NotImplementedException();
            }catch{
                return new TitleList();
            }
        }
        #region Mapping Functions
        internal static TitleList DatatabletoTitleList(DataTable dt)
        {
          TitleList titlels= new();
            try
            {
                foreach(DataRow row in dt.Rows)
                    titlels.Add(DataRowtoTitle(row));
                
            }
            catch
            {

            }
            return titlels ;

        }
        internal static Titile DataRowtoTitle(DataRow dr)
        {
            Titile t=new Titile();
            try
            {
                //if (int.TryParse(dr["title_id"]?.ToString()??"-1",out int tempint))
                t.Title_id = dr["title_id"]?.ToString()??"NA";
                t.Title = dr["title"]?.ToString() ?? "NA";
                if (int.TryParse(dr["royalty"]?.ToString() ?? "-1", out int tempint))
                    t.Royalty = tempint;
                if (int.TryParse(dr["ytd_sales"]?.ToString() ?? "-1", out tempint))
                    t.Ytd_sales = tempint;
                if (decimal.TryParse(dr["price"]?.ToString() ?? "-1", out decimal tempint1))
                    t.Price = tempint1;
                if (decimal.TryParse(dr["advance"]?.ToString() ?? "-1", out  tempint1))
                    t.Advance = tempint1;
                t.Notes = dr["notes"]?.ToString()??"NA";
                t.Type = dr["type"]?.ToString() ?? "NA";
                t.Pub_id = dr["pub_id"]?.ToString() ?? "NA";
                if (DateTime.TryParse(dr["pubdate"]?.ToString() ?? "-1", out DateTime tempint2))
                    t.Pubdate = tempint2;

                t.State = EntityState.UnChanged;
            }
            catch
            {

            }
            return t;
        }

        #endregion
    }
}
