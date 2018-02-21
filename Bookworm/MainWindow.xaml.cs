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
using System.IO;

namespace Bookworm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] all_words = File.ReadLines("C:\\Users\\Marko\\Downloads\\english-words-master\\english-words-master\\words_alpha.txt").ToArray();
        char[] available_letters = { 's', 'a', 'm', 'e', 'd', 'e', 'e', 'i', 'd', 's', 'r', 'p', 'g', 'a', 'z', 'w' };
        const int wordlength_limit = 5;

        public MainWindow()
        {
            InitializeComponent();

            for (int i = 0; i < all_words.Length; i++) // go through dictionary
            {
                char[] current_word_letters = all_words[i].ToCharArray(); // place each word in a char array as its being inspected
                if (current_word_letters.Length >= wordlength_limit) // only check relatively long words for increased speed
                {
                    for (int j = 0; j < current_word_letters.Length; j++) // go thorugh characters of each word
                    {
                        if (available_letters.Contains(current_word_letters[j])) // if letter of current word is in the available letters
                        {
                            
                        }
                        else
                        {
                            j = 20;
                        }
                    }
                }
            }
            
        }
    }
}
