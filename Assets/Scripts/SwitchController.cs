using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    public Collider bola;
    
    public Material offMaterial;
    public Material onMaterial;

    private SwitchState state;
    private Renderer renderer;

    public ScoreManager scoreManager;

    private enum SwitchState{
        Off,
        On,
        Blink
    }


    private void Start()
    {
        renderer = GetComponent<Renderer>();

        Set(false);
        StartCoroutine(BlinkTimerStart(5));
    }

    private void OnTriggerEnter(Collider other) {
        if (other == bola){
            Toggle();
        }
    }

    private void Toggle(){
        scoreManager.AddScore(10);
        if (state == SwitchState.On){
            Set(false);
        }else{
            Set(true);
        }
    }

    private void Set(bool active){
        if (active == true){
            state = SwitchState.On;
            renderer.material = onMaterial;

            StopAllCoroutines();
        }else{
            state = SwitchState.Off;
            renderer.material = offMaterial;
            StartCoroutine(BlinkTimerStart(5));
        }
    }
    private IEnumerator Blink(int times){
        state = SwitchState.Blink;

        for(int i = 0; i < times; i++){
            renderer.material = onMaterial;
            yield return new WaitForSeconds(0.5f);
            renderer.material = offMaterial;
            yield return new WaitForSeconds(0.5f);
        }

        state = SwitchState.Off;
        StartCoroutine(BlinkTimerStart(5));
    }

    private IEnumerator BlinkTimerStart(float time){
        yield return new WaitForSeconds(time);
        StartCoroutine(Blink(2));
    }
}
