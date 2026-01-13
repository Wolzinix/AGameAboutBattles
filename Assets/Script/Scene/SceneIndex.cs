using System.Collections.Generic;

public static class SceneIndex
{
    static readonly Dictionary<int, string> DicoOfScene = new()
    {
        { 0,"Menu" },
        { 1,"FonctionScene" }

    };
    public static string GetSceneWithIndex(int numOfScene) { return DicoOfScene[numOfScene]; }
}