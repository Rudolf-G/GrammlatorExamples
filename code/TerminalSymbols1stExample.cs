using System;
using System.Diagnostics;

namespace GrammlatorExamples {
   static class TerminalSymbols1stExample {
      #region grammar
      //| ErrorHaltInstruction: "DisplayRemainder(); return false;"
      //| SymbolNameOrFunctionCall: "(MyLetters)InputLine[i]";
      //| SymbolAcceptInstruction: "i++;";
      //| CompareToFlagTestBorder: 10000;
      //|
      enum MyLetters{ precedingCharacters = 96, a, b, c, d, successiveCharacters }
      //|
      //| *= a | b | c | d, c, b | d, b, c ;
      #endregion grammar

      public static Boolean AnalyzeInput()
      {
         String InputLine = Console.ReadLine() + '*';
         int i = 0;

         // Local method, also called after "#endregion grammlator generated""
         void DisplayRemainder()
             => Console.WriteLine(@$" Remainder of line: ""{InputLine.Substring(i)}""");

#region grammlator generated 4 Okt 2020 (grammlator file version/date 2020.10.03.0/4 Okt 2020)
  // State1:
  /* *Startsymbol= ►a;
   * *Startsymbol= ►b;
   * *Startsymbol= ►c;
   * *Startsymbol= ►d, c, b;
   * *Startsymbol= ►d, b, c; */
  if ((MyLetters)InputLine[i] == MyLetters.d)
     {
     i++;
     // State2:
     /* *Startsymbol= d, ►c, b;
      * *Startsymbol= d, ►b, c; */
     if ((MyLetters)InputLine[i] == MyLetters.b)
        {
        i++;
        // State4:
        /* *Startsymbol= d, b, ►c; */
        if ((MyLetters)InputLine[i] != MyLetters.c)
           goto EndWithError;
        Debug.Assert((MyLetters)InputLine[i] == MyLetters.c);
        goto AcceptEndOfGeneratedCode;
        }
     if ((MyLetters)InputLine[i] != MyLetters.c)
        goto EndWithError;
     Debug.Assert((MyLetters)InputLine[i] == MyLetters.c);
     i++;
     // State3:
     /* *Startsymbol= d, c, ►b; */
     if ((MyLetters)InputLine[i] != MyLetters.b)
        goto EndWithError;
     Debug.Assert((MyLetters)InputLine[i] == MyLetters.b);
     goto AcceptEndOfGeneratedCode;
     }
  if ((MyLetters)InputLine[i] <= MyLetters.precedingCharacters
     || (MyLetters)InputLine[i] >= MyLetters.successiveCharacters)
     goto EndWithError;
  Debug.Assert((MyLetters)InputLine[i] > MyLetters.precedingCharacters
     && (MyLetters)InputLine[i] < MyLetters.d);
AcceptEndOfGeneratedCode:
  i++;
  goto EndOfGeneratedCode;

EndWithError:
  // This point is reached after an input error has been found
  DisplayRemainder(); return false;

EndOfGeneratedCode:
  ;

#endregion grammlator generated 4 Okt 2020 (grammlator file version/date 2020.10.03.0/4 Okt 2020)
         DisplayRemainder();
         return true;
      }
   }
}
