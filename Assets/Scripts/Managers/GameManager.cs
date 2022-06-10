using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int totalFish = 0;

    public int fish = 0;
    public int coins = 0;

    public void Awake()
    {
        if (instance == null)
            instance = this;

        Debug.Log("Singleton Created. Success: " + instance != null);
    }

}
