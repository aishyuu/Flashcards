using Flashcards;
using Spectre.Console;

DbUtilities.Initialize();

var decision = MenuUtilities.MainMenu();

switch(decision)
{
    case "Create New Stack":
        MenuUtilities.NewStackPrompts();
        break;

    case "Create New Flashcard":
        MenuUtilities.NewFlashcardPrompts();
        break;

    case "Start Study Session":
        MenuUtilities.StudySession();
        break;
}