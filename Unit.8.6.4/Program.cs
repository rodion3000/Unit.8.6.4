using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
namespace Unit_8_6_4
{
    class Program
    {
        public static void Main(string[] args)
        {
            DirectoryFile.Director();
            BinarFile.Move();
            BinarFile.Deserialize();
        }
    }
    
    class BinarFile
    {
       public static string rootfile = @"\Users\Rodion\Desktop\Students\Students.dat";
        public static string binarfile = @"\Users\Rodion\Desktop\Students.dat";
        
        public static void Move()
        {
         
            try 
            {
                 
                if(File.Exists(binarfile))
                {
                    if(!File.Exists (rootfile))
                    {
                        File.Move (binarfile, rootfile);
                        Console.WriteLine($"файл{binarfile} перемещен в директорию{rootfile}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static T Deserialize<T>()
        {
            try 
            {
            if (File.Exists (rootfile))
                {
                    var result = default (T);
                    BinaryFormatter formatter = new BinaryFormatter();
                    using (var fs = new FileStream(rootfile,FileMode.OpenOrCreate))
                    {

                        result = (T)formatter.Deserialize (fs);
                        
                    }
                    return result;
                    
                }
            
            }
            catch(Exception ex)
            { throw ex;}
        }
    }
    class DirectoryFile
    {
        public static void Director()
        {
            try
            {
                var root = new DirectoryInfo(@"\Users\Rodion\Desktop\Students");
                if (!root.Exists)
                {
                    root.Create();
                    Console.WriteLine($"Директория{root}создана");
                }
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }

    }
        
        } }

