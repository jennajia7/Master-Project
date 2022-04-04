using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUIController : MonoBehaviour
{
    private GameObject[] heartContainers;
    private int maxHealth;
    private int health;
    public Transform heartsParent;
    public GameObject heartContainerPrefab;

    void Start()
    {
        // maxHealth = (int)NewPlayer.Instance.maxHealth;
        maxHealth = 15;
        health = (int)NewPlayer.Instance.health;
        heartContainers = new GameObject[maxHealth];

        NewPlayer.Instance.onHealthChangedCallback += UpdateHeartsHUD;
        InstantiateHeartContainers();
        UpdateHeartsHUD();
    }

    public void UpdateHeartsHUD()
    {
        SetHeartContainers();
    }

    void SetHeartContainers()
    {
        for (int i = 0; i < heartContainers.Length; i++)
        {
            if (i < NewPlayer.Instance.health)
            {
                heartContainers[i].SetActive(true);
            }
            else
            {
                heartContainers[i].SetActive(false);
            }
        }
    }

    void InstantiateHeartContainers()
    {
        for (int i = 0; i < heartContainers.Length; i++)
        {
            GameObject temp = Instantiate(heartContainerPrefab);
            temp.transform.SetParent(heartsParent, false);
            heartContainers[i] = temp;
        }
    }
}
