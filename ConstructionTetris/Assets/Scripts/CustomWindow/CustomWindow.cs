using UnityEditor;
using UnityEngine;
using System.IO;

public class CustomWindow : EditorWindow
{
    // Found help from https://rumorgames.com/fast-scene-switching-in-the-unity-editor/
    // Also helpful tutorial was https://www.youtube.com/watch?v=491TSNwXTIg

    // Add menu item named "Custom Window" to the Window menu
    [MenuItem("Window/Custom Window")]
    public static void ShowWindow()
    {
        //Show existing window instance. If one doesn't exist, make one.
        EditorWindow.GetWindow(typeof(CustomWindow));
    }

    void OnGUI()
    {
        GUILayout.Label("Scenes", EditorStyles.boldLabel);

        for (var i = 0; i < EditorBuildSettings.scenes.Length; i++)
        {
            var scene = EditorBuildSettings.scenes[i];
            if (scene.enabled)
            {
                var sceneName = Path.GetFileNameWithoutExtension(scene.path);
                var pressed = GUILayout.Button(i + ": " + sceneName, new GUIStyle(GUI.skin.GetStyle("Button")) { alignment = TextAnchor.MiddleLeft });
                if (pressed)
                {
                    if (EditorApplication.SaveCurrentSceneIfUserWantsTo())
                    {
                        EditorApplication.OpenScene(scene.path);
                    }
                }
            }
        }

        //EditorGUILayout.EndScrollView();
        //EditorGUILayout.EndVertical();

    }
}