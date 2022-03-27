using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewWorldGameManager : MonoBehaviour
{
    [Header ("Reference")]
    public NPCWalk npcWalk;

    // Start is called before the first frame update
    void Start()
    {
        // StartCoroutine(NewPlayer.Instance.FreezeEffect(3.0f));
        NewPlayer.Instance.Freeze(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SeenDialogue()
    {
        npcWalk.mode = NPCWalk.NPCMode.stand;
        NewPlayer.Instance.Freeze(false);
    }
}
