using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IntegratedMessages;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        btnSendMessage.Click += new EventHandler(btnSendMessage_Click);
    }

    void btnSendMessage_Click(object sender, EventArgs e)
    {
        //new IntegratedMessageSender().SendMessage("NEW_USER", "Username:ABC,Password:XYZ", "9041863630");
        //new IntegratedMessageSender().SendMessage("QUARTER_ALLOTTED", "12345", "9041863630");
        new IntegratedMessageSender().SendMessage("GUEST_HOUSE_BOOKING", "BMS Guest House", "9041863630");

    }
}