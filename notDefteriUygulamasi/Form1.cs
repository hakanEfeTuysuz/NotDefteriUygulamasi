/***********************************************************
 
                   Sakarya Üniversitesi

            Bilgisayar ve Bilişim Bilimleri Fakültesi
                 Bilgisayar Mühendisliği

               Nesneye Dayalı Programlama Dersi
                    2023-2024 Bahar Dönemi

           Ödev Numarası         : 1
           Öğrenci Adı Soyadı    : Hakan Efe Tüysüz
           Ögrenci Numarası      : B231210098
           Dersin Alındığı Gurup : A
 
 ***********************************************************/

using System.Drawing.Text;


namespace NesneyeDayalıProgramlamaÖdev1
{
    public partial class Form1 : Form
    {
        private int ToplamHesap = 0;
        public Form1()
        {
            InitializeComponent();
        }
        #region Metodlar
        #region Sekmeler
        private void AddTab()   // Bu metod yeni  bir sayfa açmayı sağlıyor
        {
            RichTextBox Body = new RichTextBox();
            Body.Name = "Body";
            Body.Dock = DockStyle.Fill;
            Body.ContextMenuStrip = contextMenuStrip1;
            TabPage NewPage = new TabPage();

            ToplamHesap++;

            string DocumentText = "Belge" + ToplamHesap;
            NewPage.Name = DocumentText;
            NewPage.Text = DocumentText;
            NewPage.Controls.Add(Body);

            tabControl1.TabPages.Add(NewPage);

        }
        private void RemoveTab()  // Bu metod seçili durumdaki sayfayı silmeye yarıyor
        {
            if (tabControl1.TabPages.Count != 1)
            {
                tabControl1.TabPages.Remove(tabControl1.SelectedTab);
            }
            else
            {
                tabControl1.TabPages.Remove(tabControl1.SelectedTab);
                AddTab();
            }
        }
        private void RemoveAllTabs() // Bu metod tüm sayfaları silmeye yarıyor
        {
            foreach (TabPage Page in tabControl1.TabPages)
            {
                tabControl1.TabPages.Remove(Page);
            }
            AddTab();
        }
        private void RemoveAllTabsButThis() // Bu metod seçili sayfa hariç tüm sayfaları kaldırır
        {
            foreach (TabPage Page in tabControl1.TabPages)
            {
                if (Page.Name != tabControl1.SelectedTab.Name)
                {
                    tabControl1.TabPages.Remove(Page);
                }
            }
        }

        #endregion

