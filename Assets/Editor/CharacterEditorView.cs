using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CharacterView))]
public class CharacterEditorView : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        CharacterView characterView = (CharacterView)target;

        if(GUILayout.Button("Change Animation"))
        {
            characterView.SetAnimation(characterView.DefaultParams);
        }
    }
}
