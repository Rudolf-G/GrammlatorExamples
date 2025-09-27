using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

using GrammlatorRuntime;

namespace GrammlatorDocumentation.code
{
   static class OptionAndRepeatVariantsExample {

      #region grammar
      //| TerminalSymbolEnum: "SomeLetters";
      //| InputExpression: "(SomeLetters)InputLine[i]";
      //| InputAcceptInstruction: "i++;";
      //| ErrorHaltInstruction: "DisplayRemainder(); return false;";
      //|
      enum SomeLetters {
         precedingCharacters = 96,
         a, b, c, d, e, f, g, h, i, j, k, l, m, n, o ,p, q, r, s, t,
         successiveCharacters }
      //|
      //| *= examples t; 
      //|    // concatenation without "," (grammlator: not allowed in combination with subsequent "(")
      //| examples=    // definition of nonterminal symbol "=" (EBNF)
      //|              /* comment */  // comment
      //|              //  alternation "|" (EBNF) , 
      //|     (a, b)   // concatenation "," (EBNF)
      //|              // grouping "(..)" (EBNF), grammlator local grouping:
      //|              //   (a, b) is equivalent to ...(local1)...; (local1)=a, b;
      //|              //   the special name "(local1)" can not be used explicitely
      //|   | (test=b) // grouping with rule, grammlator global grouping:
      //|              //   equivalent to ...test...; test=b;
      //|   | [c]      // optional  (EBNF), grammlator local optional:
      //|              //   [c] is equivalent to ...(Local2)?...; (Local2)= c;
      //|   | d?,   m  // optional, grammlator global optional
      //|              //   grammlator defines d? by d?= | d; if not yet defined,. d? can be used explicitely
      //|   | {e},  n  // repetition (EBNF), grammlator local repetition:
      //|              //   {e} is eqivalent to ...(local3)*...; (Local3)=e;
      //|   | f*,   o  // repetition, grammlator global left recursive repetition
      //|              //   grammlator adds f*= | f*, f; if not yet defined (here f* is a name and not an expression)
      //|   | g**,  p  // grammlator: global right recursive repetition
      //|              //   grammlator adds g**= | g, g**; if not yet defined 
      //|   | h+       // one or more times, grammlator: left recursive
      //|              //   grammlator adds h+= | h+, h; if not yet defined 
      //|   | i++      // grammlator: global right recursive one or more times
      //|              //   grammlator adds i++= | i++, i; if not yet defined 
      //|
      //| // combining local grouping with repetitions makes repetitions local:    
      //|   | (j)*, q  // repetition, grammlator: local grouping with left recursive repetition
      //|              //   (g)* is equivalent to  ...(local4)*...; (local4)=g; (local4)*= |(local4)*, (local4);
      //|   | (k)**, r // grammlator: local right recursive repetition
      //|
      //| // combining global grouping with repetitions declares global repetitions: 
      //|   | (test2=l)+ //  ...(test2=l)+.. is eqivalent to ...test2+...; test2=l;
      //|                //   grammlator adds test2+= test2, | test2+, test2; if not yet defined 
      //|  //    ??+5??   // priority specification at the end of a definition (grammlator)
      //|     ;        // terminator symbol (EBNF, optional in grammltor)
      //|
      #endregion grammar

