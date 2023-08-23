using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGameOver : MonoBehaviour
{
    public Collider bola;
    public GameObject canvasGameOver;

    private void OnTriggerEnter(Collider other)
    {
        if (other == bola)
        {
        canvasGameOver.SetActive(true);
        }
    }
}