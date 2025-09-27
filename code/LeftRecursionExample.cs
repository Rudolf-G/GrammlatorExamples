using System;
using System.Diagnostics;

namespace GrammlatorDocumentation.code
{
   static class LeftRecursionExample
   {
      enum SomeLetters
      {
         precedingCharacters = 'a' - 1, a, b, c, successiveCharacters
      }

      #region grammar
      //| TerminalSymbolEnum: "SomeLetters";
      //| ErrorHaltInstruction: "DisplayRemainder(); return false;";
      //| InputExpression: "PeekSymbol()";
      //| InputAcceptInstruction: "AcceptSymbol();";
      //|
      //| precedingCharacters | a | b | c | successiveCharacters;
      //|
      //| *= Sequence_of_b, a;
      //|
      //| Sequence_of_b=
      //|   /* empty */
      //|   | Sequence_of_b, b;
      #endregion grammar

      public static bool AnalyzeInput(string line)
      {
         string InputLine = line + '*';
         int i = 0;

         // Local methods
         SomeLetters PeekSymbol()
            => (SomeLetters)InputLine[i];
         void AcceptSymbol()
            => i++;
         void DisplayRemainder()
            => Console.WriteLine(" Remainder of line: \"" + InputLine[i..] + "\"");

#region grammlator generated 27 Sep 2025 (grammlator file version/date 2022.11.10.0/27 Sep 2025)

State2:
  /* *Startsymbol= Sequence_of_b, ►a;
   * Sequence_of_b= Sequence_of_b, ►b; */
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

#endregion grammlator generated 27 Sep 2025 (grammlator file version/date 2022.11.10.0/27 Sep 2025)
         DisplayRemainder();
         return true;
      }
   }
}
