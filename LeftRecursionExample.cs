using System;
using System.Diagnostics;

namespace GrammlatorExamples
{
   static class LeftRecursionExample
   {
      enum SomeLetters
      {
         precedingCharacters = (int)'a' - 1, a, b, c, successiveCharacters
      }

      #region grammar
      //| TerminalSymbolEnum: "SomeLetters";
      //| InstructionErrorHalt: "DisplayRemainder(); return false;"
      //| Symbol: "PeekSymbol()"; AcceptSymbol: "AcceptSymbol();";
      //|
      //| precedingCharacters | a | b | c | successiveCharacters;
      //|
      //| *= Sequence_of_b, a;
      //|
      //| Sequence_of_b=
      //|   /* empty */
      //|   | Sequence_of_b, b;
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

#region grammlator generated Sat, 09 May 2020 08:49:13 GMT (grammlator, File version 2020.04.07.1 09.05.2020 08:26:06)
  /* State 1
   * *Startsymbol= ►Sequence_of_b, a;
   */
State2:
  /* State 2
   * *Startsymbol= Sequence_of_b, ►a;
   * Sequence_of_b= Sequence_of_b, ►b;
   */
  if (PeekSymbol() == SomeLetters.a)
     {
     AcceptSymbol();
     /* Reduction 1
      * *Startsymbol= Sequence_of_b, a;◄
      */
     goto EndOfGeneratedCode;
     }
  if (PeekSymbol() != SomeLetters.b)
     {
     goto EndWithError;
     }
  Debug.Assert(PeekSymbol() == SomeLetters.b);
  AcceptSymbol();
  goto State2;

EndWithError:
  // This point is reached after an input error has been found
  DisplayRemainder(); return false;

EndOfGeneratedCode:
  ;
#endregion grammlator generated Sat, 09 May 2020 08:49:13 GMT (grammlator, File version 2020.04.07.1 09.05.2020 08:26:06)
         DisplayRemainder();
         return true;
      }
   }
}
