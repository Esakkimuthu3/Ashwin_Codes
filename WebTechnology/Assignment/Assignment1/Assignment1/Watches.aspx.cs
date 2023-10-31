using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_1
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Populate the dropdown list with items
                ddlItems.Items.Add(new ListItem("Graff Diamond's Hallucination", "Graff Diamond's Hallucination.png"));
                ddlItems.Items.Add(new ListItem("Patek Philippe Grandmaster Chime", "Patek Philippe Grandmaster Chime.png"));
                ddlItems.Items.Add(new ListItem("Bugatti Chiron", "Bugatti Chiron.png"));
                ddlItems.Items.Add(new ListItem("Rolex Submariner", "Rolex Submariner.png"));
                ddlItems.Items.Add(new ListItem("Patek Philippe Henry Graves Supercomplication", "Patek Philippe Henry Graves Supercomplication.png"));
            }
        }
        protected void ddlItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Set the image URL based on the selected item
            string selectedImageUrl = ddlItems.SelectedItem.Value;
            imgItem.ImageUrl = $"Images/{selectedImageUrl}";
        }

        protected void btnShowCost_Click(object sender, EventArgs e)
        {
            // Get the cost of the selected item (You can replace this with your actual cost logic)
            string selectedItem = ddlItems.SelectedItem.Text;
            string cost = GetItemCost(selectedItem);

            lblCost.Text = $"Cost of {selectedItem}: {cost}";
        }

        // You can implement your own cost retrieval logic here
        private string GetItemCost(string item)
        {
            // Replace this with your cost retrieval logic
            switch (item)
            {
                case "Graff Diamond's Hallucination":
                    return "Rs.28C";
                case "Patek Philippe Grandmaster Chime":
                    return "Rs.20C";
                case "Bugatti Chiron":
                    return "Rs.21.7C";
                case "Rolex Submariner":
                    return "Rs.57L";
                case "Patek Philippe Henry Graves Supercomplication":
                    return "Rs.5C";
                default:
                    return "N/A";
            }
        }

    }
}