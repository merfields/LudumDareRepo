using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class MainMenu : MonoBehaviour
{

    [SerializeField]
    AudioManager audioManager;

    private void Awake() {
        audioManager = FindObjectOfType<AudioManager>();
    }
    public void StartGame(){
        audioManager.PlayClip("Click");
        SceneManager.LoadScene(1);
    }

    public void ExitGame(){
        Application.Quit();
    }
}
