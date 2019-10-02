using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Class to represent a set of dialogue text so that we can edit the script inside the Unity editor
 */
[System.Serializable]
public class Dialogue
{
    [TextArea(3,10)]
    public string[] sentences;
}
