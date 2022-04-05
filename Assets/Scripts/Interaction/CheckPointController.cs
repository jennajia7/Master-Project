using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject == NewPlayer.Instance.gameObject)
        {
            if (NewPlayer.Instance.deathAction == DeathAction.NewWorld)
            {
                SceneSwitchManager.Instance.SavePosition(col.gameObject.transform.position);
            }
            else if (NewPlayer.Instance.deathAction == DeathAction.Rebith)
            {
                NewPlayer.Instance.previousPosition = col.gameObject.transform.position;
            }
        }
    }
}
