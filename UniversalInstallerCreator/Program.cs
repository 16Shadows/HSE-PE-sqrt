using System;
using System.IO;

namespace UniversalInstallerPacker
{
    class Program
    {
        const int BUFFER_SIZE = 10485760;

        static void Main(string[] args)
        {
            if(args.Length < 5) Environment.Exit(1);

            try
            {
                File.Copy(args[0], args[1], true);
                
                byte[] buffer = new byte[BUFFER_SIZE];

                int bytesToWrite;
                long startPos;

                using(FileStream file = File.OpenWrite(args[1])) {
                    file.Seek(0, SeekOrigin.End);
                    using(BinaryWriter writer = new BinaryWriter(file))
                    {
                        startPos = file.Position;
                        writer.Write(args[2]);
                        writer.Write(args[3]);
                        FileStream otherFile = null;
                        for(int i = 4; i < args.Length; i++)
                        {
                            otherFile = File.OpenRead(args[i]);
                            
                            Console.WriteLine("Writing file name: " + args[i]);

                            writer.Write(args[i]);
                            
                            Console.WriteLine("Writing file size: " + otherFile.Length);
                            
                            writer.Write(otherFile.Length);
                            
                            do
                            {
                                bytesToWrite = otherFile.Read(buffer, 0, BUFFER_SIZE);
                                file.Write(buffer, 0, bytesToWrite);
                            }
                            while(otherFile.Position != otherFile.Length);

                            otherFile.Close();
                            otherFile.Dispose();
                        }
                        Console.WriteLine("Number of bytes written: " + (file.Length - startPos - 1));
                        writer.Write(startPos);
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                Environment.Exit(1);
            }   
        }
    }
}
