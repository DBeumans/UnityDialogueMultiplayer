using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCShowDialogueText : MonoBehaviour {

    [SerializeField]
    private Text dialogueText;

    private NPCLoadDialogueText npcDialogueText;
    private NPCSetButton NPCButton;

    private ToggleUI ui;

    private void Start()
    {
        npcDialogueText = GetComponent<NPCLoadDialogueText>();
        NPCButton = GetComponent<NPCSetButton>();

        ui = FindObjectOfType<ToggleUI>();

        dialogueText.text = "";
    }

    //npcDialogueText.Get_Messages[index].Get_Message
    public void showMessage(int index)
    {
        NPCButton.disableButtons();
        dialogueText.text = npcDialogueText.Get_Messages[index].Get_Message;

        var optionsList = npcDialogueText.Get_Messages[index].Get_Options;

        for (int i = 0; i < optionsList.Count; i++)
        {
            var response = optionsList[i].Response;
            Button optionButton = NPCButton.SetButtonText(optionsList[i].Option);

            if (response < 0)
                optionButton.onClick.AddListener(delegate () { ui.ToggleDialogueWindow(false); });
            else
                optionButton.onClick.AddListener(delegate () { this.showMessage(response); });
        }
        ui.ToggleDialogueWindow(true);
    }
}
