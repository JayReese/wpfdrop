using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Collections.ObjectModel;
using Ionic.Zip;




namespace wpfdrop
{
    public class save
    {
        private List<string> keys = new List<string>();
        private List<string> paths = new List<string>();
        private List<string> rules = new List<string>();
        private List<string> actions = new List<string>();
        private string image = null;
        private string dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Drop2.xml");
        load lding = new load();


        public void saving(ObservableCollection<string> Items, List<string> removals)
        {
            if (File.Exists(dir))
                lding.loading(keys, paths, rules, actions);
            else
                return;     
            for (int i = 0; i < rules.Count(); i++)
            {
                foreach (string item in Items)
                {
                    DirectoryInfo diSource = new DirectoryInfo(item);

                    FileInfo fileInfo = new FileInfo(item);
                    DirectoryInfo diTarget;
                    diTarget = new DirectoryInfo(paths[i]);

                    #region Copy
                    if (actions[i] == "Copy")
                    {
                        if (paths[i] != "")
                        {
                            if (fileInfo.Name.Contains(keys[i]))
                            {
                                //copy directory
                                if (fileInfo.Attributes == FileAttributes.Directory)
                                {
                                    // Directory.Move(item, Path.Combine(paths[i], fileInfo.Name));
                                    CopyAll(diSource, diTarget);
                                    removals.Add(item);
                                }
                                else
                                {
                                    //copy file
                                    //add(i) if file exist
                                    if (File.Exists(Path.Combine(paths[i], fileInfo.Name)))
                                    {
                                        string fullPath = item;
                                        string path = paths[i];
                                        File.Copy(item, GetUniqueFilename(fullPath, path), true);
                                    }
                                    else
                                    {
                                        File.Copy(item, Path.Combine(paths[i], fileInfo.Name), true);
                                    }
                                    //adding items to removals to clear list
                                    removals.Add(item);
                                }
                            }
                            //if keyword is blank copy all files to path
                            if(keys[i] == string.Empty)
                            {                           
                                    File.Copy(item, Path.Combine(paths[i], fileInfo.Name), true);
                                    //adding items to removals to clear list
                                    removals.Add(item);
                            }
                        }
                    }
                    #endregion
                    #region Move
                    //moving files
                    if (actions[i] == "Move")
                    {
                        if (paths[i] != "")
                        {
                            if (fileInfo.Name.Contains(keys[i]))
                            {
                                //moving folders
                                if (fileInfo.Attributes == FileAttributes.Directory)
                                {
                                    MoveAll(diSource, diTarget);
                                    removals.Add(item);
                                }
                                else
                                {
                                    //move files, adding (i) if exsit
                                    if (File.Exists(Path.Combine(paths[i], fileInfo.Name)))
                                    {
                                        string fullPath = item;
                                        string path = paths[i];
                                        File.Move(item, GetUniqueFilename(fullPath, path));
                                    }
                                        //move file
                                    else
                                    {
                                        File.Move(item, Path.Combine(paths[i], fileInfo.Name));
                                    }
                                }
                                //adding to removals to clear list
                                removals.Add(item);
                            }
                        }
                    }
                    #endregion
                    #region Delete
                    //delete files
                    if (actions[i] == "Delete")
                    {
                        if (fileInfo.Name.Contains(keys[i]))
                        {
                            File.Delete(item);
                        }
                        //adding to removals to clear list
                        removals.Add(item);
                    }
                    #endregion
                    #region Unzip
                    //unzip  files
                    if (actions[i] == "Unzip")
                    {
                        if (paths[i] != "")
                        {
                            if (fileInfo.Name.Contains(keys[i]))
                            {
                                using (ZipFile zip = ZipFile.Read(item))
                                {
                                    foreach (ZipEntry e in zip)
                                    {
                                        e.Extract(paths[i], ExtractExistingFileAction.OverwriteSilently);
                                    }
                                    //adding to removals to clear list
                                    removals.Add(item);
                                }

                            }
                        }
                    }
                    #endregion
                    #region Zip
                    //Zip files
                        if (actions[i] == "Zip")
                        {
                            if (paths[i] != "")
                            {                               
                                if (fileInfo.Name.Contains(keys[i]))
                                {
                                    using (ZipFile zip = new ZipFile())
                                    {
                                        if (fileInfo.Attributes == FileAttributes.Directory)
                                        {
                                            string[] files = Directory.GetFiles(item);
                                            // add all those files to the ProjectX folder in the zip file
                                            zip.AddFiles(files);
                                            zip.Save(Path.Combine(paths[i], fileInfo.Name + ".zip"));
                                            //adding to removals to clear list
                                            removals.Add(item);
                                        }
                                        else
                                        {
                                            zip.AddFile(item);
                                            zip.Save(Path.Combine(paths[i], fileInfo.Name + ".zip"));
                                            //adding to removals to clear list
                                            removals.Add(item);
                                        }
                                    }
                                }
                            }
                        }
                    #endregion
                    #region Rename
                        //rename
                        if (actions[i] == "Rename")
                        {
                            if (paths[i] != "")
                            {
                                if (fileInfo.Name.Contains(keys[i]))
                                {

                                    string fullPath = item;
                                    string path = paths[i];
                                    string newname = rules[i];

                                    if (File.Exists(fullPath))
                                    {
                                        String filename = Path.GetFileName(fullPath);
                                        String filenameWOExt = Path.GetFileNameWithoutExtension(fullPath);
                                        String ext = Path.GetExtension(fullPath);

                                        do
                                        {
                                            fullPath = Path.Combine(path, String.Format("{0}{1}", newname, ext));
                                        }
                                        while (File.Exists(fullPath));
                                        File.Move(item, fullPath);
                                        //adding to removals to clear list
                                        removals.Add(item);

                                    }
                                }
                            }
                        }
                        #endregion
                }
            }

            #region Clearing Listview
            //clearing listbox
            foreach (string s in removals)
            {
                Items.Remove(s);
            }
            #endregion
        }
        //changes name if file exist adding (i) to the end
        public static string GetUniqueFilename(string fullPath,string path)
        {
            if (File.Exists(fullPath))
            {
                String filename = Path.GetFileName(fullPath);
                String filenameWOExt = Path.GetFileNameWithoutExtension(fullPath);
                String ext = Path.GetExtension(fullPath);
                int n = 1;
                do
                {
                    fullPath = Path.Combine(path, String.Format("{0} ({1}){2}", filenameWOExt, (n++), ext));
                }
                while (File.Exists(fullPath));
            }
            return fullPath;
        }
        //copying folders
        public static void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            if (source.FullName.ToLower() == target.FullName.ToLower())
            {
                return;
            }

