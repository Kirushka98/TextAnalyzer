using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using nsLex;
using Sint;
using tabHash;

namespace nsLexMainForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            tbFSource.AppendText("bc(010):-bc(010),bc(010).\r\n");
        }

        private void btnFStart_Click(object sender, EventArgs e)
        {
            TablesHash th = new TablesHash();
            CLex Lex = new CLex();
            Lex.strPSource = tbFSource.Lines;
            Lex.enumPState = TState.Start;

            symbols.Text = "";
            numbers.Text = "";
            reserved.Text = "";
            try
            {
                while (Lex.enumPState != TState.Finish)
                {
                    Lex.NextToken();
                    String word = Lex.strPLexicalUnit;
                    th.add_word(word, Lex.enumPToken);

                }
                for (int i = 0; i < th.count_letter_words; i++)
                {
                    symbols.Text += th.letter_words[i] + System.Environment.NewLine;
                }
                for (int i = 0; i < th.count_digit_words; i++)
                {
                    numbers.Text += th.digit_words[i] + System.Environment.NewLine;
                }
                for (int i = 0; i < th.count_symbolic_words; i++)
                {
                    reserved.Text += th.symbolic_words[i] + System.Environment.NewLine;
                }
            }
            catch (Exception exc)
            {
                tbFSource.Select();
                tbFSource.SelectionStart = 0;
                int n = 0;
                for (int i = 0; i < Lex.intPSourceRowSelection; i++) n += tbFSource.Lines[i].Length + 2;
                n += Lex.intPSourceColSelection;
                tbFSource.SelectionLength = n;
            }
        }
    }
}
