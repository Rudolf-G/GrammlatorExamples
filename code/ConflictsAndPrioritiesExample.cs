using System;
using System.Diagnostics;

namespace GrammlatorDocumentation.code
{
   internal class ConflictsAndPrioritiesExample
   {
      #region grammar
      //| ErrorHaltInstruction: "DisplayRemainder(); return false;";
      //| InputExpression: "PeekSymbol()"; InputAcceptInstruction: "AcceptSymbol();";
      //| StateStack: "StateStack"; AttributeStack: "AttrStack";
      //|
      enum SomeLetters { a, b, c}
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

      public static bool AnalyzeInput(string line)
      {
         string InputLine = line + "*";
         int i = 0;

         // Local methods
         SomeLetters PeekSymbol()
            => (SomeLetters)InputLine[i];
         void AcceptSymbol()
            => i++;
         void DisplayRemainder()
            => Console.WriteLine($@"Remainder of line: ""{InputLine[i..]}""");

#region grammlator generated 23 Mar 2023 (grammlator file version/date 2022.11.10.0/17 Jan 2023)

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
  if (PeekSymbol() == SomeLetters.c)
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

#endregion grammlator generated 23 Mar 2023 (grammlator file version/date 2022.11.10.0/17 Jan 2023)

         DisplayRemainder();
         return true;
      }
   }
}
