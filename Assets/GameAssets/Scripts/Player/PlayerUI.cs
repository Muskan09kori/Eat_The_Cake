using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI promptText;

    void Start()
    {
        promptText.gameObject.SetActive(false);
    }

    public void UpdateText(string promptMessage)
    {
        if (string.IsNullOrEmpty(promptMessage))
        {
            promptText.gameObject.SetActive(false);
        }
        else
        {
            promptText.gameObject.SetActive(true);
            promptText.text = promptMessage;
        }
    }
}
