using System;
using System.Windows.Controls;

namespace ZeleznicaSrbije {
    internal class ContentPage : Page {
        public event Action<string> PageEvents;


        public ContentPage() {
        }

        public static implicit operator ContentPage(LoginPage v) => new ContentPage();

        public static implicit operator ContentPage(RegisterPage v) => new ContentPage();
    }
}
