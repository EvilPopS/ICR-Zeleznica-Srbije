using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace ZeleznicaSrbije.MainWindowPages {
    public partial class InformPopUp : Window {
        public InformPopUp(string message, bool isError) {
            InitializeComponent();
            messageTxt.Text = message;
            if (isError)
                img.Source = new BitmapImage(new Uri(@"..\Assets\Images\warning-sign-icon.png", UriKind.Relative));
            else
                img.Source = new BitmapImage(new Uri(@"..\Assets\Images\task-success-icon.png", UriKind.Relative));
        }

        private void Ok_Clicked(object sender, RoutedEventArgs e) {
            this.Close();
        }
    }
}
