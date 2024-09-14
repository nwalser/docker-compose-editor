using Microsoft.AspNetCore.Components;
using Sapphire.App.Components.Pages.File;

namespace Sapphire.App.Components.Components;

public class ComEditorRefresh : ComponentBase
{
    [Inject] public required EditorState State { get; init; }

    protected override void OnAfterRender(bool firstRender)
    {
        if (firstRender)
        {
            State.StateChanged.Subscribe((e) =>
            {
                InvokeAsync(StateHasChanged);
            });
        }
        
        base.OnAfterRender(firstRender);
    }
}