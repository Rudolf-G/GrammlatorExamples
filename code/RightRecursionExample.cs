using System;
using System.Collections.Generic;
using System.Diagnostics;

using GrammlatorRuntime;

namespace GrammlatorDocumentation.code
{
   static class RightRecursionExample
   {
      private enum SomeLetters
      {
         precedingCharacters = 'a' - 1, a, b, c, successiveCharacters
      }

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

         var StateStack = new Stack<int>(50); // use Stack-Extension Discard

         #region grammar
         //| TerminalSymbolEnum: "SomeLetters";
         //| InputExpression: "PeekSymbol()"; InputAcceptInstruction: "AcceptSymbol();";
         //| ErrorHaltInstruction: "DisplayRemainder(); return false;";
         //| StateStack: "StateStack";
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

         #region grammlator generated 23 Mar 2023 (grammlator file version/date 2022.11.10.0/17 Jan 2023)
         int _StateStackInitialCount = StateStack.Count;

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
  StateStack.Remove(1);
  goto EndOfGeneratedCode;

Reduce2:
  /* sAdjust: -1
   * Sequence_of_b_ending_with_a= b, Sequence_of_b_ending_with_a;◄ */
  StateStack.Remove(1);
  // Branch1:
  if (StateStack.Peek() == 0)
     goto Reduce1;
  goto Reduce2;

EndWithError:
  // This point is reached after an input error has been found
  StateStack.Remove(StateStack.Count - _StateStackInitialCount);
  DisplayRemainder(); return false;
EndOfGeneratedCode:
  ;

#endregion grammlator generated 23 Mar 2023 (grammlator file version/date 2022.11.10.0/17 Jan 2023)
         DisplayRemainder();
         return true;
      }
   }
}
