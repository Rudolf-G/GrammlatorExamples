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
      //| InstructionErrorHalt: "DisplayRemainder(); return false;"
      //| Symbol: "PeekSymbol()"; AcceptSymbol: "AcceptSymbol();";
      //| StateStack: "StateStack"; StateStackInitialCountVariable: "StateStackInitialCount";
      //| AttributeStack: "_a";
      //|
      //| CharactersPreceding_a | a | b | c | d | e | f | CharactersFollowing_f;
      //|
      //| *= Letter_a_to_f;
      //|
      //| Letter_a_to_f-= // Minus sign followed by equals character followed by list of terminal symbols
      //|   c | e | CharactersPreceding_a | CharactersFollowing_f;
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

#region grammlator generated Sat, 09 May 2020 08:44:24 GMT (grammlator, File version 2020.04.07.1 09.05.2020 08:26:06)
  /* State 1
   * *Startsymbol= ►Letter_a_to_f;
   */
  if (PeekSymbol() <= SomeLetters.CharactersPreceding_a
     || PeekSymbol() == SomeLetters.c
     || PeekSymbol() == SomeLetters.e
     || PeekSymbol() >= SomeLetters.CharactersFollowing_f)
     {
     goto EndWithError;
     }
  Debug.Assert(PeekSymbol() == SomeLetters.a || PeekSymbol() == SomeLetters.b
     || PeekSymbol() == SomeLetters.d
     || PeekSymbol() == SomeLetters.f);
  AcceptSymbol();
  /* Reduction 1
   * *Startsymbol= Letter_a_to_f;◄
   */
  goto EndOfGeneratedCode;

EndWithError:
  // This point is reached after an input error has been found
  DisplayRemainder(); return false;

EndOfGeneratedCode:
  ;
#endregion grammlator generated Sat, 09 May 2020 08:45:48 GMT (grammlator, File version 2020.04.07.1 09.05.2020 08:26:06)
         DisplayRemainder();
         return true;
      }
   }
}
