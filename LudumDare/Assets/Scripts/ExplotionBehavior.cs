using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplotionBehavior : MonoBehaviour
{
    private AudioManager audioManager;

    private void Awake() {
        audioManager = FindObjectOfType<AudioManager>();
        StartCoroutine(DestroyExplotion());
    }

    IEnumerator DestroyExplotion(){
        audioManager.PlayClip("Explosion");
        yield return new WaitForSeconds(0.1f);

        Destroy(gameObject);
    }
}
