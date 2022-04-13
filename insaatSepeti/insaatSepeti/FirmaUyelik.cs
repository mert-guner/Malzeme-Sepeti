using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MaterialSkin;
using System.Data.SqlClient;
using Dapper;
using insaatSepeti.Class;

namespace insaatSepeti
{
    public partial class FirmaUyelik : MaterialForm
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
        public FirmaUyelik()
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

        SqlConnection sqlcon = new SqlConnection(@"Data Source=LAPTOP-4ADVPLF2;Initial Catalog=Betoncum;Integrated Security=True");

        private void FirmaUyelik_Load(object sender, EventArgs e)
        {
            il();
            ilce();
            trigger();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {

            sqlcon.Open();

            using (SqlCommand komut = new SqlCommand())
            {
                komut.Connection = sqlcon;
                komut.CommandType = CommandType.Text;
                komut.CommandText = "insert into FirmaDetay(FirmaAdi,İl,İlçe,Telefon, Email, FirmaID) values(@firmaAdi,@il,@ilce,@Telefon,@Email,@firmaid)";

                komut.Parameters.AddWithValue("@firmaAdi", txtFirmaAdı.Text);
                komut.Parameters.AddWithValue("@il", boxİL.Text);
                komut.Parameters.AddWithValue("@ilce", boxİLCE.Text);
                komut.Parameters.AddWithValue("@Telefon", txtTelefon.Text);
                komut.Parameters.AddWithValue("@Email", txtMail.Text);
                komut.Parameters.AddWithValue("@firmaid", int.Parse(textBox1.Text));

                if (komut.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Üyelik bilgileri kaydedildi. Lütfen Tekrardan Giriş Yapınız!");
                    LoginEkranı loginEkranı = new LoginEkranı();
                    this.Hide();
                    loginEkranı.Show();
                }
                else
                    MessageBox.Show("Bilgiler Eklenemedi");
            }
            sqlcon.Close();
        }
        void il()
        {
            SqlCommand komut = new SqlCommand("select * from iller",sqlcon);

            SqlDataReader dr;

            sqlcon.Open();
            dr = komut.ExecuteReader();

            while (dr.Read())
            {
                boxİL.Items.Add(dr["isim"]);
            }
            sqlcon.Close();
        }

        void ilce()
        {
            SqlCommand komut = new SqlCommand("select * from ilceler", sqlcon);

            SqlDataReader dr;

            sqlcon.Open();
            dr = komut.ExecuteReader();

            while (dr.Read())
            {
                boxİLCE.Items.Add(dr["isim"]);
            }
            sqlcon.Close();
        }

        void trigger()
        {
            SqlCommand komut = new SqlCommand("select top 1 FirmaID from FirmaTable order by FirmaID desc",sqlcon);

            SqlDataReader dr;

            sqlcon.Open();
            dr = komut.ExecuteReader();

            while (dr.Read())
            {
                textBox1.Text=dr["FirmaID"].ToString();
            }
            sqlcon.Close();
        }
    }
}
