using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextPopup : MonoBehaviour
{

    private float destroyTime = 2f;
    private Vector3 offset = new Vector3(0, 2, 0);
    private float timeSinceStart = 0f;

    private Vector3 firstPhaseMovement = new Vector3(2.05f, 3.2f, 0f);
    private Vector3 secondPhaseMovement = new Vector3(0.431f, 0.169f, 0f);

    // Start is called before the first frame update
    void Start()
    {
        //Move to above player
        transform.localPosition += offset;
        //Destroy after set time
        Destroy(gameObject, destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceStart += Time.deltaTime;

        //Change location of popup (doing it in the animator moves popup to completely wrong location
        if (timeSinceStart <= 0.2f)
        {
            transform.localPosition += firstPhaseMovement * Time.deltaTime;
        } else
        {
            transform.localPosition += secondPhaseMovement * Time.deltaTime;
        }
    }
}
