using System;
using System.IO;

namespace GrammlatorExamples {
   class Program {
      private struct ExampleDescriptionAndMethod {
         public string Description;

         public Func<string, bool> DoIt;

         public ExampleDescriptionAndMethod(String description, Func<string, bool> doIt)
         {
            Description = description;
            DoIt = doIt;
         }
      }

      static void Main()
      {
         ExampleDescriptionAndMethod[] Examples = new ExampleDescriptionAndMethod[]
            {
            new ExampleDescriptionAndMethod("Example which defines an empty startsymbol *= ",
               RegionsAndMinimalGrammarExample.RunExample ),
            new ExampleDescriptionAndMethod("Hello example which uses terminalsymbols *=h e l l o eol",
               TerminalSymbols1stExample.WriteAnswer ),
            new ExampleDescriptionAndMethod(
               "Example with two terminal symbols defined by enum *= a | b | c | d, c, b | d, b, c ;",
               TerminalSymbols2ndExample.AnalyzeInput ),
            new ExampleDescriptionAndMethod(
               "Example with two terminal symbols defined within grammlator *= a | b | c | d, c, b | d, b, c ;",
               TerminalSymbols3rdExample.AnalyzeInput ),
            new ExampleDescriptionAndMethod(
               "Example with a nonterminal symbol Variants = a, b | b, a ;",
               NonterminalSymbolsExample.AnalyzeInput ),
            new ExampleDescriptionAndMethod(
               "Example with which allows a | b | d | f by Letter_a_to_f-= c | e | CharactersPreceding_a | CharactersFollowing_f",
               AllExceptExample.AnalyzeInput ),
            new ExampleDescriptionAndMethod(
               "Example with left recursion *= Sequence_of_b,a; Sequence_of_b= /* empty  |  Sequence_of_b, b;",
               LeftRecursionExample.AnalyzeInput ),
            new ExampleDescriptionAndMethod(
               "Example with right recursion  Sequence_of_b_ending_with_a = a | b, Sequence_of_b_ending_with_a;",
               RightRecursionExample.AnalyzeInput ),
            new ExampleDescriptionAndMethod(
               "Example with C# methods as semantic actions, displaying the input in reverse order.",
               RevertExample.AnalyzeInput),
            new ExampleDescriptionAndMethod(
               "Example with C# methods and attributes, displaying the input in reverse order.",
               RevertExampleUsingAttributes.AnalyzeInput),
            new ExampleDescriptionAndMethod(
               "Example with conflicts and priorities.",
               (ConflictsAndPrioritiesExample.AnalyzeInput))
            };

         string Line;

         do
         {
            //  Display examples descriptions
            Console.WriteLine("Available examples:");
            for (int i = 0; i < Examples.Length; i++)
            {
               Console.WriteLine($"{i + 1}: {Examples[i].Description}");
            }

            // Read number of example
            Console.WriteLine("\r\nSelect an example by its number (empty input or \"0\" will end the program):");
            Line = Console.ReadLine();
            if (int.TryParse(Line, out int number) && number >= 0 && number - 1 < Examples.Length)
            {
               if (number == 0)
                  break;
               Console.WriteLine($"Starting: {Examples[number - 1].Description}");

               try
               {
                  if (Examples[number - 1].DoIt(Console.ReadLine()))
                     Console.WriteLine("Example returned true  :-)");
                  else
                     Console.WriteLine("Example returned false  :-(");
                  Console.WriteLine("Enter CR to continue");
                  Console.ReadLine();
               }
               catch (IOException e)
               {
                  Console.WriteLine(e.Message);
               }

               Console.WriteLine("------------");
            }
            else if (!string.IsNullOrEmpty(Line))
            {
               Console.WriteLine("Illegal number to select an example");
            }
         } while (!string.IsNullOrEmpty(Line));
      }
   }
}
