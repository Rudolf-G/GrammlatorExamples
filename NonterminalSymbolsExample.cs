using System;
using System.Diagnostics;

namespace GrammlatorExamples
{
   static class NonterminalSymbolsExample
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
      //| *= Variants;
      //|
      //| Variants=
      //|   a, b 
      //|   | b, a;
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

#region grammlator generated Sat, 09 May 2020 08:49:42 GMT (grammlator, File version 2020.04.07.1 09.05.2020 08:26:06)
  /* State 1
   * *Startsymbol= ►Variants;
   */
  if (PeekSymbol() == SomeLetters.a)
     {
     AcceptSymbol();
     /* State 3
      * Variants= a, ►b;
      */
     if (PeekSymbol() != SomeLetters.b)
        {
        goto EndWithError;
        }
  Debug.Assert(PeekSymbol() == SomeLetters.b);
     goto AcceptReduce1;
     }
  if (PeekSymbol() != SomeLetters.b)
     {
     goto EndWithError;
     }
  Debug.Assert(PeekSymbol() == SomeLetters.b);
  AcceptSymbol();
  /* State 2
   * Variants= b, ►a;
   */
  if (PeekSymbol() != SomeLetters.a)
     {
     goto EndWithError;
     }
  Debug.Assert(PeekSymbol() == SomeLetters.a);
AcceptReduce1:
  AcceptSymbol();
  /* Reduction 1
   * *Startsymbol= Variants;◄
   */
  goto EndOfGeneratedCode;

EndWithError:
  // This point is reached after an input error has been found
  DisplayRemainder(); return false;

EndOfGeneratedCode:
  ;
#endregion grammlator generated Sat, 09 May 2020 08:49:42 GMT (grammlator, File version 2020.04.07.1 09.05.2020 08:26:06)
         DisplayRemainder();
         return true;
      }
   }
}
