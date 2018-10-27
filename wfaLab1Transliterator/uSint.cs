using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Threading.Tasks;
using nsLex;

namespace Sint
{
    class cSint
    {
        private string[] strFSource;
        private string[] strFMessage;
        public String[] strPSource { set { strFSource = value; } get { return strFSource; } }
        public String[] strPMessage { set { strFMessage = value; } get { return strFMessage; } }
        public CLex Lex = new CLex();

        public void S()
        {
            A();
            if (Lex.enumPToken == TToken.lxmColon)
            {
                Lex.NextToken();
                if (Lex.enumPToken == TToken.lxmDash)
                {
                    Lex.NextToken();
                    B();
                    if (Lex.enumPToken == TToken.lxmDot)
                        throw new Exception("Текст верный.");
                    else
                        throw new Exception("Ожидалось .");
                }
                else throw new Exception("Ожидалось -");
            }
            else throw new Exception("Ожидалось :");

        }
        public void A()
        {
            if (Lex.enumPToken == TToken.lxmIdentifier)
            {
                Lex.NextToken();
                if (Lex.enumPToken == TToken.lxmLeftParenth)
                {
                    Lex.NextToken();
                    if (Lex.enumPToken == TToken.lxmNumber)
                    {
                        Lex.NextToken();
                        if (Lex.enumPToken == TToken.lxmRightParenth)
                        {
                            Lex.NextToken();
                        }
                        else throw new Exception("Ожидалось )");
                    }
                    else throw new Exception("Ожидалось первое слово(циферки)");

                }
                else throw new Exception("Ожидалось (");
            }
            else throw new Exception("Ожидалось второе слово(буковки)");
        }
        public void B()
        {
            A();
            if (Lex.enumPToken == TToken.lxmComma)
            {
                Lex.NextToken();
                C();
            }
        }
        public void C()
        {

            A();
            if (Lex.enumPToken == TToken.lxmComma)
            {
                Lex.NextToken();
                C();
            }
        }
    }
}
