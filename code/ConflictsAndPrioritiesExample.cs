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
      //| TerminalSymbolEnum: "SomeLetters"; ErrorHaltInstruction: "DisplayRemainder(); return false;"
      //| SymbolNameOrFunctionCall: "PeekSymbol()"; SymbolAcceptInstruction: "AcceptSymbol();";
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

#region grammlator generated 29 Sep 2020 (grammlator file version/date 2020.09.28.0/29 Sep 2020)
  // State1:
  /* *Startsymbol= ►aa;
   * *Startsymbol= ►aaaa;
   * *Startsymbol= ►Sequence_of_b; */
  if (PeekSymbol() == SomeLetters.a)
     {
     AcceptSymbol();
     // State3:
     /* aa= a, ►a;
      * aaaa= a, ►a, a, a; */
     if (PeekSymbol() != SomeLetters.a)
        goto EndWithError;
     Debug.Assert(PeekSymbol() == SomeLetters.a);
     AcceptSymbol();
     // State4:
     /* aa= a, a●;
      * aaaa= a, a, ►a, a; */
     if (PeekSymbol() != SomeLetters.a)
        goto EndOfGeneratedCode;
     Debug.Assert(PeekSymbol() == SomeLetters.a);
     AcceptSymbol();
     // State5:
     /* aaaa= a, a, a, ►a; */
     if (PeekSymbol() != SomeLetters.a)
        goto EndWithError;
     Debug.Assert(PeekSymbol() == SomeLetters.a);
     AcceptSymbol();
     goto EndOfGeneratedCode;
     }
  if (PeekSymbol() != SomeLetters.b)
     goto EndWithError;
  Debug.Assert(PeekSymbol() == SomeLetters.b);
AcceptState2:
  AcceptSymbol();
  // State2:
  /* *Startsymbol= Sequence_of_b●;
   * Sequence_of_b= Sequence_of_b, ►b; */
  if (PeekSymbol() != SomeLetters.b)
     goto EndOfGeneratedCode;
  Debug.Assert(PeekSymbol() == SomeLetters.b);
  goto AcceptState2;

EndWithError:
  // This point is reached after an input error has been found
  DisplayRemainder(); return false;

EndOfGeneratedCode:
  ;

#endregion grammlator generated 29 Sep 2020 (grammlator file version/date 2020.09.28.0/29 Sep 2020)

         DisplayRemainder();
         return true;
      }
   }
}
