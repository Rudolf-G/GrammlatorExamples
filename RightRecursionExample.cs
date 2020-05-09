using System;
using System.Collections.Generic;
using System.Diagnostics;
using GrammlatorRuntime;

namespace GrammlatorExamples
{
   static class RightRecursionExample
   {
      private enum SomeLetters
      {
         precedingCharacters = (int)'a' - 1, a, b, c, successiveCharacters
      }

      #region grammar
      //| TerminalSymbolEnum: "SomeLetters";
      //| InstructionErrorHalt: "DisplayRemainder(); return false;"
      //| Symbol: "PeekSymbol()"; AcceptSymbol: "AcceptSymbol();";
      //| StateStack: "StateStack"; StateStackInitialCountVariable: "StateStackInitialCount";
      //| AttributeStack: "_a";
      //|
      //| precedingCharacters | a | b | c | successiveCharacters;
      //|
      //| *= Sequence_of_b_ending_with_a;
      //|
      //| Sequence_of_b_ending_with_a=
      //|   a
      //|   | b, Sequence_of_b_ending_with_a;
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

         var StateStack = new Stack<Int32>(50);

#region grammlator generated Sat, 09 May 2020 08:54:31 GMT (grammlator, File version 2020.04.07.1 09.05.2020 08:26:06)
  Int32 StateStackInitialCount = StateStack.Count;
  /* State 1 (0)
   * *Startsymbol= ►Sequence_of_b_ending_with_a;
   */
  StateStack.Push(0);
  if (PeekSymbol() == SomeLetters.a)
     {
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
  /* State 2 (1)
   * Sequence_of_b_ending_with_a= b, ►Sequence_of_b_ending_with_a;
   */
  StateStack.Push(1);
  if (PeekSymbol() == SomeLetters.a)
     {
     AcceptSymbol();
     goto Reduce2;
     }
  if (PeekSymbol() != SomeLetters.b)
     {
     goto EndWithError;
     }
  Debug.Assert(PeekSymbol() == SomeLetters.b);
  goto AcceptState2;

Reduce1:
  /* Reduction 1
   * *Startsymbol= Sequence_of_b_ending_with_a;◄
   */
  // Halt: a definition of the startsymbol with 0 attributes has been recognized.
  StateStack.Pop();
  goto EndOfGeneratedCode;

Reduce2:
  /* Reduction 2, sStack: -1
   * Sequence_of_b_ending_with_a= b, Sequence_of_b_ending_with_a;◄
   */
  StateStack.Pop();
  /* Branch 1*/
  if (StateStack.Peek() == 1)
     goto Reduce2;
  goto Reduce1;

EndWithError:
  // This point is reached after an input error has been found
  StateStack.Discard(StateStack.Count - StateStackInitialCount);
  DisplayRemainder(); return false;

EndOfGeneratedCode:
  ;
#endregion grammlator generated Sat, 09 May 2020 08:54:31 GMT (grammlator, File version 2020.04.07.1 09.05.2020 08:26:06)
         DisplayRemainder();
         return true;
      }
   }
}
