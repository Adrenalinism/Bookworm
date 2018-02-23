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
using System.Globalization;

namespace Bookworm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] all_words = File.ReadLines("C:\\Users\\Marko\\Downloads\\english-words-master\\english-words-master\\words_alpha.txt").ToArray();
        
        
        
        const int wordlength_limit = 5;

        

        string[] largest_word = { "$", "$", "$", "$", "$" };

        public MainWindow()
        {
            InitializeComponent();
            
        }

        static string UppercaseFirst(string s)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            return char.ToUpper(s[0]) + s.Substring(1);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            char[] original_letters = input.Text.ToCharArray();
            char[] available_letters = new char[original_letters.Length];

            for (int i = 0; i < all_words.Length; i++) // go through dictionary
            {
                Array.Copy(original_letters, available_letters, original_letters.Length); // clone original letters so they can be temporarily modified

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

                            for (int l = 0; l < largest_word.Length; l++)
                            {
                                if (letters_matched == current_word_letters.Length && current_word_letters.Length > largest_word[l].Length && !largest_word.Any(all_words[i].Contains)) // if all letters of word exist in available letters and if this is word is the biggest yet, make it the biggest
                                {

                                    largest_word[l] = all_words[i];

                                }
                            }
                        }
                        else
                        {
                            exit = 1;
                        }
                    }
                }
            }
            label1.Content = "1. " + UppercaseFirst(largest_word[0]);
            label1_Copy3.Content = "2. " + UppercaseFirst(largest_word[1]);
            label1_Copy4.Content = "3. " + UppercaseFirst(largest_word[2]);
            label1_Copy5.Content = "4. " + UppercaseFirst(largest_word[3]);
            label1_Copy6.Content = "5. " + UppercaseFirst(largest_word[4]);

            string s = new string(original_letters);
            //label1_Copy2.Content = s.ToUpper();
        }
    }
}
