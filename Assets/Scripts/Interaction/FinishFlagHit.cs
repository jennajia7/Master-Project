using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishFlagHit : MonoBehaviour
{
    public GameObject flag;
    public GameObject top;
    public GameObject bottom;
    public bool flagMoveUp = false;
    public float moveSpeed = 3.0f;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (flagMoveUp && flag.transform.position.y < top.transform.position.y)
        {
            flag.transform.position = flag.transform.position + Vector3.up * moveSpeed * Time.deltaTime;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.GetComponent<NewPlayer>() != null)
        {
            flagMoveUp = true;
            NewPlayer.Instance.Freeze(true);
            StartCoroutine(FinishGame());
        }
    }

    private IEnumerator FinishGame()
    {
        yield return new WaitForSeconds(3.0f);
        GameManager.Instance.hud.ShowEndingText(NewPlayer.Instance.coins);
    }
}
