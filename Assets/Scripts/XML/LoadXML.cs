using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.Xml;

public static class LoadXML {

    public static XmlDocument LoadLocalFile(string filePath)
    {
        XmlDocument document = new XmlDocument();
        TextAsset resourceFile = Resources.Load(filePath) as TextAsset;
        
        if (!resourceFile)
            throw new XmlException("Failed to load file.");

        try
        {
            document.LoadXml(resourceFile.text);
            return document;
        }
        catch(Exception exception)
        {
            throw new Exception("Failed to load xml file. " + exception);
        }
    }
    
}
