using System.Reactive.Subjects;
using System.Text.Json;
using Sapphire.Data.Internal;

namespace Sapphire.App.Components.Pages.File;

public class EditorState
{
    public readonly Subject<EditorState> StateChanged = new();

    public Stack<string> Performed { get; } = new(5);
    public Stack<string> Recalled { get; } = new(5); // todo: implement with dropout stacks

    public DockerStack Stack { get; set; } = MockData.Stack;


    public EditorState()
    {
        PushHistory();
    }
    

    public void Undo()
    {
        if (Performed.Count < 2)
            return;

        var performed = Performed.Pop();
        Recalled.Push(performed);
        Stack = JsonSerializer.Deserialize<DockerStack>(Performed.Peek()) ?? new DockerStack();
        
        StateChanged.OnNext(this);
    }

    public void Redo()
    {
        if (Recalled.Count == 0)
            return;

        var recalled = Recalled.Pop();
        Performed.Push(recalled);
        Stack = JsonSerializer.Deserialize<DockerStack>(recalled) ?? new DockerStack();
        
        StateChanged.OnNext(this);
    }

    public void PushHistory()
    {
        var serialized = JsonSerializer.Serialize(Stack);
        Performed.Push(serialized);
        Recalled.Clear();
        
        StateChanged.OnNext(this);
    }
}