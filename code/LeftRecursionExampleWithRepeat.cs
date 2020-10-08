using System;
using System.Diagnostics;

namespace GrammlatorExamples
{
   static class LeftRecursionExampleWithRepeat
   {
      enum SomeLetters
      {
         precedingCharacters = (int)'a' - 1, a, b, c, successiveCharacters
      }

      #region grammar
      //| TerminalSymbolEnum: "SomeLetters";
      //| SymbolNameOrFunctionCall: "PeekSymbol()";
      //| SymbolAcceptInstruction: "AcceptSymbol();";
      //| ErrorHaltInstruction: "DisplayRemainder(); return false;"
      //|
      //| precedingCharacters | a | b | c | successiveCharacters;
      //|
      //| *= b*, a;
      //|
      #endregion grammar

      public static Boolean AnalyzeInput()
      {
         String InputLine = Console.ReadLine() + '*';
         int i = 0;

         // Local methods
         SomeLetters PeekSymbol()
            => (SomeLetters)InputLine[i];
         void AcceptSymbol()
            => i++;
         void DisplayRemainder()
            => Console.WriteLine(" Remainder of line: \"" + InputLine.Substring(i) + "\"");

#region grammlator generated 29 Sep 2020 (grammlator file version/date 2020.09.28.0/29 Sep 2020)
State2:
  /* *Startsymbol= b*, ►a;
   * b*= b*, ►b; */
  if (PeekSymbol() == SomeLetters.a)
     {
     AcceptSymbol();
     goto EndOfGeneratedCode;
     }
  if (PeekSymbol() != SomeLetters.b)
     goto EndWithError;
  Debug.Assert(PeekSymbol() == SomeLetters.b);
  AcceptSymbol();
  goto State2;

EndWithError:
  // This point is reached after an input error has been found
  DisplayRemainder(); return false;

EndOfGeneratedCode:
  ;

#endregion grammlator generated 29 Sep 2020 (grammlator file version/date 2020.09.28.0/29 Sep 2020)
         DisplayRemainder();
         return true;
      }
   }
}
