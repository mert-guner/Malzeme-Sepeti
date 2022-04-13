using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using insaatSepeti.Class;
using Dapper;
using System.Data.SqlClient;

namespace insaatSepeti
{
    public partial class LoginEkranı : MaterialForm
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );

        SqlConnection sqlcon = new SqlConnection(@"Data Source=LAPTOP-4ADVPLF2;Initial Catalog=Betoncum;Integrated Security=True");

        public LoginEkranı()
        {
            InitializeComponent();
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = false;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, 
                Accent.Orange200, TextShade.WHITE);
            
        }

        MaterialSkinManager material = MaterialSkinManager.Instance;
        private void LoginEkranı_Load(object sender, EventArgs e)
        {
      


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #region Kullanıcı Giriş Buton Hareketi

        
        // kullanıcı Giriş Buton
        private void button2_Click(object sender, EventArgs e)
        {
            
                panelKullanici.Left -= 260;
                panelFirma.Left -= 260;
                panelKullanici.Visible = true;
                panelFirma.Visible = false;
                
            
            
        }
        #endregion

        #region Kurumsal Giriş Buton Hareketi

        
        // Kurumsal giriş Buton
        private void button3_Click(object sender, EventArgs e)
        {
            
                panelKullanici.Left += 260;
                panelFirma.Left += 260;
                panelKullanici.Visible = false;
                panelFirma.Visible = true;
                
            
            
        }
        #endregion


        int a;


        // Firma giriş butonu
        private void btnFirmaGiris_Click(object sender, EventArgs e)
        {
            using (SqlCommand cmd = new SqlCommand("firmagirisi", sqlcon))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@kullaniciadi", txtFirmaAdi.Text);
                    cmd.Parameters.AddWithValue("@sifresi", txtFirmaSifre.Text);

                    SqlParameter outPutParameter = new SqlParameter();
                    outPutParameter.ParameterName = "@id";
                    outPutParameter.SqlDbType = System.Data.SqlDbType.Int;
                    outPutParameter.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(outPutParameter);
                    sqlcon.Open();
                    cmd.ExecuteNonQuery();

                    if (outPutParameter.Value.ToString() == "0")
                    {
                        MessageBox.Show("BU KULLANICI MEVCUT DEĞİL LÜTFEN ÜYE OLUNUZ");

                    }

                    else
                    {
                        MessageBox.Show("Giriş Başarılı");
                        textBox5.Text = outPutParameter.Value.ToString();
                        a = Convert.ToInt32(textBox5.Text);
                        FirmaPanel firmaPanel = new FirmaPanel(a);
                        this.Hide();
                        firmaPanel.Show();
                    }
                    sqlcon.Close();

                }
                catch (Exception ex)
                {
                    var sqlException = ex.InnerException as SqlException;
                    if (sqlException is null)
                    {
                        MessageBox.Show("Bu Kullanıcı Mevcut");
                    }

                }
            }
        }


        // firma üye ol butonu
        private void btnFirmaUyeol_Click(object sender, EventArgs e)
        {
            using (SqlCommand cmd = new SqlCommand("uyeol", sqlcon))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@kullaniciadi", txtFirmaAdi.Text);
                    cmd.Parameters.AddWithValue("@sifresi", txtFirmaSifre.Text);

                    SqlParameter outPutParameter = new SqlParameter();
                    outPutParameter.ParameterName = "@id";
                    outPutParameter.SqlDbType = System.Data.SqlDbType.Int;
                    outPutParameter.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(outPutParameter);
                    sqlcon.Open();
                    cmd.ExecuteNonQuery();
                    if (outPutParameter.Value.ToString() == "1")
                    {
                        MessageBox.Show("Aynı kullanıcı adı daha önce alınmış");
                    }
                    else
                    {
                        MessageBox.Show("Kayıt Başarılı");

                        FirmaUyelik firmaUyelik = new FirmaUyelik();
                        this.Hide();
                        firmaUyelik.Show();

                    }
                    sqlcon.Close();

                }
                catch (Exception ex)
                {
                    var sqlException = ex.InnerException as SqlException;
                    if (sqlException is null)
                    {
                        MessageBox.Show("Bu Kullanıcı Mevcut");
                    }

                }



            }
        }

        // kullanıcı giriş butonu
        private void btnKullaniciGiris_Click(object sender, EventArgs e)
        {
            using (SqlCommand cmd = new SqlCommand("kullanicigirisi", sqlcon))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@kullaniciadi", txtKullaniciAdi.Text);
                    cmd.Parameters.AddWithValue("@sifre", txtKullaniciSifre.Text);

                    SqlParameter outPutParameter = new SqlParameter();
                    outPutParameter.ParameterName = "@id";
                    outPutParameter.SqlDbType = System.Data.SqlDbType.Int;
                    outPutParameter.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(outPutParameter);
                    sqlcon.Open();
                    cmd.ExecuteNonQuery();
                    if (outPutParameter.Value.ToString() == "0")
                    {
                        MessageBox.Show("BU KULLANICI MEVCUT DEĞİL LÜTFEN ÜYE OLUNUZ");
                    }
                    else
                    {
                        MessageBox.Show("Giriş Başarılı");
                        textBox5.Text = outPutParameter.Value.ToString();
                        a = Convert.ToInt32(textBox5.Text);
                        Form1 form1 = new Form1(a);
                        this.Hide();
                        form1.Show();

                    }
                    sqlcon.Close();

                }
                catch (Exception ex)
                {
                    var sqlException = ex.InnerException as SqlException;
                    if (sqlException is null)
                    {
                        MessageBox.Show("Bu Kullanıcı Mevcut");
                    }

                }
            }
        }

        // kullanıcı üye ol butonu
        private void btnKullaniciUyeol_Click(object sender, EventArgs e)
        {

            using (SqlCommand cmd = new SqlCommand("kullaniciuyeol", sqlcon))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@kullaniciadi", txtKullaniciAdi.Text);
                    cmd.Parameters.AddWithValue("@sifre", txtKullaniciSifre.Text);

                    SqlParameter outPutParameter = new SqlParameter();
                    outPutParameter.ParameterName = "@id";
                    outPutParameter.SqlDbType = System.Data.SqlDbType.Int;
                    outPutParameter.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(outPutParameter);
                    sqlcon.Open();
                    cmd.ExecuteNonQuery();
                    if (outPutParameter.Value.ToString() == "1")
                    {
                        MessageBox.Show("Aynı kullanıcı adı daha önce alınmış");
                    }
                    else
                    {
                        MessageBox.Show("Kayıt Başarılı");

                        MusteriUyelik musteriUyelik = new MusteriUyelik();
                        this.Hide();
                        musteriUyelik.Show();

                    }
                    sqlcon.Close();

                }
                catch (Exception ex)
                {
                    var sqlException = ex.InnerException as SqlException;
                    if (sqlException is null)
                    {
                        MessageBox.Show("Bu Kullanıcı Mevcut");
                    }

                }
            }
        }
        #region MyRegion
        //if (e.KeyCode == Keys.Enter)
        //    {
        //        btnFirmaGiris.PerformClick();
        //    }
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        btnKullaniciGiris.PerformClick();
        //    }
        #endregion

        #region Enter ile giriş yapma




        #endregion

        private void LoginEkranı_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnFirmaGiris.PerformClick();
            }
            if (e.KeyCode == Keys.Enter)
            {
                btnKullaniciGiris.PerformClick();
            }
        }
    }
}
