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
using System.Windows.Shapes;

namespace ReunioSocial
{
    /// <summary>
    /// Lógica de interacción para ConfigEscenari.xaml
    /// </summary>
    public partial class ConfigEscenari : Window
    {
        MainWindow m;
        public ConfigEscenari(MainWindow m)
        {
            InitializeComponent();
            this.m = m;
        }

        private void btnAcceptar_Click(object sender, RoutedEventArgs e)
        {
            m.Num_homes = (int)sldHomes.Value;
            m.Num_dones = (int)sldDones.Value;
            m.Num_cambrers = (int)sldCambrers.Value;
            m.Num_files = (int)sldFiles.Value;
            m.Num_columnes = (int)sldColumnes.Value;
            this.Close(); 
        }


        private void sldCambrers_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            tbnumCambrers.Text = Convert.ToString((int)sldCambrers.Value);
        }

        private void sldHomes_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            tbnumHomes.Text = Convert.ToString((int)sldHomes.Value);
        }

        private void sldDones_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            tbnumDones.Text = Convert.ToString((int)sldDones.Value);
        }

        private void sldFiles_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            tbnumFiles.Text = Convert.ToString((int)sldFiles.Value);
        }

        private void sldColumnes_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            tbnumColumnes.Text = Convert.ToString((int)sldColumnes.Value);
        }
    }
}
