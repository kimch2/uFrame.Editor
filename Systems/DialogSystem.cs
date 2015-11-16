using Invert.Core;
using Invert.Core.GraphDesigner;
using Invert.IOC;
using UnityEditor;

public class DialogSystem : DiagramPlugin
    ,IExecuteCommand<ShowSaveFileDialog>
    ,IExecuteCommand<ShowOpenFileDialog>
    ,IExecuteCommand<ShowOpenFolderDialog>
    ,IExecuteCommand<ShowSaveFolderDialog>
{
    public override void Initialize(UFrameContainer container)
    {
        base.Initialize(container);
    }

    public void Execute(ShowSaveFileDialog command)
    {
        command.Result = EditorUtility.SaveFilePanelInProject(command.Title, command.DefaultName, command.Extension,
            command.Message);
    }

    public void Execute(ShowOpenFileDialog command)
    {
        command.Result = EditorUtility.OpenFilePanelWithFilters(command.Title, command.Directory, command.Filters);
    }

    public void Execute(ShowOpenFolderDialog command)
    {
        command.Result = EditorUtility.OpenFolderPanel(command.Title, command.Folder, command.DefaultName);
    }

    public void Execute(ShowSaveFolderDialog command)
    {
        command.Result = EditorUtility.SaveFolderPanel(command.Title, command.Folder, command.DefaultName);
    }
}

public class ShowSaveFileDialog : Command {
    public string Result { get; set; }
    public string DefaultName { get; set; }
    public string Extension { get; set; }
    public string Message { get; set; }
}
public class ShowOpenFileDialog : Command {
    public string Directory { get; set; }
    public string[] Filters { get; set; }
    public string Result { get; set; }
}
public class ShowOpenFolderDialog : Command {
    public string Result { get; set; }
    public string Folder { get; set; }
    public string DefaultName { get; set; }
}
public class ShowSaveFolderDialog : Command {
    public string Result { get; set; }
    public string Folder { get; set; }
    public string DefaultName { get; set; }
}