      public static bool AnalyzeInput(string line)
      {
         string InputLine = line + '*';
         int i = 0;

         void DisplayRemainder()
            => Console.WriteLine($@" Remainder of line: ""{InputLine[i..]}""");

         var _s = new Stack<int>();

#region grammlator generated 27 Sep 2025 (grammlator file version/date 2022.11.10.0/27 Sep 2025)
  Int32 _StateStackInitialCount = _s.Count;

  // State1:
  /* *Startsymbol= ►examples, t; */
  _s.Push(0);
  switch ((SomeLetters)InputLine[i])
  {
  // <= SomeLetters.precedingCharacters
  // >= SomeLetters.successiveCharacters: goto EndWithError; // see end of switch
  case SomeLetters.s:
     goto EndWithError;
  case SomeLetters.a:
     {
     i++;
     // State15:
     /* (Local1)= a, ►b; */
     if ((SomeLetters)InputLine[i] != SomeLetters.b)
        goto EndWithError;
     Debug.Assert((SomeLetters)InputLine[i] == SomeLetters.b);
     goto AcceptState14;
     }
  case SomeLetters.b:
  case SomeLetters.c:
     goto AcceptState14;
  case SomeLetters.d:
     {
     i++;
     goto State13;
     }
  case SomeLetters.e:
  case SomeLetters.n:
     goto State6;
  case SomeLetters.f:
  case SomeLetters.o:
     goto State5;
  case SomeLetters.g:
     goto AcceptState12;
  case SomeLetters.h:
     goto AcceptState11;
  case SomeLetters.i:
     {
     i++;
     // State9:
     /* *Startsymbol= examples, ►t;
      * i++= i, ►i++; */
     // *Push(1)
     if ((SomeLetters)InputLine[i] == SomeLetters.i)
        {
        i++;
        // PushState1:
        _s.Push(1);
        goto State10;
        }
     if ((SomeLetters)InputLine[i] != SomeLetters.t)
        goto EndWithError;
     Debug.Assert((SomeLetters)InputLine[i] == SomeLetters.t);
     i++;
     // Reduce3:
     /* *Startsymbol= examples, t;◄ */
     goto ApplyStartsymbolDefinition1;
     }
  case SomeLetters.j:
  case SomeLetters.q:
     goto State3;
  case SomeLetters.k:
     goto AcceptState8;
  case SomeLetters.l:
     goto AcceptState7;
  case SomeLetters.m:
     goto State13;
  case SomeLetters.p:
     goto State4;
  case SomeLetters.r:
     goto State2;
  case SomeLetters.t:
     goto State14;
  } // end of switch
  Debug.Assert((SomeLetters)InputLine[i] <= SomeLetters.precedingCharacters || (SomeLetters)InputLine[i] >= SomeLetters.successiveCharacters);

  goto EndWithError;

AcceptReduce1:
  i++;
  // Reduce1:
  /* *Startsymbol= examples, t;◄ */
ApplyStartsymbolDefinition1:
  // Halt: a definition of the startsymbol with 0 attributes has been recognized.
  _s.Remove(1);
  goto EndOfGeneratedCode;

State2:
  /* examples= (Local5)**, ►r; */
  Debug.Assert((SomeLetters)InputLine[i] == SomeLetters.r);
AcceptState14:
  i++;
State14:
  /* *Startsymbol= examples, ►t; */
  if ((SomeLetters)InputLine[i] != SomeLetters.t)
     goto EndWithError;
  Debug.Assert((SomeLetters)InputLine[i] == SomeLetters.t);
  goto AcceptReduce1;

State3:
  /* examples= (Local4)*, ►q;
   * (Local4)*= (Local4)*, ►(Local4); */
  if ((SomeLetters)InputLine[i] == SomeLetters.j)
     {
     i++;
     goto State3;
     }
  if ((SomeLetters)InputLine[i] != SomeLetters.q)
     goto EndWithError;
  Debug.Assert((SomeLetters)InputLine[i] == SomeLetters.q);
  goto AcceptState14;

State4:
  /* examples= g**, ►p; */
  Debug.Assert((SomeLetters)InputLine[i] == SomeLetters.p);
  goto AcceptState14;

State5:
  /* examples= f*, ►o;
   * f*= f*, ►f; */
  if ((SomeLetters)InputLine[i] == SomeLetters.f)
     {
     i++;
     goto State5;
     }
  if ((SomeLetters)InputLine[i] != SomeLetters.o)
     goto EndWithError;
  Debug.Assert((SomeLetters)InputLine[i] == SomeLetters.o);
  goto AcceptState14;

State6:
  /* examples= (Local3)*, ►n;
   * (Local3)*= (Local3)*, ►(Local3); */
  if ((SomeLetters)InputLine[i] == SomeLetters.e)
     {
     i++;
     goto State6;
     }
  if ((SomeLetters)InputLine[i] != SomeLetters.n)
     goto EndWithError;
  Debug.Assert((SomeLetters)InputLine[i] == SomeLetters.n);
  goto AcceptState14;

AcceptState7:
  i++;
  // State7:
  /* *Startsymbol= examples, ►t;
   * test2+= test2+, ►test2; */
  if ((SomeLetters)InputLine[i] == SomeLetters.l)
     goto AcceptState7;
  if ((SomeLetters)InputLine[i] != SomeLetters.t)
     goto EndWithError;
  Debug.Assert((SomeLetters)InputLine[i] == SomeLetters.t);
  goto AcceptReduce1;

AcceptState8:
  i++;
  // State8:
  /* (Local5)**= (Local5), ►(Local5)**; */
  _s.Push(1);
  if ((SomeLetters)InputLine[i] == SomeLetters.k)
     goto AcceptState8;
  if ((SomeLetters)InputLine[i] != SomeLetters.r)
     goto EndWithError;
  Debug.Assert((SomeLetters)InputLine[i] == SomeLetters.r);
Reduce2:
  /* sAdjust: -1
   * (Local5)**= (Local5), (Local5)**;◄ */
  _s.Remove(1);
  // Branch1:
  if (_s.Peek() == 0)
     goto State2;
  goto Reduce2;

State10:
  /* i++= i, ►i++;
   * i++= i, i++●; */
  _s.Push(2);
  if ((SomeLetters)InputLine[i] == SomeLetters.t)
     // Reduce5:
     {
     /* sAdjust: -2
      * i++= i, i++;◄ */
     _s.Remove(2);
     goto Branch2;
     }
  if ((SomeLetters)InputLine[i] != SomeLetters.i)
     goto EndWithError;
  Debug.Assert((SomeLetters)InputLine[i] == SomeLetters.i);
  i++;
  goto State10;

AcceptState11:
  i++;
  // State11:
  /* *Startsymbol= examples, ►t;
   * h+= h+, ►h; */
  if ((SomeLetters)InputLine[i] == SomeLetters.h)
     goto AcceptState11;
  if ((SomeLetters)InputLine[i] != SomeLetters.t)
     goto EndWithError;
  Debug.Assert((SomeLetters)InputLine[i] == SomeLetters.t);
  goto AcceptReduce1;

AcceptState12:
  i++;
  // State12:
  /* g**= g, ►g**; */
  _s.Push(1);
  if ((SomeLetters)InputLine[i] == SomeLetters.g)
     goto AcceptState12;
  if ((SomeLetters)InputLine[i] != SomeLetters.p)
     goto EndWithError;
  Debug.Assert((SomeLetters)InputLine[i] == SomeLetters.p);
Reduce7:
  /* sAdjust: -1
   * g**= g, g**;◄ */
  _s.Remove(1);
  // Branch3:
  if (_s.Peek() == 0)
     goto State4;
  goto Reduce7;

State13:
  /* examples= d?, ►m; */
  if ((SomeLetters)InputLine[i] != SomeLetters.m)
     goto EndWithError;
  Debug.Assert((SomeLetters)InputLine[i] == SomeLetters.m);
  goto AcceptState14;

Branch2:
  switch (_s.Peek())
  {
  case 0:
     goto State14;
  case 2:
     // Reduce6:
     {
     /* sAdjust: -1
      * i++= i, i++;◄ */
     _s.Remove(1);
     goto Branch2;
     }
  /*case 1:
  default: break; */
  }
  // Reduce4:
  /* sAdjust: -1
   * i++= i, i++;◄ */
  _s.Remove(1);
  goto State14;

EndWithError:
  // This point is reached after an input error has been found
  _s.Remove(_s.Count - _StateStackInitialCount);
  DisplayRemainder(); return false;
EndOfGeneratedCode:
  ;

#endregion grammlator generated 27 Sep 2025 (grammlator file version/date 2022.11.10.0/27 Sep 2025)
         DisplayRemainder();
         return true;
      }
   }
}
