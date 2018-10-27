using System;
namespace nsLex
{
    public enum TState { Start, Continue, Finish };
    public enum TCharType { Letter, Digit, EndRow, EndText, Space, ReservedSymbol };
    public enum TToken { lxmIdentifier, lxmNumber, lxmUnknown, lxmEmpty, lxmLeftParenth, lxmRightParenth, lxmIs, lxmDot, lxmComma, lxmColon, lxmDash };
    public class CLex
    {
        private String[] strFSource;  // указатель на массив строк
        private String[] strFMessage;  // указатель на массив строк
        public TCharType enumFSelectionCharType;
        private char chrFSelection;
        private TState enumFState;
        private int intFSourceRowSelection;
        private int intFSourceColSelection;
        private String strFLexicalUnit;
        private TToken enumFToken;
        public String[] strPSource { set { strFSource = value; } get { return strFSource; } }
        public String[] strPMessage { set { strFMessage = value; } get { return strFMessage; } }
        public TState enumPState { set { enumFState = value; } get { return enumFState; } }
        public String strPLexicalUnit { set { strFLexicalUnit = value; } get { return strFLexicalUnit; } }
        public TToken enumPToken { set { enumFToken = value; } get { return enumFToken; } }
        public int intPSourceRowSelection { get { return intFSourceRowSelection; }}
        public int intPSourceColSelection { get { return intFSourceColSelection; }}
        public CLex()
        {
        }
        public void GetSymbol()
        {
            intFSourceColSelection++;
            if (intFSourceColSelection > strFSource[intFSourceRowSelection].Length - 1)
            {
                intFSourceRowSelection++;
                if (intFSourceRowSelection <= strFSource.Length - 1)
                {
                    intFSourceColSelection = -1;
                    chrFSelection = '\0';
                    enumFSelectionCharType = TCharType.EndRow;
                    enumFState = TState.Continue;
                }
                else
                {
                    chrFSelection = '\0';
                    enumFSelectionCharType = TCharType.EndText;
                    enumFState = TState.Finish;

                }
            }
            else
            {
                chrFSelection = strFSource[intFSourceRowSelection][intFSourceColSelection];
                if (chrFSelection == ' ') enumFSelectionCharType = TCharType.Space;
                else if (chrFSelection >= 'a' && chrFSelection <= 'd') enumFSelectionCharType = TCharType.Letter;
                else if (chrFSelection == '0' || chrFSelection == '1') enumFSelectionCharType = TCharType.Digit;
                else if (chrFSelection == '/') enumFSelectionCharType = TCharType.ReservedSymbol;
                else if (chrFSelection == '*') enumFSelectionCharType = TCharType.ReservedSymbol;
                else if (chrFSelection == 'S') enumFSelectionCharType = TCharType.ReservedSymbol;
                else if (chrFSelection == 'A') enumFSelectionCharType = TCharType.ReservedSymbol;
                else if (chrFSelection == 'B') enumFSelectionCharType = TCharType.ReservedSymbol;
                else if (chrFSelection == '>' || chrFSelection == '<') enumFSelectionCharType = TCharType.ReservedSymbol;
                else if (chrFSelection == '(' || chrFSelection == ')' || chrFSelection == ':' || chrFSelection == '-' || chrFSelection == ',' || chrFSelection == '.') enumFSelectionCharType = TCharType.ReservedSymbol;

                else throw new System.Exception("Cимвол вне алфавита");
                enumFState = TState.Continue;
            }
        }
        private void TakeSymbol()
        {
            char[] c = { chrFSelection };
            String s = new string(c);
            strFLexicalUnit += s;
            GetSymbol();
        }
        public void NextToken()
        {
            strFLexicalUnit = "";
            if (enumFState == TState.Start)
            {
                intFSourceRowSelection = 0;
                intFSourceColSelection = -1;
                GetSymbol();
            }

            while (enumFSelectionCharType == TCharType.Space || enumFSelectionCharType == TCharType.EndRow)
            {
                GetSymbol();
            }

            if (chrFSelection == '/')
            {
                GetSymbol();
                if (chrFSelection == '/')
                    while (enumFSelectionCharType != TCharType.EndRow)
                    {
                        GetSymbol();
                    }
                GetSymbol();
            }


            // Вариант 4
            switch (enumFSelectionCharType)
            {
                case TCharType.Letter:
                    {

                    A:
                        {
                            if (chrFSelection == 'b' || chrFSelection == 'c' ||  chrFSelection == 'd')
                            {
                                TakeSymbol();
                                goto AFin;
                            }
                            else if (chrFSelection == 'a' )
                            {
                                TakeSymbol();
                                goto BFin;
                            }
                            else throw new Exception("Ошибка в идентификаторе");
                        }
                    AFin:
                        {
                            if (chrFSelection == 'a' || chrFSelection == 'b' || chrFSelection == 'd' || chrFSelection == 'c')
                            {
                                TakeSymbol();
                                goto AFin;
                            }
                            else
                            {
                                enumFToken = TToken.lxmIdentifier;
                                return;
                            }
                        }
                    BFin:
                        {
                            if (chrFSelection == 'b')
                            {
                                TakeSymbol();
                                throw new Exception("Ошибка в идентификаторе");
                            }
                            else if (chrFSelection == 'a' || chrFSelection == 'c' || chrFSelection == 'd')
                            {
                                TakeSymbol();
                                goto AFin;
                            }
                            else
                            {
                                enumFToken = TToken.lxmIdentifier;
                                return;
                            }
                        }
                    }
                case TCharType.Digit:
                    {
                    A:
                        if (chrFSelection == '0')
                        {
                            TakeSymbol();
                            goto B;
                        }
                        else throw new Exception("Ожидалось 0");
                        B:
                        if (chrFSelection == '0')
                        {
                            TakeSymbol();
                            goto C;
                        }
                        else if (chrFSelection == '1')
                        {
                            TakeSymbol();
                            goto DFin;
                        }
                        else throw new Exception("Ожидалась цифра");
                        C:
                        if (chrFSelection == '0')
                        {
                            TakeSymbol();
                            goto A;
                        }
                        else throw new Exception("Ожидалось 0");
                        DFin:
                        if (chrFSelection == '0')
                        {
                            TakeSymbol();
                            goto E;
                        }
                        else throw new Exception("Ожидалось 0");
                        E:
                        if (chrFSelection == '1')
                        {
                            TakeSymbol();
                            goto F;
                        }
                        else if (enumFSelectionCharType != TCharType.Digit) { enumFToken = TToken.lxmNumber; return; }
                        else throw new Exception("Ожидалось 1");
                        F:
                        if (chrFSelection == '0')
                        {
                            TakeSymbol();
                            goto DFin;
                        }
                        else throw new Exception("Ожидалось 0");
                    }
                case TCharType.ReservedSymbol:
                    {
                        if (chrFSelection == '/')
                        {
                            GetSymbol();
                            if (chrFSelection == '/')
                            {
                                intFSourceColSelection = strFSource[intFSourceRowSelection].Length;
                            }
                        }
                        if (chrFSelection == ':')
                        {
                            enumFToken = TToken.lxmColon;
                        }
                        if (chrFSelection == '-')
                        {
                            enumFToken = TToken.lxmDash;
                        }
                        if (chrFSelection == '.')
                        {
                            enumFToken = TToken.lxmDot;
                        }
                        if (chrFSelection == ',')
                        {
                            enumFToken = TToken.lxmComma;
                        }
                        if (chrFSelection == '(')
                        {
                            enumFToken = TToken.lxmLeftParenth;
                        }
                        if (chrFSelection == ')')
                        {
                            enumFToken = TToken.lxmRightParenth;
                        }
                        TakeSymbol();
                        break;
                    }
                case TCharType.EndText:
                    {
                        enumFToken = TToken.lxmEmpty;
                        break;
                    }
            }
        }

    }
}