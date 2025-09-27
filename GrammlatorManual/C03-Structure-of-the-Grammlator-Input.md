#3. Structure of the Grammlator Input (C# Source File)

## 3.1 The "Hello Example"

It is common practice to start with a hello example. To get the example running it is recommended to create a .NET core console application using your usual C# programming environment e. g. Visual Studio, paste the code of the hello example into  the program file, store it, use grammlator to add the control structure and continue in your programming environment.

Because the purpose of grammlator is to support the analysis of streams of elements, this example will not print "hello" but ask the user to input "hello" and then read and check the input and write an (old style)  smiley.

```c#
using System; // .NET Core 3.1 Console Application
using System.Diagnostics;

namespace GrammlatorConsoleExample { // .NET Core 3.1 Console Application
   class Program {
      static void Main()
      {
         Console.WriteLine(@"Please type ""hello"" and then hit the enter key");
         WriteAnswer(Console.ReadLine());
      }
      public static void WriteAnswer(string line)
      {
         // Declare the constants to be used as terminal symbols:
         const char EndOfLine = (char)('a' - 1); // == (char)100
         const char Other = (char)('o' + 1);

         int Column = 0;
         char PeekTerminalSymbol()
            => Column >= line.Length
            ? EndOfLine
            : line[Column] >= 'a' && line[Column] <= 'o'
              ? line[Column]
              : Other;

         #region grammar
         //| /* grammlator settings: */
         //| InputExpression: "PeekTerminalSymbol()";
         //| InputAcceptInstruction: "Column++;";
         //| ErrorHaltInstruction: "Console.WriteLine("":-("");";
         //| GenerateComments: false; // recommended: true;
         //| NameOfAssertMethod: ""; // recommended: "Debug.Assert";
         //|
         //| /* Declaration of the complete set of terminal symbols 
         //|    by a sorted list of char literals and char constants: */
         //|
         //| EndOfLine = 96 | 'a' | 'b' | 'c' | 'd' | 'e' | 'f' | 'g' | 'h' 
         //|   | 'i' | 'j' | 'k' | 'l' | 'm' | 'n' | 'o' | Other;
         //|
         //| /* The 1st grammar rule defines the startsymbol "*" ,
         //|    in this example by a sequence of terminal symbols */  
         //| *= 'h' 'e' 'l' 'l' 'o' EndOfLine 
         void HelloSuccess() => Console.WriteLine(":-)");
         //|   
         #endregion grammar
             
         #region grammlator generated
         // This region will be replaced by grammlator
         #endregion grammlator generated 31 Okt 2020 (grammlator file version/date 2020.10.30.0/31 Okt 2020)

         Console.WriteLine("bye");
         return;
      }
   }   
}
```

The method *WriteAnswer(string line)* is written using a simple grammar rule. 

In this example the requisites, which are required by the generated code are defined first. They are in the scope of the generated code.

- The terminal symbols are implemented as characters. Two char constants *EndOfLine* and *Other* are declared explicitly. They will be used as terminal symbols. All other terminal symbols are C# char literals (see below).
- A variable *Column* is declared, which will be used in *PeekTerminalSymbol()*  and which will be incremented by "Column++;", the "InputAcceptInstruction" which is inserted by grammlator in the generated code.
  Note: LR parsing does never require any backtrack, hence grammlator does not need an instruction which decrements  this examples variable "Column". 
- A local char function *PeekTerminalSymbol()* is declared, which will be used as *InputExpression* to get the next terminal symbol.

Then follows the "#region grammar".

- In general all lines in this region are special C# comment lines prefaced with "//|". Only at well defined locations C# code may be inserted. Grammlator accepts comments alike C# comments.

- At the beginning of the grammar region a small number of grammlator settings are defined.

- Then a list of  names defines the terminal symbols. The '|' character is used as separator. The list is terminated by ';'. 

  Here the terminals symbols all look like character literals. This is possible because grammlator allows not only letters and digits but also some special characters to construct names. Grammlator uses the character sequence of each terminal identifier blindly without knowing anything about char types. This is the reason why the value of the 1st terminal symbol is declared (even though the values of the terminal symbols are not used by grammlator in this simple example). The other terminal symbols get their values assigned implicitly alike members of an enum type.

- This example needs only one nonterminal symbol, the start symbol, which is defined using "*=" and a sequence of terminals symbols. In general the elements of a sequence of symbols are separated by ','. This separator may be omitted in most cases.

- At the end of this definition ("alternative") a C# method is declared as a semantic method. This method will to be executed ever when the generated code recognizes the definition (can apply the definition to the input). Grammlator recognizes the type of the return value which must be *void*, the method name and the method parameters (which implement semantic attributes). It ignores the remaining characters and lines up to the next "//|" line.

