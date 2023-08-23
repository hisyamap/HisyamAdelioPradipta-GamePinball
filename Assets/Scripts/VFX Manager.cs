using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
    public GameObject VFXSource;

    public void PlayVFX(Vector3 spawnPosition){
        GameObject.Instantiate(VFXSource, spawnPosition, Quaternion.identity);
    }
}
