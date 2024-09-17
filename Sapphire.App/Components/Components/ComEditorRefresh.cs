using System.Diagnostics;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Sapphire.Data.Validation;

namespace Sapphire.App.Components.Components;

public class ComEditorRefresh : ComponentBase
{
    [Inject] public required EditorState State { get; init; }
    [Inject] public required IDialogService Dialog { get; init; }

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

    protected async Task OpenIssueDialog(IEnumerable<Issue> issues)
    {
        var options = new DialogOptions { CloseOnEscapeKey = true };
        var parameter = new DialogParameters()
        {
            { "Issues", issues }
        };
        
        await Dialog.ShowAsync<ComIssuesDialog>("", parameter, options);
    }

    protected void OpenLink(string link)
    {
        Process.Start(new ProcessStartInfo(link) { UseShellExecute = true });
    }
}