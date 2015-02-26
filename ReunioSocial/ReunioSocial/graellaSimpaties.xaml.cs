using ClassesParty;
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
    /// Lógica de interacción para graellaSimpaties.xaml
    /// </summary>
    public partial class graellaSimpaties : Window
    {
        private int num_homes;
        private int num_dones;
        private int num_convidats;
        private int num_cambrers;
        private int num_files = 0;
        private int num_columnes = 0;
        string[] nomsDones = { "maria", "marta", "anna", "cristina", "susana", "ague", "channel", "noa", "maite", "mercedes", "nuria", "silvia" };
        string[] nomsHomes = { "joan", "jordi", "cristian", "eric", "david", "alex", "sergi", "martí", "xavier", "eudald", "gabri", "arnau" };

        string[] imgHomes = { "Brian.png", "Peter Griffin.png", "Quagmire.PNG", "xerxes.png" };
        string[] imgDones = { "tia1.png", "tia2.png", "tia3.png", "tia4.png", "tia5.png", "tia6.png", "tia7.png", "tia8.png", "tia9.png", "tia10.png", "tia11png" };

        Escenari esc;

        public graellaSimpaties(Escenari escenari, int numConvidats)
        {
            InitializeComponent();
            this.esc = escenari;
            this.num_convidats = numConvidats;
            
            iniciaGraella();
        }

        private void iniciaGraella()
        {
            
            // Reiniciem la graella
            grdGraella.ColumnDefinitions.Clear();
            grdGraella.RowDefinitions.Clear();
            grdGraella.Children.Clear();

            // Calculem el nombre de convidats per fer la graella sense tenir en compte els cambrers
            // ja que no cal que apareixin
            

            inicialitzaGraella();

            ompleSimpaties();

            
            grdGraella.ShowGridLines = true;

        }

        #region GENEREM TOTA LA GRAELLA DE SIMPATIES
        private void ompleSimpaties()
        {
            TextBox simpatiaPersona;

            // Mostrem les simpaties de cada convidat anvers a totes les altres a la graella
            for (int i = 0; i < num_convidats; i++)
            {
                for (int j = 0; j < num_convidats; j++)
                {
                    if (j != i && !(esc.Tp.ElementAt(i) is Cambrer) && !(esc.Tp.ElementAt(j) is Cambrer))
                    {
                        simpatiaPersona = new TextBox();
                        
                        simpatiaPersona.FontSize = 16;
                        simpatiaPersona.FontWeight = FontWeights.Bold;
                        simpatiaPersona.VerticalAlignment = VerticalAlignment.Center;
                        simpatiaPersona.HorizontalAlignment = HorizontalAlignment.Center;

                        if (esc.Tp.ElementAt(i) is Home)
                        {
                            Home aux = (Home)esc.Tp.ElementAt(i);
                            simpatiaPersona.Text = (aux[esc.Tp.ElementAt(j).Nom] + aux.PlusSexe).ToString();
                            simpatiaPersona.LostFocus +=simpatiaPersona_LostFocus;
                        }
                        else if (esc.Tp.ElementAt(i) is Dona)
                        {
                            Dona aux = (Dona)esc.Tp.ElementAt(i);
                            simpatiaPersona.Text = (aux[esc.Tp.ElementAt(j).Nom] + aux.PlusSexe).ToString();
                            simpatiaPersona.LostFocus += simpatiaPersona_LostFocus;
                            
                        }

                        Grid.SetColumn(simpatiaPersona, j + 1);
                        Grid.SetRow(simpatiaPersona, i + 1);
                        grdGraella.Children.Add(simpatiaPersona);
                    }
                }
            }
        }

        // Canviem les simpaties durant l'execució del programa
        private void simpatiaPersona_LostFocus(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("entra");
            try
            {
                int nouValor = Convert.ToInt32(((TextBox)sender).Text);
                int columna = Grid.GetColumn((TextBox)sender);
                int fila = Grid.GetRow((TextBox)sender);

                string nom, nom2;

                if(nouValor < -8 || nouValor > 8)
                {
                    MessageBox.Show("Els valors vàlids son de -8 a 8");
                }
                else
                {
                    if (fila > columna) // Hem d'agafar el valor de la columna esquerra com a nom
                    {

                        TextBlock tb = (TextBlock)grdGraella.Children[fila - 1]; // Obtenim la persona que li canvia la simpatia
                        nom = tb.Text;

                        TextBlock tb2 = (TextBlock)grdGraella.Children[columna - 1]; // Obtenim la persona anvers es fa la simpatia
                        nom2 = tb2.Text;

                        Convidat personaAcanviar = (Convidat)esc.Tp[nom]; // Busquem la persona que és en funcio del nom

                        personaAcanviar[nom2] = nouValor;

                    }
                    else  // Hem d'agafar el valor de la fila de dalt com a nom
                    {
                        TextBlock tb = (TextBlock)grdGraella.Children[fila - 1]; // Obtenim la persona que li canvia la simpatia
                        nom = tb.Text;

                        TextBlock tb2 = (TextBlock)grdGraella.Children[columna - 1]; // Obtenim la persona anvers es fa la simpatia
                        nom2 = tb2.Text;

                        Convidat personaAcanviar = (Convidat)esc.Tp[nom]; // Busquem la persona que és en funcio del nom

                        personaAcanviar[nom2] = nouValor;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("No has entrat un nombre. Error: " + ex.ToString());
            }
            
        }



        // Inicialitzem la graella amb els noms dels convidats a la primera fila i també a la primera columna
        private void inicialitzaGraella()
        {
            ColumnDefinition colDef;
            RowDefinition rowDef;
            TextBlock nomPersona;

            ////Columna de noms
            colDef = new ColumnDefinition();
            grdGraella.ColumnDefinitions.Add(colDef);

            // Generem les columnes de la graella 
            // i també posem els noms dels convidats a la primera fila
            for (int i = 0; i < num_convidats; i++)
            {
                colDef = new ColumnDefinition();

                grdGraella.ColumnDefinitions.Add(colDef);

                // Creem l'element que mostrarà el nom de la persona
                nomPersona = new TextBlock();
                nomPersona.Text = esc.Tp.ElementAt(i).Nom;
                nomPersona.FontSize = 14;
                nomPersona.FontWeight = FontWeights.Bold;
                nomPersona.Foreground = new SolidColorBrush(Colors.Black);
                nomPersona.VerticalAlignment = VerticalAlignment.Center;
                nomPersona.HorizontalAlignment = HorizontalAlignment.Center;
                nomPersona.RenderTransformOrigin = new Point(0.5, 0.5);
                nomPersona.RenderTransform = new RotateTransform(-90);
                Grid.SetRow(nomPersona, 0);
                Grid.SetColumn(nomPersona, i + 1);
                grdGraella.Children.Add(nomPersona);
            }

            //Fila de noms
            rowDef = new RowDefinition();
            grdGraella.RowDefinitions.Add(rowDef);

            // Generem les files de la graella 
            // i també posem els noms dels convidats a la primera columna
            for (int i = 0; i < num_convidats; i++)
            {
                rowDef = new RowDefinition();
                grdGraella.RowDefinitions.Add(rowDef);

                nomPersona = new TextBlock();
                nomPersona.Text = esc.Tp.ElementAt(i).Nom;
                nomPersona.FontSize = 14;
                nomPersona.FontWeight = FontWeights.Bold;
                nomPersona.Foreground = new SolidColorBrush(Colors.Black);
                nomPersona.VerticalAlignment = VerticalAlignment.Center;
                nomPersona.HorizontalAlignment = HorizontalAlignment.Center;
                Grid.SetRow(nomPersona, i + 1);
                Grid.SetColumn(nomPersona, 0);
                grdGraella.Children.Add(nomPersona);
            }
        }

        #endregion

        
    }
}
