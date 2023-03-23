## 4. Basic Grammlator Settings

A grammar describes how to form sequences of terminal symbols according to a syntax but not how to generate code.
Settings can be used to define or modify how code is generated by grammlator. A typical application will change only few of the settings. 

The grammlator settings are:

#### `InputExpression: "PeekSymbol()";`
This expression (a peek function call, a variable name,...) will be used in the generated comparisons.
If it is a variable name a value has to be assigned by the `InputAssignInstruction` or by the `InputAcceptInstruction`.
Note: Grammlator does not generate code which declares this variable or this function.
This has to be done by the application programmer in the context.
Examples: `"Symbol"` or `"MyReader.Peek()"` or `"(MyEnum)line[i]"`
      Somewhere in the context there must be a declaration
       `"MyEnum Symbol"` or `"MyEnum MyReader.Peek(){....}"` or ...

#### `InputAssignInstruction: "";`
This instruction is inserted in the generated code to assign the value of the next
input symbol to a variable (see `PeekSymbol`) just before this variable is used.
Examples: `""`  (if `InputExpression` is a method call)
              or `"Symbol = MyReader.Peek();"` (if InputExpression is "Symbol") */

#### `InputAcceptInstruction: "AcceptSymbol();";`
This instruction will be inserted in the generated code at all places where a
terminal symbol (the value of `InputExpression` ) has to be accepted (the first step of a "shift operation").
Example: `"AcceptSymbol();"`  or `"_ = MyReader.Read();"`
         The referenced method(s) have to be declared somewhere in the context. 
If the generated code is allowed to look ahead prematurely then this instruction can be used additionally to assign the next input symbol to a variable referenced in `InputExpression`.

#### `TerminalSymbolEnum: "￿";`

Initially `TerminalSymbolEnum` is set to undefined and if an enum is used to declare the terminal symbols then grammlator will replace it with the name of the enum.
This name will be combined in the generated code with the names of the terminal symbols using the dot syntax `MyEnum.member`.
`TerminalSymbolEnum : ""` assigns the empty string so that the name of an (optional) enum is not used in code generation.
Typical usage: `"OtherClass.MyEnum"` if the enum defining the terminal symbols is defined in another class and a copy with a modified name is used to define the terminal symbols.

#### `NameOfErrorHandlerMethod: "";`
If a `NameOfErrorHandlerMethod` is given then grammlator will generate code that calls this method if an input error is detected. The calls of the error handler are generated as part of states, in which the errors are detected.
Examples: `""` or `"ErrorHandler"`
   The referenced mehtod has to be declared somewhere in the context e. g.
   `Boolean ErrorHandler(Int32 stateNumber, String stateDescription, MyEnum symbol)`

#### `ErrorHaltInstruction: "";`
This optional instruction will be inserted in the generated code so that it is executed
when the generated parser detects an error in its input data just before the `goto` to the end of the generated code.
It is executed after the optional `NameOfErrorHandlerMethod` has been called
 and returned false (or if there is no `NameOfErrorHandlerMethod` defined)
just before the jump to the end of generated code.
Examples: `""` or `"return false;"`

#### `TerminalDefaultWeight: 20;`
The  weight assigned to terminal symbol with no explicitly given weight. Terminals with a high weight
tend to be checked earlier in generated conditions.

#### `GenerateSmallStateStackNumbers: true;`
If this option is set to false, states push their own number (minus one) on the stack. This improves
readability of the generated code but may cause less performing switch statements.
It may affect other optimizations performed by grammlator.

#### `NestingLevelLimit: 5;`
This limits the nesting in the generated code.
If this limit is exceeded a goto is generated instead of inlining code.
A typical value is "5".

#### `LineLengthLimit: 120;`
This limits the length of lines in the generated code.
If this limit is exceeded a line break will be inserted at the next convenient place in the generated code.
A typical value is "120".

#### `GenerateSwitchStartingLevel: 5;`
A sequence of conditional actions is generated as a sequence of if statements, 
if its complexity (estimated number of logical operations) is less or equal
than this number (typically 5), else a switch statement will be generated.

#### `GenerateFlagTestStartingLevel: 3;`
If the span of  the values of the terminal symbols is less or equal 63 or if the values of the terminal symbols are suited to be used as flags then the comparisons of the input symbol with terminal symbols in if statements can be generated as a test of flags instead of a sequence of < or > or == comparisons together with && and || operations.
If the estimated complexity of the sequence of comparisons is greater than the `GenerateFlagTestStartingLevel` (and if the `NameOfFlagTestMethod` is defined then a test of flags will be generated.
A typical value is `3`.

#### `NameOfFlagTestMethod: "_is";`
The name of the boolean method which implements the flag test. Grammlator will generate this local method and flag constants representing terminal symbols if this name is defined and flags will be used in comparisons.

#### `PrefixOfFlagConstants: "_f";`
This string is used as prefix to the names of terminals to declare flag constants.
The initial value "_f" will avoid conflicts with other names.

#### `NameOfAssertMethod: "Debug.Assert";`
If defined then "Debug.Assert(...)" instructions will be generated.
These assertions are less intended to debug the code but primarily to comment the code.

#### `GenerateComments: true;`
If true then comments are generated to help to understand the generated code.

#### `PrefixOfStateDescriptionConstant: "";`
For each generated state, for which a call of `NameOfErrorHandlerMethod` is generated, grammlator combines this string and the number of the state to build the name of a constant with the description of the state.
This constant is used as argument of the generated error handler.
If the prefix is the empty string, then no constant is generated and the empty string is used as argument in the call of the error handler.
If no such constant is generated for a state and if `GenerateComments` is true the description of the state is generated as a comment.

#### `PriorityDynamicSwitchPart1: "switch(Methods.IndexOfMaximum(";`
Grammlator may generate special switch instructions if the grammar uses dynamic priorities. This switch instructions use a method which accepts integer arguments and returns the index of the largest value. 
A typical value is `"switch(Methods.IndexOfMaximum("`  whereby `Methods.IndexOfMaximum` is the name of a method in `grammlatorRuntime.cs`.

#### `PriorityDynamicSwitchEndOfMatchExpression: "))";`
A typical value is `"))"`.

#### `PriorityDynamicSwitchCaseLabelFormat: "case {0}: ";`
This format is used to generate the case labels.
A typical value is "case {0}: "

#### ` `StateStack: "_s";
This name is used in the generated code as the name of the state stack.
A typical value is `"_s"`, which is defined in g`rammlatorRuntime.cs`.

#### `AttributeStack: "_a";`
This name is used in the generated code as the name of the attribute stack.
A typical value is `"_a"`, which is defined in `grammlatorRuntime.cs`.

#### `AttributesOfSymbolStack: "_AttributesOfSymbol";`
This name is used in the generated code as the name of a small attribute stack, which stores the attributes of the last recognized symbol while reductions may modify the stack.
A typical value is "_a", which is defined in `grammlatorRuntime.cs`.

#### `AttributesCopyAndRemoveInstructionFormat: "{0}.CopyAndRemoveFrom({1}, {2});";`
This instruction is used to move n attribute values from one attribute stack to another. This format is used with 3 arguments:
(0) the destination stack, (1) the source stack, (2) the number of arguments.

#### `AttributeStackNameOfInitialCountVariable: "_AttributeStackInitialCount";`
This  variable is declared and used in the generated code to store the initial size of the attribute stack (if an attribute stack is used in the generated code.
A typical value is `"_AttributeStackInitialCount"`.