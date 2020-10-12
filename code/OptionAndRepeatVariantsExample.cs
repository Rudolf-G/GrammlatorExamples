using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace GrammlatorExamples {
   static class OptionAndRepeatVariantsExample {

      #region grammar
      //| TerminalSymbolEnum: "SomeLetters";
      //| SymbolNameOrFunctionCall: "(SomeLetters)InputLine[i]";
      //| SymbolAcceptInstruction: "i++;";
      //| ErrorHaltInstruction: "DisplayRemainder(); return false;";
      //| OptimizeStateStackNumbers: false;
      //|
      enum SomeLetters {
         precedingCharacters = 96, a, b, c, d, e, f, g, h, i, j, k, l, successiveCharacters
      }
      //|
      //| *= examples l; 
      //|
      //| examples=
      //|     (test=a)
      //|   | b*
      //|   | (c)*
      //|   | d+
      //|   | e++
      //|   | f?
      //|   | {g}
      //|   | [h]
      //|   | i, test, a, b*, (c)*, d+, e++, f?, {g}, [h];
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

#region grammlator generated 12 Okt 2020 (grammlator file version/date 2020.10.10.0/11 Okt 2020)
  Int32 _StateStackInitialCount = _s.Count;
  const Int64 _fc = 1L << (Int32)(SomeLetters.c-96);
  const Int64 _fd = 1L << (Int32)(SomeLetters.d-96);
  const Int64 _fe = 1L << (Int32)(SomeLetters.e-96);
  const Int64 _ff = 1L << (Int32)(SomeLetters.f-96);
  const Int64 _fg = 1L << (Int32)(SomeLetters.g-96);
  const Int64 _fh = 1L << (Int32)(SomeLetters.h-96);
  const Int64 _fl = 1L << (Int32)(SomeLetters.l-96);
  Boolean _is(Int64 flags) => (1L << (Int32)(((SomeLetters)InputLine[i])-96) & flags) != 0;

  // State1:
  /* *Startsymbol= ►examples, l; */
  _s.Push(0);
  switch ((SomeLetters)InputLine[i])
  {
  // <= SomeLetters.precedingCharacters
  // >= SomeLetters.successiveCharacters: goto EndWithError // see end of switch
  case SomeLetters.j:
  case SomeLetters.k:
     goto EndWithError;
  case SomeLetters.a:
  case SomeLetters.f:
  case SomeLetters.h:
     {
     i++;
     goto State18;
     }
  case SomeLetters.b:
  case SomeLetters.l:
     goto State4;
  case SomeLetters.c:
     goto State3;
  case SomeLetters.d:
     goto AcceptState17;
  case SomeLetters.e:
     {
     i++;
     // State16:
     /* *Startsymbol= examples, ►l;
      * e++= e, ►e++; */// *Push(15)
     if ((SomeLetters)InputLine[i] == SomeLetters.e)
        {
        i++;
        // PushState3:
        _s.Push(15);
        goto State15;
        }
     if ((SomeLetters)InputLine[i] == SomeLetters.l)
        {
        i++;
        // Reduce7:
        /* *Startsymbol= examples, l;◄ */
        goto ApplyStartsymbolDefinition1;
        }
     Debug.Assert(!_is(_fe | _fl));
     // PushState4:
     _s.Push(15);
     goto EndWithError;
     }
  case SomeLetters.g:
     goto State2;
  case SomeLetters.i:
     {
     i++;
     // State5:
     /* examples= i, ►test, a, b*, (Local4)*, d+, e++, f?, (Local5)*, (Local6)?; */
     if ((SomeLetters)InputLine[i] != SomeLetters.a)
        goto EndWithError;
     Debug.Assert((SomeLetters)InputLine[i] == SomeLetters.a);
     i++;
     // State6:
     /* examples= i, test, ►a, b*, (Local4)*, d+, e++, f?, (Local5)*, (Local6)?; */
     if ((SomeLetters)InputLine[i] != SomeLetters.a)
        goto EndWithError;
     Debug.Assert((SomeLetters)InputLine[i] == SomeLetters.a);
     goto AcceptState8;
     }
  } // end of switch
  Debug.Assert((SomeLetters)InputLine[i] <= SomeLetters.precedingCharacters || (SomeLetters)InputLine[i] >= SomeLetters.successiveCharacters);

  goto EndWithError;

AcceptReduce1:
  i++;
  // Reduce1:
  /* *Startsymbol= examples, l;◄ */
ApplyStartsymbolDefinition1:
  // Halt: a definition of the startsymbol with 0 attributes has been recognized.
  _s.Pop();
  goto EndOfGeneratedCode;

Reduce3:
  /* sAdjust: -2
   * examples= i, test, a, b*, (Local4)*, d+, e++, f?, (Local5)*, (Local6)?;◄ */
  _s.Discard(2);
State18:
  /* *Startsymbol= examples, ►l; */
  if ((SomeLetters)InputLine[i] != SomeLetters.l)
     goto EndWithError;
  Debug.Assert((SomeLetters)InputLine[i] == SomeLetters.l);
  goto AcceptReduce1;

State2:
  /* *Startsymbol= examples, ►l;
   * (Local2)*= (Local2)*, ►(Local2); */
  if ((SomeLetters)InputLine[i] == SomeLetters.g)
     {
     i++;
     goto State2;
     }
  if ((SomeLetters)InputLine[i] != SomeLetters.l)
     goto EndWithError;
  Debug.Assert((SomeLetters)InputLine[i] == SomeLetters.l);
  goto AcceptReduce1;

State3:
  /* *Startsymbol= examples, ►l;
   * (Local1)*= (Local1)*, ►(Local1); */
  if ((SomeLetters)InputLine[i] == SomeLetters.c)
     {
     i++;
     goto State3;
     }
  if ((SomeLetters)InputLine[i] != SomeLetters.l)
     goto EndWithError;
  Debug.Assert((SomeLetters)InputLine[i] == SomeLetters.l);
  goto AcceptReduce1;

State4:
  /* *Startsymbol= examples, ►l;
   * b*= b*, ►b; */
  if ((SomeLetters)InputLine[i] == SomeLetters.b)
     {
     i++;
     goto State4;
     }
  if ((SomeLetters)InputLine[i] != SomeLetters.l)
     goto EndWithError;
  Debug.Assert((SomeLetters)InputLine[i] == SomeLetters.l);
  goto AcceptReduce1;

AcceptState8:
  i++;
  // State8:
  /* examples= i, test, a, b*, ►(Local4)*, d+, e++, f?, (Local5)*, (Local6)?;
   * b*= b*, ►b; */
  if ((SomeLetters)InputLine[i] == SomeLetters.b)
     goto AcceptState8;
  if (!_is(_fc | _fd))
     goto EndWithError;
  Debug.Assert(_is(_fc | _fd));
State9:
  /* examples= i, test, a, b*, (Local4)*, ►d+, e++, f?, (Local5)*, (Local6)?;
   * (Local4)*= (Local4)*, ►(Local4); */
  if ((SomeLetters)InputLine[i] == SomeLetters.c)
     {
     i++;
     goto State9;
     }
  if ((SomeLetters)InputLine[i] != SomeLetters.d)
     goto EndWithError;
  Debug.Assert((SomeLetters)InputLine[i] == SomeLetters.d);
  i++;
State10:
  /* examples= i, test, a, b*, (Local4)*, d+, ►e++, f?, (Local5)*, (Local6)?;
   * d+= d+, ►d; */// *Push(9)
  if ((SomeLetters)InputLine[i] == SomeLetters.d)
     {
     i++;
     // Reduce2:
     /* d+= d+, d;◄ */
     goto State10;
     }
  if ((SomeLetters)InputLine[i] == SomeLetters.e)
     {
     i++;
     // PushState1:
     _s.Push(9);
     // State14:
     /* examples= i, test, a, b*, (Local4)*, d+, e++, ►f?, (Local5)*, (Local6)?;
      * e++= e, ►e++; */
     _s.Push(13);
     if ((SomeLetters)InputLine[i] == SomeLetters.e)
        goto AcceptState15;
     if ((SomeLetters)InputLine[i] == SomeLetters.f)
        goto AcceptState13;
     if (!_is(_fg | _fh | _fl))
        goto EndWithError;
     Debug.Assert(_is(_fg | _fh | _fl));
     goto State13;
     }
  Debug.Assert(!_is(_fd | _fe));
  // PushState2:
  _s.Push(9);
  goto EndWithError;

State11:
  /* examples= i, test, a, b*, (Local4)*, d+, e++, ►f?, (Local5)*, (Local6)?; */
  _s.Push(10);
  if ((SomeLetters)InputLine[i] <= SomeLetters.f)
     goto AcceptState13;
  Debug.Assert(_is(_fg | _fh | _fl));
State13:
  /* examples= i, test, a, b*, (Local4)*, d+, e++, f?, (Local5)*, ►(Local6)?;
   * (Local5)*= (Local5)*, ►(Local5); */
  if ((SomeLetters)InputLine[i] == SomeLetters.l)
     goto Reduce3;
  if ((SomeLetters)InputLine[i] == SomeLetters.h)
     {
     i++;
     goto Reduce3;
     }
  if ((SomeLetters)InputLine[i] != SomeLetters.g)
     goto EndWithError;
  Debug.Assert((SomeLetters)InputLine[i] == SomeLetters.g);
AcceptState13:
  i++;
  goto State13;

AcceptState15:
  i++;
State15:
  /* e++= e, ►e++;
   * e++= e, e++●; */
  _s.Push(14);
  if ((SomeLetters)InputLine[i] == SomeLetters.e)
     goto AcceptState15;
  if (!_is(_ff | _fg | _fh | _fl))
     goto EndWithError;
  Debug.Assert(_is(_ff | _fg | _fh | _fl));
  // Reduce5:
  /* sAdjust: -2
   * e++= e, e++;◄ */
  _s.Discard(2);
Branch1:
  switch (_s.Peek())
  {
  case 0:
     goto State18;
  case 9:
     goto State11;
  case 13:
     // Reduce4:
     {
     /* sAdjust: -1
      * e++= e, e++;◄ */
     _s.Pop();
     goto State11;
     }
  case 14:
     // Reduce6:
     {
     /* sAdjust: -1
      * e++= e, e++;◄ */
     _s.Pop();
     goto Branch1;
     }
  /*case 15:
  default: break; */
  }
  // Reduce8:
  /* sAdjust: -1
   * e++= e, e++;◄ */
  _s.Pop();
  goto State18;

AcceptState17:
  i++;
  // State17:
  /* *Startsymbol= examples, ►l;
   * d+= d+, ►d; */
  if ((SomeLetters)InputLine[i] == SomeLetters.d)
     goto AcceptState17;
  if ((SomeLetters)InputLine[i] != SomeLetters.l)
     goto EndWithError;
  Debug.Assert((SomeLetters)InputLine[i] == SomeLetters.l);
  goto AcceptReduce1;

EndWithError:
  // This point is reached after an input error has been found
  _s.Discard(_s.Count - _StateStackInitialCount);
  DisplayRemainder(); return false;

EndOfGeneratedCode:
  ;

#endregion grammlator generated 12 Okt 2020 (grammlator file version/date 2020.10.10.0/11 Okt 2020)
         DisplayRemainder();
         return true;
      }
   }
}
