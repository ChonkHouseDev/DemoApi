using System;
using System.IO;
namespace WebAPICore.Services
{
    public class LogErrores
    {
        private string path = "";

        public LogErrores(string Path) 
        {  
            this.path= Path;
        }

        public void Add(string sLog)
        {
            CreateDirectory();

            string nombre = GetNameFile();

            string cadena = "";
               
            cadena += DateTime.Now + " - " + sLog + Environment.NewLine;
            
            StreamWriter SW = new StreamWriter(path + "/" + nombre, true);

            SW.WriteLine(cadena);
            SW.Close();
        }

        private string GetNameFile()
        {
            string nombre = "";

            nombre = "log_" + DateTime.Now.Day+"_"+DateTime.Now.Month+"_"+DateTime.Now.Year + ".txt";

            return nombre;
        }

        private void CreateDirectory()
        {
            try { 
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            }
            catch(DirectoryNotFoundException ex)
            {
                throw new Exception(ex.Message);
            
            }
        }
    }
}
