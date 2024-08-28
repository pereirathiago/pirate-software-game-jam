using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "New Dialogue/Dialogue")]
public class DialogueSettings : ScriptableObject
{
    [Header("Settings")]
    public GameObject actor;

    [Header("Dialogue")]
    public string actorName;
    public Sprite speakerSprite;
    public string sentencePortuguese;
    public string sentenceEnglish;

    public List<Sentences> dialogues = new List<Sentences>();
}

[System.Serializable]
public class Sentences
{
    public string actorName;
    public Sprite profile;
    public Languages sentence;
}

#if UNITY_EDITOR
[CustomEditor(typeof(DialogueSettings))]
public class BuilderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        DialogueSettings ds = (DialogueSettings)target;

        Languages l = new Languages();
        l.portuguese = ds.sentencePortuguese;
        l.english = ds.sentenceEnglish;

        Sentences s = new Sentences();
        s.actorName = ds.actorName;
        s.profile = ds.speakerSprite;
        s.sentence = l;

        if (GUILayout.Button("Create Dialogue"))
        {
            if(ds.sentencePortuguese != "") {
                ds.dialogues.Add(s);
                ds.actorName = "";
                ds.speakerSprite = null;
                ds.sentencePortuguese = "";
                ds.sentenceEnglish = "";
            }
        }
    }
}


#endif