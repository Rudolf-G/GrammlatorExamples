using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace GrammlatorDocumentation.code
{
   static class AllExceptExample {

      #region grammar
      //| TerminalSymbolEnum: "SomeLetters";
      //| InputExpression: "Peek()";
      //| InputAcceptInstruction: "i++;";
      //| ErrorHaltInstruction: "DisplayRemainder(); return false;";
      //| StateStack: "StateStack";
      //| AttributeStack: "_a";
      //| LineLengthLimit: 80;
      //|
      private enum SomeLetters { a = 97, b, c, d, e, f, other }
      //|
      //| *= Letter_b_to_e;
      //|
      //| // all except is defined by minus character followed by equals character followed by list of terminal symbols
      //| Letter_b_to_e-= // all input symbols except a, f, other
      //|   a | f | other;
      //|
      #endregion grammar

      public static bool AnalyzeInput(string line)
      {
         string InputLine = line + '*';
         int i = 0;

         void DisplayRemainder()
            => Console.WriteLine($" Remainder of line: \"{InputLine[i..]}\"");
         SomeLetters Peek()
            => InputLine[i] < 'a' || InputLine[i] > 'f' ? SomeLetters.other : (SomeLetters)InputLine[i];

#region grammlator generated 23 Mar 2023 (grammlator file version/date 2022.11.10.0/17 Jan 2023)
  const long _fa = 1L << (int)(SomeLetters.a-97);
  const long _ff = 1L << (int)(SomeLetters.f-97);
  const long _fother = 1L << (int)(SomeLetters.other-97);
         bool _is(long flags) => (1L << (int)(Peek()-97) & flags) != 0;

  // State1:
  /* *Startsymbol= ►Letter_b_to_e; */
  if (_is(_fa | _ff | _fother))
     goto EndWithError;
  Debug.Assert(!_is(_fa | _ff | _fother));
  i++;
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
