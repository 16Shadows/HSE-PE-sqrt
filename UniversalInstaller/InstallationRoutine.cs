using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace UniversalInstaller
{
    static class InstallationRoutine
    {
        const int BUFFER_SIZE = 10485760;

        private static List<string> createdDirectories;
        private static List<string> unpackedFiles;

        public static bool isRunning;

        public static string FolderName { get; private set; }
        public static string shortcutExe { get; private set; }

        private static long installerStart;

        public static void PreParse()
        {
            using(FileStream thisFile = File.OpenRead( Assembly.GetExecutingAssembly().Location))
            {
                using (BinaryReader reader = new BinaryReader(thisFile))
                {
                    //Read byte offset of the installer
                    thisFile.Seek(-8, SeekOrigin.End);
                    long offset = reader.ReadInt64();

                    //Jump to the beginning of the installer data
                    thisFile.Seek(offset, SeekOrigin.Begin);

                    FolderName = reader.ReadString();
                    shortcutExe = reader.ReadString();

                    installerStart = thisFile.Position;
                }
            }
        }

        public static bool Run(string path, bool useGUI = false, Label text = null, ProgressBar bar = null)
        {
            if(path == null) return false;
            else if(useGUI && (bar == null || text == null)) useGUI = false;

            isRunning = true;

            if(useGUI)
            {
                text.Text = "0%";
                bar.Value = 0;
            }

            //Assemble a list of directories created to put the files into
            //It will come in handy should the need to undo everything arise
            createdDirectories = new List<string>();

            //A list of files we have unpacked (or began unpacking) so far
            //It will come in handy should the need to undo everything arise
            unpackedFiles = new List<string>();
            try
            {
                if(path.LastIndexOf('\\') == path.Length-1 || path.LastIndexOf('/') == path.Length-1) path = path.Remove(path.Length-1, 1);
                string part = path;

                while( !Directory.Exists(part) )
                {
                    createdDirectories.Add(part);
                    part = Path.GetDirectoryName(part);
                }

                Directory.CreateDirectory(path);

                using(FileStream thisFile = File.OpenRead( Assembly.GetExecutingAssembly().Location)) {
                    using(BinaryReader reader = new BinaryReader(thisFile))
                    {
                        long offset;
                    
                        //Jump to the beginning of the installer data
                        thisFile.Seek(installerStart, SeekOrigin.Begin);

                        FileStream otherFile;
                        string filename;

                        byte[] buffer = new byte[BUFFER_SIZE];
                        int bytesTransfered;
                        int bytesOperation;

                        long totalBytes = (thisFile.Length - installerStart - 1);
                        long totalBytesTransfered = 0;

                        //Parse files in the installer
                        if(useGUI)
                        {
                            while(isRunning && thisFile.Position < thisFile.Length - 8 )
                            {
                                filename = reader.ReadString();
                                offset = reader.ReadInt64();

                                filename = path + "\\" + filename;

                                //Add the folders we create to the list
                                part = Path.GetDirectoryName(filename);
                            
                                if(!Directory.Exists(part))
                                {
                                    while( !Directory.Exists(part) )
                                    {
                                        createdDirectories.Add(part);
                                        part = Path.GetDirectoryName(part);
                                    }
                                    Directory.CreateDirectory(Path.GetDirectoryName(filename));
                                }
                            
                                //Unpack the file
                                unpackedFiles.Add(filename);
                                using(otherFile = File.OpenWrite(filename))
                                {
                                    for(bytesTransfered = 0; bytesTransfered < offset; bytesTransfered += bytesOperation)
                                    {
                                        bytesOperation = thisFile.Read(buffer, 0, (int)Math.Min(offset - bytesTransfered, BUFFER_SIZE));
                                        otherFile.Write(buffer, 0, bytesOperation);
                                        totalBytesTransfered += bytesOperation;
                                        bar.Value = (int)Math.Ceiling(100*totalBytesTransfered/(double)totalBytes);
                                        text.Text = bar.Value + "%";
                                    }
                                }
                            }
                        }
                        else
                        {
                            while(isRunning && thisFile.Position < thisFile.Length - 8 )
                            {
                                filename = reader.ReadString();
                                offset = reader.ReadInt64();

                                filename = path + "\\" + filename;

                                //Add the folders we create to the list
                                part = Path.GetDirectoryName(filename);
                            
                                if(!Directory.Exists(part))
                                {
                                    while( !Directory.Exists(part) )
                                    {
                                        createdDirectories.Add(part);
                                        part = Path.GetDirectoryName(part);
                                    }
                                    Directory.CreateDirectory(Path.GetDirectoryName(filename));
                                }
                            
                                //Unpack the file
                                unpackedFiles.Add(filename);
                                using(otherFile = File.OpenWrite(filename))
                                {
                                    for(bytesTransfered = 0; bytesTransfered < offset; bytesTransfered += bytesOperation)
                                    {
                                        bytesOperation = thisFile.Read(buffer, 0, (int)Math.Min(offset - bytesTransfered, BUFFER_SIZE));
                                        otherFile.Write(buffer, 0, bytesOperation);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch(Exception e)
            {
                UndoFiles();
                UndoDirectories();
                isRunning = false;
                throw e;
            }
            
            if(unpackedFiles.Count == 0) UndoDirectories();

            isRunning = false;

            return true;
        }

        public static void UndoDirectories()
        {
            if(createdDirectories != null && createdDirectories.Count > 0)
            {
                foreach(string directory in createdDirectories.OrderByDescending(str => str.Length))
                    if(Directory.Exists(directory))
                        Directory.Delete(directory);
            }
        }

        public static void UndoFiles()
        {
            if(unpackedFiles != null && unpackedFiles.Count > 0)
            {
                for(int i = 0; i < unpackedFiles.Count; i++)
                    if(File.Exists(unpackedFiles[i]))
                        File.Delete(unpackedFiles[i]);
            }
        }
    }
}
