using System;
using System.Collections.Generic;
using System.Diagnostics;

using GrammlatorRuntime;

namespace GrammlatorDocumentation.code
{
   class RevertExampleUsingAttributes {
      enum AorBorEnd { a, b, End, Other }

      public static bool AnalyzeInput(string line)
      {
         string Line = line;
         int i = 0;

         // Local methods
         AorBorEnd PeekSymbol() =>
            i >= Line.Length ? AorBorEnd.End
            : Line[i] >= 'a' && Line[i] <= 'b' ? (AorBorEnd)(Line[i] - 'a')
            : AorBorEnd.Other;
         
         void MyError() // called from the generated code (see ErrorHaltInstruction)
         {
            if (i < Line.Length)
               Console.WriteLine
                  (" The remainder of the line doesn't conform to the grammar:" +
                   $@" ""{Line[i..]}""");
            Console.WriteLine();
         }

         static void Success() // explicitly called from own code after the generated code
            => Console.WriteLine(" This is the input in reversed order.");

         var StateStack = new Stack<int>(50);
         var AttrStack = new StackOfMultiTypeElements(50);

         #region grammar
         //| TerminalSymbolEnum: "AorBorEnd"; 
         //| InputExpression: "PeekSymbol()"; InputAcceptInstruction: "i++;";
         //| ErrorHaltInstruction: "MyError(); return false;";
         //| StateStack: "StateStack";
         //| AttributeStack: "AttrStack";
         //|
         //|  a | b | End | Other;
         //|
         //| *= Sequence_of_a_and_b, End;       
         //| 
         //| Sequence_of_a_and_b=
         //|     /* empty definition (must be the 1st definition)*/
         static void EndOfSequence() => Console.WriteLine(" This input conforms to the grammar.");

         //|   | AorB(char ch), Sequence_of_a_and_b
         static void DisplayAorB(char ch) 
            => Console.Write(ch); // reverse order

         //| AorB(char x)=
         //|   a
         static void DisplayAndAssignA(out char x)
         {
            x = 'a';
            Console.Write('a'); // input order
         }

         //|   | b
         static void DisplayAndAssignB(out char x)
         {
            x = 'b';
            Console.Write('b'); // input order
         }
         #endregion grammar

#region grammlator generated 27 Sep 2025 (grammlator file version/date 2022.11.10.0/27 Sep 2025)
  Int32 _StateStackInitialCount = StateStack.Count;
  Int32 _AttributeStackInitialCount = AttrStack.Count;

  // State1:
  /* *Startsymbol= ►Sequence_of_a_and_b, End; */
  StateStack.Push(0);
  if (PeekSymbol() == AorBorEnd.End)
     // Reduce1:
     {
     /* Sequence_of_a_and_b= ;◄ */

     EndOfSequence();

     goto State3;
     }
  if (PeekSymbol() == AorBorEnd.a)
     goto AcceptReduce2;
  if (PeekSymbol() == AorBorEnd.Other)
     goto EndWithError;
  Debug.Assert(PeekSymbol() == AorBorEnd.b);
AcceptReduce3:
  i++;
  // Reduce3:
  /* aAdjust: 1
   * AorB(char x)= b;◄ */
  AttrStack.Allocate(1);

  DisplayAndAssignB(
     x: out AttrStack.PeekRef(0)._char
     );

State2:
  /* Sequence_of_a_and_b= AorB(char ch), ►Sequence_of_a_and_b; */
  StateStack.Push(1);
  if (PeekSymbol() == AorBorEnd.End)
     // Reduce4:
     {
     /* Sequence_of_a_and_b= ;◄ */

     EndOfSequence();

     goto Reduce5;
     }
  if (PeekSymbol() == AorBorEnd.b)
     goto AcceptReduce3;
  if (PeekSymbol() == AorBorEnd.Other)
     goto EndWithError;
  Debug.Assert(PeekSymbol() == AorBorEnd.a);
AcceptReduce2:
  i++;
  // Reduce2:
  /* aAdjust: 1
   * AorB(char x)= a;◄ */
  AttrStack.Allocate(1);

  DisplayAndAssignA(
     x: out AttrStack.PeekRef(0)._char
     );

  goto State2;

State3:
  /* *Startsymbol= Sequence_of_a_and_b, ►End; */
  Debug.Assert(PeekSymbol() == AorBorEnd.End);
  i++;
  // Reduce6:
  /* *Startsymbol= Sequence_of_a_and_b, End;◄ */
  // Halt: a definition of the startsymbol with 0 attributes has been recognized.
  StateStack.Remove(1);
  goto EndOfGeneratedCode;

Reduce5:
  /* sAdjust: -1, aAdjust: -1
   * Sequence_of_a_and_b= AorB(char ch), Sequence_of_a_and_b;◄ */
  StateStack.Remove(1);

  DisplayAorB(
     ch: AttrStack.PeekRef(0)._char
     );

  AttrStack.Remove(1);
  // Branch1:
  if (StateStack.Peek() == 0)
     goto State3;
  goto Reduce5;

EndWithError:
  // This point is reached after an input error has been found
  StateStack.Remove(StateStack.Count - _StateStackInitialCount);
  AttrStack.Remove(AttrStack.Count - _AttributeStackInitialCount);
  MyError(); return false;
EndOfGeneratedCode:
  ;

#endregion grammlator generated 27 Sep 2025 (grammlator file version/date 2022.11.10.0/27 Sep 2025)

         Success();
         return true;
      }
   }
}
