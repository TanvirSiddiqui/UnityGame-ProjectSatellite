using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 2f;
    [SerializeField] AudioClip success;
    [SerializeField] AudioClip crash;

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("You are safe!");
                break;
            case "Finish":
                StartSuccessSequence();
                Debug.Log("Congratulation, You have reached");
                break;
            case "Fuel":
                Debug.Log("You have filled your tank");
                break;
            default:
                StartCrashSequence();
                break;
        }
    }

     void StartSuccessSequence()
    {
        audioSource.PlayOneShot(success);
        // todo add particle effect upon success
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", levelLoadDelay);

    }

    void StartCrashSequence()
     {

        audioSource.PlayOneShot(crash);
        // todo add particle effect ipon crash
         GetComponent<Movement>().enabled = false;
         Invoke("ReloadLevel", levelLoadDelay);
      }

    void LoadNextLevel()
        {
            int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            int nextSceneIndex = CurrentSceneIndex + 1;
            if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
            {
                nextSceneIndex = 0;
            }
            SceneManager.LoadScene(nextSceneIndex);
        }

        void ReloadLevel()
        {
            int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(CurrentSceneIndex);
        }
}
