using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource BGMAudioSource;
    public GameObject SFXAudioSource;

    void Start()
    {
        PlayBGM();
    }

    public void PlayBGM(){
        BGMAudioSource.Play();
    }

    public void PlaySFX(Vector3 spawnPosition){
        GameObject.Instantiate(SFXAudioSource, spawnPosition, Quaternion.identity);
    }
}
