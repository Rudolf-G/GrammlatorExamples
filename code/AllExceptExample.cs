using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace GrammlatorExamples
{
   static class AllExceptExample
   {
      private enum SomeLetters
      {
         CharactersPreceding_a = (int)'a' - 1, a, b, c, d, e, f, CharactersFollowing_f
      }

      #region grammar
      //| TerminalSymbolEnum: "SomeLetters";
      //| SymbolNameOrFunctionCall: "PeekSymbol()"; SymbolAcceptInstruction: "AcceptSymbol();";
      //| ErrorHaltInstruction: "DisplayRemainder(); return false;"
      //| StateStack: "StateStack"; StateStackInitialCountVariable: "StateStackInitialCount";
      //| AttributeStack: "_a";
      //|
      //| CharactersPreceding_a | a | b | c | d | e | f | CharactersFollowing_f;
      //|
      //| *= Letter_a_to_f;
      //|
      //| // all except is defined by minus character followed by equals character followed by list of terminal symbols
      //| Letter_a_to_f-= // all input symbols except c, e, CharactersPreceding_a and CharactersFollowing_f
      //|   c | e | CharactersPreceding_a | CharactersFollowing_f;
      //|
      #endregion grammar

      public static Boolean AnalyzeInput()
      {
         String InputLine = Console.ReadLine() + '*';
         int i = 0;

         // Local methods
         SomeLetters PeekSymbol()
            => (SomeLetters)InputLine[i];
         void AcceptSymbol()
            => i++;
         void DisplayRemainder()
            => Console.WriteLine(" Remainder of line: \"" + InputLine.Substring(i) + "\"");

#region grammlator generated 29 Sep 2020 (grammlator file version/date 2020.09.28.0/29 Sep 2020)
  const Int64 _fCharactersPreceding_a = 2L << (Int32)SomeLetters.CharactersPreceding_a;
  const Int64 _fa = 2L << (Int32)SomeLetters.a;
  const Int64 _fb = 2L << (Int32)SomeLetters.b;
  const Int64 _fc = 2L << (Int32)SomeLetters.c;
  const Int64 _fd = 2L << (Int32)SomeLetters.d;
  const Int64 _fe = 2L << (Int32)SomeLetters.e;
  const Int64 _ff = 2L << (Int32)SomeLetters.f;
  const Int64 _fCharactersFollowing_f = 2L << (Int32)SomeLetters.CharactersFollowing_f;
  Boolean _IsIn(Int64 flags) => ((2L << (Int32)PeekSymbol()) & flags) != 0;

  // State1:
  /* *Startsymbol= ►Letter_a_to_f; */
  if (!_IsIn(_fa | _fb | _fd | _ff))
     goto EndWithError;
  Debug.Assert(!_IsIn(_fCharactersPreceding_a | _fc | _fe | _fCharactersFollowing_f));
  AcceptSymbol();
  goto EndOfGeneratedCode;

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
