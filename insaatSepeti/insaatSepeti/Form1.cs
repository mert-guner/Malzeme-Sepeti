using MaterialSkin;
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
using System.Runtime.InteropServices; //radius
using insaatSepeti.Class;
using Dapper;
using System.Data.SqlClient;

namespace insaatSepeti
{
    // b => kullanıcı id
    // textbox4 => firma id
    public partial class Form1 : MaterialForm
    {
        //[DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        //private static extern IntPtr CreateRoundRectRgn
        //(
        //    int nLeftRect,     // x-coordinate of upper-left corner
        //    int nTopRect,      // y-coordinate of upper-left corner
        //    int nRightRect,    // x-coordinate of lower-right corner
        //    int nBottomRect,   // y-coordinate of lower-right corner
        //    int nWidthEllipse, // height of ellipse
        //    int nHeightEllipse // width of ellipse
        //);

        SqlConnection sqlcon = new SqlConnection(@"Data Source=LAPTOP-4ADVPLF2;Initial Catalog=Betoncum;Integrated Security=True");

        int b;
        public Form1(int a)
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = false;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            // this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            this.b = a;
        }

        
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }

        #region KOYU TEMA

        

        // Tema
        private void Tema_CheckedChanged(object sender, EventArgs e)
        {
            var materialSkinManager = MaterialSkinManager.Instance;

            if (Tema.Checked)
            {
                materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            }
            else
                materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;

            
        }
        #endregion


        #region Sipariş Ver Butonu


        private void btnSiparisVer_Click(object sender, EventArgs e)
        {
            

            try
            {
                if (boxBetoncesidi.Text == "" || boxCimentoCesidi.Text == "" || boxKatkiCesidi.Text == ""||boxKivam.Text==""||txtSiparisTarihi.Text==""||
                    txtMiktar.Text=="")
                {
                    MessageBox.Show("Alanlar Boş Geçilemez");
                }
                else
                {
                    if (sqlcon.State == ConnectionState.Closed)
                    {
                        sqlcon.Open();
                    }

                    if (textBox2.Text=="")
                    {
                        MessageBox.Show("Lütfen ilk önce firmayı seçiniz!");
                    }
                    else
                    {

                    

                    DynamicParameters param = new DynamicParameters();
                    param.Add("@musteriid", b);
                    param.Add("@firmaid", int.Parse(textBox2.Text));
                    param.Add("@siparistarihi", DateTime.Parse(txtSiparisTarihi.Text));
                    
                    param.Add("@betoncesidi", boxBetoncesidi.Text);
                    siparis();
                    param.Add("@urunid", int.Parse(textBox5.Text));
                    param.Add("@cimentocesidi", boxCimentoCesidi.Text);
                    param.Add("@katkicesidi", boxKatkiCesidi.Text);
                    param.Add("@kivamcesidi", boxKivam.Text);
                    param.Add("@birimfiyati", double.Parse(textBox6.Text));
                    param.Add("@miktar", double.Parse(txtMiktar.Text));
                    param.Add("@siparisdurumu", "Sipariş Alındı");



                        sqlcon.Execute("siparisEkle", param, commandType: CommandType.StoredProcedure);

                        Form1_Load(this,null);
                    }

                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally // en son işi yapıyor
            {
                sqlcon.Close();
            }

            

        }

        #endregion

        #region Sipariş Ver Butonu Metot

        
        void siparis()
        {
            SqlCommand komut10 = new SqlCommand("select UrunID, BirimFiyat from Urunler where UrunAdi='"+boxBetoncesidi.Text+"'", sqlcon);
        
            SqlDataReader reader10 = komut10.ExecuteReader();

            while (reader10.Read())
            {
                textBox5.Text = reader10["UrunID"].ToString();
                textBox6.Text = reader10["BirimFiyat"].ToString();
            }
            sqlcon.Close();
        }
        #endregion


        //Şirket seçtiğimde sipariş vermeye yönlendiriyor.
        private void dataGridView3_DoubleClick(object sender, EventArgs e)
        {
            materialTabControl1.SelectTab(tabPage3);
            textBox4.Text = dataGridView3.CurrentRow.Cells[6].Value.ToString(); // firma id
            boxBetoncesidi.Items.Clear();
            SqlCommand komut7 = new SqlCommand("select * from Urunler where Stok='Var' and FirmaID=" + int.Parse(textBox4.Text), sqlcon);
            sqlcon.Open();
            SqlDataReader reader7 = komut7.ExecuteReader();
            while (reader7.Read())
            {
                boxBetoncesidi.Items.Add(reader7["UrunAdi"]);
            }
            sqlcon.Close();
        }

        //Favori seçtiğimde sipariş vermeye yönlendiriyor.
        private void dataGridView4_DoubleClick(object sender, EventArgs e)
        {
            materialTabControl1.SelectTab(tabPage3);
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }


        #region Firma Listeleme

        
        void FillDataGridView()// veritabanını listeliyor
        {
            
            DynamicParameters param = new DynamicParameters();
            param.Add("@Aramametni", txtAra.Text.Trim());

            List<FirmaDetay> list = sqlcon.Query<FirmaDetay>//Query kullanıyoruz çünkü liste döndürdük
                ("FirmaArama", param, commandType: CommandType.StoredProcedure).ToList<FirmaDetay>();

            dataGridView3.DataSource = list;
            dataGridView3.Columns[0].Visible = false;
            dataGridView3.Columns[6].Visible = false;
        }
        #endregion


        #region Favori listeleme metot


        void FillDataGridView2()
        {
            DynamicParameters dynamic = new DynamicParameters();
            dynamic.Add("@id", b);

            //List<Favoriler> list = sqlcon.Query<Favoriler>
               // ("favorilistele", commandType: CommandType.StoredProcedure).ToList<Favoriler>();

            List<FirmaDetay> list2 = sqlcon.Query<FirmaDetay>
                ("favorilistele", dynamic, commandType: CommandType.StoredProcedure).ToList<FirmaDetay>();

            dataGridView4.DataSource = list2;
            //dataGridView4.DataSource = list;
            dataGridView4.Columns[0].Visible = false;
            dataGridView4.Columns[6].Visible = false;
            
        }
        #endregion


       

        private void Form1_Load(object sender, EventArgs e)
        {
            #region Şirketler

            try
            {
                FillDataGridView();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


            #endregion
            


            #region İl ve İlçeleri Getiren Kod

            SqlCommand komut8 = new SqlCommand("select * from iller", sqlcon);
            sqlcon.Open();
            SqlDataReader reader8 = komut8.ExecuteReader();
            while (reader8.Read())
            {
                boxİL.Items.Add(reader8["isim"]);
            }
            sqlcon.Close();

            SqlCommand komut9 = new SqlCommand("select * from ilceler", sqlcon);
            sqlcon.Open();
            SqlDataReader reader9 = komut9.ExecuteReader();
            while (reader9.Read())
            {
                boxİLCE.Items.Add(reader9["isim"]);
            }
            sqlcon.Close();
            #endregion

            #region Favori Listeleme

            try
            {
                FillDataGridView2();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            #endregion

            #region Siparis Listele
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@id", b);

            List<Siparis> list10 = sqlcon.Query<Siparis>
               ("siparisListele", dynamicParameters, commandType: CommandType.StoredProcedure).ToList<Siparis>();

            dataGridView2.DataSource = list10;
            dataGridView2.Columns[0].Visible = false;
            dataGridView2.Columns[1].Visible = false;
            dataGridView2.Columns[2].Visible = false;
            dataGridView2.Columns[4].Visible = false;

            #endregion

            #region Sipariş Takibi 

            dataGridView5.DataSource = list10;
            dataGridView5.Columns[0].Visible = false;
            dataGridView5.Columns[1].Visible = false;
            dataGridView5.Columns[2].Visible = false;
            dataGridView5.Columns[4].Visible = false;

            #endregion

            #region Geçmiş Siparişler

            dataGridView1.DataSource = list10;

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[4].Visible = false;

            #endregion

            Bildirim();
        }

        #region Favoriye Ekleme Butonu

        

        // Favoriye ekleme Butonu
        private void btnFavoriEkle_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text == "")
                {
                    MessageBox.Show("Lütfen Favoriye Eklenecek Firmayı Seçiniz!");
                }
                else
                {
                    if (sqlcon.State == ConnectionState.Closed)
                    {
                        sqlcon.Open();
                    }

                    DynamicParameters param = new DynamicParameters();
                    param.Add("@firmaid", int.Parse(textBox2.Text));
                    param.Add("@musteriid", b);
                    param.Add("@id", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    
                    sqlcon.Execute("favoriekle", param, commandType: CommandType.StoredProcedure);

                    MessageBox.Show("Favorilere Eklendi!");

                    FillDataGridView2();
                    
                    FillDataGridView();
                    textBox2.Clear();
                }


            }
            catch (Exception)
            {

                MessageBox.Show("Favori Eklenemedi");
            }
            finally // en son işi yapıyor
            {
                sqlcon.Close();
            }
        }
        #endregion

        #region Bildirim Görüntüleme

        void Bildirim()
        {
            SqlCommand komut = new SqlCommand("select * from Bildirim", sqlcon);
            sqlcon.Open();


            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("bildirimid");
            dataTable.Columns.Add("firmaid");
            dataTable.Columns.Add("baslik");
            dataTable.Columns.Add("konu");

            SqlDataReader okuyucu = komut.ExecuteReader();

            while (okuyucu.Read())
            {
                DataRow row = dataTable.NewRow();
                row["bildirimid"] = okuyucu["BildirimID"];
                row["firmaid"] = okuyucu["FirmaID"];
                row["baslik"] = okuyucu["Baslik"];
                row["konu"] = okuyucu["Konu"];

                dataTable.Rows.Add(row);
            }
            dataGridView6.DataSource = dataTable;
            dataGridView6.Columns[0].Visible = false;
            dataGridView6.Columns[1].Visible = false;
            dataGridView6.Columns[2].Width = 270;
            dataGridView6.Columns[3].Width = 273;
            sqlcon.Close();
        }

        #endregion

        private void materialButton1_Click(object sender, EventArgs e)
        {

        }

        #region Çıkış Butonu

        

        // çıkış butonu
        private void materialButton1_Click_1(object sender, EventArgs e)
        {
            LoginEkranı loginEkranı = new LoginEkranı();
            this.Hide();
            loginEkranı.Show();

        }
        #endregion



        #region Favoriye ekleme DataGridView CellClick


        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView3.CurrentRow.Cells[6].Value.ToString();
        }
        #endregion

        #region Kullanıcı Giriş Bilgileri Güncelle


        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }

                DynamicParameters dynamic = new DynamicParameters();
                dynamic.Add("@kullaniciadi", txtKullaniciAdi.Text.Trim());
                dynamic.Add("@kullanicisifresi", txtSifre.Text.Trim());
                dynamic.Add("@id", b);

                sqlcon.Execute("kullanicigirisbilgileriduzenle", dynamic, commandType: CommandType.StoredProcedure);
                MessageBox.Show("Güncelleme Başarılı");
                txtKullaniciAdi.Clear();
                txtSifre.Clear();

            }
            catch (Exception)
            {

                MessageBox.Show("Güncelleme Yapılamadı");
            }
            finally
            {
                sqlcon.Close();
            }
        }

        #endregion

        #region Üyelik bilgileri güncelle

        
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
                DynamicParameters dynamic = new DynamicParameters();
                dynamic.Add("@ad", txtKullaniciAd.Text.Trim());
                dynamic.Add("@soyad", txtKullaniciSoyad.Text.Trim());
                dynamic.Add("@il", boxİL.Text.Trim());
                dynamic.Add("@ilce", boxİLCE.Text.Trim());
                dynamic.Add("@tel", txtTelefon.Text.Trim());
                dynamic.Add("@mail", txtMail.Text.Trim());
                dynamic.Add("@adres", txtAdres.Text.Trim());
                dynamic.Add("@id", b);
                sqlcon.Execute("kullanicibilgileriduzenle", dynamic, commandType: CommandType.StoredProcedure);
                MessageBox.Show("Güncelleme Başarılı");
                txtKullaniciAd.Clear();
                txtKullaniciSoyad.Clear();
                txtTelefon.Clear();
                txtMail.Clear();
                txtAdres.Clear();
            }
            catch (Exception)
            {

                MessageBox.Show("Güncelleme Yapılamadı");
            }
            finally
            {
                sqlcon.Close();
            }
        }
        #endregion


        #region Favori silme Butonu

        
        private void materialButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox3.Text == "")
                {
                    MessageBox.Show("Lütfen Silmek istediğiniz Firmayı Seçiniz!");
                }
                else
                {
                    if (sqlcon.State == ConnectionState.Closed)
                    {
                        sqlcon.Open();
                    }

                    DynamicParameters param = new DynamicParameters();
                    param.Add("@firmaid", int.Parse(textBox3.Text));


                    sqlcon.Execute("favorisil", param, commandType: CommandType.StoredProcedure);
                    MessageBox.Show("Favori Silindi!");
                    FillDataGridView2();

                    textBox3.Clear();
                }


            }
            catch (Exception)
            {

                MessageBox.Show("Favori Silinemedi");
            }
            finally // en son işi yapıyor
            {
                sqlcon.Close();
            }
        }

        #endregion


        #region Favori silme datagrid cellclick

       
        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox3.Text=dataGridView4.CurrentRow.Cells[6].Value.ToString();
        }
        #endregion

        #region Firma Arama Butonu

        
        private void btnAra_Click(object sender, EventArgs e)
        {
            FillDataGridView();
        }

        #endregion


        #region Sipariş Durumu Görüntüle butonu

        
        private void btnsiparisdurumu_Click(object sender, EventArgs e)
        {
            switch (textBox7.Text)
            {
                case "Sipariş Alındı":
                    materialFloatingActionButton1.Mini = false;
                    materialFloatingActionButton1.Location = new Point(342, 316);

                    panel3.Visible = true;
                    panel4.Visible = false;
                    panel5.Visible = false;
                    panel6.Visible = false;
                    //////////////////////////////////
                    materialFloatingActionButton2.Mini = true;
                    materialFloatingActionButton2.Location = new Point(488, 324);

                    materialFloatingActionButton3.Mini = true;
                    materialFloatingActionButton3.Location = new Point(635, 323);

                    materialFloatingActionButton4.Mini = true;
                    materialFloatingActionButton4.Location = new Point(777, 324);
                    break;

                case "Hazırlanıyor":
                    materialFloatingActionButton1.Mini = false;
                    materialFloatingActionButton1.Location = new Point(342, 316);

                    panel3.Visible = true;
                    panel4.Visible = true;
                    panel5.Visible = false;
                    panel6.Visible = false;

                    materialFloatingActionButton2.Mini = false;
                    materialFloatingActionButton2.Location = new Point(484, 315);

                    //////////////////////////////////

                    materialFloatingActionButton3.Mini = true;
                    materialFloatingActionButton3.Location = new Point(635, 323);

                    materialFloatingActionButton4.Mini = true;
                    materialFloatingActionButton4.Location = new Point(777, 324);
                    break;

                case "Yola Çıktı":
                    materialFloatingActionButton1.Mini = false;
                    materialFloatingActionButton1.Location = new Point(342, 316);

                    materialFloatingActionButton2.Mini = false;
                    materialFloatingActionButton2.Location = new Point(484, 315);

                    materialFloatingActionButton3.Mini = false;
                    materialFloatingActionButton3.Location = new Point(628, 316);

                    panel3.Visible = true;
                    panel4.Visible = true;
                    panel5.Visible = true;
                    panel6.Visible = false;
                    ////////////////////////////////////////

                    materialFloatingActionButton4.Mini = true;
                    materialFloatingActionButton4.Location = new Point(777, 324);

                    break;

                case "Teslim Edildi":
                    materialFloatingActionButton1.Mini = false;
                    materialFloatingActionButton1.Location = new Point(342, 316);

                    materialFloatingActionButton2.Mini = false;
                    materialFloatingActionButton2.Location = new Point(484, 315);

                    materialFloatingActionButton3.Mini = false;
                    materialFloatingActionButton3.Location = new Point(628, 316);

                    materialFloatingActionButton4.Mini = false;
                    materialFloatingActionButton4.Location = new Point(772, 316);

                    panel3.Visible = true;
                    panel4.Visible = true;
                    panel5.Visible = true;
                    panel6.Visible = true;
                    break;

                default:
                    MessageBox.Show("Lütfen ilk önce siparişi seçiniz!");
                    break;
            }
        }

        #endregion

        #region Sipariş durumu görüntüleme datagrid cellclick

        

        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox7.Text = dataGridView5.CurrentRow.Cells[12].Value.ToString();
        }

        #endregion

        private void dataGridView6_DoubleClick(object sender, EventArgs e)
        {
            materialTabControl1.SelectTab(tabPage3);
            textBox4.Text = dataGridView6.CurrentRow.Cells[1].Value.ToString(); // firma id
            boxBetoncesidi.Items.Clear();
            SqlCommand komut7 = new SqlCommand("select * from Urunler where FirmaID=" + int.Parse(textBox4.Text), sqlcon);
            sqlcon.Open();
            SqlDataReader reader7 = komut7.ExecuteReader();
            while (reader7.Read())
            {
                boxBetoncesidi.Items.Add(reader7["UrunAdi"]);
            }
            sqlcon.Close();
        }
    }
}
