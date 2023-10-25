using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class InputUI : MonoBehaviour
{
    public GameObject consolePrefab;
    public Transform consoleRect;
    public Scrollbar scrollbar;
    public TMP_InputField inputField;
    public InterpreterClient interpreterClient;

    private void LateUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            EnterInput();
        }
    }

    void EnterInput ()
    {
        string input = inputField.text;
        string output = interpreterClient.ParseInput(input);
        inputField.text = "";
        GameObject loggedInput;
        if (input != "")
        {
            loggedInput = Instantiate(consolePrefab, consoleRect);
            loggedInput.GetComponentInChildren<TextMeshProUGUI>().text = input;
        }
        if (output != "")
        {
            loggedInput = Instantiate(consolePrefab, consoleRect);
            loggedInput.GetComponentInChildren<TextMeshProUGUI>().text = output;
        }
        Invoke("ZeroScrollbar", 0.1f);
    }

    public void ZeroScrollbar ()
    {
        scrollbar.value = 0.000000001f;
    }
}
