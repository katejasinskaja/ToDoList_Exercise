
using System.Threading.Tasks;
using System.Xml.Linq;
var todos = new List<string>();
bool shallExit = false;
while (!shallExit)
{
    Console.WriteLine("What do you want to do?");
    Console.WriteLine("[S]ee all TODOs ");
    Console.WriteLine("[A]dd a TODO");
    Console.WriteLine("[R]emove a TODO");
    Console.WriteLine("[E]xit");
    var userChoice = Console.ReadLine();

    switch (userChoice)
    {
        case "E":
        case "e":
            shallExit = true;
            break;
        case "S":
        case "s":
            SeeToDo();
            break;
        case "A":
        case "a":           
            AddToDo();
            break;
        case "R":
        case "r":
            RemoveToDo();
            break;
        default:
            Console.WriteLine("Invalid choice");
            break;
    }
}

void SeeToDo()
{
    if (todos.Count == 0)
    {
        ShowNoToDosMessage();
        return;
    }  
    for (int i = 0; i < todos.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {todos[i]}");
    }
}

void AddToDo()
{

    string task;
    do
    {
        Console.WriteLine("Enter the TODO description:");
        task = Console.ReadLine();
    } while (!IsDescriptionValid(task));

    todos.Add(task);

}

bool IsDescriptionValid (string task)
{
    if (task == "")
    {
        Console.WriteLine("The description cannot be empty.");
        return false;

    }
    if (todos.Contains(task))
    {
        Console.WriteLine("The description must be unique.");
        return false;
    }
    return true;
}


void RemoveToDo()
{
    if (todos.Count == 0)
    {
        ShowNoToDosMessage();
        return;
    }
    int index;
    do
    {
        Console.WriteLine("Select the index of the TODO you want to remove:");
        SeeToDo();     
    } while (!TryReadIndex(out index));

    RemoveToDoAtIndex(index - 1);


}
void RemoveToDoAtIndex(int index)
{
    var toDoToBeRemoved = todos[index];
    todos.RemoveAt(index);
    Console.WriteLine("TODO removed: " + toDoToBeRemoved);
}
bool TryReadIndex(out int index)
{
    var userInput = Console.ReadLine();
    if (userInput == "")
    {
        index = 0;
        Console.WriteLine("Selected index cannot be empty.");
        return false;
    }
    if (int.TryParse(userInput, out index) && index >= 1 && index <= todos.Count)
    {
        return true;
    }
    Console.WriteLine("The given index is not valid");
    return false;
}

static void ShowNoToDosMessage()
{
    Console.WriteLine("No TODOS have been added yet");
}