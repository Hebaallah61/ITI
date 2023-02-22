using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Entity
{
    public class Titile:EntityBase
    {

        string title_id;
        string title;
        string type;
        string pub_id;
        decimal? price;
        decimal? advance;
        int? royalty;
        int? ytd_sales;
        string? notes;
        DateTime pubdate;
        public string Title_id{ get=>title_id; set { if(value!=title_id) {  this.State = EntityState.Changed; title_id = value; } } }
        public string Title { get=>title; set { if (value != title) { if (this.State != EntityState.Add) this.State = EntityState.Changed; title = value; } } }
        public string Type { get => type; set { if (value != type) { if (this.State != EntityState.Add) this.State = EntityState.Changed; type = value; } } }
        public string Pub_id { get => pub_id; set { if (value != pub_id) { if (this.State != EntityState.Add) this.State = EntityState.Changed; pub_id = value; } } }
        public decimal? Price { get => price; set { if (value != price) { if (this.State != EntityState.Add) this.State = EntityState.Changed; price = value; } } }
        public decimal? Advance { get => advance; set { if (value != advance) { if (this.State != EntityState.Add) this.State = EntityState.Changed; advance = value; } } }
        public int? Royalty { get => royalty; set { if (value != royalty) { if (this.State != EntityState.Add) this.State = EntityState.Changed; royalty = value; } } }
        public int? Ytd_sales { get => ytd_sales; set { if (value != ytd_sales) { if (this.State != EntityState.Add) this.State = EntityState.Changed; ytd_sales = value; } } }
        public string? Notes { get => notes; set { if (value != notes) { if (this.State != EntityState.Add) this.State = EntityState.Changed; notes = value; } } }
        public DateTime Pubdate { get => pubdate; set { if (value != Pubdate) { if (this.State != EntityState.Add) this.State = EntityState.Changed; pubdate = value; } } }

       

    }
}
