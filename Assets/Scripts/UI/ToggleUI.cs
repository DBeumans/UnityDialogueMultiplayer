using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleUI : MonoBehaviour {

    [SerializeField]
    private Text interactionText;

    [SerializeField]
    private GameObject dialogueWindow;

    public void ToggleInteractionText(string text)
    {
        interactionText.text = text;
    }

    public void ToggleDialogueWindow(bool value)
    {
        dialogueWindow.SetActive(value);
    }
}
