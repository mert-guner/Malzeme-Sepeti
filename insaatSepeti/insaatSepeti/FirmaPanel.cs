using Dapper;
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
using insaatSepeti.Class;
using System.Data.SqlClient;

namespace insaatSepeti
{
    public partial class FirmaPanel : MaterialForm
    {
        int b;
        public FirmaPanel(int a)
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = false; // üstte olacak
            materialSkinManager.AddFormToManage(this);
            
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, 
                Accent.Orange200, TextShade.WHITE);

            this.b = a;
        }

        SqlConnection sqlcon = new SqlConnection(@"Data Source=LAPTOP-4ADVPLF2;Initial Catalog=Betoncum;Integrated Security=True");

        void FillDataGridView()// veritabanını listeliyor
        {
            DynamicParameters dynamic = new DynamicParameters();
            dynamic.Add("@firmaid", b);

            List<Urunler> list = sqlcon.Query<Urunler>//Query kullanıyoruz çünkü liste döndürdük
                ("urunListele", dynamic, commandType: CommandType.StoredProcedure).ToList<Urunler>();

            dataGridView1.DataSource = list;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[3].Width = 150;
            dataGridView1.Columns[4].Width = 150;

        }

        #region Bildirim Listele Metot

        void bildirim()
        {
            SqlCommand komut = new SqlCommand("select * from Bildirim where FirmaID=" + b, sqlcon);
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
            dataGridView3.DataSource = dataTable;
            dataGridView3.Columns[0].Visible = false;
            dataGridView3.Columns[1].Visible = false;
            dataGridView3.Columns[2].Width = 220;
            dataGridView3.Columns[3].Width = 220;
            sqlcon.Close();
        }

        #endregion

        private void FirmaPanel_Load(object sender, EventArgs e)
        {
            try
            {
                FillDataGridView();

                #region Firma Adı 


                
                SqlCommand komut = new SqlCommand("select FirmaAdi from FirmaDetay where FirmaID='"+b+"'", sqlcon);

                SqlDataReader dr;

                sqlcon.Open();
                dr = komut.ExecuteReader();

                while (dr.Read())
                {
                    lblFirmaAdi.Text = dr["FirmaAdi"].ToString();
                }
                sqlcon.Close();
                #endregion


                #region Hakkında

                
                SqlCommand komut2 = new SqlCommand("select Hakkinda from FirmaDetay where FirmaID='" + b + "'", sqlcon);

                SqlDataReader dr2;

                sqlcon.Open();
                dr2 = komut2.ExecuteReader();

                while (dr2.Read())
                {
                    txtHakkimizda.Text = dr2["Hakkinda"].ToString();
                }
                sqlcon.Close();

                #endregion

                #region il getiriyor
                SqlCommand komut5 = new SqlCommand("select * from iller", sqlcon);
                sqlcon.Open();
                SqlDataReader reader5 = komut5.ExecuteReader();
                while (reader5.Read())
                {
                    boxİL.Items.Add(reader5["isim"]);
                }
                sqlcon.Close();
                #endregion

                #region İlçeleri getiriyor
                SqlCommand komut6 = new SqlCommand("select * from ilceler", sqlcon);
                sqlcon.Open();
                SqlDataReader reader6 = komut6.ExecuteReader();
                while (reader6.Read())
                {
                    boxİLCE.Items.Add(reader6["isim"]);
                }
                sqlcon.Close();
                #endregion


                #region Sipariş Listele

                //  List<Siparis> list10 = sqlcon.Query<Siparis>
                //("siparisListele", commandType: CommandType.StoredProcedure).ToList<Siparis>();

                //  dataGridView2.DataSource = list10;
                //  dataGridView2.Columns[0].Visible = false;
                //  dataGridView2.Columns[1].Visible = false;
                //  dataGridView2.Columns[2].Visible = false;
                //  dataGridView2.Columns[4].Visible = false;

                SqlCommand komut7 = new SqlCommand("select * from Siparis where FirmaID='" + b + "'", sqlcon);
                sqlcon.Open();

                DataTable dataTable = new DataTable();

                dataTable.Columns.Add("satisid");
                dataTable.Columns.Add("musteriid");
                dataTable.Columns.Add("firmaid");
                dataTable.Columns.Add("siparistarihi");
                dataTable.Columns.Add("urunid");
                dataTable.Columns.Add("betoncesidi");
                dataTable.Columns.Add("cimentocesidi");
                dataTable.Columns.Add("katkicesidi");
                dataTable.Columns.Add("kivamcesidi");
                dataTable.Columns.Add("birimfiyati");
                dataTable.Columns.Add("miktar");
                dataTable.Columns.Add("firmaadi");
                dataTable.Columns.Add("siparisdurumu");

                SqlDataReader okuyucu = komut7.ExecuteReader();

                while (okuyucu.Read())
                {
                    DataRow row = dataTable.NewRow();
                    row["satisid"] = okuyucu["SatisID"];
                    row["musteriid"] = okuyucu["MusteriID"];
                    row["firmaid"] = okuyucu["FirmaID"];
                    row["siparistarihi"] = okuyucu["SiparisTarihi"];
                    row["urunid"] = okuyucu["UrunID"];
                    row["betoncesidi"] = okuyucu["BetonCesidi"];
                    row["cimentocesidi"] = okuyucu["CimentoCesidi"];
                    row["katkicesidi"] = okuyucu["KatkiCesidi"];
                    row["kivamcesidi"] = okuyucu["KivamCesidi"];
                    row["birimfiyati"] = okuyucu["BirimFiyati"];
                    row["miktar"] = okuyucu["Miktar"];
                    row["firmaadi"] = okuyucu["FirmaAdi"];
                    row["siparisdurumu"] = okuyucu["SiparisDurumu"];
                    dataTable.Rows.Add(row);
                }
                dataGridView2.DataSource = dataTable;
                sqlcon.Close();

                #endregion

                bildirim();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void boxİLCE_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        #region Koyu tema 

        
        private void Tema_CheckedChanged(object sender, EventArgs e)
        {
            MaterialSkinManager MaterialSkin = MaterialSkinManager.Instance;

            if (Tema.Checked)
            {
                MaterialSkin.Theme = MaterialSkinManager.Themes.LIGHT;
            }
            else
                MaterialSkin.Theme = MaterialSkinManager.Themes.DARK;
        }
        #endregion

        #region Çıkış Butonu

       
        private void materialButton1_Click(object sender, EventArgs e)
        {
            LoginEkranı loginEkranı = new LoginEkranı();
            this.Hide();
            loginEkranı.Show();
        }
        #endregion


        void clear()
        {
            txtFiyat.Clear();
            txtUrunAdi.Clear();
            textBox1.Clear();
        }

        #region Ürün Ekle

        
        // ürün ekle
        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUrunAdi.Text=="" || txtFiyat.Text=="" || boxStok.Text=="")
                {
                    MessageBox.Show("Alanlar Boş Geçilemez");
                }
                else
                {
                    if (sqlcon.State == ConnectionState.Closed)
                    {
                        sqlcon.Open();
                    }

                    DynamicParameters param = new DynamicParameters();
                    param.Add("@urunadi", txtUrunAdi.Text.Trim());
                    param.Add("@birimfiyati", txtFiyat.Text.Trim());
                    param.Add("@stok", boxStok.Text);                
                    param.Add("@firmaid", b);             

                    sqlcon.Execute("urunEkle", param, commandType: CommandType.StoredProcedure);

                    FillDataGridView();
                    clear();
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

        #region Ürün Güncelleme

        
        // ürün Güncelleme
        private void btnUrunguncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUrunAdi.Text == "" || txtFiyat.Text == "" || boxStok.Text == "")
                {
                    MessageBox.Show("Alanlar Boş Geçilemez");
                }
                else
                {
                    if (sqlcon.State == ConnectionState.Closed)
                    {
                        sqlcon.Open();
                    }

                    DynamicParameters param = new DynamicParameters();
                    param.Add("@id", int.Parse(textBox1.Text));
                    param.Add("@urunadi", txtUrunAdi.Text.Trim());
                    param.Add("@birimfiyati", txtFiyat.Text.Trim());
                    param.Add("@stok", boxStok.Text);                

                    sqlcon.Execute("urunGuncelle", param, commandType: CommandType.StoredProcedure);



                    FillDataGridView();
                    clear();
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

        #region Ürün Silme

        
        // ürün silme
        private void btnsil_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Silmek istediğiniz ürünü seçiniz!");
                }
                else
                {
                    if (sqlcon.State == ConnectionState.Closed)
                    {
                        sqlcon.Open();
                    }

                    DynamicParameters param = new DynamicParameters();
                    param.Add("@id", int.Parse(textBox1.Text));
                    param.Add("@betonadi", txtUrunAdi.Text);

                    sqlcon.Execute("urunSil", param, commandType: CommandType.StoredProcedure);



                    FillDataGridView();
                    clear();
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


        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtUrunAdi.Text= dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtFiyat.Text= dataGridView1.CurrentRow.Cells[3].Value.ToString();
            
        }

        #region Firma Giriş Güncelleme

        

        // firma giriş güncelleme
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                    sqlcon.Open();
                DynamicParameters param1 = new DynamicParameters();
                param1.Add("@firmakullaniciadi", txtKullaniciAdi.Text.Trim());
                param1.Add("@firmasifre", txtSifre.Text.Trim());
                param1.Add("@id", b);

                sqlcon.Execute
                    ("firmagirisbilgileriduzenle", param1, commandType: CommandType.StoredProcedure);
                MessageBox.Show("Güncelleme Başarılı");
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

        #region Firma Bilgisi Güncelleme

        
        // firma bilgisi güncelleme
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                    sqlcon.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@firmaAdi", txtFirmaAdı.Text.Trim());
                param.Add("@firmatel", txtTelefon.Text.Trim());
                param.Add("@firmaEmail", txtMail.Text.Trim());
                param.Add("@firmail", boxİL.Text.Trim());
                param.Add("@firmailce", boxİLCE.Text.Trim());
                param.Add("@id", b);
                sqlcon.Execute
                    ("firmabilgileriduzenle", param, commandType: CommandType.StoredProcedure);
                MessageBox.Show("Güncelleme Başarılı");
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


        #region Hakkında Kaydet

        
        private void btnHakkindaKaydet_Click(object sender, EventArgs e)
        {
            sqlcon.Open();

            using (SqlCommand komut3 = new SqlCommand())
            {
                komut3.Connection = sqlcon;
                komut3.CommandType = CommandType.Text;
                komut3.CommandText = "update FirmaDetay set Hakkinda=@hakkinda where FirmaID='" + b + "'";

                komut3.Parameters.AddWithValue("@hakkinda", txtHakkimizda.Text);             

                if (komut3.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Bilgileriniz Güncellendi!");                 
                }
                else
                    MessageBox.Show("Bilgiler Güncellenemedi!");
            }
            sqlcon.Close();
        }
        #endregion

        #region Siparis durumu datagrid cellclick

       
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
        }
        #endregion


        #region Siparis durumu güncelleme buton

        
        private void btnsiparisdurumuguncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                    sqlcon.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@id", int.Parse(textBox2.Text));
                param.Add("@siparisdurum", boxSiparisDurumu.Text);
      
                sqlcon.Execute
                    ("siparisdurumuguncelle", param, commandType: CommandType.StoredProcedure);
                MessageBox.Show("Güncelleme Başarılı");
            }
            catch (Exception)
            {
                MessageBox.Show("Güncelleme Yapılamadı");

            }
            finally
            {
                sqlcon.Close();
            }

            FirmaPanel_Load(this,null);
        }

        #endregion

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        #region Bildirim Ekle

        
        private void btnBildirimEkle_Click(object sender, EventArgs e)
        {
            SqlCommand eklekomut = new SqlCommand();
            sqlcon.Open();

            eklekomut.Connection = sqlcon;
            eklekomut.CommandType = CommandType.Text;
            eklekomut.CommandText = "insert into Bildirim(FirmaID,Baslik,Konu)" +
                "values(@firmaid,@Baslik,@Konu)";
            eklekomut.Parameters.AddWithValue("@Baslik", txtBaslik.Text);
            eklekomut.Parameters.AddWithValue("@firmaid", b);
            eklekomut.Parameters.AddWithValue("@Konu", txtKonu.Text);

            if (eklekomut.ExecuteNonQuery() == 1)
                MessageBox.Show("Bildirim Eklendi");
            else
                MessageBox.Show("Bildirim Eklenmedi");
            sqlcon.Close();
            FirmaPanel_Load(this, null);
        }

        #endregion


        #region Bildirim Silme

        
        private void btnBildirimSil_Click(object sender, EventArgs e)
        {
            SqlCommand silkomut = new SqlCommand();
            sqlcon.Open();

            silkomut.Connection = sqlcon;
            silkomut.CommandType = CommandType.Text;
            silkomut.CommandText = "delete from Bildirim where BildirimID=@id";
            silkomut.Parameters.AddWithValue("@id", int.Parse(textBox3.Text));

            if (silkomut.ExecuteNonQuery() == 1)
                MessageBox.Show("Bildirim Silindi");
            else
                MessageBox.Show("Bildirim Silinemedi");
            sqlcon.Close();
            FirmaPanel_Load(this, null);
        }
        #endregion

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox3.Text = dataGridView3.CurrentRow.Cells[0].Value.ToString();
        }
    }
}
