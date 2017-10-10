using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCSetButton : MonoBehaviour {

    [SerializeField]
    private List<Button> buttons = new List<Button>();
    private List<Text> buttonsText = new List<Text>();


    private void Start()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            buttonsText.Add(buttons[i].GetComponentInChildren<Text>());
            buttons[i].gameObject.SetActive(false);
        }       
    }

    public void disableButtons()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].gameObject.SetActive(false);
        }
    }

    public Button SetButtonText(string buttonText)
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            if (buttons[i].gameObject.activeSelf)
                continue;

            buttonsText[i].text = buttonText;
            buttons[i].gameObject.SetActive(true);
            return buttons[i];
        }
        return null;
    }
}
