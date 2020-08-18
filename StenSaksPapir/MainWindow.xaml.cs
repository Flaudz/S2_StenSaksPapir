using System;
using System.Collections.Generic;
using System.IO;
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

namespace StenSaksPapir
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BitmapImage thinkingImgSource = new BitmapImage(new Uri("C:/Users/nico936d/Documents/S-2/Uge_33/Onsdag-StenSaksPapir/StenSaksPapir/Thinking.png"));
        BitmapImage rockImgSource = new BitmapImage(new Uri("C:/Users/nico936d/Documents/S-2/Uge_33/Onsdag-StenSaksPapir/StenSaksPapir/Rock.png"));
        BitmapImage paperImgSource = new BitmapImage(new Uri("C:/Users/nico936d/Documents/S-2/Uge_33/Onsdag-StenSaksPapir/StenSaksPapir/Paper.png"));
        BitmapImage scissorsImgSource = new BitmapImage(new Uri("C:/Users/nico936d/Documents/S-2/Uge_33/Onsdag-StenSaksPapir/StenSaksPapir/Scissors.png"));

        public bool playerRock = false;
        public bool playerPaper = false;
        public bool playerScissors = false;

        public bool thinking = true;

        public bool pcRock = false;
        public bool pcPaper = false;
        public bool pcScissors = false;

        public int score = 0;
        public MainWindow()
        {
            InitializeComponent();

            if(thinking == true)
            {
                playerImage.Source = thinkingImgSource;
                pcImage.Source = thinkingImgSource;
            }
            
        }

        private void rockBtn_Click(object sender, RoutedEventArgs e)
        {
            playerImage.Source = rockImgSource;
            playerRock = true;
            thinking = false;
            pc();

        }

        private void paiperBtn_Click(object sender, RoutedEventArgs e)
        {
            playerImage.Source = paperImgSource;
            playerPaper = true;
            thinking = false;
            pc();
        }

        private void scissorsBtn_Click(object sender, RoutedEventArgs e)
        {
            playerImage.Source = scissorsImgSource;
            playerScissors = true;
            thinking = false;
            pc();
        }

        private void pc()
        {
            rockBtn.IsEnabled = false;
            paiperBtn.IsEnabled = false;
            scissorsBtn.IsEnabled = false;

            Random rnd = new Random();
            int pcRndNumber = rnd.Next(1, 3);
            if(pcRndNumber == 1)
            {
                pcImage.Source = rockImgSource;
                pcRock = true;
            }
            else if(pcRndNumber == 2)
            {
                pcImage.Source = paperImgSource;
                pcPaper = true;
            }
            else
            {
                pcImage.Source = scissorsImgSource;
                pcScissors = true;
            }
            wait();
        }

        private void scoreCalculater()
        {
            
            if(playerRock && pcRock || playerPaper && pcPaper || playerScissors && pcScissors)
            {
                
            }
            else if((playerRock == true && pcPaper == false) || (playerPaper == true && pcScissors == false) || (playerScissors == true && pcRock == false))
            {
                score++;
            }
            else
            {
                if(score > 0)
                {
                    score--;
                }
            }

            pointLabel.Content = score.ToString();

            pcRock = false;
            pcPaper = false;
            pcScissors = false;
            playerPaper = false;
            playerRock = false;
            playerScissors = false;
            thinking = true;

            rockBtn.IsEnabled = true;
            paiperBtn.IsEnabled = true;
            scissorsBtn.IsEnabled = true;
        }

        async void wait()
        {
            await Task.Delay(1000);
            scoreCalculater();
        }
    }
}
