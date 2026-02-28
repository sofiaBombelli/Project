using UnityEngine;
using System.Collections.Generic;
using System.Collections;
public class RandomEx : MonoBehaviour
{
    public static RandomEx Instance { get; private set; }//singleton
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    private void Start()
    {
        //float randomValue = Random.Range(0f, 1f);
        //Debug.Log("Random value: " + randomValue);
    }
    public int GetRandomvalue(int num1, int num2)
    {
        int rand = Random.Range(num1, num2);
        return rand;
    }
}
