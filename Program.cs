using System;
using System.IO;

namespace GrammlatorExamples {
   class Program {
      private struct ExampleDescriptionAndMethod {
         public String Description;

         public Func<Boolean> DoIt;

         public ExampleDescriptionAndMethod(String description, Func<Boolean> doIt)
            {
            Description = description;
            DoIt = doIt;
            }
         }

      static void Main(string[] args)
         {
         ExampleDescriptionAndMethod[] Examples = new ExampleDescriptionAndMethod[]
{
            new ExampleDescriptionAndMethod("Example which defines an empty startsymbol *= ",
               RegionsAndMinimalGrammarExample.RunExample ),
            new ExampleDescriptionAndMethod(
               "Example with two terminal symbols *= a, b | b, a ;",
               TerminalSymbols2ndExample.AnalyzeInput ),
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
               (new RevertExample()).AnalyzeInput),
            new ExampleDescriptionAndMethod(
               "Example with C# methods and attributes, displaying the input in reverse order.",
               (new RevertExampleUsingAttributes()).AnalyzeInput),
            new ExampleDescriptionAndMethod(
               "Example with conflicts and priorities.",
               (new ConflictsAndPrioritiesExample()).AnalyzeInput)
};

         String Line;
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
                  if (Examples[number - 1].DoIt())
                     Console.WriteLine("Example returned true.");
                  else
                     Console.WriteLine("Example returned false.");
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