- In general the declaration of a nonterminal is terminated by ';'. This may be omitted after C# lines (as is the case in this example). 

- Next in this example is the *region grammlator generated* which will be replaced by grammlator with C# instructions which analyze the text.

- Following this grammlator generated region the program continues with an instruction which shall be executed after the input has been analyzed.

To complete the example here is the code which grammlator inserts:

```c#
#region grammlator generated 31 Okt 2020 (grammlator file version/date 2020.10.30.0/31 Okt 2020)
  if (PeekTerminalSymbol() != 'h')
     goto EndWithError;
  Column++;
  if (PeekTerminalSymbol() != 'e')
     goto EndWithError;
  Column++;
  if (PeekTerminalSymbol() != 'l')
     goto EndWithError;
  Column++;
  if (PeekTerminalSymbol() != 'l')
     goto EndWithError;
  Column++;
  if (PeekTerminalSymbol() != 'o')
     goto EndWithError;
  Column++;
  if (PeekTerminalSymbol() != EndOfLine)
     goto EndWithError;
  Column++;

  HelloSuccess();

  goto EndOfGeneratedCode;

EndWithError:
  Console.WriteLine(":-(");

EndOfGeneratedCode:
  ;

#endregion grammlator generated 31 Okt 2020 (grammlator file version/date 2020.10.30.0/31 Okt 2020)
```

Don't worry if you expect a state stack. This will appear in more complex examples.

Grammlator generates goto labels that may conflict with labels used by the programmer in the scope of the generated code. The labels are listed in the appendix.

##3.2 The special C# regions of a grammlator source file

Grammlator expects two special C# region types in the input.

The lines from `#region grammar` up to `#endregion grammar` are interpreted by grammlator. These **"grammar region(s)"** must match the rules described in the following chapters. There may be more than one such region. This is shown in one of the the next examples. All lines outside this grammar regions are not interpreted by grammlator.

The lines from `#region grammlator generated` up to `#endregion grammlator generated` must come after the last grammar region. They are substituted by grammlator with the **generated code**. All other lines (including the grammar lines and all lines after  `#endregion grammlator generated`) are copied by grammlator from the input to the output.

Additional information appended to the region lines will be ignored by grammlator. Grammlator itself appends information about the date and the grammlator version to "#region grammlator generated" and ."#endregion grammlator generated"

## 3.3 The parts in the grammar region(s)

The **"grammar region(s)"** consists of three parts:

- The 1st part is optional. It may contain instructions to adjust **the grammlator settings**. Each of these instructions starts with the name of the respective setting, followed by a colon, followed by the value (integer, string or boolean) and terminated by a semicolon. The order of the settings is irrelevant. Each setting has a default value. All settings can be displayed by Help / Display settings ... .

- The 2nd (optional) part of the grammar contains **the definition of the terminal symbols** (if any). The minimal example in chapter 2.2.c demonstrates that grammlator will also accept a grammar without any terminal symbol. But thats not really useful.

- The 3rd part is the essential part. It contains **the declarations of the nonterminals symbols and the embedded C# methods**. At first the start symbol has to be defined. The order of the following declarations of nonterminal symbols is irrelevant. Only one declaration of a nonterminal symbol is allowed. It may consist of one or more alternative definitions. The 1st of these may be the empty sequence.

The segmentation into these three parts is independent of the splitting into one or more C# regions.


Links to all Chapters:

 ## 0. [Abstract](C00-Grammlator-Manual)
 ## 1. [Introduction](C01-Introduction.md)
 ## 2. [The Grammlator Application](C02-The-Grammlator-Application.md)
 ## 3. [Structure of the grammlator input (C# source file)](C03-Structure-of-the-grammlator-input.md) 
 ## 4. [Basic Grammlator settings](C04-Basic-Grammlator-Settings.md)
 ## 5. [Declare Terminal symbols](C05-Declare-Terminal-Symbols.md)

 To be added later:
 ## 6. Define the startsymbol and other nonterminal symbols
 ### ... sequence of symbols (definition, alternative), priority, method
 ### ... sequence of definitions, optional semicolon
 ## 7. Use Recursion
 ## 8. Semantic Attributes
 ### Types
 ### Stack 
 ### Assignment by overlay
 ### Usage and assignment by methods
 ## 9. Syntactic sugar: repeat operators
 ## 10. Solve Conflicts
 ## 11. Advanced
 ### 1st and last terminal symbol
 ### Compiler Settings

## 99.  [Appendix](C99-Appendix.md)

