using System;
using System.IO;

namespace GrammlatorDocumentation.code
{
   class Program {
      private struct ExampleDescriptionAndMethod(string description, Func<string, bool> doIt)
      {
         public string Description = description;

         public Func<string, bool> DoIt = doIt;
      }

      static void Main()
      {
         ExampleDescriptionAndMethod[] Examples =
            [
            new("Example which defines an empty startsymbol *= ",
               RegionsAndMinimalGrammarExample.RunExample ),
            new("Hello example which uses terminalsymbols *=h e l l o eol",
               TerminalSymbols1stExample.WriteAnswer ),
            new(
               "Example with two terminal symbols defined by enum *= a | b | c | d, c, b | d, b, c ;",
               TerminalSymbols2ndExample.AnalyzeInput ),
            new(
               "Example with two terminal symbols defined within grammlator *= a | b | c | d, c, b | d, b, c ;",
               TerminalSymbols3rdExample.AnalyzeInput ),
            new(
               "Example with a nonterminal symbol Variants = a, b | b, a ;",
               NonterminalSymbolsExample.AnalyzeInput ),
            new(
               "Example with which allows a | b | d | f by Letter_a_to_f-= c | e | CharactersPreceding_a | CharactersFollowing_f",
               AllExceptExample.AnalyzeInput ),
            new(
               "Example with left recursion *= Sequence_of_b,a; Sequence_of_b= /* empty  |  Sequence_of_b, b;",
               LeftRecursionExample.AnalyzeInput ),
            new(
               "Example with right recursion  Sequence_of_b_ending_with_a = a | b, Sequence_of_b_ending_with_a;",
               RightRecursionExample.AnalyzeInput ),
            new(
               "Example with C# methods as semantic actions, displaying the input in reverse order.",
               RevertExample.AnalyzeInput),
            new(
               "Example with C# methods and attributes, displaying the input in reverse order.",
               RevertExampleUsingAttributes.AnalyzeInput),
            new(
               "Example with conflicts and priorities.",
               ConflictsAndPrioritiesExample.AnalyzeInput)
            ];

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
