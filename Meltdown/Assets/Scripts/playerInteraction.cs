using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInteraction : MonoBehaviour
{
    public HUD Hud;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Interact with the object
        if (mInteractItem != null && Input.GetKeyDown(KeyCode.J))
        {
            // Interact animation
            //mInteractItem.OnInteractAnimation(_animator);
            InteractWithItem();
        }

    }

    public void InteractWithItem()
    {
        if (mInteractItem != null)
        {
            mInteractItem.OnInteract();

        }

        Hud.CloseMessagePanel();

        mInteractItem = null;
    }

    private InteractableObjectBase mInteractItem = null;

    private void OnTriggerEnter(Collider other)
    {
        InteractableObjectBase item = other.GetComponent<InteractableObjectBase>();

        if (item != null)
        {
            if (item.CanInteract())
            {

                mInteractItem = item;
                Hud.OpenMessagePanel(mInteractItem);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        InteractableObjectBase item = other.GetComponent<InteractableObjectBase>();
        if (item != null)
        {
            //Hud.CloseMessagePanel();
            mInteractItem = null;
        }
    }
}
