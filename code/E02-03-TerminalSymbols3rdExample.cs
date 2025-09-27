using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace GrammlatorDocumentation.code
{
   static class TerminalSymbols3rdExample {
      // a) The values of the terminal symbols are powers of 2 so that
      //    grammlator can generate code that uses the symbols as flags
      // b) The terminal symbols are declared twice:
      //    grammlator checks if both declarations are consistent
      #region grammar
      //| InputAssignInstruction: "";
      //| InputExpression: "NextSymbol";
      //| InputAcceptInstruction: "AcceptAndPeekSymbol();";
      //| ErrorHaltInstruction: "DisplayRemainder(); return false;";
      //| GenerateFlagTestStartingLevel: 2;
      //|
      //| /* Terminal symbols (redundant declaration): */ 
      //|     a=1 | b | c=4 | d=8 | other=16
      enum ThreeLetters { a = 1, b = 2, c = 4, d = 8, other = 16 }
      //| /* Startsymbol : */ 
      //|     *= a | b | c | d, c, b | d, b, c ;
      #endregion grammar

      public static bool AnalyzeInput(string inputLine)
      {
         int i = 0;
         ThreeLetters NextSymbol;

         AcceptAndPeekSymbol();

         // Local methods

         void AcceptAndPeekSymbol()
         {
            char x = i < inputLine.Length
               ? inputLine[i++]
               : (char)0;
            NextSymbol = x < 'a' || x > 'd'
               ? ThreeLetters.other
               : (ThreeLetters)(1 << x - 'a');
         }

         void DisplayRemainder()
            => Console.WriteLine($" Remainder of line: \"{inputLine[i..]}\"");

#region grammlator generated 27 Sep 2025 (grammlator file version/date 2022.11.10.0/27 Sep 2025)

  // State1:
  /* *Startsymbol= ►a;
   * *Startsymbol= ►b;
   * *Startsymbol= ►c;
   * *Startsymbol= ►d, c, b;
   * *Startsymbol= ►d, b, c; */
  if (NextSymbol <= ThreeLetters.c)
     goto AcceptEndOfGeneratedCode;
  if (NextSymbol == ThreeLetters.other)
     goto EndWithError;
  Debug.Assert(NextSymbol == ThreeLetters.d);
  AcceptAndPeekSymbol();
  // State2:
  /* *Startsymbol= d, ►c, b;
   * *Startsymbol= d, ►b, c; */
  if (NextSymbol == ThreeLetters.b)
     {
     AcceptAndPeekSymbol();
     // State4:
     /* *Startsymbol= d, b, ►c; */
     if (NextSymbol != ThreeLetters.c)
        goto EndWithError;
     Debug.Assert(NextSymbol == ThreeLetters.c);
     goto AcceptEndOfGeneratedCode;
     }
  if (NextSymbol != ThreeLetters.c)
     goto EndWithError;
  Debug.Assert(NextSymbol == ThreeLetters.c);
  AcceptAndPeekSymbol();
  // State3:
  /* *Startsymbol= d, c, ►b; */
  if (NextSymbol != ThreeLetters.b)
     goto EndWithError;
  Debug.Assert(NextSymbol == ThreeLetters.b);
AcceptEndOfGeneratedCode:
  AcceptAndPeekSymbol();
  goto EndOfGeneratedCode;

EndWithError:
  // This point is reached after an input error has been found
  DisplayRemainder(); return false;
EndOfGeneratedCode:
  ;

#endregion grammlator generated 27 Sep 2025 (grammlator file version/date 2022.11.10.0/27 Sep 2025)
         DisplayRemainder();
         return true;
      }
   }
}
