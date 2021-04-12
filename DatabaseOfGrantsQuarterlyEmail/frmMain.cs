using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using DatabaseOfGrantsQuarterlyEmail.Properties;
using GrantsIdentification;

namespace DatabaseOfGrantsQuarterlyEmail
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        // button1 used for testing, added SendEmail function during testing
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void SendEmail()
        {
            GIDB db = new GIDB();
            DataSet ds = new DataSet();
            ds = db.SelectAllGrantsNearDue();

            // Set up an html table and fill with data from SQL for the email body
            string textBody = " <table border=" + 1 + " cellpadding=" + 0 + " cellspacing=" + 0 + " width = " + 400 + " ><tr bgcolor='#4da6ff'><td><b>Program Name</b></td> <td> <b>Grant Subject</b> </td> <td> <b>Due Date</b> </td>  <td> <b>Fed/State</b> </td></tr>";
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                textBody += "<tr> <center> <td>" + ds.Tables[0].Rows[i]["ProgramName"] + "</td><td> " + ds.Tables[0].Rows[i]["GrantSubject"] + "</td><td>" + ((DateTime)ds.Tables[0].Rows[i]["DueDate"]).ToString("MM/dd/yyyy") + "</td><td> " + ds.Tables[0].Rows[i]["FedState"] + " </td> </center> </tr>";
            }
            textBody += "</table>";

            Settings settings = new Settings();
            MailMessage message = new MailMessage
            {
                From = new MailAddress("no-response@menv.com")
            };

            /*
             * Grab the list of recipients from the EmailList xml file and add them to the mailaddress to
             * XML document allows us to change addresses without updating the application
             * File Name = "EmailList.config.xml"
             * Node Used = <Email>
             * Add or edit email addresses using the node above
            */
            XmlDocument doc = new XmlDocument();
            doc.Load("EmailList.config.xml");
            XmlNodeList elemList = doc.GetElementsByTagName("Email");
            for (int i = 0; i < elemList.Count; i++)
            {
                Console.WriteLine(elemList[i].InnerXml);
                message.To.Add(new MailAddress(elemList[i].InnerXml));
            }

            message.Subject = "Database of Grants - Upcoming Near Due Grants";
            message.Body = textBody;
            // IsBodyHtml is necessary to produce an HTML table in the email
            message.IsBodyHtml = true;

            SmtpClient client = new SmtpClient(settings.SMTPClient);
            client.Send(message);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                SendEmail();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Close();
            }

        }

    }
}
