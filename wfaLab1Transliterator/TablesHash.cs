using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using nsLex;

namespace tabHash
{
    class TablesHash
    {
        public string[] letter_words = new String[10];
        public string[] digit_words = new String[10];
        public string[] symbolic_words = new String[10];

        public int count_letter_words = 0;
        public int count_digit_words = 0;
        public int count_symbolic_words = 0;

        private bool flag_exist;

        public void add_word(string word, TToken type)
        {
            flag_exist = false;
            switch (type)
            {
                case TToken.lxmIdentifier:
                    for (int i = 0; i < count_letter_words; i++)
                    {
                        if (word == letter_words[i])
                        {
                            flag_exist = true;
                        }
                    }
                    if (!flag_exist)
                    {
                        letter_words[count_letter_words] = word;
                        count_letter_words++;
                    }
                    break;
                case TToken.lxmNumber:
                    for (int i = 0; i < count_digit_words; i++)
                    {
                        if (word == digit_words[i])
                        {
                            flag_exist = true;
                        }
                    }
                    if (!flag_exist)
                    {
                        digit_words[count_digit_words] = word;
                        count_digit_words++;
                    }
                    break;
                default:
                    for (int i = 0; i < count_symbolic_words; i++)
                    {
                        if (word == symbolic_words[i])
                        {
                            flag_exist = true;
                        }
                    }
                    if (!flag_exist)
                    {
                        symbolic_words[count_symbolic_words] = word;
                        count_symbolic_words++;
                    }
                    break;
            }
        }
    }
}