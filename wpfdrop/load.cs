using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace wpfdrop
{
    public class load
    {
        private List<string> keys = new List<string>();
        private List<string> paths = new List<string>();
        private List<string> rules = new List<string>();
        private List<string> actions = new List<string>();

        private string image;
        private string dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Drop2.xml");
        Words word = new Words();
        XmlLoad<Words> loadword = new XmlLoad<Words>();


        public void loading()
        {
            word = loadword.LoadData(dir);
            image = word.image;

            foreach (string item in word.s1)
            {
                keys.Add(item);
            }
            foreach (string item in word.s2)
            {
                paths.Add(item);
            }
            foreach (string item in word.s3)
            {
                rules.Add(item);
            }
            foreach (string item in word.s4)
            {
                actions.Add(item);
            }
        }

        public string loading (string image)
        {

            word = loadword.LoadData(dir);
            image = word.image;
            //image1 = word.image;



            foreach (string item in word.s1)
            {
                keys.Add(item);
            }
            foreach (string item in word.s2)
            {
                paths.Add(item);
            }
            foreach (string item in word.s3)
            {
                rules.Add(item);
            }
            foreach (string item in word.s4)
            {
                actions.Add(item);
            }


            return image;
        }

        public void loading(List<string> k,List<string> p,List<string> r,List<string> a)
        {

            word = loadword.LoadData(dir);

            image = word.image;

            foreach (string item in word.s1)
            {
                k.Add(item);
            }
            foreach (string item in word.s2)
            {
                p.Add(item);
            }
            foreach (string item in word.s3)
            {
                r.Add(item);
            }
            foreach (string item in word.s4)
            {
                a.Add(item);
            }
        }

        public void savingwords(List<string> r, List<string> k, List<string> p, List<string> a, string image)
        {

            word.s1 = k;
            word.s2 = p;
            word.s3 = r;
            word.s4 = a;
            word.image = image;

            XmlSave.SaveData(word, dir);
        }
        public void savingwords(List<string> r, List<string> k, List<string> p, List<string> a)
        {

            word.s1 = k;
            word.s2 = p;
            word.s3 = r;
            word.s4 = a;
            word.image = image;

            XmlSave.SaveData(word, dir);
        }

        //public void savingwords(string image)
        //{
        //    word.image = image;
        //}
        //public void saving()
        //{
        //   XmlSave.SaveData(word, dir);
        //}
    
    }
}