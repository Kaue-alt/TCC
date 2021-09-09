using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialCanvas : MonoBehaviour
{
    public GameObject textoTutorial;
    public Image tutorialBackground;

    public Text textoAndar;

    public GameObject _textoAndar;

    private bool paused = false;

    Combos combosScript;
    Movimentacao movScript;
    void Start()
    {
        tutorialBackground.enabled = false;
        textoAndar.enabled = false;
        _textoAndar.SetActive(true);

        combosScript = FindObjectOfType<Combos>();
        movScript = FindObjectOfType<Movimentacao>();
    }

    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!paused)
            {
                Time.timeScale = 0;
                textoAndar.enabled = true;
                tutorialBackground.enabled = true;
                paused = true;
            }
            else
            {
                //Cursor.lockState = CursorLockMode.Locked;
                //Time.timeScale = 1;
                //textoAndar.enabled = false;
                //tutorialBackground.enabled = false;
                //paused = false;
            }

            //textoAndar.enabled = true;
            //tutorialBackground.enabled = true;

            Debug.Log("funfo");
            //dialogBox.SetActive(true);
            //combosScript.enabled = false;
            // movScript.enabled = false;
            if (Input.GetKeyUp(KeyCode.M) & paused == true)
            {
                Debug.Log("Enter");
                Time.timeScale = 1;
                paused = false;
                //dialogBox.SetActive(false);
                //movScript.enabled = true;
                //combosScript.enabled = true;
            }
        }

    }
    public void OnClickButtonDespausar()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        textoAndar.enabled = true;
        tutorialBackground.enabled = true;
        paused = false;
    }
}
