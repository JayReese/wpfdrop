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
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Shapes;
using WPFFolderBrowser;
using System.ComponentModel;
using System.IO;

namespace wpfdrop
{
    /// <summary>
    /// Interaction logic for rules.xaml
    /// </summary>
    public partial class rules : Window
    {
        WPFFolderBrowser.WPFFolderBrowserDialog z = new WPFFolderBrowser.WPFFolderBrowserDialog();
        private string dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Drop2.xml");
        private List<string> rulez = new List<string>();
        private List<string> keyz = new List<string>();
        private List<string> pathz = new List<string>();
        private List<string> actionz = new List<string>();

        Words word = new Words();
        load lding = new load();
        XmlLoad<Words> loadword = new XmlLoad<Words>();


        public rules()
        {
            InitializeComponent();
            loadrules();
        }

        private void loadrules()
        {
            if (File.Exists(dir))
                lding.loading(keyz, pathz, rulez, actionz);
            else
                return;


            for (int i = 0; i < rulez.Count(); i++)
            {
                this.listview1.Items.Add(new Words { rulesq = rulez[i], keysq = keyz[i], pathsq = pathz[i], actionq = actionz[i] });
            }

            
        }

        public void update()
        {
            lding.savingwords(rulez, keyz, pathz, actionz);

            listview1.Items.Clear();

            for (int i = 0; i < rulez.Count(); i++)
            {
                this.listview1.Items.Add(new Words { rulesq = rulez[i], keysq = keyz[i], pathsq = pathz[i], actionq = actionz[i] });
            }
        }
        public void update(string image)
        {
            lding.savingwords(rulez, keyz, pathz, actionz, image);

            listview1.Items.Clear();

            for (int i = 0; i < rulez.Count(); i++)
            {
                this.listview1.Items.Add(new Words { rulesq = rulez[i], keysq = keyz[i], pathsq = pathz[i], actionq = actionz[i] });
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //location
            z.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            Nullable<bool> result = z.ShowDialog();

            if (result == true)
            {
                textBox3.Text = z.FileName;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //save rule
                if (textBox1.Text != "")
                {
                    rulez.Add(textBox1.Text);
                }
                else
                {
                    rulez.Add("new rule");
                }
                if (textBox2.Text != "")
                {
                    keyz.Add(textBox2.Text);
                }
                else
                {
                    keyz.Add(string.Empty);
                }


                if (textBox3.Text != "")
                {
                    pathz.Add(textBox3.Text);
                }
                else
                {
                    pathz.Add(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));

                }
                if (comboBox.SelectedItem != null)
                {
                    
                    actionz.Add(comboBox.SelectedValue.ToString());
                }
                else
                {
                    comboBox.SelectedIndex = 1;
                    actionz.Add(comboBox.SelectedValue.ToString());
                }


                hidden();
                update();


        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //update();
            //this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            visable();

        }




        private void listview1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            visable();
            dcombo();

            textBox1.Text = rulez[listview1.SelectedIndex].ToString();
            textBox2.Text = keyz[listview1.SelectedIndex].ToString();
            textBox3.Text = pathz[listview1.SelectedIndex].ToString();
            comboBox.Text = actionz[listview1.SelectedIndex].ToString();


            //rulez.RemoveAt(listview1.SelectedIndex);
            //keyz.RemoveAt(listview1.SelectedIndex);
            //pathz.RemoveAt(listview1.SelectedIndex);
            //actionz.RemoveAt(listview1.SelectedIndex);

            //test = true;

            //rulez[listview1.SelectedIndex] = textBox1.Text; 

        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dcombo();
        }

        private void listview1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void selectAll(object sender, RoutedEventArgs e)
        {
        }

        private void unSelectAll(object sender, RoutedEventArgs e)
        {
        }

        private void listview1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Delete && listview1.SelectedIndex > -1)
            {
                rulez.RemoveAt(listview1.SelectedIndex);
                keyz.RemoveAt(listview1.SelectedIndex);
                pathz.RemoveAt(listview1.SelectedIndex);
                actionz.RemoveAt(listview1.SelectedIndex);
            }
            update();
        }

        private void dcombo()
        {
            if (comboBox.SelectedIndex == 4)
            {
                textBox3.Visibility = Visibility.Hidden;
                l4.Visibility = Visibility.Hidden;
                location.Visibility = Visibility.Hidden;
                textBox3.Text = "Marked for deletion";
            }
            else
            {
                textBox3.Visibility = Visibility.Visible;
                l4.Visibility = Visibility.Visible;
                location.Visibility = Visibility.Visible;
                textBox3.Text = string.Empty;

            }

        }

        private void hidden()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

            textBox1.Visibility = Visibility.Hidden;
            textBox2.Visibility = Visibility.Hidden;
            textBox3.Visibility = Visibility.Hidden;
            comboBox.Visibility = Visibility.Hidden;

            l1.Visibility = Visibility.Hidden;
            l2.Visibility = Visibility.Hidden;
            l3.Visibility = Visibility.Hidden;
            l4.Visibility = Visibility.Hidden;

            location.Visibility = Visibility.Hidden;
            saverule.Visibility = Visibility.Hidden;

            this.Width = 595;

        }
        private void visable()
        {
            textBox1.Visibility = Visibility.Visible;
            textBox2.Visibility = Visibility.Visible;
            textBox3.Visibility = Visibility.Visible;

            comboBox.Visibility = Visibility.Visible;
            comboBox.SelectedIndex = 0;

            l1.Visibility = Visibility.Visible;
            l2.Visibility = Visibility.Visible;
            l3.Visibility = Visibility.Visible;
            l4.Visibility = Visibility.Visible;

            location.Visibility = Visibility.Visible;
            saverule.Visibility = Visibility.Visible;

            this.Width = 883;

        }

        private void Window_Activated_1(object sender, EventArgs e)
        {

        }


    }
}
