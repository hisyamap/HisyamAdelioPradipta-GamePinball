using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherController : MonoBehaviour
{
    public Collider bola;
    public KeyCode input;

    public float maxForce;
    public float maxTimeHold;

    private bool isHold;

    private Renderer renderer;
    public Color color;

    private void OnCollisionStay(Collision collision) {
        if(collision.collider == bola){
            ReadInput(bola);
        }
    }

    private void Start(){
        isHold = false;

        renderer = GetComponent<Renderer>();
        renderer.material.color = color;
    }

    private void ReadInput(Collider collider){
        if(Input.GetKey(input) && !isHold){
            StartCoroutine(StartHold(collider));
        }
    }
    
    private IEnumerator StartHold(Collider collider){
        renderer.material.color = Color.red;
        float force = 0.0f;
        float timeHold = 0.0f;
        isHold = true;

        while(Input.GetKey(input)){
            force = Mathf.Lerp(0, maxForce, timeHold/maxTimeHold);

            yield return new WaitForEndOfFrame();
            timeHold += Time.deltaTime;
        }
        collider.GetComponent<Rigidbody>().AddForce(Vector3.forward * force);
        isHold = false;
        renderer.material.color = color;
    }
}
