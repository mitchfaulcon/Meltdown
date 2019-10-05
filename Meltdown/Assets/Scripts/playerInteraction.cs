using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInteraction : MonoBehaviour
{
    public HUD Hud;
    public ItemTypes heldItem = ItemTypes.NONE;
    public GameObject holdingBottle;
    public GameObject holdingRubbish;
    public GameObject holdingCompost;
    public GameObject holdingTomato;
    public GameObject holdingTree;
    public GameObject holdingPotato;
    public GameObject holdingCarrot;
    public GameObject holdingCan;

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
            heldItem = mInteractItem.OnInteract();
            Debug.Log("Picked Up: " + heldItem);
            if (heldItem == ItemTypes.Recyclables)
            {
                holdingBottle.SetActive(true);
                holdingRubbish.SetActive(false);
                holdingCompost.SetActive(false);
            }
            else if (heldItem == ItemTypes.RubbishBag)
            {
                holdingBottle.SetActive(false);
                holdingRubbish.SetActive(true);
                holdingCompost.SetActive(false);
            }
            else if (heldItem == ItemTypes.BananaSkin)
            {
                holdingBottle.SetActive(false);
                holdingRubbish.SetActive(false);
                holdingCompost.SetActive(true);
            }
            else if (heldItem == ItemTypes.NONE)
            {
                holdingBottle.SetActive(false);
                holdingRubbish.SetActive(false);
                holdingCompost.SetActive(false);
            }

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
            if (item.CanInteract(heldItem))
            {
                Debug.Log("Currently Holding Item: " + heldItem);
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
            Hud.CloseMessagePanel();
            mInteractItem = null;
        }
    }
}
