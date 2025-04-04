using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;
using Autok;

namespace AutokWPF;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    List<Auto> autok;
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Betolt_Click(object sender, RoutedEventArgs e)
    {
        OpenFileDialog megnyitas = new OpenFileDialog();
        megnyitas.ShowDialog();
        string path = megnyitas.FileName;
        if (path != "")
        {
            autok = Auto.Beolvasas(path);
        }
        dataGridAutok.ItemsSource = autok;
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        int beirtev;
        List<string> markamodel = new List<string>();
        try
        {
            beirtev = int.Parse(txtGyartasiEv.Text);
            List<Auto> szurt = autok.Where(x => x.Gyartasi_ev == beirtev).ToList();
            foreach (var item in szurt)
            {
                markamodel.Add($"{item.Marka} {item.Model}");
            }
        }
        catch (Exception)
        {

            MessageBox.Show("nem jo formatum");
        }
        listBoxAutok.ItemsSource = markamodel;
    }

    private void Bezar_Click(object sender, RoutedEventArgs e)
    {
        MessageBoxResult result = MessageBox.Show("Biztosan ki szeretne lépni?",
                                                  "Kilépés megerősítése",
                                                  MessageBoxButton.YesNo,
                                                  MessageBoxImage.Question);

        if (result == MessageBoxResult.Yes)
        {
            Application.Current.Shutdown();
        }
    }
}