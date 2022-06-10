using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FishManager : MonoBehaviour
{
    GameManager gameManager;
    [SerializeField] Bucket bucket;

    [Header("Fishing")]
    [Space]
    [Header("Values")]
    [SerializeField] float valueMin = 1.50f;
    [SerializeField] float valueMax = 5f;

    public UnityEvent OnFishEvent;
    public UnityEvent OnFishSellEvent;

    private void Start()
    {
        gameManager = GameManager.instance;

        if (OnFishEvent == null)
            OnFishEvent = new UnityEvent();
        if (OnFishSellEvent == null)
            OnFishSellEvent = new UnityEvent();

    }

    public void Fish()
    {
        gameManager.totalFish++;

        if (bucket.capacity != gameManager.fish)
            gameManager.fish++;

        OnFishEvent.Invoke();
    }

    public void SellFish()
    {
        int fish = gameManager.fish;
        int totalValue = (int) Random.Range(fish * valueMin, fish * valueMax);

        gameManager.coins += totalValue;
        gameManager.fish = 0;
        OnFishSellEvent.Invoke();
    }
}

