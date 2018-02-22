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
        char[] available_letters = new char[16];
        char[] original_letters = { 's', 'x', 'm', 'x', 'i', 'e', 'e', 'i', 'd', 's', 'r', 'p', 'g', 'x', 'z', 'w' };
        const int wordlength_limit = 5;

        

        string largest_word = "";

        public MainWindow()
        {
            InitializeComponent();
            

            for (int i = 0; i < all_words.Length; i++) // go through dictionary
            {
                Array.Copy(original_letters, available_letters, 16);

                int letters_matched = 0;
                int exit = 0;
                char[] current_word_letters = all_words[i].ToCharArray(); // place each word in a char array as its being inspected

                if (current_word_letters.Length >= wordlength_limit) // only check relatively long words for increased speed
                {
                    for (int j = 0; j < current_word_letters.Length; j++) // go thorugh characters of each word
                    {
                        if (available_letters.Contains(current_word_letters[j]) && exit == 0) // if letter of current word is in the available letters
                        {
                            letters_matched++; // increase the count of letters of current word that are matched
                            available_letters[Array.IndexOf(available_letters, current_word_letters[j])] = '$'; // prevent letter from being used again in the loop
                            //available_letters = available_letters.Select(x => x.Replace("one", "zero")).ToArray();

                            if (letters_matched == current_word_letters.Length && current_word_letters.Length > largest_word.Length) // if all letters of word exist in available letters and if this is word is the biggest yet, make it the biggest
                            {
                                largest_word = all_words[i];
                            }
                        }
                        else
                        {
                            exit = 1;
                        }
                    }
                }
            }
            label1.Content = largest_word;
            
        }
    }
}
