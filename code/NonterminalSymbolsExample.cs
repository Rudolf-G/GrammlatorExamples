using System;
using System.Diagnostics;

namespace GrammlatorExamples
{
   static class NonterminalSymbolsExample
   {
      enum SomeLetters
      {
         precedingCharacters = (int)'a' - 1, a, b, c, successiveCharacters
      }

      #region grammar
      //| TerminalSymbolEnum: "SomeLetters";
      //| InputExpression: "PeekSymbol()";
      //| InputAcceptInstruction: "AcceptSymbol();";
      //| ErrorHaltInstruction: "DisplayRemainder(); return false;";
      //|
      //| precedingCharacters | a | b | c | successiveCharacters;
      //|
      //| *= Variants;
      //|
      //| Variants=
      //|   a, b 
      //|   | b, a;
      #endregion grammar

      public static Boolean AnalyzeInput(string line)
      {
         String InputLine = line + '*';
         int i = 0;

         // Local methods
         SomeLetters PeekSymbol()
            => (SomeLetters)InputLine[i];
         void AcceptSymbol()
            => i++;
         void DisplayRemainder()
            => Console.WriteLine($@" Remainder of line: ""{InputLine[i..]}""");

#region grammlator generated 23 Mar 2023 (grammlator file version/date 2022.11.10.0/17 Jan 2023)

  // State1:
  /* *Startsymbol= ►Variants; */
  if (PeekSymbol() == SomeLetters.a)
     {
     AcceptSymbol();
     // State3:
     /* Variants= a, ►b; */
     if (PeekSymbol() != SomeLetters.b)
        goto EndWithError;
     Debug.Assert(PeekSymbol() == SomeLetters.b);
     goto AcceptEndOfGeneratedCode;
     }
  if (PeekSymbol() != SomeLetters.b)
     goto EndWithError;
  Debug.Assert(PeekSymbol() == SomeLetters.b);
  AcceptSymbol();
  // State2:
  /* Variants= b, ►a; */
  if (PeekSymbol() != SomeLetters.a)
     goto EndWithError;
  Debug.Assert(PeekSymbol() == SomeLetters.a);
AcceptEndOfGeneratedCode:
  AcceptSymbol();
  goto EndOfGeneratedCode;

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
