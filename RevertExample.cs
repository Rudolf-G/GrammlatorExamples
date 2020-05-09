using System;
using System.Collections.Generic;
using System.Diagnostics;
using GrammlatorRuntime;

namespace GrammlatorExamples
{
   class RevertExample
   {
      enum SomeLetters
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
      //| *= Sequence_of_a_and_b_terminated_by_c;
      //| 
      //| A = a
      private static void DisplayInputA()
      {
         Console.Write('a');
      }

      //| B = b
      private static void DisplayInputB() => Console.Write('b');

      //| Sequence_of_a_and_b_terminated_by_c=
      //|   c
      private static void DisplayLine()
      {
         Console.Write('c'); // last accepted input character
         Console.WriteLine();
         Console.Write('c'); // is first character of reverse input
      }

      //|   | A, Sequence_of_a_and_b_terminated_by_c
      private static void DisplayA() => Console.Write('a');

      //|   | B, Sequence_of_a_and_b_terminated_by_c
      private static void DisplayB() => Console.Write('b');

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

#region grammlator generated Sat, 09 May 2020 08:52:07 GMT (grammlator, File version 2020.04.07.1 09.05.2020 08:26:06)
  Int32 StateStackInitialCount = StateStack.Count;
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
   * Sequence_of_a_and_b_terminated_by_c= c;◄ method: DisplayLine
   * then: *Startsymbol= Sequence_of_a_and_b_terminated_by_c;◄
   */

  DisplayLine();

ApplyStartsymbolDefinition1:
  // Halt: a definition of the startsymbol with 0 attributes has been recognized.
  StateStack.Pop();
  goto EndOfGeneratedCode;

Reduce6:
  /* Reduction 6, sStack: -1
   * Sequence_of_a_and_b_terminated_by_c= B, Sequence_of_a_and_b_terminated_by_c;◄ method: DisplayB
   */
  StateStack.Pop();

  DisplayB();

Branch1:
  /* Branch 1*/
  switch (StateStack.Peek())
  {
  case 1:
     goto Reduce6;
  case 2:
     goto Reduce8;
  /*case 0:
  default: break;
  */
  }
  /* Reduction 4
   * *Startsymbol= Sequence_of_a_and_b_terminated_by_c;◄
   */
  goto ApplyStartsymbolDefinition1;

AcceptReduce1:
  AcceptSymbol();
  /* Reduction 1
   * A= a;◄ method: DisplayInputA
   */

  DisplayInputA();

  /* State 3 (2)
   * Sequence_of_a_and_b_terminated_by_c= A, ►Sequence_of_a_and_b_terminated_by_c;
   */
  StateStack.Push(2);
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
  /* Reduction 7
   * Sequence_of_a_and_b_terminated_by_c= c;◄ method: DisplayLine
   */

  DisplayLine();

Reduce8:
  /* Reduction 8, sStack: -1
   * Sequence_of_a_and_b_terminated_by_c= A, Sequence_of_a_and_b_terminated_by_c;◄ method: DisplayA
   */
  StateStack.Pop();

  DisplayA();

  goto Branch1;

AcceptReduce2:
  AcceptSymbol();
  /* Reduction 2
   * B= b;◄ method: DisplayInputB
   */

  DisplayInputB();

  /* State 2 (1)
   * Sequence_of_a_and_b_terminated_by_c= B, ►Sequence_of_a_and_b_terminated_by_c;
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
   * Sequence_of_a_and_b_terminated_by_c= c;◄ method: DisplayLine
   */

  DisplayLine();

  goto Reduce6;

EndWithError:
  // This point is reached after an input error has been found
  StateStack.Discard(StateStack.Count - StateStackInitialCount);
  DisplayRemainder(); return false;

EndOfGeneratedCode:
  ;
#endregion grammlator generated Sat, 09 May 2020 08:52:07 GMT (grammlator, File version 2020.04.07.1 09.05.2020 08:26:06)

         DisplayRemainder();
         return true;
      }
   }
}
