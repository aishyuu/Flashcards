using Spectre.Console;

namespace Flashcards
{
    internal class MenuUtilities
    {
        internal static string MainMenu()
        {
            string decision = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("Select your [green]action[/]!")
                .AddChoices(new[]
                {
                    "Create New Stack", "Create New Flashcard", "Start Study Session"
                }));

            return decision;
        }

        internal static void NewStackPrompts()
        {
            AnsiConsole.MarkupLineInterpolated($"[red]New Stack Chosen[/]");
        }

        internal static void NewFlashcardPrompts()
        {
            AnsiConsole.MarkupLineInterpolated($"[yellow]New Flashcard Chosen[/]");
        }

        internal static void StudySession()
        {
            AnsiConsole.MarkupLineInterpolated($"[blue]Study Session Chosen[/]");
        }
    }
}
