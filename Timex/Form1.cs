using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using ZXing;
using ZXing.Common;
using ZXing.QrCode.Internal;
using ZXing.Rendering;
using AForge.Video.DirectShow;
using AForge.Video;
using MailKit.Net.Smtp;
using MimeKit;
using System.Threading;
using Microsoft.Office.Interop.Excel;


namespace Timex
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public static string id;

        SqlDataReader dr;

        System.Data.DataTable dt;

        public int loggedin { get; set; }
        public int UserID { get; set; }
       
        public string UserName { get; set; }
        public Form1()
        {
            InitializeComponent();
            loggedin = 0;
            

           
        }
        private FilterInfoCollection FilterInfoCollection;
        private VideoCaptureDevice capturedevice;
        

        private void Form1_Load(object sender, EventArgs e)
        {
  
        }


        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void metroTabPage2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Activated(object sender, EventArgs e)
        {

            pictureBox9.Visible = false;

            if (loggedin == 0)
            {
                Login newlogin = new Login();
                newlogin.ShowDialog();

                if (newlogin.loginflag == false)
                {
                    Close();
                }
                else
                {
                    UserID = newlogin.UserID;


                    if (UserID == 1)
                    {
                        metroTabControl1.Controls.Remove(Attendence);

                    }
                    else if (UserID == 2)
                    {

                        metroTabControl1.Controls.Remove(Manage_Employee);
                        metroTabControl1.Controls.Remove(New_Registration);
                        metroTabControl1.Controls.Remove(Attendence);
                        metroTabControl1.Controls.Remove(View_Reports);
                        
                        


                    }
                    else if (UserID == 3)
                    {
                        metroTabControl1.Controls.Remove(Manage_Employee);
                        metroTabControl1.Controls.Remove(New_Registration);

                        metroTabControl1.Controls.Remove(Covid_Tracking);
                       
                    }
                    else
                    {

                    }

                    loggedin = 1;

                }




            }

        }
        private void metroLabel2_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void metroButton5_Click(object sender, EventArgs e)
        {

        }

        private void Attendence_ControlAdded(object sender, ControlEventArgs e)
        {
         
        }
        private void metroTabPage4_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel15_Click(object sender, EventArgs e)
        {

        }

        private void metroComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void metroLabel18_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel20_Click(object sender, EventArgs e)
        {

        }

        private void metroTabPage7_Click(object sender, EventArgs e)
        {

        }

        private void metroButton7_Click(object sender, EventArgs e)
        {

        }
        private void Attendence_Enter(object sender, EventArgs e)
        {

         

            capturedevice = new VideoCaptureDevice(FilterInfoCollection[comboBox1.SelectedIndex].MonikerString);
            capturedevice.NewFrame += Capturedevice_newframe;

            capturedevice.Start();
            timer1.Start();

        }
        private void metroTile7_Click(object sender, EventArgs e)
        {
       
        }

        private void Attendence_Leave(object sender, EventArgs e)
        {

            if (capturedevice.IsRunning)
            {
                capturedevice.Stop();
            }


        }



        private void metroTile1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=Timex;Integrated Security=True");
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("select * from Emloyee where ID=@ID ", conn))
                {
                    cmd.Parameters.AddWithValue("ID", int.Parse(tbID.Text));
                    
                    SqlDataAdapter show = new SqlDataAdapter(cmd);
                     dt = new System.Data.DataTable();
                    show.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
  





            }
            catch
            {
                MessageBox.Show("not valid");
            }


        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            tbEmail.Clear();
            tbID.Clear();
            tbName.Clear();
            comboBox3.Text = "";

        }

        private void metroTextBox6_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void metroTile6_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=Timex;Integrated Security=True");
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into [Emloyee] values(@ID, @Name, @Email, @Department)", conn);
                cmd.Parameters.AddWithValue("@ID", int.Parse(metroTextBox8.Text));
                cmd.Parameters.AddWithValue("@Name", metroTextBox9.Text);
                cmd.Parameters.AddWithValue("@Email", metroTextBox10.Text);
                cmd.Parameters.AddWithValue("@Department", comboBox2.Text);

                cmd.ExecuteNonQuery();


                conn.Close();
                MessageBox.Show("success");
            }
            catch
            {
                MessageBox.Show("Failed");
            }


        }

        private void metroTile10_Click(object sender, EventArgs e)
        {
            metroTextBox8.Text = string.Empty;
            metroTextBox9.Text = string.Empty;
            metroTextBox10.Text = string.Empty;
            comboBox2.Text = string.Empty;
            



        }

        private void metroTile6_Click_1(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=Timex;Integrated Security=True");
            conn.Open();

            using (SqlCommand cmd = new SqlCommand("select * from Emloyee where Name=@Name ", conn))
            {
                cmd.Parameters.AddWithValue("@name", tbName.Text);

                SqlDataAdapter show = new SqlDataAdapter(cmd);
                
                  dt = new System.Data.DataTable();
                show.Fill(dt);
                dataGridView1.DataSource = dt;
            }




        }


        private void metroTile11_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=Timex;Integrated Security=True");
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("select * from Emloyee where Department=@Department ", conn))
            {
                cmd.Parameters.AddWithValue("@department", comboBox3.Text);
                
                SqlDataAdapter show = new SqlDataAdapter(cmd);
                 dt = new System.Data.DataTable();
                show.Fill(dt);
                dataGridView1.DataSource = dt;
            }

        }

        private void metroTile12_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=Timex;Integrated Security=True");
            conn.Open();

            using (SqlCommand cmd = new SqlCommand("select * from Emloyee where Email=@Email ", conn))
            {
                cmd.Parameters.AddWithValue("@email", tbEmail.Text);
                
                SqlDataAdapter show = new SqlDataAdapter(cmd);
                dt = new System.Data.DataTable();
                show.Fill(dt);
                dataGridView1.DataSource = dt;
            }

        }

        private void metroTile2_Click_1(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=Timex;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("Update Emloyee set Name=@Name, Email=@Email, Department=@Department where ID=@ID ", conn);
            cmd.Parameters.AddWithValue("@ID", int.Parse(tbID.Text));
            cmd.Parameters.AddWithValue("@Name", tbName.Text);
            cmd.Parameters.AddWithValue("@Email", tbEmail.Text);
            cmd.Parameters.AddWithValue("@Department", comboBox3.Text);
            cmd.ExecuteNonQuery();

            conn.Close();
            MessageBox.Show("success");



        }

        private void metroTile4_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=Timex;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("Delete Emloyee where ID=@ID ", conn);
            cmd.Parameters.AddWithValue("@ID", int.Parse(tbID.Text));
            cmd.ExecuteNonQuery();

            conn.Close();
            MessageBox.Show("success");
        }

        private void metroTile13_Click(object sender, EventArgs e)
        {
            id = tbID.Text;
            QR_GENARATE form = new QR_GENARATE();
            form.ShowDialog();


          
        }

        private void metroTile14_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void metroTextBox8_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBox8_TextChanged(object sender, EventArgs e)
        {
            try
            {
                BarcodeWriter qrWriter = new BarcodeWriter();
                EncodingOptions encodingOptions = new EncodingOptions() { Width = 300, Height = 300, Margin = 0, PureBarcode = false };
                encodingOptions.Hints.Add(EncodeHintType.ERROR_CORRECTION, ErrorCorrectionLevel.H);
                qrWriter.Renderer = new BitmapRenderer();
                qrWriter.Options = encodingOptions;
                qrWriter.Format = BarcodeFormat.QR_CODE;
                Bitmap bitmap = qrWriter.Write(metroTextBox8.Text);
                NEW_QR.Image = bitmap;
            }
            catch
            {
                NEW_QR.Image = null;
            }
        }

        private void New_Registration_Click(object sender, EventArgs e)
        {

        }

        private void metroTile5_Click(object sender, EventArgs e)
        {

            SaveFileDialog imagesave = new SaveFileDialog();
            imagesave.Filter = "JPG(*.JPG)|*.jpg";

            if (imagesave.ShowDialog() == DialogResult.OK)
            {
                NEW_QR.Image.Save(imagesave.FileName);
            }
        }

        private void metroTile14_Click_1(object sender, EventArgs e)
        {

        }

        private void Capturedevice_newframe(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //DateTime dateTimeVariable = DateTime.Now;

            //metroLabel11.Text = dateTimeVariable.ToString("HH:mm:ss");

            //metroLabel3.Text = dateTimeVariable.ToString("YYYYMMDD");

            try
            {

                if (pictureBox1.Image != null)
                {
                    BarcodeReader barcodereader = new BarcodeReader();
                    Result result = barcodereader.Decode((Bitmap)pictureBox1.Image);
                    if (result != null)
                    {

                        readID.Text = result.ToString();

                        timer1.Stop();
                        //if (capturedevice.IsRunning)
                        //    capturedevice.Stop();

                        SqlConnection connn = new SqlConnection("Data Source=.;Initial Catalog=Timex;Integrated Security=True");
                        connn.Open();
                        SqlCommand cmd = new SqlCommand("insert into [Attendance] values(@EmployeeID, @Date)", connn);
                        cmd.Parameters.AddWithValue("@EmployeeID", int.Parse(readID.Text));
                        //cmd.Parameters.AddWithValue("ftime", metroLabel11.Text);
                        cmd.Parameters.AddWithValue("@Date", dateTimePicker2.Text);
                        int p = cmd.ExecuteNonQuery();
                        connn.Close();
                        readID.Text = "";

                        MessageBox.Show("success");

                        if (p > 0)
                        {
                            timer1.Start();
                        }





                    }
                }
            }
            catch
            {
                MessageBox.Show("not valid");
            }



        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            


        }

        private void New_Registration_Leave(object sender, EventArgs e)
        {

        }

        private void metroTile7_Click_1(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=Timex;Integrated Security=True");
            
            SqlCommand cmd = new SqlCommand("select Attendance.EmployeeID, Attendance.Date, Emloyee.Name, Emloyee.Department from Emloyee INNER JOIN Attendance ON Emloyee.ID=Attendance.EmployeeID where ID=@ID And Date=@Date", conn);
            conn.Open();
            cmd.Parameters.AddWithValue("@ID", int.Parse(metroTextBox2.Text));
            cmd.Parameters.AddWithValue("@Date", dateTimePicker1.Text);

            cmd.ExecuteNonQuery();

            dt = new System.Data.DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            sqlDataAdapter.Fill(dt);
            dataGridView2.DataSource = dt;
            conn.Close();


        }

        private void readID_Click(object sender, EventArgs e)
        {

        }

        private void metroTile14_Click_2(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=Timex;Integrated Security=True");

            SqlCommand cmd = new SqlCommand("select Attendance.EmployeeID, Attendance.Date, Emloyee.Name, Emloyee.Department from Emloyee INNER JOIN Attendance ON Emloyee.ID=Attendance.EmployeeID where Date=@Date", conn);
            conn.Open();
            cmd.Parameters.AddWithValue("@Date", dateTimePicker3.Text);

            cmd.ExecuteNonQuery();

            dt = new System.Data.DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            sqlDataAdapter.Fill(dt);
            dataGridView2.DataSource = dt;
            conn.Close();
        }

        private void metroTile15_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=Timex;Integrated Security=True");

            SqlCommand cmd = new SqlCommand("select Attendance.EmployeeID, Attendance.Date, Emloyee.Name, Emloyee.Department from Emloyee INNER JOIN Attendance ON Emloyee.ID=Attendance.EmployeeID where Department=@Department And Date=@Date ", conn);
            conn.Open();
            cmd.Parameters.AddWithValue("@Department", comboBox4.Text);
            
            cmd.Parameters.AddWithValue("@Date", dateTimePicker1.Text);

            cmd.ExecuteNonQuery();

            dt = new System.Data.DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            sqlDataAdapter.Fill(dt);
            dataGridView2.DataSource = dt;
            conn.Close();

        }

        private void Covid_Tracking_Click(object sender, EventArgs e)
        {

        }
        
        private void metroTile16_Click(object sender, EventArgs e)
        {
            //try
            //{
                SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=Timex;Integrated Security=True");

                using (SqlCommand cmd = new SqlCommand("select max(Date) From Attendance Where EmployeeID=@ID ", conn))
                {
                  
                        conn.Open();
                        cmd.Parameters.AddWithValue("@ID", int.Parse(metroTextBox5.Text));
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            string value = result.ToString();
                            metroTextBox6.Text = value.ToString();
                        }
                

                 

            
                    
            


                }
                using (SqlCommand cmd = new SqlCommand("select Department from Emloyee where ID=@ID ", conn))
                {
                    cmd.Parameters.AddWithValue("@ID", int.Parse(metroTextBox5.Text));
                    object result = cmd.ExecuteScalar();


                    if (result != null)
                    {
                        string value = result.ToString();
                        metroTextBox7.Text = value.ToString();
                    }
                }

                
                using (SqlCommand cmd1 = new SqlCommand("select Emloyee.Email from Emloyee INNER JOIN Attendance ON Emloyee.ID=Attendance.EmployeeID where Date=@Date And Department=@Department And Not ID=@ID", conn))
                {
                    cmd1.Parameters.AddWithValue("@ID", int.Parse(metroTextBox5.Text));
                    cmd1.Parameters.AddWithValue("@Date", metroTextBox6.Text);
                    cmd1.Parameters.AddWithValue("@Department", metroTextBox7.Text);

                    listBox1.Items.Clear();
                     dr = cmd1.ExecuteReader();
                        while (dr.Read())
                        {
                            

                            listBox1.Items.Add(dr["email"]);
                            



                        }
                     conn.Close();






                //string line = cmd1.ExecuteReader().ToString();
                //while (line  != null)
                //{
                //    listBox1.Items.Add(line);
                //}






            }


            //}

            
            //catch
            //{
            //    MessageBox.Show("Inset Correctly");
            //}




        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                CheckForIllegalCrossThreadCalls = false;
                SmtpClient client = new SmtpClient();
                client.Timeout = 50000;
                client.AuthenticationMechanisms.Remove("xoauth2");

                BodyBuilder builder = new BodyBuilder();
                builder.HtmlBody = metroTextBox11.Text;

                MimeMessage mail = new MimeMessage();
                mail.Subject = metroTextBox12.Text;
                mail.Body = builder.ToMessageBody();

                client.Connect("smtp.gmail.com", int.Parse("465"), true);
                client.Authenticate("minuda6212@gmail.com", "euydvxbqcgnvqfdd");



                foreach (string item in listBox1.Items)
                {

                    mail.From.Add(new MailboxAddress("minuda", "minuda6212@gmail.com"));
                    mail.To.Add(new MailboxAddress("", item));


                    client.Send(mail);

                    Thread.Sleep(1000);

                }

                client.Disconnect(true);
            }
            catch
            {
                MessageBox.Show("email not sent");
                
            }






        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            metroTile17.Enabled = true;
            pictureBox9.Visible = false;
            MessageBox.Show("done");
        }

        private void metroTile17_Click(object sender, EventArgs e)
        {
            metroTile17.Enabled = false;
            pictureBox9.Visible = true;

            backgroundWorker1.RunWorkerAsync();
        }

        private void metroLabel11_Click(object sender, EventArgs e)
        {

        }

        private void metroTile8_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=Timex;Integrated Security=True");

            SqlCommand cmd = new SqlCommand("select Attendance.EmployeeID, Attendance.Date, Emloyee.Name, Emloyee.Department from Emloyee INNER JOIN Attendance ON Emloyee.ID=Attendance.EmployeeID where Department=@Department ", conn);
            conn.Open();
            cmd.Parameters.AddWithValue("@Department", comboBox5.Text);

            

            cmd.ExecuteNonQuery();

            dt = new System.Data.DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            sqlDataAdapter.Fill(dt);
            dataGridView2.DataSource = dt;
            conn.Close();
        }

        private void metroTile9_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=Timex;Integrated Security=True");

            SqlCommand cmd = new SqlCommand("select Attendance.EmployeeID, Attendance.Date, Emloyee.Name, Emloyee.Department from Emloyee INNER JOIN Attendance ON Emloyee.ID=Attendance.EmployeeID where ID=@ID", conn);
            conn.Open();
            cmd.Parameters.AddWithValue("@ID", int.Parse(metroTextBox3.Text));

            cmd.ExecuteNonQuery();

            dt = new System.Data.DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            sqlDataAdapter.Fill(dt);
            dataGridView2.DataSource = dt;
            conn.Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            
        }

        private void metroTile18_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application Excel = new Microsoft.Office.Interop.Excel.Application();
            Workbook wb = Excel.Workbooks.Add(XlSheetType.xlWorksheet);
            Worksheet ws = (Worksheet)Excel.ActiveSheet;
            Excel.Visible = true;

            for(int i = 1; i < dataGridView2.Columns.Count + 1; i++)
            {
                ws.Cells[1, i] = dataGridView2.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
            {
                for (int j = 0; j< dataGridView2.Columns.Count ; j++)
                {
                    ws.Cells[i + 2, j + 1] = dataGridView2.Rows[i].Cells[j].Value.ToString();            
                }

            }

        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void View_Reports_Click(object sender, EventArgs e)
        {

        }
    }
    
}
