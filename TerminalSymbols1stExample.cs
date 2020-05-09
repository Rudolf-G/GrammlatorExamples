using System;
using System.Diagnostics;

namespace GrammlatorExamples
{
   static class TerminalSymbolsExample
   {
      const Int32 IntOfCharactersPreceding_a =(int)'a'-1;

      enum SomeLetters: Byte
      {
         charactersPreceding_a = IntOfCharactersPreceding_a , a, b, c, successiveCharacters
      }

      #region grammar
      //| TerminalSymbolEnum: "SomeLetters"; 
      //| InstructionErrorHalt: "DisplayRemainder(); return false;"
      //| Symbol: "PeekSymbol()"; AcceptSymbol: "AcceptSymbol();";
      //|
      //| charactersPreceding_a | a | b | c | successiveCharacters;
      //|
      //| *= a, b | b, a;
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

#region grammlator generated Sat, 09 May 2020 08:55:16 GMT (grammlator, File version 2020.04.07.1 09.05.2020 08:26:06)
  /* State 1
   * *Startsymbol= ►a, b;
   * *Startsymbol= ►b, a;
   */
  if (PeekSymbol() == SomeLetters.a)
     {
     AcceptSymbol();
     /* State 3
      * *Startsymbol= a, ►b;
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
   * *Startsymbol= b, ►a;
   */
  if (PeekSymbol() != SomeLetters.a)
     {
     goto EndWithError;
     }
  Debug.Assert(PeekSymbol() == SomeLetters.a);
AcceptReduce1:
  AcceptSymbol();
  /* Reduction 1
   * *Startsymbol= b, a;◄
   */
  goto EndOfGeneratedCode;

EndWithError:
  // This point is reached after an input error has been found
  DisplayRemainder(); return false;

EndOfGeneratedCode:
  ;
#endregion grammlator generated Sat, 09 May 2020 08:55:16 GMT (grammlator, File version 2020.04.07.1 09.05.2020 08:26:06)
         DisplayRemainder();
         return true;
      }
   }
}
