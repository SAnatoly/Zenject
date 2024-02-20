using System.Collections;
using System;
using ShootEmUp;
using UnityEngine;

public class CountdownTimer : MonoBehaviour,
    IGameStartListener
{
    public event Action completed;
    public event Action changeTime;
    [SerializeField] private int countdownValue;

    public void OnStart()
    {
        StartCoroutine(nameof(CountdownCoroutine));
    }

    public IEnumerator CountdownCoroutine()
    { 
        while(countdownValue > 0)
        {
            yield return new WaitForSeconds(1);
            countdownValue--;
            changeTime.Invoke();
        }
        
        completed?.Invoke();
    }

    public int GetTime()
    {
        return countdownValue;
    }
}
