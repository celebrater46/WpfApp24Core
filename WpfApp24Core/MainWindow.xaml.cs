using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp24Core
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBlock1_OnPreviewDragOver(object sender, DragEventArgs e)
        {
            // Change a mouse cursor to "coping"
            e.Effects = DragDropEffects.Copy;
            e.Handled = e.Data.GetDataPresent(DataFormats.FileDrop);
        }

        private void TextBlock1_OnDrop(object sender, DragEventArgs e)
        {
            var txt = sender as TextBlock;
            var files = e.Data.GetData(DataFormats.FileDrop) as string[];

            if (files == null)
            {
                txt.Text = "";
                return;
            }

            var sb = new StringBuilder();
            foreach (string file in files)
            {
                sb.Append(file).Append("\r\n");
            }

            txt.Text = sb.ToString();
        }
    }
}
