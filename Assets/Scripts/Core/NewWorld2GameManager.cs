using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewWorld2GameManager : MonoBehaviour
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
    private static NewWorld2GameManager instance;
    public static NewWorld2GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<NewWorld2GameManager>();
            }
            return instance;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        SetupDiaglogue1();
    }

    public void SetupDiaglogue1()
    {
        dialogue.Clear();
        dialogue.Add("CharacterA", new string[] {
            "Hi, it's me again.",
            " You've found your way to the underworld because you died.",
            "However...",
            "However...you've got a second chance.",
            "In the underworld you get a chance to get your health back from the enemies that killed you.",
            "Find all the hearts, and you'll have a chance to return.",
            "Are you ready?"
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
            "You have killed all the enemies and gotten your health back.",
            "You're now ready to make your way back to the normal world."

        });
        dialogueBoxController.dialogue = dialogue;
        dialogueTrigger.completed = false;
        dialogueTrigger.sleeping = false;
        npcWalk.mode = NPCWalk.NPCMode.follow;
        // npcWalk.transform.position = npcAppearPlace.transform.position;
        npcWalk.maxSpeed = 5;
        dialogueState = DialogueState.two;

    }

    public void OnCompleteDiaglogue()
    {
        if (dialogueState == DialogueState.two)
        {
            StartCoroutine(SceneSwitchManager.Instance.GoBack("NewWorld2"));
        }
    }
}
