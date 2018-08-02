using HCM.WebApp.BLL.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HCM.WebApp.UC
{
    public partial class ucAlertMessage : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["AlertMessageMsgStrong"] != null && Session["AlertMessageMsg"] != null && Session["AlertMessageMsgType"] != null)
                {
                    Common.msgType msgType = Common.msgType.alertMessageDefault;
                    Enum.TryParse(Session["AlertMessageMsgType"].ToString(), true, out msgType);

                    AlertMessage(Session["AlertMessageMsgStrong"].ToString(), Session["AlertMessageMsg"].ToString(), msgType);

                    Session["AlertMessageMsgStrong"] = null;
                    Session["AlertMessageMsg"] = null;
                    Session["AlertMessageMsgType"] = null;
                }
            }
        }
        public void Clear()
        {
            divMsg.Visible = false;
            lblMsg.Text = String.Empty;
            lblMsgStrong.Text = String.Empty;
        }
        public void AlertMessage(string msgStrong, string msg, Common.msgType typ, string url)
        {
            Session["AlertMessageMsgStrong"] = msgStrong;
            Session["AlertMessageMsg"] = msg;
            Session["AlertMessageMsgType"] = typ;

            HttpContext.Current.Response.Redirect(url, true);
        }
        public void AlertMessage(string msgStrong, string msg, Common.msgType typ)
        {
            string cls = "";
            lblMsgStrong.Text = msgStrong;
            lblMsg.Text = msg;
            switch (typ)
            {
                case Common.msgType.alertMessageInfo:
                    cls = "alert alert-dismissible alert-info";
                    break;
                case Common.msgType.alertMessageWarning:
                    cls = "alert alert-dismissible alert-warning";
                    break;
                case Common.msgType.alertMessageSuccess:
                    cls = "alert alert-dismissible alert-success";
                    break;
                case Common.msgType.alertMessageDanger:
                    cls = "alert alert-dismissible alert-danger";
                    break;
                case Common.msgType.alertMessageDefault:
                    cls = "alert-dismissible alert-primary";
                    break;
                default:
                    cls = "alert alert-minimal";
                    break;
            }
            divMsg.Visible = true;
            divMsg.Attributes.Remove("class");
            divMsg.Attributes.Add("class", cls);
        }
    }
}