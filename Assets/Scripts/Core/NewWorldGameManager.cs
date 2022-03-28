using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewWorldGameManager : MonoBehaviour
{
    [Header ("Reference")]
    public NPCWalk npcWalk;
    public GameObject npcAppearPlace;
    public DialogueBoxController dialogueBoxController;
    public DialogueTrigger dialogueTrigger;

    [Header ("Property")]
    public Dictionary<string, string[]> dialogue = new Dictionary<string, string[]>();
    private enum DialogueState {one, two};
    private DialogueState dialogueState = DialogueState.one;
    private static NewWorldGameManager instance;
    public static NewWorldGameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<NewWorldGameManager>();
            }
            return instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // StartCoroutine(NewPlayer.Instance.FreezeEffect(3.0f));
        SetupDiaglogue1();
    }

    public void SetupDiaglogue1()
    {
        dialogue.Clear();
        dialogue.Add("CharacterA", new string[] {
            "Hi, it's me again.",
            "This is not the normal world because you've 'dead'.",
            "However...",
            "However...You got a second chance.",
            "Kill all the enemies and get your health back!",
            "Good luck!"
        });
        dialogueBoxController.dialogue = dialogue;
        dialogueTrigger.completed = false;
        dialogueState = DialogueState.one;
    }

    public void SetupDiaglogue2()
    {
        dialogue.Clear();
        dialogue.Add("CharacterA", new string[] {
            "Nice job!",
            "You have killed 3 enemies.",
            "Let's transfer you to the normal world.",
        });
        dialogueBoxController.dialogue = dialogue;
        dialogueTrigger.completed = false;
        dialogueTrigger.sleeping = false;
        npcWalk.mode = NPCWalk.NPCMode.follow;
        npcWalk.transform.position = npcAppearPlace.transform.position;
        dialogueState = DialogueState.two;

    }

    public void OnCompleteDiaglogue()
    {
        if (dialogueState == DialogueState.two)
        {
            StartCoroutine(SceneSwitchManager.Instance.GoBack());
        }
    }
}
