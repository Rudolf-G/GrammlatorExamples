using System;

namespace GrammlatorDocumentation.code
{
   static class TerminalSymbols1stExample {
      #region grammar
      //| /* grammlator settings: */
      //| InputExpression: "Peek()";
      //| InputAcceptInstruction: "Column++;";
      //| ErrorHaltInstruction: "return false;";
      //| GenerateComments: false; // recommended: true;
      //| NameOfAssertMethod: ""; // recommended: "Debug.Assert";
      //|
      //| /* Declaration of the terminal symbols by an enum: */
      enum SomeLetters : ushort { e = 'e', f, g, h, i, j, k, l, m, n, o, eol, other };
      #endregion grammar

      static public bool WriteAnswer(string line)
      {
         int Column = 0;

         static SomeLetters CharToSomeLetters(char c)
            => c < 'e' | c > 'o' ? SomeLetters.other : (SomeLetters)c;

         SomeLetters Peek() => Column >= line.Length
                  ? SomeLetters.eol
                  : CharToSomeLetters(line[Column]);

         #region grammar
         //|
         //| /* The 1st grammar rule defines the startsymbol "*" */
         //| *= h, e, l, l, o, eol
         static void Hello() => Console.WriteLine(":-)");
         // This C# method will be called by the generated code
         // when "hello" followed by "eol" is recognized 

         //| 
         #endregion grammar

#region grammlator generated 27 Sep 2025 (grammlator file version/date 2022.11.10.0/27 Sep 2025)

  if (Peek() != SomeLetters.h)
     goto EndWithError;
  Column++;
  if (Peek() != SomeLetters.e)
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

#endregion grammlator generated 27 Sep 2025 (grammlator file version/date 2022.11.10.0/27 Sep 2025)

         return true;
      }
   }
}
