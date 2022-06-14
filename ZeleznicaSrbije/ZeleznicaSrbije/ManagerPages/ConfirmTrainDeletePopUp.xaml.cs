using System;
using System.Windows;

namespace ZeleznicaSrbije.ManagerPages {
    public partial class ConfirmTrainDeletePopUp : Window
    {
        public event Action<bool> YesClicked;

        public ConfirmTrainDeletePopUp(string popUpMessage)
        {
            InitializeComponent();
            trainDeleteTextBlock.Text = popUpMessage;
        }

        private void Yes_Clicked(object sender, RoutedEventArgs e)
        {
            YesClicked?.Invoke(true);
            this.Close();
        }

        private void No_Clicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }




    }
}
