using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    float invokeTime = 0.5f;
    [SerializeField] ParticleSystem finishEffect;
    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            GetComponent<AudioSource>().Play();
            finishEffect.Play();
            Invoke("restartLevel",invokeTime);    
        }
    }

    void restartLevel(){
        Debug.Log("You finished");
        SceneManager.LoadScene("Level1");
    }
}
