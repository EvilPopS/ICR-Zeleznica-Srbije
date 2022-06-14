using System.Windows;

namespace ZeleznicaSrbije.Help {
    public class HelpProvider {
        public static readonly DependencyProperty HelpKeyProperty =
               DependencyProperty.RegisterAttached("HelpKey", typeof(string), typeof(HelpProvider), new PropertyMetadata("index", HelpKey));

        public static string GetHelpKey(DependencyObject obj) {
            return obj.GetValue(HelpKeyProperty) as string;
        }

        public static void SetHelpKey(DependencyObject obj, string value) {
            obj.SetValue(HelpKeyProperty, value);
        }

        private static void HelpKey(DependencyObject d, DependencyPropertyChangedEventArgs e) {

        }

        public static void ShowHelp(string key, Window originator) {
            HelpViewer hh = new HelpViewer(key, originator);
            hh.Show();
        }
    }
}
