using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1GameManager : MonoBehaviour
{
    public DialogueBoxController dialogueBoxController;
    private static Level1GameManager instance;
    public static Level1GameManager Instance
    {
        get
        {
            if (Instance == null)
            {
                instance = GameObject.FindObjectOfType<Level1GameManager>();
            }
            return instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SetupDiaglogue();
    }

    void SetupDiaglogue()
    {
        Dictionary<string, string[]> dialogue = new Dictionary<string, string[]>();
        //Door
        dialogue.Add("LockedDoorA", new string[] {
            "A large door...",
            "But it's locked!",
            "Where is the key…?"
        });


        dialogue.Add("LockedDoorB", new string[] {
            "Key used!"
        });

        //NPC
        dialogue.Add("CharacterA", new string[] {
            "Hi there!",
            "Welcome to this world!",
            "You can move around by using the arrow keys and, space to jump.",
            "We have monsters in this world, so you'll want to avoid them or left click to shoot a bullet in the direction you're facing.",
            "Your goal is to make your way out and find as many coins as you can.",
            "Good luck!"
        });

        dialogueBoxController.dialogue = dialogue;
    }
}
