using System;
using System.Diagnostics;

namespace GrammlatorExamples
{
   internal class ConflictsAndPrioritiesExample
   {
      private enum SomeLetters
      {
         precedingCharacters = (int)'a' - 1, a, b, c, successiveCharacters
      }

      #region grammar
      //| TerminalSymbolEnum: "SomeLetters"; InstructionErrorHalt: "DisplayRemainder(); return false;"
      //| Symbol: "PeekSymbol()"; AcceptSymbol: "AcceptSymbol();";
      //| StateStack: "StateStack"; StateStackInitialCountVariable: "StateStackInitialCount";
      //| AttributeStack: "AttrStack";
      //|
      //| precedingCharacters | a | b | c | successiveCharacters;
      //|
      //| *= aa 
      //|   | aaaa 
      //|   | Sequence_of_b ??-1??;
      //| 
      //| aa= a, a ??-1??; 
      //| 
      //| aaaa= a, a, a, a;
      //| 
      //| Sequence_of_b=
      //|   b
      //|   | Sequence_of_b, b;
      //|
      #endregion grammar

      public Boolean AnalyzeInput()
      {
         Console.WriteLine("Please input \"aa\", \"aaaa\" or a sequence of b's");
         String InputLine = Console.ReadLine() + "*";
         int i = 0;

         // Local methods
         SomeLetters PeekSymbol()
            => (SomeLetters)InputLine[i];
         void AcceptSymbol()
            => i++;
         void DisplayRemainder()
            => Console.WriteLine("Remainder of line: \"" + InputLine.Substring(i)+ "\"");

#region grammlator generated Sat, 09 May 2020 08:46:33 GMT (grammlator, File version 2020.04.07.1 09.05.2020 08:26:06)
  /* State 1
   * *Startsymbol= ►aa;
   * *Startsymbol= ►aaaa;
   * *Startsymbol= ►Sequence_of_b;
   */
  if (PeekSymbol() == SomeLetters.a)
     {
     AcceptSymbol();
     /* State 3
      * aa= a, ►a;
      * aaaa= a, ►a, a, a;
      */
     if (PeekSymbol() != SomeLetters.a)
        {
        goto EndWithError;
        }
  Debug.Assert(PeekSymbol() == SomeLetters.a);
     AcceptSymbol();
     /* State 4
      * aa= a, a●;
      * aaaa= a, a, ►a, a;
      */
     if (PeekSymbol() != SomeLetters.a)
        goto Reduce1;
     Debug.Assert(PeekSymbol() == SomeLetters.a);
     AcceptSymbol();
     /* State 5
      * aaaa= a, a, a, ►a;
      */
     if (PeekSymbol() != SomeLetters.a)
        {
        goto EndWithError;
        }
  Debug.Assert(PeekSymbol() == SomeLetters.a);
     AcceptSymbol();
     goto Reduce1;
     }
  if (PeekSymbol() != SomeLetters.b)
     {
     goto EndWithError;
     }
  Debug.Assert(PeekSymbol() == SomeLetters.b);
AcceptState2:
  AcceptSymbol();
  /* State 2
   * *Startsymbol= Sequence_of_b●;
   * Sequence_of_b= Sequence_of_b, ►b;
   */
  if (PeekSymbol() != SomeLetters.b)
     goto Reduce1;
  Debug.Assert(PeekSymbol() == SomeLetters.b);
  goto AcceptState2;

Reduce1:
  /* Reduction 1
   * *Startsymbol= aa;◄
   */
  goto EndOfGeneratedCode;

EndWithError:
  // This point is reached after an input error has been found
  DisplayRemainder(); return false;

EndOfGeneratedCode:
  ;
#endregion grammlator generated Sat, 09 May 2020 08:46:33 GMT (grammlator, File version 2020.04.07.1 09.05.2020 08:26:06)

         DisplayRemainder();
         return true;
      }
   }
}
