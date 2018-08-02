using HCM.WebApp.BLL.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HCM.WebApp.UC
{
    public partial class ucLocation : UserControlCommon
    {
        public string Lat
        {
            get
            {
                return hfLat.Value;
            }
            set
            {
                txtLat.Text = value;
                hfLat.Value = value;
            }
        }
        public string Lng
        {
            get
            {
                return hfLng.Value;
            }
            set
            {
                txtLng.Text = value;
                hfLng.Value = value;
            }
        }
        public int Zoom
        {
            get
            {
                int i = 12;
                int.TryParse(hfZoom.Value, out i);
                return i;
            }
            set
            {
                hfZoom.Value = value.ToString();
            }
        }
        public string Name { get; set; }
        public string Desc { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}