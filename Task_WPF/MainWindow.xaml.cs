using System;
using System.Threading.Tasks;
using System.Windows;

namespace Task_WPF
{
    /// <summary>
    ///  we can used a gif to show a loding 
    /// </summary>
    public partial class MainWindow : Window
    {
        bool flag = true;
        int tot = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Processo2()
        {
            int sum = 0;

            for (int i = 0; i < 150; i++)
            {
                await Task.Delay(800);
                await Task.Run(() =>
                {
                    sum += i;
                });

                Timer.Text = $"{sum}  hai cliccato N{tot}";
                await Task.Delay(200);
                loadding.Stop();
                loadding.Play();
            }

            MessageBox.Show("Loding completato");
            loadding.Close();
            loadding.Visibility = Visibility.Collapsed;
            flag = true;
        }

        private void Button_Click_Counter(object sender, RoutedEventArgs e)
        {
            if (flag == true) {Processo2(); flag = false;}

            tot++;
        }


    }
}
