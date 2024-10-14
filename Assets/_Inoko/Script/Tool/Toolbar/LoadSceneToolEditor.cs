using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace InnoStudio
{
    [InitializeOnLoad]
    public static class LoadSceneToolEditor
    {
        static class ToolbarStyles
        {
            public static readonly GUIStyle commandButtonStyle;

            static ToolbarStyles()
            {
                commandButtonStyle = new GUIStyle("Command")
                {
                    fontSize = 10,
                    alignment = TextAnchor.MiddleCenter,
                    imagePosition = ImagePosition.ImageAbove,
                    fontStyle = FontStyle.Normal,
                    fixedWidth = 70,
                };
            }
        }

        static LoadSceneToolEditor()
        {
            ToolbarExtender.LeftToolbarGUI.Add(OnToolbarGUI);
        }

        static void OnToolbarGUI()
        {
            GUILayout.FlexibleSpace();
            if (GUILayout.Button(new GUIContent("Splash", "Start Loading Scene"), ToolbarStyles.commandButtonStyle))
            {
                SceneHelper.StartScene("Splash");
            }
            if (GUILayout.Button(new GUIContent("Master Level", "Start Loading Scene"), ToolbarStyles.commandButtonStyle))
            {
                SceneHelper.StartScene("MasterLevel");
            }

            if (GUILayout.Button(new GUIContent("Main Game", "Start Loading Scene"), ToolbarStyles.commandButtonStyle))
            {
                SceneHelper.StartScene("MainGame");
            }

        }

        static class SceneHelper
        {
            static string sceneToOpen;

            public static void StartScene(string sceneName)
            {
                if (EditorApplication.isPlaying)
                {
                    EditorApplication.isPlaying = false;
                }

                sceneToOpen = sceneName;
                EditorApplication.update += OnUpdate;
            }

            static void OnUpdate()
            {
                if (sceneToOpen == null ||
                    EditorApplication.isPlaying || EditorApplication.isPaused ||
                    EditorApplication.isCompiling || EditorApplication.isPlayingOrWillChangePlaymode)
                {
                    return;
                }

                EditorApplication.update -= OnUpdate;

                if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
                {
                    // need to get scene via search because the path to the scene
                    // file contains the package version so it'll change over time
                    string[] guids = AssetDatabase.FindAssets("t:scene " + sceneToOpen, null);
                    if (guids.Length == 0)
                    {
                        Debug.LogWarning("Couldn't find scene file");
                    }
                    else
                    {
                        string scenePath = AssetDatabase.GUIDToAssetPath(guids[0]);
                        EditorSceneManager.OpenScene(scenePath);
                        //EditorApplication.isPlaying = true;
                    }
                }
                sceneToOpen = null;
            }
        }
    }
}
