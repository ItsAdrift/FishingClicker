using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{

    public UnityEvent OnTimerEnd;

    void Start()
    {
        if (OnTimerEnd == null)
            OnTimerEnd = new UnityEvent();
    }

    public void StartTimer(float delay)
    {
        StartCoroutine(_Timer(delay));
    }

    IEnumerator _Timer(float delay)
    {
        yield return new WaitForSeconds(delay);

        OnTimerEnd.Invoke();
    }
}
