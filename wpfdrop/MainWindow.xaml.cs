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
using System.Windows.Navigation;
using System.IO;
using System.Xml.Serialization;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Collections;


namespace wpfdrop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //private  ObservableCollection<string> zitem = new ObservableCollection<string>();
         private ObservableCollection<string> zitem = new ObservableCollection<string>();
         private List<string> ditem = new List<string>();
         private List<string> safe = new List<string>();
         private  List<string> removals = new List<string>();

         private string dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Drop2.xml");



        Words word = new Words();
        load lding = new load();
        XmlLoad<Words> loadword = new XmlLoad<Words>();

        removals rm = null;
        save sv = null;
        info i = null;
        rules rl = null;
        picturemode pm = null;






        public MainWindow()
        {
            InitializeComponent();
            if (File.Exists(dir))
                lding.loading();
            else
                XmlSave.SaveData(word, dir);
        }


        private void listBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
                e.Effects = DragDropEffects.All;
        }

        private void listBox1_Drop(object sender, DragEventArgs e)
        {
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
            rm = new removals();
            rm.specials(safe);
            
            zitem = new ObservableCollection<string>(ditem.Except(safe));
            listBox1.ItemsSource = zitem;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //save
            sv = new save();
            sv.saving(zitem, removals);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //clear all
            rm = new removals();
            rm.f1clear(ditem);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //rules
            rl = new rules();
            rl.Show();
        }

        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //info
            i = new info();
            if (listBox1.SelectedIndex > -1)
            {
                FileInfo file = new FileInfo(ditem[listBox1.SelectedIndex].ToString());
                i.information(ditem, file);
                lblFileSize.Content = i.size;
            }
            else
                lblFileSize.Content = string.Empty;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //delete
            rm = new removals();
            rm.permdelete(removals);
        }





        //Picture Mode Stuff

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            //picture mode
            pm = new picturemode();
            pm.Show();
            this.Close();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            //had errors with a class hanging open, this is to test to make sure each class closes on programs end
            // also used for testing picturemode image from main window

            //this.Close();
            //pm.Close();
            //options op = new options();
            //op.Close();
            //rules rl = new rules();

            //rl.Close();
            //Words word = new Words();
            //rules rl = new rules();
            //XmlLoad<Words> loadword = new XmlLoad<Words>();


            //word = loadword.LoadData(lding.dir);
            //Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            //dlg.FileName = "Picture"; // Default file name
            //dlg.DefaultExt = ".jpg"; // Default file extension
            //dlg.Filter = "Image FIles (.jpg)|*.jpg"; // Filter files by extension 

            //Nullable<bool> result = dlg.ShowDialog();

            //if (result == true)
            //{
            //    // Open document 
            //  // word.image = dlg.FileName;
            //   //word.image = picturemode.image;
            //   // rl.update();
            //   // rl.Close();
            //}
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            //removing selected listview item with delete key
            if (e.Key == Key.Delete && listBox1.SelectedIndex > -1)
                ditem.RemoveAt(listBox1.SelectedIndex);
        }
        private void listBox1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //starts the item selected when double clicked
            string item = listBox1.SelectedItem as string;

            if (listBox1.SelectedIndex > -1 && item != null)
                    Process.Start(item);
        }

    }
}
