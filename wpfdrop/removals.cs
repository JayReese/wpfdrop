using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Windows;
using System.Collections.ObjectModel;



namespace wpfdrop
{
    class removals
    {


        public void permdelete(List<string>removals)
        {
            if (removals.Count > 0)
                if (MessageBox.Show("Do you want to delete all original files?",
                 "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    foreach (string item in removals)
                    {
                        if (Directory.Exists(item))
                            Directory.Delete(item, true);
                        else
                            File.Delete(item);
                    }
        }

        public void f1clear(List<string>zitem)
        {
            zitem.Clear();
        }

        public void specials(List<string> safe)
        {


            string[] specialPaths = Enum.GetNames(typeof(Environment.SpecialFolder));

            foreach (string special in specialPaths)
            {
                Environment.SpecialFolder specialFolder = (Environment.SpecialFolder)Enum.Parse(typeof(Environment.SpecialFolder), special);

                string path = Environment.GetFolderPath(specialFolder);

                safe.Add(path.ToLower());

            }
            

        }
    }
}
