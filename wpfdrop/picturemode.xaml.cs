using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
//using System.Windows.Shapes;
using System.IO;
using System.Collections.ObjectModel;



namespace wpfdrop
{
    /// <summary>
    /// Interaction logic for picturemode.xaml
    /// </summary>
    public partial class picturemode : Window
    {
        private ObservableCollection<string> zitem;
        private List<string> ditem = new List<string>();
        private List<string> safe = new List<string>();
        private List<string> removals = new List<string>();

        private string image;
        private  bool alwaystop;
        private  bool canmove = true;

        private string dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Drop2.xml");

        Words word = new Words();
        load lding = new load();
        XmlLoad<Words> loadword = new XmlLoad<Words>();
        removals rm = null;
        MainWindow mw = null;
        rules rl = null;
        save sv = null;


        public picturemode()
        {
            InitializeComponent();
            pmload();
        }
        public void pmload()
        {
            this.ShowInTaskbar = false;
            if (File.Exists(dir))
            {
                lding.loading(image);
                this.image = lding.loading(image);

                if (image != null)
                {
                    this.Background = new ImageBrush(new BitmapImage(new Uri(image)));
                }
            }
            else
                return;
        }


        private void Window_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                e.Effects = DragDropEffects.All;
            }

        }

        private void Window_Drop(object sender, DragEventArgs e)
        {
             sv = new save();

            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (string file in files)
            {
                if (Directory.Exists(file))
                {
                    string[] folders = Directory.GetDirectories(file, "*.*", SearchOption.TopDirectoryOnly);
                    foreach (string d in folders)
                    {

                        ditem.Add(d.ToLower());
                    }
                    string[] dirfiles = Directory.GetFiles(file);
                    foreach (string dirfile in dirfiles)
                    {
                        ditem.Add(dirfile.ToLower());
                    }
                }
                else
                {
                    ditem.Add(file.ToLower());
                }
            }
           // rm.specials(safe);
            zitem = new ObservableCollection<string>(ditem.Except(safe));
            sv.saving(zitem, removals);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.X || e.Key == Key.Escape)
            {
                mw = new MainWindow();
                this.Close();
                mw.Show();
               
            }

        }


        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (canmove == true)
            {
                DragMove();
            }
            //MouseDown += delegate { DragMove(); };
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            //background
            word = loadword.LoadData(dir);
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "Picture"; // Default file name
            dlg.DefaultExt = ".jpg"; // Default file extension
            dlg.Filter = "Image FIles (.jpg)|*.jpg"; // Filter files by extension 

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                rl = new rules();
                // Open document 
                image = dlg.FileName;
                this.Background = new ImageBrush(new BitmapImage(new Uri(image)));
                //lding.savingwords(image);
                rl.update(image);
                rl.Close();
            }

        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            //always on top

            if (alwaystop == false)
            {
                alwaystop = true;
                this.Topmost = true;
            }
            else
            {
                alwaystop = false;
                this.Topmost = false;
            }
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            if (canmove == false)
            {
                canmove = true;
                this.ResizeMode = System.Windows.ResizeMode.CanResize;
            }
            else
            {
                canmove = false;
                this.ResizeMode = System.Windows.ResizeMode.NoResize;
            }
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            rl = new rules();
            rl.Show();

        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            mw = new MainWindow();
            this.Close();
            mw.Show();
        }


    }
}
