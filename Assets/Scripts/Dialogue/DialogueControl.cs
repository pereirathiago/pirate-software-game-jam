using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{
    [System.Serializable]
    public enum idiom
    {
        pt,
        eng
    }

    public idiom language;

    [Header("Components")]
    public GameObject dialogueObj;
    public Image profileSprite;
    public TextMeshProUGUI speechText;
    public TextMeshProUGUI actorNameText;

    [Header("Settings")]
    public float typingSpeed;

    private bool isShowing;
    private int index;
    private string[] sentences;
    private string[] actors;
    private Sprite[] profiles;

    public static DialogueControl instance;

    public bool IsShowing { get => isShowing; set => isShowing = value; }

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && IsShowing)
        {
            NextSentence();
        }
    }

    IEnumerator TypeSentence()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        if(speechText.text == sentences[index])
        {
            if(index < sentences.Length - 1)
            {
                index++;
                speechText.text = "";
                actorNameText.text = actors[index];
                profileSprite.sprite = profiles[index];
                StartCoroutine(TypeSentence());
            } else
            {
                speechText.text = "";
                actorNameText.text = "";
                index = 0;
                dialogueObj.SetActive(false);
                sentences = null;
                IsShowing = false;
            }
        } else
        {
            StopAllCoroutines();
            speechText.text = sentences[index];
        }
    }

    public void Speech(string[] txt, string[] actorName, Sprite[] profile)
    {
        if(!IsShowing)
        {
            dialogueObj.SetActive(true);
            sentences = txt;
            actors = actorName;
            profiles = profile;
            actorNameText.text = actors[index];
            profileSprite.sprite = profiles[index];
            StartCoroutine(TypeSentence());
            IsShowing = true;
        }
    }
}
