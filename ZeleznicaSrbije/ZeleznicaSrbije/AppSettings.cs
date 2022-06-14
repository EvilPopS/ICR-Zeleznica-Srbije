using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeleznicaSrbije {
    internal class AppSettings {
        public static string projectRoot = System.IO.Path.GetFullPath(@"..\..\");
        
        public static string databasePath = projectRoot + @"Database\DataFiles\";
    }
}
