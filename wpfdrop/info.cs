using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Collections.ObjectModel;



namespace wpfdrop
{
    class info
    {
        private string filesize;

        public void information(List<string>Items,FileInfo file)
        {
            double len = 0;
            byte type = 0;
            string typeName = "";
            if ((file.Attributes & FileAttributes.Directory) == FileAttributes.Directory)
            {
                filesize = "This is a directory.";
                return;
            }

            len = (double)file.Length;
            while (len > 1024)
            {
                len /= 1024;
                type++;
            }
            switch (type)
            {
                case 0:
                    typeName = " bytes";
                    break;
                case 1:
                    typeName = " kb";
                    break;
                case 2:
                    typeName = " MB";
                    break;
                case 3:
                    typeName = " GB";
                    break;
                default:
                    len = (double)file.Length;
                    typeName = " bytes";
                    break;
            }
            string size = len.ToString("F");
            if (size.EndsWith(".00"))
                size = size.Remove(size.Length - 3, 3);
            filesize = size + typeName;
            return;

        }
        public string size
        {
            get { return filesize; }
            set{value = filesize;}
        }

    }
}