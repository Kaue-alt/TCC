using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogImport : MonoBehaviour
{

    public TextAsset txtFile;
    public string[] textLines;

    public GameObject dialogBox;
    public Text showText;
    public int currentLine, lastLine;

    Combos combosScript;
    Movimentacao movScript;

    void Start()
    {

        combosScript = FindObjectOfType<Combos>();
        movScript = FindObjectOfType<Movimentacao>();

        combosScript.enabled = false;
        movScript.enabled = false;

        if (txtFile != null)
        {
            textLines = (txtFile.text.Split('\n'));
        }

        if(lastLine == 0)
        {
            lastLine = textLines.Length - 1;
        }
    }

    void Update()
    {
        showText.text = textLines[currentLine];

        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            currentLine += 1;
        }

        if(currentLine > lastLine)
        {
            dialogBox.SetActive(false);
            movScript.enabled = true;
            combosScript.enabled = true;
        }
    }
}
