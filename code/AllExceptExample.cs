using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace GrammlatorExamples
{
   static class AllExceptExample
   {

      #region grammar
      //| TerminalSymbolEnum: "SomeLetters";
      //| SymbolNameOrFunctionCall: "(SomeLetters)InputLine[i]";
      //| SymbolAcceptInstruction: "i++;";
      //| ErrorHaltInstruction: "DisplayRemainder(); return false;";
      //| StateStack: "StateStack"; StateStackInitialCountVariable: "StateStackInitialCount";
      //| AttributeStack: "_a";
      //|LineLengthLimit: 80;
      //|
      private enum SomeLetters {
         CharactersPreceding_a = 96, a, b, c, d, e, f, CharactersFollowing_f
      }
      //|
      //| *= Letter_a_to_f;
      //|
      //| // all except is defined by minus character followed by equals character followed by list of terminal symbols
      //| Letter_a_to_f-= // all input symbols except c, e, CharactersPreceding_a and CharactersFollowing_f
      //|   c | e | CharactersPreceding_a | CharactersFollowing_f;
      //|
      #endregion grammar

      public static Boolean AnalyzeInput(string line)
      {
         String InputLine = line + '*';
         int i = 0;

         void DisplayRemainder()
            => Console.WriteLine(" Remainder of line: \"" + InputLine.Substring(i) + "\"");

#region grammlator generated 12 Okt 2020 (grammlator file version/date 2020.10.10.0/11 Okt 2020)
  const Int64 _fa = 1L << (Int32)(SomeLetters.a-96);
  const Int64 _fb = 1L << (Int32)(SomeLetters.b-96);
  const Int64 _fc = 1L << (Int32)(SomeLetters.c-96);
  const Int64 _fd = 1L << (Int32)(SomeLetters.d-96);
  const Int64 _fe = 1L << (Int32)(SomeLetters.e-96);
  const Int64 _ff = 1L << (Int32)(SomeLetters.f-96);
  Boolean _is(Int64 flags) => (1L << (Int32)(((SomeLetters)InputLine[i])-96) & flags) != 0;

  // State1:
  /* *Startsymbol= ►Letter_a_to_f; */
  if (!_is(_fa | _fb | _fd | _ff))
     goto EndWithError;
  Debug.Assert((SomeLetters)InputLine[i] > SomeLetters.CharactersPreceding_a
         && (SomeLetters)InputLine[i] < SomeLetters.CharactersFollowing_f && !_is(
        _fc | _fe));
  i++;
  goto EndOfGeneratedCode;

EndWithError:
  // This point is reached after an input error has been found
  DisplayRemainder(); return false;

EndOfGeneratedCode:
  ;

#endregion grammlator generated 12 Okt 2020 (grammlator file version/date 2020.10.10.0/11 Okt 2020)
         DisplayRemainder();
         return true;
      }
   }
}
