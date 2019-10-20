using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeIndoorSaladBubble : MonoBehaviour
{
    public Quaternion iniRot;

    // Start is called before the first frame update
    void Start()
    {
        iniRot = transform.rotation;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.rotation = iniRot;
    } 
}
