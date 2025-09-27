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

#region grammlator generated 27 Sep 2025 (grammlator file version/date 2022.11.10.0/27 Sep 2025)
  const Int64 _fa = 1L << (Int32)(SomeLetters.a-97);
  const Int64 _ff = 1L << (Int32)(SomeLetters.f-97);
  const Int64 _fother = 1L << (Int32)(SomeLetters.other-97);
  Boolean _is(Int64 flags) => (1L << (Int32)((Peek())-97) & flags) != 0;

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

#endregion grammlator generated 27 Sep 2025 (grammlator file version/date 2022.11.10.0/27 Sep 2025)
         DisplayRemainder();
         return true;
      }
   }
}
