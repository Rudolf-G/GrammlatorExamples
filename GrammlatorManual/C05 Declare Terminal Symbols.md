## 5. How to declare the terminal symbols

After assignments to its settings grammlator expects the declaration of all terminal symbols. The declaration of the terminals symbol can be

- a list of the names of the terminal symbol, separated by vertical bars and ending with a semicolon, e. g.

  `identifier | number | comment`  

  A number can be assigned  as value of the terminal symbol, e. g. '`LetterA= 65, LetterB'`  . If no number is assigned then grammlator assigns 0 to the 1st terminal symbol and the value of the preceding terminal symbol plus 1 to all other terminal symbols with no explicit assignment.

- a restricted form of a C# enum declaration with a list of names of enum members (with optional assignments of numbers as values)

- (or a redundant combination of both).

*The optional declaration of semantic attributes and of weights of terminal symbols will be addressed  later*.

The name of a terminal symbol can be

- an identifier, starting with a letter (or underscore or point) followed by letters (or underscores or points)  and digits e. g. `number`or  `xyz.Number`,
- a simple form of a character literal: a character enclosed in  Apostrophes e.g. `'a'`,
- a simple form of a string: an optional leading '@' followed by a sequence of characters enclosed in quotation marks e. g. `"abc"`.

Grammlator will insert the names of the terminal symbols in the generated code. It will not check whether the names a legal C# names. If the programmer uses names which are not legal C# names of constants then the C# compiler will report errors when compiling the generated code.

Grammlator will generate code which compares the input symbol with terminal symbols. It uses not only equality comparisons but it may also generate code which checks if the input symbol is less or greater than a terminal symbol. Therefore

- the terminal values must be comparable,
- each terminal symbol must have a different value.

It is not comfortable, to use names like `MyEnum.MyEnumElement`as names of terminals symbols. Instead in the settings part (before the terminal symbols are declared) the setting

​	`TerminalSymbolEnum: "MyEnum";`

may be used. If this value is defined grammlator will prefix each name of a terminal symbol in the generated code by this string and a point e.g. `MyEnum.xy`.

