using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*This script stores every dialogue conversation in a public Dictionary.*/

public class NewWorldDialogue : Dialogue
{
    void Start()
    {
        //NPC
        dialogue.Add("CharacterA", new string[] {
            "Hi there!",
            "Welcome to this world!",
            "Please try to kill the bug by pressing left button",
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
    }
}
