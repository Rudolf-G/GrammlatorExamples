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

      #region grammar
      //| TerminalSymbolEnum: "SomeLetters";
      //| SymbolNameOrFunctionCall: "PeekSymbol()"; SymbolAcceptInstruction: "AcceptSymbol();";
      //| ErrorHaltInstruction: "DisplayRemainder(); return false;"
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

#region grammlator generated 29 Sep 2020 (grammlator file version/date 2020.09.28.0/29 Sep 2020)
  Int32 StateStackInitialCount = StateStack.Count;

  // State1:
  /* *Startsymbol= ►Sequence_of_b_ending_with_a; */
  StateStack.Push(0);
  if (PeekSymbol() == SomeLetters.a)
     {
     AcceptSymbol();
     goto Reduce1;
     }
  if (PeekSymbol() != SomeLetters.b)
     goto EndWithError;
  Debug.Assert(PeekSymbol() == SomeLetters.b);
AcceptState2:
  AcceptSymbol();
  // State2:
  /* Sequence_of_b_ending_with_a= b, ►Sequence_of_b_ending_with_a; */
  StateStack.Push(1);
  if (PeekSymbol() == SomeLetters.a)
     {
     AcceptSymbol();
     goto Reduce2;
     }
  if (PeekSymbol() != SomeLetters.b)
     goto EndWithError;
  Debug.Assert(PeekSymbol() == SomeLetters.b);
  goto AcceptState2;

Reduce1:
  /* *Startsymbol= Sequence_of_b_ending_with_a;◄ */
  // Halt: a definition of the startsymbol with 0 attributes has been recognized.
  StateStack.Pop();
  goto EndOfGeneratedCode;

Reduce2:
  /* sAdjust: -1
   * Sequence_of_b_ending_with_a= b, Sequence_of_b_ending_with_a;◄ */
  StateStack.Pop();
  // Branch1:
  if (StateStack.Peek() == 0)
     goto Reduce1;
  goto Reduce2;

EndWithError:
  // This point is reached after an input error has been found
  StateStack.Discard(StateStack.Count - StateStackInitialCount);
  DisplayRemainder(); return false;

EndOfGeneratedCode:
  ;

#endregion grammlator generated 29 Sep 2020 (grammlator file version/date 2020.09.28.0/29 Sep 2020)
         DisplayRemainder();
         return true;
      }
   }
}
