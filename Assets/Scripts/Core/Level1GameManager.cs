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
            "Looks like it has a key hole!"
        });


        dialogue.Add("LockedDoorB", new string[] {
            "Key used!"
        });

        //NPC
        dialogue.Add("CharacterA", new string[] {
            "Hi there!",
            "Welcome to this world!",
            "You can move around by using arrow key, space to jump, and left click to attack.",
            "Please find your way out with as much coin as you can.",
            "Good luck!"
        });

        dialogueBoxController.dialogue = dialogue;
    }
}
