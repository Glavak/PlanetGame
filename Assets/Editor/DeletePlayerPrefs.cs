using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class DeletePlayerPrefs : EditorWindow
{
    [MenuItem("Game/Clear PlayerPrefs")]
    private static void Delete()
    {
        PlayerPrefs.DeleteAll();
    }
}
