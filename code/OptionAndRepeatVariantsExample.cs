using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace GrammlatorExamples {
   static class OptionAndRepeatVariantsExample {
      enum SomeLetters {
         precedingCharacters = (int)'a' - 1, a, b, c, d, e, f, g, h, successiveCharacters
      }

      #region grammar
      //| TerminalSymbolEnum: "SomeLetters";
      //| SymbolNameOrFunctionCall: "(SomeLetters)InputLine[i]";
      //| SymbolAcceptInstruction: "i++;";
      //| ErrorHaltInstruction: "DisplayRemainder(); return false;"
      //| OptimizeStateStackNumbers: false;
      //|
      //| precedingCharacters | a | b | c | d | e | f | g | h | successiveCharacters;
      //|
      //| *= examples h; 
      //|
      //| examples=
      //|     (test=a)
      //|   | b*
      //|   | (c)*
      //|   | d*
      //|   | e**
      //|   | f+
      //|   | g++
      //|   | a, (b)*;
      //|
      #endregion grammar

      public static void Discard(this Stack<Int32> s, int n)
      {
         while (n > 0)
         { n--; s.Pop(); }
      }

      public static Boolean AnalyzeInput()
      {
         String InputLine = Console.ReadLine() + '*';
         int i = 0;

         void DisplayRemainder()
            => Console.WriteLine(" Remainder of line: \"" + InputLine.Substring(i) + "\"");

         var _s = new Stack<int>();

#region grammlator generated 2 Okt 2020 (grammlator file version/date 2020.09.28.0/2 Okt 2020)
  Int32 _StateStackInitialCount = _s.Count;

  // State1:
  /* *Startsymbol= ►examples, h; */
  _s.Push(0);
  switch ((SomeLetters)InputLine[i])
  {
  // <= SomeLetters.precedingCharacters
  // >= SomeLetters.successiveCharacters: goto EndWithError // see end of switch
  case SomeLetters.a:
     {
     i++;
     // State10:
     /* *Startsymbol= examples, ►h;
      * examples= a, ►(Local2)*; */
     if ((SomeLetters)InputLine[i] == SomeLetters.b)
        goto State11;
     if ((SomeLetters)InputLine[i] != SomeLetters.h)
        goto EndWithError;
     Debug.Assert((SomeLetters)InputLine[i] == SomeLetters.h);
     goto AcceptReduce1;
     }
  case SomeLetters.b:
  case SomeLetters.h:
     goto State4;
  case SomeLetters.c:
     goto State3;
  case SomeLetters.d:
     goto State2;
  case SomeLetters.e:
     goto AcceptState9;
  case SomeLetters.f:
     goto AcceptState8;
  case SomeLetters.g:
     {
     i++;
     // State6:
     /* *Startsymbol= examples, ►h;
      * g++= g, ►g++; */// *Push(5)
     if ((SomeLetters)InputLine[i] == SomeLetters.g)
        {
        i++;
        // PushState1:
        _s.Push(5);
        goto State7;
        }
     if ((SomeLetters)InputLine[i] == SomeLetters.h)
        {
        i++;
        // Reduce2:
        /* *Startsymbol= examples, h;◄ */
        goto ApplyStartsymbolDefinition1;
        }
     Debug.Assert((SomeLetters)InputLine[i] != SomeLetters.g && (SomeLetters)InputLine[i] != SomeLetters.h);
     // PushState2:
     _s.Push(5);
     goto EndWithError;
     }
  } // end of switch
  Debug.Assert((SomeLetters)InputLine[i] <= SomeLetters.precedingCharacters || (SomeLetters)InputLine[i] >= SomeLetters.successiveCharacters);

  goto EndWithError;

AcceptReduce1:
  i++;
  // Reduce1:
  /* *Startsymbol= examples, h;◄ */
ApplyStartsymbolDefinition1:
  // Halt: a definition of the startsymbol with 0 attributes has been recognized.
  _s.Pop();
  goto EndOfGeneratedCode;

State2:
  /* *Startsymbol= examples, ►h;
   * d*= d*, ►d; */
  if ((SomeLetters)InputLine[i] == SomeLetters.d)
     {
     i++;
     goto State2;
     }
  if ((SomeLetters)InputLine[i] != SomeLetters.h)
     goto EndWithError;
  Debug.Assert((SomeLetters)InputLine[i] == SomeLetters.h);
  goto AcceptReduce1;

State3:
  /* *Startsymbol= examples, ►h;
   * (Local1)*= (Local1)*, ►(Local1); */
  if ((SomeLetters)InputLine[i] == SomeLetters.c)
     {
     i++;
     goto State3;
     }
  if ((SomeLetters)InputLine[i] != SomeLetters.h)
     goto EndWithError;
  Debug.Assert((SomeLetters)InputLine[i] == SomeLetters.h);
  goto AcceptReduce1;

State4:
  /* *Startsymbol= examples, ►h;
   * b*= b*, ►b; */
  if ((SomeLetters)InputLine[i] == SomeLetters.b)
     {
     i++;
     goto State4;
     }
  if ((SomeLetters)InputLine[i] != SomeLetters.h)
     goto EndWithError;
  Debug.Assert((SomeLetters)InputLine[i] == SomeLetters.h);
  goto AcceptReduce1;

State5:
  /* *Startsymbol= examples, ►h; */
  Debug.Assert((SomeLetters)InputLine[i] == SomeLetters.h);
  goto AcceptReduce1;

State7:
  /* g++= g, ►g++;
   * g++= g, g++●; */
  _s.Push(6);
  if ((SomeLetters)InputLine[i] == SomeLetters.h)
     // Reduce4:
     {
     /* sAdjust: -2
      * g++= g, g++;◄ */
     _s.Discard(2);
     goto Branch1;
     }
  if ((SomeLetters)InputLine[i] != SomeLetters.g)
     goto EndWithError;
  Debug.Assert((SomeLetters)InputLine[i] == SomeLetters.g);
  i++;
  goto State7;

AcceptState8:
  i++;
  // State8:
  /* *Startsymbol= examples, ►h;
   * f+= f+, ►f; */
  if ((SomeLetters)InputLine[i] == SomeLetters.f)
     goto AcceptState8;
  if ((SomeLetters)InputLine[i] != SomeLetters.h)
     goto EndWithError;
  Debug.Assert((SomeLetters)InputLine[i] == SomeLetters.h);
  goto AcceptReduce1;

AcceptState9:
  i++;
  // State9:
  /* e**= e, ►e**; */
  _s.Push(8);
  if ((SomeLetters)InputLine[i] == SomeLetters.e)
     goto AcceptState9;
  if ((SomeLetters)InputLine[i] != SomeLetters.h)
     goto EndWithError;
  Debug.Assert((SomeLetters)InputLine[i] == SomeLetters.h);
Reduce6:
  /* sAdjust: -1
   * e**= e, e**;◄ */
  _s.Pop();
  // Branch2:
  if (_s.Peek() == 0)
     goto State5;
  goto Reduce6;

State11:
  /* examples= a, (Local2)*●;
   * (Local2)*= (Local2)*, ►(Local2); */
  if ((SomeLetters)InputLine[i] == SomeLetters.h)
     goto State5;
  if ((SomeLetters)InputLine[i] != SomeLetters.b)
     goto EndWithError;
  Debug.Assert((SomeLetters)InputLine[i] == SomeLetters.b);
  i++;
  goto State11;

Branch1:
  switch (_s.Peek())
  {
  case 0:
     goto State5;
  case 6:
     // Reduce5:
     {
     /* sAdjust: -1
      * g++= g, g++;◄ */
     _s.Pop();
     goto Branch1;
     }
  /*case 5:
  default: break; */
  }
  // Reduce3:
  /* sAdjust: -1
   * g++= g, g++;◄ */
  _s.Pop();
  goto State5;

EndWithError:
  // This point is reached after an input error has been found
  _s.Discard(_s.Count - _StateStackInitialCount);
  DisplayRemainder(); return false;

EndOfGeneratedCode:
  ;

#endregion grammlator generated 2 Okt 2020 (grammlator file version/date 2020.09.28.0/2 Okt 2020)
         DisplayRemainder();
         return true;
      }
   }
}
