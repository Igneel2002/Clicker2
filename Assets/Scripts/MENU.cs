using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MENU : MonoBehaviour
{
    [SerializeField]
    private GameObject GameParts;
    [SerializeField]
    private GameObject Menu;
    [SerializeField]
    private GameObject MenuResume;
    [SerializeField]
    private bool St;
    [SerializeField]
    private GameObject Tip;
    // Start is called before the first frame update
    void Start()
    {
        // Set everything ecexpt for start menu inactive
        MenuResume.SetActive(false);
        GameParts.SetActive(false);
        Tip.SetActive(false);
        Menu.SetActive(true);
        // Set bool to true
        St = true;
    }

    public void start()
    {
        // Display message
        Tip.SetActive(true);
        // Activate game
        GameParts.SetActive(true);
        // Start game
        Time.timeScale = 1;
        // Dismiss menu
        Menu.SetActive(false);
    }

    public void Resume()
    {
        // Display message
        Tip.SetActive(true);
        // Hide pause menu
        MenuResume.SetActive(false);
        // activate game
        Time.timeScale = 1;
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    // Update is called once per frame
    void Update()
    {
        // If p is pressed
        if (Input.GetKeyDown("p"))
        {
            // And if bool is true
            if (St == true)
            {
                // Hide message
                Tip.SetActive(false);
                // Bring up menu
                MenuResume.SetActive(true);
                // Pause game
                Time.timeScale = 0;
                // Play Coroutine
                StartCoroutine(Delay(0.1f));
            }
            // If bool is false
            if (St == false)
            {
                // Display message
                Tip.SetActive(true);
                // Dismiss menu
                MenuResume.SetActive(false);
                // Unpause game
                Time.timeScale = 1;
                // Run Coroutine 2
                StartCoroutine(Delay2(0.1f));
            }
        }
    }


    public IEnumerator Delay(float _Delay)
    {
        // return value and wait for 0.1 seconds in real time to pass
        yield return new WaitForSecondsRealtime(_Delay);
        // Set bool to false
        St = false;
    }

    public IEnumerator Delay2(float _Delay)
    {
        // return value and wait for 0.1 seconds in real time to pass
        yield return new WaitForSecondsRealtime(_Delay);
        // Set bool to true
        St = true;
    }
}
