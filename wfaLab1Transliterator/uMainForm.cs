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

namespace nsLexMainForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //            tbFSource.Lines.Count = 2;
            tbFSource.AppendText("bc(010):-bc(010),bc(010).\r\n");
            //            int n = tbFSource.Lines.Length;
            //            n = n;
        }

        private void btnFStart_Click(object sender, EventArgs e)
        {
            cSint Lex = new cSint();
            Lex.Lex.strPSource = tbFSource.Lines;
            Lex.Lex.strPMessage = tbFMessage.Lines;
            Lex.Lex.enumPState = TState.Start;
            try
            {
                while (Lex.Lex.enumPState != TState.Finish)
                {
                    Lex.Lex.NextToken();
                    Lex.S();
                }
            }
            catch (Exception exc)
            {
                tbFMessage.Text += exc.Message;
                tbFSource.Select();
                tbFSource.SelectionStart = 0;
                int n = 0;
                for (int i = 0; i < Lex.Lex.intPSourceRowSelection; i++) n += tbFSource.Lines[i].Length + 2;
                n += Lex.Lex.intPSourceColSelection;
                tbFSource.SelectionLength = n;
            }
        }
    }
}
