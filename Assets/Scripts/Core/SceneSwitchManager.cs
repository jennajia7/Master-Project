using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitchManager : MonoBehaviour
{
    private static SceneSwitchManager instance;
    private static bool created = false;
    public static Vector3 previousPosition;
    public static string previousScene;
    public string loadSceneName;
    public static bool visitedNewWorld1 = false;
    public static bool visitedNewWorld2 = false;
    public static SceneSwitchManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<SceneSwitchManager>();
            }
            return instance;
        }
    }
    void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(transform.gameObject);
            created = true;
        }
        else
        {
            Destroy(this.gameObject);
        }
        if (SceneManager.GetActiveScene().name == "DemoLevel v2")
        {
            if (visitedNewWorld1 || visitedNewWorld2)
            {
                InitializeLevelFromNewWorld();
            }
            else
            {
                InitializeLevelFromBegin();
            }
        }
        else if (SceneManager.GetActiveScene().name == "NewWorld1")
        {
            NewPlayer.Instance.Freeze(true);
        }
        else if (SceneManager.GetActiveScene().name == "NewWorld2")
        {
            NewPlayer.Instance.Freeze(true);
        }
    }

    void Start()
    {
        // SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "DemoLevel v2")
        {
            if (visitedNewWorld1 || visitedNewWorld2)
            {
                InitializeLevelFromNewWorld();
            }
            else
            {
                InitializeLevelFromBegin();
            }
        }
        else if (scene.name == "NewWorld1")
        {
            NewPlayer.Instance.Freeze(true);
        }
    }

    public void SavePosition(Vector3 pos)
    {
        previousPosition = pos;
        Debug.Log("save player position " + previousPosition);
        previousScene = SceneManager.GetActiveScene().name;
        visitedNewWorld1 = false;
        visitedNewWorld2 = false;
    }

    public IEnumerator GoBack(string sceneName)
    {
        Debug.Log("Go back to level, from scene " + sceneName);
        if (sceneName == "NewWorld1")
        {
            visitedNewWorld1 = true;
        }
        else if (sceneName == "NewWorld2")
        {
            visitedNewWorld2 = true;
        }
        GameManager.Instance.hud.animator.SetTrigger("coverScreen");
        GameManager.Instance.hud.loadSceneName = previousScene;
        yield return new WaitForSeconds(1.0f);
    }

    public void InitializeLevelFromBegin()
    {
        Debug.Log("Initialize Scene from Begin");
        NewPlayer.Instance.Freeze(true);
    }

    public void InitializeLevelFromNewWorld()
    {
        Debug.Log("Initialize Scene From NewWorld " + previousPosition);
        NewPlayer.Instance.transform.position = previousPosition;
        GameObject npc = GameObject.Find("NPC");
        npc.GetComponent<DialogueTrigger>().completed = true;
        npc.GetComponent<DialogueTrigger>().sleeping = true;
        npc.GetComponent<NPCWalk>().mode = NPCWalk.NPCMode.stand;
        NewPlayer.Instance.maxHealth = 3;
        NewPlayer.Instance.recoveryCounter.counter = 0;
    }
}
