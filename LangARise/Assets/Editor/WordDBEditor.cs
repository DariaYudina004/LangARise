using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(NewWordsItemsConfig))]
public class WordDBEditor : Editor
{
    private NewWordsItemsConfig config;

    private void Awake()
    {
        config = (NewWordsItemsConfig)target;
    }

    public override void OnInspectorGUI()
    {
        GUILayout.BeginHorizontal();

        if(GUILayout.Button("Remove All"))
        {
            config.ClearDatabase();
        }
        if (GUILayout.Button("Remove"))
        {
            config.RemoveElement();
        }
        if (GUILayout.Button("Add"))
        {
            config.AddElement();
        }
        if (GUILayout.Button("Prev"))
        {
            config.GetPrev();
        }
        if (GUILayout.Button("Next"))
        {
            config.GetNext();
        }

        GUILayout.EndHorizontal();
        base.OnInspectorGUI();
    }
  
}
