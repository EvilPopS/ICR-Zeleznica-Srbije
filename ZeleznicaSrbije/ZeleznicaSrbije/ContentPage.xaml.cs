using System;
using System.Windows.Controls;

namespace ZeleznicaSrbije {
    public partial class ContentPage : Page {
        public event Action<string> PageEvents;


        public ContentPage() {
        }

        #pragma warning disable IDE0060 // Remove unused parameter
        public static implicit operator ContentPage(LoginPage v) => new ContentPage();

        #pragma warning disable IDE0060 // Remove unused parameter
        public static implicit operator ContentPage(RegisterPage v) => new ContentPage();
    }
}
