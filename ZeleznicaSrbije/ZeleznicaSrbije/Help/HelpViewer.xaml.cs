using System;
using System.IO;
using System.Windows;

namespace ZeleznicaSrbije.Help {
    public partial class HelpViewer : Window {
        public HelpViewer() {
            InitializeComponent();
        }

        public HelpViewer(string key, Window originator) {
            InitializeComponent();
            string path = string.Format(AppSettings.projectRoot + @"Help\Pages\{0}.html", key);
            Console.WriteLine(path);
            if (!File.Exists(path)) {
                key = "error";
            }
            Uri u = new Uri(string.Format(AppSettings.projectRoot + @"Help\Pages\{0}.html",key));
            wbHelp.Navigate(u);
        }

        private void wbHelp_Navigating(object sender, System.Windows.Navigation.NavigatingCancelEventArgs e) {

        }
    }
}
