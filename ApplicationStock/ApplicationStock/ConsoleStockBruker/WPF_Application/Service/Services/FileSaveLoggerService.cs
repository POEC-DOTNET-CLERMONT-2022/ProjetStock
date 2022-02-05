using ProjectStockLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace WPF_Application.Service.Services
{
    public class FileSaveLoggerService
    {

        private static readonly object _saveLocker = new object();


        public void SaveThreadSafe(string content)
        {
            lock (_saveLocker)
            {
                Console.WriteLine("ouverture de notre fichier !!");

                using var streamWriter = new StreamWriter("./my_save.txt");

                Thread.Sleep(15000);

                Console.WriteLine("Ecriture");

                streamWriter.Write(content);
            }
        }




        public void AccessToMyInfo(Client client)
        {
            lock (_saveLocker)
            {
                MessageBox.Show("Debut ecriture", "Ecriure", MessageBoxButton.OK, MessageBoxImage.Asterisk) ;
                try
                {
                    using var streamWriter = new StreamWriter("./save_user_info.txt");

                    Thread.Sleep(15000);

                    string content = $" id : {client.Id.ToString() }, Name :{ client._lastName}, firstName: {client._firstName}";

                    content += client.readAllMyAdress() + "}";

                    MessageBox.Show("Erreur", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);

                    streamWriter.Write(content);


                }
                catch(Exception e)
                {

                    MessageBox.Show("Fin ecriture", "Ecriure", MessageBoxButton.OK, MessageBoxImage.Asterisk);

                    throw new Exception("Erreur ecriture");
                }
              

            }
        }
    }
}
