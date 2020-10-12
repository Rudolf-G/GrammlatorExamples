using System;
using System.Diagnostics;

namespace GrammlatorExamples {
   static class TerminalSymbols3rdExample {

      #region grammar
      //| TerminalSymbolEnum: "ThreeLetters"; 
      //| SymbolNameOrFunctionCall: "PeekSymbol()";
      //| SymbolAcceptInstruction: "AcceptSymbol();";
      //| ErrorHaltInstruction: "DisplayRemainder(); return false;"
      //| CompareToFlagTestBorder: 1; IfToSwitchBorder: 2;
      //|
      //| /* Terminal symbols: */ a | b | c | d | other
      enum ThreeLetters { a = 1, b = 2, c = 4, d = 8, other = 16 }
      //| /* Startsymbol : */ *= a | b | c | d, c, b | d, b, c ;
      #endregion grammar

      public static Boolean AnalyzeInput(string inputLine)
      {
         int i = 0;

         // Local methods
         ThreeLetters PeekSymbol()
         {
            char x = inputLine[i];
            return (x < 'a') || x > 'd' ? ThreeLetters.other : (ThreeLetters)(x - 'a');
         }
         void AcceptSymbol() => i++;
         void DisplayRemainder()
            => Console.WriteLine(" Remainder of line: \"" + inputLine.Substring(i) + "\"");

#region grammlator generated 4 Okt 2020 (grammlator file version/date 2020.10.03.0/4 Okt 2020)
  const ThreeLetters _fb = ThreeLetters.b;
  const ThreeLetters _fc = ThreeLetters.c;
  const ThreeLetters _fd = ThreeLetters.d;
  const ThreeLetters _fother = ThreeLetters.other;
  Boolean _Is(ThreeLetters flags) => ((PeekSymbol()) & flags) != 0;

  // State1:
  /* *Startsymbol= ►a;
   * *Startsymbol= ►b;
   * *Startsymbol= ►c;
   * *Startsymbol= ►d, c, b;
   * *Startsymbol= ►d, b, c; */
  if (!_Is(_fd | _fother))
     goto AcceptEndOfGeneratedCode;
  if (!_Is(_fd))
     goto EndWithError;
  Debug.Assert(_Is(_fd));
  AcceptSymbol();
  // State2:
  /* *Startsymbol= d, ►c, b;
   * *Startsymbol= d, ►b, c; */
  if (_Is(_fb))
     {
     AcceptSymbol();
     // State4:
     /* *Startsymbol= d, b, ►c; */
     if (!_Is(_fc))
        goto EndWithError;
     Debug.Assert(_Is(_fc));
     goto AcceptEndOfGeneratedCode;
     }
  if (!_Is(_fc))
     goto EndWithError;
  Debug.Assert(_Is(_fc));
  AcceptSymbol();
  // State3:
  /* *Startsymbol= d, c, ►b; */
  if (!_Is(_fb))
     goto EndWithError;
  Debug.Assert(_Is(_fb));
AcceptEndOfGeneratedCode:
  AcceptSymbol();
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
