using System;

namespace GrammlatorExamples {
   static class TerminalSymbols1stExample {
      #region grammar
      //| /* grammlator settings: */
      //| SymbolNameOrFunctionCall: "Peek()";
      //| SymbolAcceptInstruction: "Column++;";
      //| ErrorHaltInstruction: "return false;";
      //| GenerateComments: false; // recommended: true;
      //| DebugAssertMethod: ""; // recommended: "Debug.Assert";
      //|
      //| /* declaration of terminal symbols: */
      enum SomeLetters { e = 101, f, g, h, i, j, k, l, m, n, o, eol, other };

      //|
      //| /* The 1st grammar rule defines the startsymbol "*" */
      //| *= h, e, l, l, o, eol
      private static void Hello() => Console.WriteLine(":-)");
      // This C# method will be called by the generated code
      // when "hello" followed by end of line is recognized 

      //| 
      #endregion grammar

      static public bool WriteAnswer(string line)
      {
         int Column = 0;

         static SomeLetters CharToSomeLetters(char c)
            => c < 'e' | c > 'o' ? SomeLetters.other : (SomeLetters)(c);

         SomeLetters Peek() => (Column >= line.Length)
                  ? SomeLetters.eol
                  : CharToSomeLetters(line[Column]);

         #region grammlator generated 11 Okt 2020 (grammlator file version/date 2020.10.10.0/10 Okt 2020)
         if (Peek() != SomeLetters.h)
            goto EndWithError;
         Column++;
         if (Peek() > SomeLetters.e)
            goto EndWithError;
         Column++;
         if (Peek() != SomeLetters.l)
            goto EndWithError;
         Column++;
         if (Peek() != SomeLetters.l)
            goto EndWithError;
         Column++;
         if (Peek() != SomeLetters.o)
            goto EndWithError;
         Column++;
         if (Peek() != SomeLetters.eol)
            goto EndWithError;
         Column++;

         Hello();

         goto EndOfGeneratedCode;

      EndWithError:
         return false;

      EndOfGeneratedCode:
         ;

         #endregion grammlator generated 11 Okt 2020 (grammlator file version/date 2020.10.10.0/10 Okt 2020)

         return true;
      }
   }
}
