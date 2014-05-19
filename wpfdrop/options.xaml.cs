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
using System.Xml.Serialization;
using WPFFolderBrowser;


namespace wpfdrop
{
    /// <summary>
    /// Interaction logic for options.xaml
    /// </summary>
    public partial class options : Window
    {
       // Words word = new Words();

       // save sv = new save();
       // removals r = new removals();
       //WPFFolderBrowser.WPFFolderBrowserDialog z = new WPFFolderBrowser.WPFFolderBrowserDialog();
       //public List<string> keysz = new List<string>();
       //public List<string> pathsz = new List<string>();

       // public static options op = null;
        public options()
        {
            //InitializeComponent();
            ////op = this;
            ////lding.loadtext();
            //z.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            //loadtext();
        }
        public void loadtext()
        {
            //load lding = new load();

            //string dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Drop2.xml");

            //if (File.Exists(dir))
            //{


            //    lding.loading();
            //    Words word = new Words();

                   
            //    textBox1.Text = load.keys[0];
            //    textBox2.Text = load.keys[1];
            //    textBox3.Text = load.keys[2];
            //    textBox4.Text = load.keys[3];

            //    textBox5.Text = load.paths[0];
            //    textBox6.Text = load.paths[1];
            //    textBox7.Text = load.paths[2];
            //    textBox8.Text = load.paths[3];
            //    textBox9.Text = load.paths[4];


            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ////load lding = new load();
            ////Words word = new Words();
            //string dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Drop2.xml");
            //keysz.Clear();

            //if (textBox1.Text != null)
            //{
            //    keysz.Add(textBox1.Text);
            //}
            //else
            //{
            //    keysz.Add("");
            //}
            //if (textBox2.Text != null)
            //{
            //    keysz.Add(textBox2.Text);
            //}
            //else
            //{
            //    keysz.Add("");
            //}
            //if (textBox3.Text != null)
            //{
            //    keysz.Add(textBox3.Text);
            //}
            //else
            //{
            //    keysz.Add("");
            //}
            //if (textBox4.Text != null)
            //{
            //    keysz.Add(textBox4.Text);
            //}
            //else
            //{
            //    keysz.Add("");
            //}

            //keysz.Add("");
            //word.s1 = keysz;

            //pathsz.Clear();

            //if (textBox5.Text != null)
            //{
            //    pathsz.Add(textBox5.Text);
            //}
            //else
            //{
            //    keysz.Add("");
            //}
            //if (textBox6.Text != null)
            //{
            //    pathsz.Add(textBox6.Text);
            //}
            //else
            //{
            //    keysz.Add("");
            //}
            //if (textBox7.Text != null)
            //{
            //    pathsz.Add(textBox7.Text);
            //}
            //else
            //{
            //    keysz.Add("");
            //}
            //if (textBox8.Text != null)
            //{
            //    pathsz.Add(textBox8.Text);
            //}
            //else
            //{
            //    keysz.Add("");
            //}
            //if (textBox9.Text != null)
            //{
            //    pathsz.Add(textBox9.Text);
            //}
            //else
            //{
            //    keysz.Add("");
            //}

            //word.s2 = pathsz;


            //XmlSave.SaveData(word, dir);
            //this.Close();

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //Nullable<bool> result = z.ShowDialog();

            //if (result == true)
            //{
            //    textBox5.Text = z.FileName;
            //}
            //else
            //{
            //    return;
            //}
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Nullable<bool> result = z.ShowDialog();

            //if (result == true)
            //{
            //    textBox6.Text = z.FileName;
            //}
            //else
            //{
            //    return;
            //}
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //Nullable<bool> result = z.ShowDialog();

            //if (result == true)
            //{
            //    textBox7.Text = z.FileName;
            //}
            //else
            //{
            //    return;
            //}
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            //Nullable<bool> result = z.ShowDialog();

            //if (result == true)
            //{
            //    textBox8.Text = z.FileName;
            //}
            //else
            //{
            //    return;
            //}
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            //Nullable<bool> result = z.ShowDialog();

            //if (result == true)
            //{
            //    textBox9.Text = z.FileName;
            //}
            //else
            //{
            //    return;
            //}
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
           // //clear keys
           // textBox1.Clear();
           // textBox2.Clear();
           // textBox3.Clear();
           // textBox4.Clear();

           //// r.opkeyclear();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            ////clear paths
            //textBox5.Clear();
            //textBox6.Clear();
            //textBox7.Clear();
            //textBox8.Clear();
            //textBox9.Clear();

            ////r.oppathclear();
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            //keysz.Add(textBox1.Text);
            //pathsz.Add(textBox5.Text);
        }
    }
}
