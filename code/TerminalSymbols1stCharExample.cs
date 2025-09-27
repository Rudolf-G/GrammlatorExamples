using System;
using System.Collections.Generic;
using System.Text;

namespace GrammlatorDocumentation.code {
   class TerminalSymbols1stCharExample {

      static public bool WriteAnswer(string line)
      {
         // Declare the special char constants
         const char MyEndOfLine = (char)('e' - 1);
         const char other = (char)('o' + 1);

         int Column = 0;
         char MyPeek()
            => Column >= line.Length
            ? MyEndOfLine
            : line[Column] >= 'e' && line[Column] <= 'o'
              ? line[Column]
              : other;

         #region grammar
         //| /* grammlator settings: */
         //| InputExpression: "MyPeek()";
         //| InputAcceptInstruction: "Column++;";
         //| ErrorHaltInstruction: "return false;";
         //| GenerateComments: false; // recommended: true;
         //| NameOfAssertMethod: ""; // recommended: "Debug.Assert";
         //|
         //| /* Declaration of the terminal symbols by a sorted list of char literals and char constants: */
         //|   MyEndOfLine=96 | 'e' | 'f' | 'g' | 'h' | 'i' | 'j' | 'k' | 'l' | 'm' | 'n' | 'o' | other;
         //|
         //| /* The 1st grammar rule defines the startsymbol "*" */
         //| *= 'h' 'e' 'l' 'l' 'o' MyEndOfLine
         static void Hello() => Console.WriteLine(":-)");
         // This C# method will be called by the generated code
         // after "hello" followed by end of line is recognized 

         //| 
         #endregion grammar

#region grammlator generated 27 Sep 2025 (grammlator file version/date 2022.11.10.0/27 Sep 2025)

  if (MyPeek() != 'h')
     goto EndWithError;
  Column++;
  if (MyPeek() != 'e')
     goto EndWithError;
  Column++;
  if (MyPeek() != 'l')
     goto EndWithError;
  Column++;
  if (MyPeek() != 'l')
     goto EndWithError;
  Column++;
  if (MyPeek() != 'o')
     goto EndWithError;
  Column++;
  if (MyPeek() != MyEndOfLine)
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