            // Check if the target directory exists, if not, create it.
            if (Directory.Exists(target.FullName) == false)
            {
                Directory.CreateDirectory(target.FullName);
            }

            // Copy each file into it's new directory.
            foreach (FileInfo fi in source.GetFiles())
            {
                fi.CopyTo(Path.Combine(target.ToString(), fi.Name), true);
            }

            // Copy each subdirectory using recursion.
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir =
                    target.CreateSubdirectory(diSourceSubDir.Name);
                CopyAll(diSourceSubDir, nextTargetSubDir);
            }
        }
        public static void MoveAll(DirectoryInfo source, DirectoryInfo target)
        {
            if (source.FullName.ToLower() == target.FullName.ToLower())
            {
                return;
            }

            // Check if the target directory exists, if not, create it.
            if (Directory.Exists(target.FullName) == false)
            {
                Directory.CreateDirectory(target.FullName);
            }

            // Copy each file into it's new directory.
            foreach (FileInfo fi in source.GetFiles())
            {
                fi.MoveTo(Path.Combine(target.ToString(), fi.Name));
            }

            // Copy each subdirectory using recursion.
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir =
                    target.CreateSubdirectory(diSourceSubDir.Name);
                MoveAll(diSourceSubDir, nextTargetSubDir);
            }
        }

    }
}
