using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*This script stores every dialogue conversation in a public Dictionary.*/

public class Dialogue : MonoBehaviour
{

    public Dictionary<string, string[]> dialogue = new Dictionary<string, string[]>();

    void Start()
    {
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
            "Please find your way out with as much coin as you can.",
            "Good luck!"
        });

        // dialogue.Add("CharacterAChoice1", new string[] {
        //     "",
        //     "",
        //     "Let me go find some coins!",
        // });

        // dialogue.Add("CharacterAChoice2", new string[] {
        //     "",
        //     "",
        //     "What else can you do?"
        // });

        dialogue.Add("CharacterB", new string[] {
            "Hey! You found 80 coins! That means 'npcB' is now being used inside 'Dialogue.cs'!",
            "After my dialogue completes, I'll take 80 coins, or however many you specify in the inspector...",
            "And I'll also give you a new ability!",
            "In this case, how about a generic DOWNWARD SMASH? Simply attack while pressing down in mid-air!"
        });
    }
}
