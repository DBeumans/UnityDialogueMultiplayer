using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Xml;

public class NPCLoadDialogueText : MonoBehaviour {

    private List<Message_struct> messagesList = new List<Message_struct>();
    public List<Message_struct> Get_Messages { get { return messagesList; } }

    public void loadDialogueText(XmlDocument document)
    {
        XmlNodeList totalNPCs = document.GetElementsByTagName("npc");

        for (int i = 0; i < totalNPCs.Count; i++)
        {
            if (totalNPCs[i].Attributes["name"].Value != this.name)
                continue;

            XmlNodeList npcsList = totalNPCs[i].ChildNodes;

            for (int j = 0; j < npcsList.Count; j++)
            {
                if(npcsList[j].Name == "message")
                {
                    messagesList.Add(new Message_struct(npcsList[j].InnerText));
                }

                if (npcsList[j].Name == "option")
                {
                    int parentMessage = int.Parse(npcsList[j].Attributes["forMsgID"].Value);
                    int responseMsg;

                    if (!int.TryParse(npcsList[j].Attributes["response"].Value, out responseMsg))
                        responseMsg = -1;
                    string option = npcsList[j].InnerText;

                    messagesList[parentMessage].addOption(new Option_struct(option, responseMsg));

                }
            }

            
        }
    }
}
