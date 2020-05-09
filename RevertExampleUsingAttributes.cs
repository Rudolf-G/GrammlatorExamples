using System;
using System.Collections.Generic;
using System.Diagnostics;
using GrammlatorRuntime;

namespace GrammlatorExamples
{
   class RevertExampleUsingAttributes
   {
      enum SomeLetters
      {
         precedingCharacters = (int)'a' - 1, a, b, c, successiveCharacters
      }

      #region grammar
      //| TerminalSymbolEnum: "SomeLetters"; 
      //| InstructionErrorHalt: "DisplayRemainder(); return false;"
      //| Symbol: "PeekSymbol()"; AcceptSymbol: "AcceptSymbol();";
      //| StateStack: "StateStack";
      //| StateStackInitialCountVariable: "StateStackInitialCount";
      //| AttributeStack: "AttrStack";
      //|
      //| precedingCharacters | a | b | c | successiveCharacters;
      //|
      //| *= Sequence_of_a_and_b_terminated_by_c;
      //| 
      //| Sequence_of_a_and_b_terminated_by_c=
      //|   c
      private static void FoundC()
      {
         Console.Write('c');
         Console.WriteLine();
         Console.Write('c');
      }

      //|   | AorB(char AorB), Sequence_of_a_and_b_terminated_by_c
      private static void DisplayAorB(char AorB) => Console.Write(AorB);

      //| AorB(char x)=
      //|   a
      private static void DisplayAndAssignA(out char x)
      {
         x = 'a';
         Console.Write('a');
      }

      //|   | b
      private static void DisplayAndAssignB(out char x)
      {
         x = 'b';
         Console.Write('b');
      }
      #endregion grammar

      public Boolean AnalyzeInput()
      {
         Console.WriteLine("Please input a sequence of 'a's and 'b's terminated by a 'c'.");
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
         var AttrStack = new StackOfMultiTypeElements(50);

#region grammlator generated Sat, 09 May 2020 08:53:05 GMT (grammlator, File version 2020.04.07.1 09.05.2020 08:26:06)
  Int32 StateStackInitialCount = StateStack.Count;
  Int32 AttributeStackInitialCount = AttrStack.Count;
  /* State 1 (0)
   * *Startsymbol= ►Sequence_of_a_and_b_terminated_by_c;
   */
  StateStack.Push(0);
  if (PeekSymbol() == SomeLetters.a)
     goto AcceptReduce1;
  if (PeekSymbol() == SomeLetters.b)
     goto AcceptReduce2;
  if (PeekSymbol() != SomeLetters.c)
     {
     goto EndWithError;
     }
  Debug.Assert(PeekSymbol() == SomeLetters.c);
  AcceptSymbol();
  /* Reduction 3
   * Sequence_of_a_and_b_terminated_by_c= c;◄ method: FoundC
   * then: *Startsymbol= Sequence_of_a_and_b_terminated_by_c;◄
   */

  FoundC();

ApplyStartsymbolDefinition1:
  // Halt: a definition of the startsymbol with 0 attributes has been recognized.
  StateStack.Pop();
  goto EndOfGeneratedCode;

AcceptReduce1:
  AcceptSymbol();
  /* Reduction 1, aStack: 1
   * AorB(char x)= a;◄ aStack: 1, method: DisplayAndAssignA
   */
  AttrStack.Allocate();

  DisplayAndAssignA(
     x: out AttrStack.PeekRef(0)._char
     );

State2:
  /* State 2 (1)
   * Sequence_of_a_and_b_terminated_by_c= AorB(char AorB), ►Sequence_of_a_and_b_terminated_by_c;
   */
  StateStack.Push(1);
  if (PeekSymbol() == SomeLetters.a)
     goto AcceptReduce1;
  if (PeekSymbol() == SomeLetters.b)
     goto AcceptReduce2;
  if (PeekSymbol() != SomeLetters.c)
     {
     goto EndWithError;
     }
  Debug.Assert(PeekSymbol() == SomeLetters.c);
  AcceptSymbol();
  /* Reduction 5
   * Sequence_of_a_and_b_terminated_by_c= c;◄ method: FoundC
   */

  FoundC();

Reduce6:
  /* Reduction 6, sStack: -1, aStack: -1
   * Sequence_of_a_and_b_terminated_by_c= AorB(char AorB), Sequence_of_a_and_b_terminated_by_c;◄ method: DisplayAorB, aStack: -1
   */
  StateStack.Pop();

  DisplayAorB(
     AorB: AttrStack.PeekRef(0)._char
     );

  AttrStack.Free();
  /* Branch 1*/
  if (StateStack.Peek() == 1)
     goto Reduce6;
  /* Reduction 4
   * *Startsymbol= Sequence_of_a_and_b_terminated_by_c;◄
   */
  goto ApplyStartsymbolDefinition1;

AcceptReduce2:
  AcceptSymbol();
  /* Reduction 2, aStack: 1
   * AorB(char x)= b;◄ aStack: 1, method: DisplayAndAssignB
   */
  AttrStack.Allocate();

  DisplayAndAssignB(
     x: out AttrStack.PeekRef(0)._char
     );

  goto State2;

EndWithError:
  // This point is reached after an input error has been found
  StateStack.Discard(StateStack.Count - StateStackInitialCount);
  AttrStack.Free(AttrStack.Count - AttributeStackInitialCount);
  DisplayRemainder(); return false;

EndOfGeneratedCode:
  ;
#endregion grammlator generated Sat, 09 May 2020 08:53:05 GMT (grammlator, File version 2020.04.07.1 09.05.2020 08:26:06)

         DisplayRemainder();
         return true;
      }
   }
}
