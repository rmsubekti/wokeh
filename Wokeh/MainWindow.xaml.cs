using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Wokeh
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool sP;
        int sF = 0;
        Functions fun = new Functions();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TitleWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void menu_Click(object sender, RoutedEventArgs e)
        {
            (sender as Button).ContextMenu.IsEnabled = true;
            (sender as Button).ContextMenu.PlacementTarget = (sender as Button);
            (sender as Button).ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            (sender as Button).ContextMenu.IsOpen = true;
        }

        private void btnClose_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void btnPin_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (sP == true)
            {
                sP = false;
                btnPin.Foreground = Brushes.Black;
            }
            else
            {
                sP = true;
                btnPin.Foreground = Brushes.Red;
            }

            this.Topmost = sP;
        }

        private void htmlEncode_Click(object sender, RoutedEventArgs e)
        {
            sF = 0;
            this.Title = "Wokeh HTML Encoder";
            TitleWindow.Content = "Wokeh HTML Encoder";
            action.Content = "Encode";
        }

        private void htmlDecode_Click(object sender, RoutedEventArgs e)
        {
            sF = 1;
            this.Title = "Wokeh HTML Decoder";
            TitleWindow.Content = "Wokeh HTML Decoder";
            action.Content = "Decode";
        }

        private void imgEncode_Click(object sender, RoutedEventArgs e)
        {
            sF = 2;
            this.Title = "Wokeh Image Encoder";
            TitleWindow.Content = "Wokeh Image Encoder";
            action.Content = "Open File";
        }
        
        private void action_Click(object sender, RoutedEventArgs e)
        {
            if (sF == 2) preview.Text = fun.toBase64();
            else preview.Text = fun.htmlEntt(sF);
        }

        private void preview_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            preview.Text = "Wokeh\n"+
                "A Simple Offline Blogger Tool\n\n"+
                "Tunggu dulu, kamu bener - bener pake alat ini?\n"+
                "Ahh, Aku cuma ga nyangka aplikasi ini berguna.\n\n"+
                "Jika kamu anggap aplikasi ini benar - benar berguna, Beri bintang atau fork disini:\n"+
                "https://github.com/rmsubekti/wokeh/fork\n\n" +
                "Atau bantu Laporkan Error / kesalahan :\n"+
                "https://github.com/rmsubekti/wokeh/issues";
        }
    }
}
