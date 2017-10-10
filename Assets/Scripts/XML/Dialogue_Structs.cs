using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue_Structs : MonoBehaviour {

}

public struct Message_struct
{
    private string message;
    public string Get_Message { get { return message; } }

    private List<Option_struct> options;
    public List<Option_struct> Get_Options { get { return options; } }

    public Message_struct(string msg)
    {
        this.message = msg;
        options = new List<Option_struct>();
    }

    public void addOption(Option_struct option)
    {
        options.Add(option);
    }
}

public struct Option_struct
{
    private string option;
    public string Option { get { return option; } }

    private int response;
    public int Response { get { return response; } }

    public Option_struct(string option, int response)
    {
        this.option = option;
        this.response = response;
    }
}


