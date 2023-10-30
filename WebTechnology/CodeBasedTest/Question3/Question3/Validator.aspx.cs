using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Question3
{
    public partial class Validator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //string script = "window.open('http://www.example.com', '_self', 'width=500,height=500')";
            //script += "?Name=" + txtName.Text;
            //script += "&FamilyName=" + txtFamilyName.Text;
            //script += "&Address=" + txtAddress.Text;
            //script += "&City=" + txtCity.Text;
            //script += "&ZipCode=" + txtZipCode.Text;
            //script += "&Phone=" + txtPhone.Text;
            //script += "&Email=" + txtEmail.Text;

            //ClientScript.RegisterStartupScript(this.GetType(), "openwindow", script, true);

            string name = txtName.Text;
            string familyName = txtFamilyName.Text;
            string address = txtAddress.Text;
            string city = txtCity.Text;
            string zipCode = txtZipCode.Text;
            string phone = txtPhone.Text;
            string email = txtEmail.Text;


            
            string resultMessage = $@"Name: {name}<br />
                                     Family Name: {familyName}<br />
                                     Address: {address}<br />
                                     City: {city}<br />
                                     Zip Code: {zipCode}<br />
                                     Phone: {phone}<br />
                                     Email: {email}<br />";

           
            resultLabel.Text = resultMessage;
        }
    }

}
   