using System.Collections.Generic;

public static class SceneIndex
{
    static readonly Dictionary<int, string> DicoOfScene = new()
    {
        { 0,"MainMenu" },
        { 1,"Firstbattle" }

    };
    public static string GetSceneWithIndex(int numOfScene) { return DicoOfScene[numOfScene]; }
}