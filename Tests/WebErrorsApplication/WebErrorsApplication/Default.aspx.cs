using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebErrorsApplication
{
    public partial class _Default : Page
    {
        protected int roomSize = 100;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ErrorLabel.Visible = false;
            int width, length = 0;
            double numTiles;
            try
            {
                if (int.TryParse(Width.Text, out width) && int.TryParse(Length.Text, out length))
                {
                    numTiles = CalculateNumberOfTiles(width, length);
                    Quantity.Text = numTiles.ToString();
                }
                else
                    throw new Exception($"Invalid input width = {Width.Text} and/or length={Length.Text}. Please enter valid integers for width and length.");
            }
            catch (Exception ex)
            {
                // Log the exception or display an error message to the user
                Logs.logErrors(ex.Message);
                ErrorLabel.Text = ex.Message;
                ErrorLabel.Visible = true;

            }
        }

        protected double CalculateNumberOfTiles(int width, int length)
        {
            int area, numTiles = 0;
            try
            {
                Debug.Assert((width != 0) || (length != 0), "Width and length must be non-zero values.");
                area = width * length;
                numTiles = roomSize / area;
                Contract.Ensures(numTiles > 0, "Number of tiles must be positive.");
            }
            catch (DivideByZeroException divex)
            {
                // Log the exception or display an error message to the user
                Logs.logErrors(divex.Message);
                ErrorLabel.Text = "Value Cannot be Zero!\n" + divex.Message;
                ErrorLabel.Visible = true;
                numTiles = -1;
            }
            catch(ArithmeticException arex)
            {
                // Log the exception or display an error message to the user
                Logs.logErrors(arex.Message);
                ErrorLabel.Text = "Calculation error!\n" + arex.Message;
                ErrorLabel.Visible = true;
                numTiles = -1;
            }
            catch(Exception ex)
            {
                // Log the exception or display an error message to the user
                string strError = "Error in CalculateNumberOfTiles\n" + ex.Message + "\n"; 
                strError += "Stack Trace: "+ex.StackTrace.ToString() + "\n";
                strError += "Date/Time: " + DateTime.Now.ToString();
                Logs.logErrors(strError);   
                ErrorLabel.Text = strError;
                ErrorLabel.Visible = true;
                numTiles = -1;
            }
            return numTiles;
        }
    }
}