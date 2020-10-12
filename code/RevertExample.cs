using System;
using System.Collections.Generic;
using System.Diagnostics;

using GrammlatorRuntime;

namespace GrammlatorExamples {
   class RevertExample {

      #region grammar
      //| TerminalSymbolEnum: "SomeLetters";
      //| SymbolNameOrFunctionCall: "PeekSymbol()"; SymbolAcceptInstruction: "AcceptSymbol();";
      //| ErrorHaltInstruction: "DisplayRemainder(); return false;"
      //| StateStack: "StateStack"; StateStackInitialCountVariable: "StateStackInitialCount";
      //| AttributeStack: "_a";
      //|
      enum SomeLetters { precedingCharacters = 96, a, b, c, successiveCharacters }
      //|
      //| *= Sequence_of_a_and_b_terminated_by_c;
      //| 
      //| A = a
      private static void DisplayInputA() => Console.Write('a');

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

      public Boolean AnalyzeInput(string line)
      {
         String InputLine = line + '*';
         int i = 0;

         // Local methods
         SomeLetters PeekSymbol() => (SomeLetters)InputLine[i];
         void AcceptSymbol() => i++;
         void DisplayRemainder()
            => Console.WriteLine(" Remainder of line: \"" + InputLine.Substring(i) + "\"");

         var StateStack = new Stack<Int32>(50);

         #region grammlator generated 29 Sep 2020 (grammlator file version/date 2020.09.28.0/29 Sep 2020)
         Int32 StateStackInitialCount = StateStack.Count;

         // State1:
         /* *Startsymbol= ►Sequence_of_a_and_b_terminated_by_c; */
         StateStack.Push(0);
         if (PeekSymbol() == SomeLetters.c)
         {
            AcceptSymbol();
            // Reduce3:
            /* Sequence_of_a_and_b_terminated_by_c= c;◄
             * then: *Startsymbol= Sequence_of_a_and_b_terminated_by_c;◄ */

            DisplayLine();

            goto ApplyStartsymbolDefinition1;
         }
         if (PeekSymbol() == SomeLetters.a)
            goto AcceptReduce1;
         if (PeekSymbol() != SomeLetters.b)
            goto EndWithError;
         Debug.Assert(PeekSymbol() == SomeLetters.b);
      AcceptReduce2:
         AcceptSymbol();
         // Reduce2:
         /* B= b;◄ */

         DisplayInputB();

         // State2:
         /* Sequence_of_a_and_b_terminated_by_c= B, ►Sequence_of_a_and_b_terminated_by_c; */
         StateStack.Push(1);
         if (PeekSymbol() == SomeLetters.b)
            goto AcceptReduce2;
         if (PeekSymbol() == SomeLetters.c)
         {
            AcceptSymbol();
            // Reduce5:
            /* Sequence_of_a_and_b_terminated_by_c= c;◄ */

            DisplayLine();

            goto Reduce6;
         }
         if (PeekSymbol() != SomeLetters.a)
            goto EndWithError;
         Debug.Assert(PeekSymbol() == SomeLetters.a);
      AcceptReduce1:
         AcceptSymbol();
         // Reduce1:
         /* A= a;◄ */

         DisplayInputA();

         // State3:
         /* Sequence_of_a_and_b_terminated_by_c= A, ►Sequence_of_a_and_b_terminated_by_c; */
         StateStack.Push(2);
         if (PeekSymbol() == SomeLetters.a)
            goto AcceptReduce1;
         if (PeekSymbol() == SomeLetters.b)
            goto AcceptReduce2;
         if (PeekSymbol() != SomeLetters.c)
            goto EndWithError;
         Debug.Assert(PeekSymbol() == SomeLetters.c);
         AcceptSymbol();
         // Reduce7:
         /* Sequence_of_a_and_b_terminated_by_c= c;◄ */

         DisplayLine();

      Reduce8:
         /* sAdjust: -1
          * Sequence_of_a_and_b_terminated_by_c= A, Sequence_of_a_and_b_terminated_by_c;◄ */
         StateStack.Pop();

         DisplayA();

      Branch1:
         switch (StateStack.Peek())
         {
         case 0:
         // Reduce4:
         {
            /* *Startsymbol= Sequence_of_a_and_b_terminated_by_c;◄ */
            goto ApplyStartsymbolDefinition1;
         }
         case 1:
            goto Reduce6;
            /*case 2:
            default: break; */
         }
         goto Reduce8;

      Reduce6:
         /* sAdjust: -1
          * Sequence_of_a_and_b_terminated_by_c= B, Sequence_of_a_and_b_terminated_by_c;◄ */
         StateStack.Pop();

         DisplayB();

         goto Branch1;

      ApplyStartsymbolDefinition1:
         // Halt: a definition of the startsymbol with 0 attributes has been recognized.
         StateStack.Pop();
         goto EndOfGeneratedCode;

      EndWithError:
         // This point is reached after an input error has been found
         StateStack.Discard(StateStack.Count - StateStackInitialCount);
         DisplayRemainder();
         return false;

      EndOfGeneratedCode:
         ;

         #endregion grammlator generated 29 Sep 2020 (grammlator file version/date 2020.09.28.0/29 Sep 2020)

         DisplayRemainder();
         return true;
      }
   }
}
