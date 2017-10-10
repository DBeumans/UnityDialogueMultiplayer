using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NPC : MonoBehaviour {

    [SerializeField]
    protected string npcName;

    protected GameObject player;

    protected ToggleUI ui;

    protected bool isInConversation;
    protected bool enableUpdate;
    
    protected float max_interactionRange;
    protected float rotationSpeed;
    
    protected Vector3 lookAt;
    protected Rigidbody rigid;
    public Rigidbody Get_Rigidbody { get { return rigid; } }

    protected NPCLoadDialogueText NPCDialogueTextLoader;
    protected NPCShowDialogueText npcShowDialogueText;
    protected NPCLookAtObject npcLookAtObject;

    protected void Start()
    {
        this.getComponents();
        this.setVariableValues();


        enableUpdate = true;
    }

    protected void getComponents()
    {
        NPCDialogueTextLoader = GetComponent<NPCLoadDialogueText>();
        npcShowDialogueText = GetComponent<NPCShowDialogueText>();
        npcLookAtObject = GetComponent<NPCLookAtObject>();

        rigid = GetComponent<Rigidbody>();

        player = GameObject.FindGameObjectWithTag(TagList.Player);

        ui = GameObject.FindObjectOfType<ToggleUI>();

        NPCDialogueTextLoader.loadDialogueText(LoadXML.LoadLocalFile("XML/npc_dialogue"));
    }

    protected void setVariableValues()
    {
        max_interactionRange = 2.5f;
        rotationSpeed = 5;
        lookAt = new Vector3(0, transform.eulerAngles.y, 0);
    }

    protected void Update()
    {
        if (!enableUpdate)
            return;
        // This line fixed a wierd bug that for some reason fixes that the player is able to talk with other npcs.
        if (!CheckRange.CheckRangeBetweenObjects(this.gameObject.transform, player.gameObject.transform, max_interactionRange * 2))
        {
            npcLookAtObject.LookAtVector(lookAt, rotationSpeed);
            return;
        }
           
        if (!CheckRange.CheckRangeBetweenObjects(this.gameObject.transform, player.gameObject.transform, max_interactionRange))
        {
            ui.ToggleInteractionText("");
            ui.ToggleDialogueWindow(false);
            isInConversation = false;
            return;
        }
        if (isInConversation)
            return;

        ui.ToggleInteractionText("Press E to chat with " + npcName);
        npcLookAtObject.LookAtObject(player);
        CheckPlayerInput();
       
    }

    protected void CheckPlayerInput()
    {
        if (!InputManager.Get_KeyE)
            return;

        isInConversation = true;

        ui.ToggleInteractionText("");
        ui.ToggleDialogueWindow(true);
        npcShowDialogueText.showMessage(0);   
    }

}
