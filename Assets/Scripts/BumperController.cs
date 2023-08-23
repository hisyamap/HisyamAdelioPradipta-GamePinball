using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{
    public Color color;
    private Renderer renderer;

    public Collider bola;
    public float multiplier;

    private Animator animator;

    public AudioManager audioManager;
    public VFXManager VFXManager;
    public ScoreManager scoreManager;

    private void Start(){
        renderer = GetComponent<Renderer>();
        renderer.material.color = color;

        animator = GetComponent<Animator>();
    }
    
    private void OnCollisionEnter(Collision collision) {
        if(collision.collider == bola){
            Rigidbody rigbola = bola.GetComponent<Rigidbody>();
            rigbola.velocity *= multiplier;

            animator.SetTrigger("Hit");

            audioManager.PlaySFX(collision.transform.position);
            VFXManager.PlayVFX(collision.transform.position);
            scoreManager.AddScore(5);
        }
    }
}
