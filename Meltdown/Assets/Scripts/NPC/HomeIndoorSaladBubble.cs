using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeIndoorSaladBubble : MonoBehaviour
{
    public Quaternion iniRot;

    // Start is called before the first frame update
    void Start()
    {
        // Init the salad bubble rotation toward the camera
        iniRot = transform.rotation;
        iniRot.y = -270;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Ensure each frame, the bubble does not rotate
        transform.rotation = iniRot;
    } 
}
