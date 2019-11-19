using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassicWowCharacterManager
{
    public static class DatabaseConnection
    {
        static string systemPath = System.Environment.
                             GetFolderPath(
                                 Environment.SpecialFolder.CommonApplicationData
                             );
        static string complete = Path.Combine(systemPath, "files");

        static string DBFile = System.Reflection.Assembly.GetEntryAssembly().Location + @"\WoWServer.mdf";
        public static string DB = string.Format(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={0};Integrated Security=True", DBFile);
        public static string DB2 = string.Format(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={0};Integrated Security=True", Application.StartupPath + @"\WoWServer.mdf");


    }
}