        #region KaydetAç
        private void Save() // Bu metod dosyayı RTF belgesi şeklinde kaydetmeye yarar
        {
            saveFileDialog1.FileName = tabControl1.SelectedTab.Name;
            saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveFileDialog1.Filter = "RTF|*.rtf";
            saveFileDialog1.Title = "Save";

            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (saveFileDialog1.FileName.Length > 0)
                {
                    GetCurrentDocument.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.RichText);
                    GetCurrentDocument.Modified = false;
                }
            }
            
        }
        private void SaveAs() // Bu metodun temel amacı ise belgenin farklı bir isim altında kaydedilmesine yardım eder
        {
            saveFileDialog1.FileName = tabControl1.SelectedTab.Name;
            saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveFileDialog1.Filter = "Text Files|*.txt|C# dosyası|*.cs|Tüm Dosyalar|*.*";
            saveFileDialog1.Title = "Farklı Kaydet";

            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (saveFileDialog1.FileName.Length > 0)
                {
                    GetCurrentDocument.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                    GetCurrentDocument.Modified = false;
                }
            }

        }
        private void Open() // Burada kaydedilen dosyaların RTF şeklinde açılmasını sağlar
        {
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialog1.Filter = "RTF|*.rtf|Text dosyası|*.txt|Tüm dosyalar|*.*";

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (openFileDialog1.FileName.Length > 0)
                {
                    GetCurrentDocument.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.RichText);
                }
            }
        }

        #endregion
        #region Özelliler
        private RichTextBox GetCurrentDocument
        {
            get { return (RichTextBox)tabControl1.SelectedTab.Controls["Body"]; }
        }
        #endregion
        #region Text Fonksiyonları
        private void Undo()  // Yapılan işlemi geri almayı sağlar
        {
            GetCurrentDocument.Undo();
        }
        private void Redo() // Yapılan işlemi ileri almaya sağlar
        {
            GetCurrentDocument.Redo();
        }
        private void Cut() // Kes işlemini yapar
        {
            GetCurrentDocument.Cut();
        }
        private void Copy() // Kopyalama işlemini yapar
        {
            GetCurrentDocument.Copy();
        }
        private void Paste() // Yapıştır işlemini yapar
        {
            GetCurrentDocument.Paste();
        }
        private void SelectAll() // Hepsini seç işlemini yapar
        {
            GetCurrentDocument.SelectAll();
        }

        #endregion
        #region Font
        private void GetFontCollection() // Bu metodda sistemdeki yazı tiplerini alır ve araç çubuğu komboboxuna ekleyerek kullanıcıya liste şeklinde sunar
        {
            InstalledFontCollection InsFonts = new InstalledFontCollection();

            foreach (FontFamily item in InsFonts.Families)
            {
                toolStripComboBoxFontType.Items.Add(item.Name);
            }
            toolStripComboBoxFontType.SelectedIndex = 0;
        }
        private void PopulateFontSize() // Bu metodda araç çubuğu komboboxuna 1 ila 75 arasındaki yazı tipi boyutlarını ekler
        {
            for (int i = 1; i <= 75; i++)
            {
                toolStripComboBoxFontSize.Items.Add(i);
            }
            toolStripComboBoxFontSize.SelectedIndex = 12;
        }
        #endregion

        #endregion

        private void geriAlToolStripMenuItem_Click(object sender, EventArgs e) // İlgili arayüze Tıklama olayı ile Undo metodunu çağırır
        {
            Undo();
        }

        private void yineleToolStripMenuItem_Click(object sender, EventArgs e) // İlgili arayüze Tıklama olayı ile Redo metodunu çağırır
        {
            Redo();
        }

        private void kesToolStripMenuItem_Click(object sender, EventArgs e) // İlgili arayüze Tıklama olayı ile Cut metodunu çağırır
        {
            Cut();
        }

        private void kopyalaToolStripMenuItem_Click(object sender, EventArgs e) // İlgili arayüze Tıklama olayı ile Copy metodunu çağırır
        {
            Copy();
        }

        private void yapıştırToolStripMenuItem_Click(object sender, EventArgs e) // İlgili arayüze Tıklama olayı ile Paste metodunu çağırır
        {
            Paste();
        }

        private void tümünüSeçToolStripMenuItem_Click(object sender, EventArgs e) // İlgili arayüze Tıklama olayı ile SelectAll metodunu çağırır
        {
            SelectAll();
        }

        private void yeniToolStripMenuItem_Click(object sender, EventArgs e)  // İlgili arayüze Tıklama olayı ile AddTab metodunu çağırır
        {
            AddTab();
        }

        private void açToolStripMenuItem_Click(object sender, EventArgs e)  // İlgili arayüze Tıklama olayı ile Open metodunu çağırır
        {
            Open();
        }

        private void kaydetToolStripMenuItem_Click(object sender, EventArgs e)  // İlgili arayüze Tıklama olayı ile Save metodunu çağırır
        {
            Save();
        }

        private void farklıKaydetToolStripMenuItem_Click(object sender, EventArgs e)  // İlgili arayüze Tıklama olayı ile SaveAs metodunu çağırır
        {
            SaveAs();
        }

        private void yeniToolStripButton_Click(object sender, EventArgs e)  // İlgili arayüze Tıklama olayı ile AddTab metodunu çağırır
        {
            AddTab();
        }

        private void removeToolStripButton1_Click(object sender, EventArgs e)  // İlgili arayüze Tıklama olayı ile RemoveTab metodunu çağırır
        {
            RemoveTab();
        }

        private void açToolStripButton_Click(object sender, EventArgs e)  // İlgili arayüze Tıklama olayı ile Open metodunu çağırır
        {
            Open();
        }

        private void kaydetToolStripButton_Click(object sender, EventArgs e) // İlgili arayüze Tıklama olayı ile Save metodunu çağırır
        {
            Save();
        }

        private void kesToolStripButton_Click(object sender, EventArgs e) // İlgili arayüze Tıklama olayı ile Cut metodunu çağırır
        {
            Cut();
        }

        private void kopyalaToolStripButton_Click(object sender, EventArgs e) // İlgili arayüze Tıklama olayı ile Copy metodunu çağırır
        {
            Copy();
        }

        private void yapıştırToolStripButton_Click(object sender, EventArgs e) // İlgili arayüze Tıklama olayı ile Paste metodunu çağırır
        {
            Paste();
        }

        private void toolStripButtonBold_Click(object sender, EventArgs e) // Bu metod ilgili arayüze tıklama olayı ile yazı fontunu Bold (Kalın) yapar
        {
            Font BoldFont = new Font(GetCurrentDocument.SelectionFont.FontFamily, GetCurrentDocument.SelectionFont.SizeInPoints, FontStyle.Bold);
            Font RegularFont = new Font(GetCurrentDocument.SelectionFont.FontFamily, GetCurrentDocument.SelectionFont.SizeInPoints, FontStyle.Regular);

            if (GetCurrentDocument.SelectionFont.Bold)  // Burada eğer Bold seçiliyse yazı fontunu normal yapar , Seçili değil ise Bold yapar
            {
                GetCurrentDocument.SelectionFont = RegularFont;
            }
            else
            {
                GetCurrentDocument.SelectionFont = BoldFont;
            }

        }

        private void toolStripButtonItalic_Click(object sender, EventArgs e)  // Bu metod ilgili arayüze tıklama olayı ile yazı fontunu Italic yapar
        {
            Font ItalicFont = new Font(GetCurrentDocument.SelectionFont.FontFamily, GetCurrentDocument.SelectionFont.SizeInPoints, FontStyle.Italic);
            Font RegularFont = new Font(GetCurrentDocument.SelectionFont.FontFamily, GetCurrentDocument.SelectionFont.SizeInPoints, FontStyle.Regular);

            if (GetCurrentDocument.SelectionFont.Italic)  // Burada eğer Italic seçiliyse yazı fontunu normal yapar , Seçili değil ise Italic yapar
            {
                GetCurrentDocument.SelectionFont = RegularFont;
            }
            else
            {
                GetCurrentDocument.SelectionFont = ItalicFont;
            }
        }

        private void toolStripButtonUnderline_Click(object sender, EventArgs e)  // Bu metod ilgili arayüze tıklama olayı ile yazı fontunu Under line (Altı çizili) yapar
        {
            Font UnderLineFont = new Font(GetCurrentDocument.SelectionFont.FontFamily, GetCurrentDocument.SelectionFont.SizeInPoints, FontStyle.Underline);
            Font RegularFont = new Font(GetCurrentDocument.SelectionFont.FontFamily, GetCurrentDocument.SelectionFont.SizeInPoints, FontStyle.Regular);

            if (GetCurrentDocument.SelectionFont.Underline)  // Burada eğer Under line seçiliyse yazı fontunu normal yapar , Seçili değil ise Under line yapar
            {
                GetCurrentDocument.SelectionFont = RegularFont;
            }
            else
            {
                GetCurrentDocument.SelectionFont = UnderLineFont;
            }
        }

        private void toolStripButtonStrikeOut_Click(object sender, EventArgs e)  // Bu metod ilgili arayüze tıklama olayı ile yazı fontunu Strike out (Üstü çizili) yapar
        {
            Font StrikeoutFont = new Font(GetCurrentDocument.SelectionFont.FontFamily, GetCurrentDocument.SelectionFont.SizeInPoints, FontStyle.Strikeout);
            Font RegularFont = new Font(GetCurrentDocument.SelectionFont.FontFamily, GetCurrentDocument.SelectionFont.SizeInPoints, FontStyle.Regular);

            if (GetCurrentDocument.SelectionFont.Strikeout) // Burada eğer Strike out seçiliyse yazı fontunu normal yapar , Seçili değil ise Strike out yapar
            {
                GetCurrentDocument.SelectionFont = RegularFont;
            }
            else
            {
                GetCurrentDocument.SelectionFont = StrikeoutFont;
            }
        }

        private void toolStripButtonUpper_Click(object sender, EventArgs e)  // Bu metod araç çubuğuna tıklama olayı ile seçili metni büyük harflere dönüştürür
        {
            GetCurrentDocument.SelectedText = GetCurrentDocument.SelectedText.ToUpper();
        }

        private void toolStripButtonLower_Click(object sender, EventArgs e)  // Bu metod araç çubuğuna tıklama olayı ile seçili metni küçük harflere dönüştürür
        {
            GetCurrentDocument.SelectedText = GetCurrentDocument.SelectedText.ToLower();
        }

        private void toolStripButtonIncrease_Click(object sender, EventArgs e) // Bu metod araç çubuğuna tıklama olayı ile seçili metnin font boyutunu artırmakta kullanılır 
        {
            float NewFontSize = GetCurrentDocument.SelectionFont.SizeInPoints + 2;

            Font NewSize = new Font(GetCurrentDocument.SelectionFont.Name, NewFontSize, GetCurrentDocument.SelectionFont.Style);
            GetCurrentDocument.SelectionFont = NewSize;
        }

        private void toolStripButtonDecrease_Click(object sender, EventArgs e) // Bu metod araç çubuğuna tıklama olayı ile seçili metnin font boyutunu azaltmakta kullanılır
        {
            float NewFontSize = GetCurrentDocument.SelectionFont.SizeInPoints - 2;

            Font NewSize = new Font(GetCurrentDocument.SelectionFont.Name, NewFontSize, GetCurrentDocument.SelectionFont.Style);
            GetCurrentDocument.SelectionFont = NewSize;
        }

        private void toolStripButtonFontColor_Click(object sender, EventArgs e)  // Bu metod araç çubuğuna tıklama olayı ile seçili metnin font rengini değiştirmekte kullanılır
        {
            if (colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                GetCurrentDocument.SelectionColor = colorDialog1.Color;
            }
        }

        private void toolStripMenuItemGreen_Click(object sender, EventArgs e)  // Bu metod araç çubuğuna tıklama olayı ile seçili metnin arka planını yeşil yapmakta kullanılır
        {
            GetCurrentDocument.SelectionBackColor = Color.Lime;
        }

        private void toolStripMenuItemOrange_Click(object sender, EventArgs e)  // Bu metod araç çubuğuna tıklama olayı ile seçili metnin arka planını turuncu yapmakta kullanılır
        {
            GetCurrentDocument.SelectionBackColor = Color.Orange;
        }

        private void toolStripMenuItemYellow_Click(object sender, EventArgs e)  // Bu metod araç çubuğuna tıklama olayı ile seçili metnin arka planını sarı yapmakta kullanılır
        {
            GetCurrentDocument.SelectionBackColor = Color.Yellow;
        }

        private void toolStripComboBoxFontType_SelectedIndexChanged(object sender, EventArgs e)  // Bu metod araç çubuğuna tıklama olayı ile seçili metnin yazı tipini değiştirmekte kullanılır
        {
            Font NewFont = new Font(toolStripComboBoxFontType.SelectedItem.ToString(), GetCurrentDocument.SelectionFont.Size, GetCurrentDocument.SelectionFont.Style);
            GetCurrentDocument.SelectionFont = NewFont;
        }

        private void toolStripComboBoxFontSize_SelectedIndexChanged(object sender, EventArgs e)  // Bu metod araç çubuğuna tıklama olayı ile seçili metnin font boyutunu değiştirmekte kullanılır
        {
            float NewSize;
            float.TryParse(toolStripComboBoxFontSize.SelectedItem.ToString(), out NewSize);
            Font NewFont = new Font(GetCurrentDocument.SelectionFont.Name, NewSize, GetCurrentDocument.SelectionFont.Style);
            GetCurrentDocument.SelectionFont = NewFont;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)  // İlgili arayüze Tıklama olayı ile Undo metodunu çağırır
        {
            Undo();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)  // İlgili arayüze Tıklama olayı ile Redo metodunu çağırır
        {
            Redo();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)  // İlgili arayüze Tıklama olayı ile Cut metodunu çağırır
        {
            Cut();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)  // İlgili arayüze Tıklama olayı ile Copy metodunu çağırır
        {
            Copy();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)  // İlgili arayüze Tıklama olayı ile Paste metodunu çağırır
        {
            Paste();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)  // İlgili arayüze Tıklama olayı ile Save metodunu çağırır
        {
            Save();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)  // İlgili arayüze Tıklama olayı ile RemoveTab metodunu çağırır
        {
            RemoveTab();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)  // İlgili arayüze Tıklama olayı ile RemoveAllTabs metodunu çağırır
        {
            RemoveAllTabs();
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)  // İlgili arayüze Tıklama olayı ile RemoveAllTabsButThis metodunu çağırır
        {
            RemoveAllTabsButThis();
        }

        private void Form1_Load(object sender, EventArgs e)  // Form ilk yüklendiğinde boş bir sayfa açar ve geçerli yazı tipi ve font büyüklüğünü ayarlar
        {
            AddTab();
            GetFontCollection();
            PopulateFontSize();
        }

        private void timer1_Tick(object sender, EventArgs e) // Bu metodda timer nesnesi ile belirli bir aralıkta metin belgesindeki karakter sayısını kontrol eder
        {
            if (GetCurrentDocument.Text.Length > 0)
            {
                toolStripStatusLabel1.Text = "Toplam karakter sayısı = " + GetCurrentDocument.Text.Length.ToString();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) // Buradaki metod ile kaydedilmemiş dosyaların olduğu kullanıcıya iletilir ve cevap beklenir
        {
            // Eğer metin belgesinde değişiklik yapıldıysa
            if (GetCurrentDocument.Modified)
            {
                // Kullanıcıya bir iletişim kutusu gösterir
                DialogResult result = MessageBox.Show("Kaydedilmemiş değişiklikler var. Çıkmak istiyor musunuz?", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                // Eğer kullanıcı Tamam'a basarsa, form kapatılır
                if (result == DialogResult.OK)
                {
                    // Formu kapat
                    e.Cancel = false;
                }
                // Eğer kullanıcı İptal'e basarsa, form kapatılmaz
                else
                {
                    // Formun kapatılmasını iptal et
                    e.Cancel = true;
                }
            }
        }
    }
}
