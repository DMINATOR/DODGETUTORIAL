using Godot;
using System;

/// <summary>
///  Loads and saves game data, see: https://docs.godotengine.org/en/stable/tutorials/io/saving_games.html
/// </summary>
public class GlobalGameStateManager : Node
{
    public override void _Ready()
    {
        base._Ready();

        LoadGame();
    }

    public void SaveGame()
    {
        var saveGame = new File();
        saveGame.Open("user://savegame.save", File.ModeFlags.Write);

        saveGame.StoreLine(JSON.Print(GlobalGameState.PersistedData));

        saveGame.Close();
    }

    public void LoadGame()
    {
        var saveGame = new File();
        if (!saveGame.FileExists("user://savegame.save"))
        {
            // First load, nothing available
            return;
        }

        // We need to revert the game state so we're not cloning objects during loading.
        // This will vary wildly depending on the needs of a project, so take care with
        // this step.
        // For our example, we will accomplish this by deleting saveable objects.
        //var saveNodes = GetTree().GetNodesInGroup("Persist");
        //foreach (Node saveNode in saveNodes)
        //    saveNode.QueueFree();

        //// Load the file line by line and process that dictionary to restore the object
        //// it represents.
        //saveGame.Open("user://savegame.save", (int)File.ModeFlags.Read);

        //while (saveGame.GetPosition() < saveGame.GetLen())
        //{
        //    // Get the saved dictionary from the next line in the save file
        //    var nodeData = new Godot.Collections.Dictionary<string, object>((Godot.Collections.Dictionary)JSON.Parse(saveGame.GetLine()).Result);

        //    // Firstly, we need to create the object and add it to the tree and set its position.
        //    var newObjectScene = (PackedScene)ResourceLoader.Load(nodeData["Filename"].ToString());
        //    var newObject = (Node)newObjectScene.Instance();
        //    GetNode(nodeData["Parent"].ToString()).AddChild(newObject);
        //    newObject.Set("Position", new Vector2((float)nodeData["PosX"], (float)nodeData["PosY"]));

        //    // Now we set the remaining variables.
        //    foreach (KeyValuePair<string, object> entry in nodeData)
        //    {
        //        string key = entry.Key.ToString();
        //        if (key == "Filename" || key == "Parent" || key == "PosX" || key == "PosY")
        //            continue;
        //        newObject.Set(key, entry.Value);
        //    }
        //}

        saveGame.Close();
    }
}
