using System;
using System.Diagnostics;

namespace GrammlatorDocumentation.code
{
   static class LeftRecursionExampleWithRepeat
   {
      #region grammar
      //| InputExpression: "(SomeLetters)InputLine[i]";
      //| InputAcceptInstruction: "i++;";
      //|
      enum SomeLetters { precedingCharacters = 96, a, b, c, successiveCharacters }
      //|
      //| *= b*, a;
      //|
      #endregion grammar

      public static bool AnalyzeInput(string line)
      {
         string InputLine = line + '*';
         int i = 0;

         // Local methods
         void DisplayRemainder()
            => Console.WriteLine(" Remainder of line: \"" + InputLine[i..] + "\"");

#region grammlator generated 27 Sep 2025 (grammlator file version/date 2022.11.10.0/27 Sep 2025)

State2:
  /* *Startsymbol= b*, ►a;
   * b*= b*, ►b; */
  if ((SomeLetters)InputLine[i] == SomeLetters.a)
     {
     i++;
     goto EndOfGeneratedCode;
     }
  if ((SomeLetters)InputLine[i] != SomeLetters.b)
     goto EndWithError;
  Debug.Assert((SomeLetters)InputLine[i] == SomeLetters.b);
  i++;
  goto State2;

EndWithError:
  // This point is reached after an input error has been found
EndOfGeneratedCode:
  ;

#endregion grammlator generated 27 Sep 2025 (grammlator file version/date 2022.11.10.0/27 Sep 2025)
         DisplayRemainder();
         return true;
      }
   }
}
