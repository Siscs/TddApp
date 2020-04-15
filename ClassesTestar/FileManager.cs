using System;
using System.IO;

namespace ClassesTestar
{
    public class FileManager
    {

        public bool ExisteArquivo(string nomeArquivo)
        {
            if(string.IsNullOrEmpty(nomeArquivo))
            {
                throw new ArgumentNullException("nome do arquivo inválido.");
            }

            return File.Exists(nomeArquivo);
            
        }
    }
}
