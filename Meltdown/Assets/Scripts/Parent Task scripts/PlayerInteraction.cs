using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerInteraction : MonoBehaviour
{
    public HUD Hud;
    public ItemTypes heldItem = ItemTypes.NONE;

    public AudioSource gameMusic;

    // Start is called before the first frame update
    void Start()
    {
        //Hide the cursor when the game starts
        Cursor.visible = false;

        // Start game music if enabled
        if (GameSettings.music == true)
        {
            gameMusic.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Interact with the object
        if (mInteractItem != null && Input.GetKeyDown(KeyCode.J))
        {
            // Interact animation
            InteractWithItem();
        }

    }

    public void InteractWithItem()
    {
        // As long as the player is holding an item, show a speech bubble showing they are holding that
        // item above them relevant to the item
        if (mInteractItem != null)
        {
            
            heldItem = mInteractItem.OnInteract();
            removeSpeechBubbles();
            setActiveBubble();

        }

        // Once the interaction is complete, hide the interaction prompt if it is not a chopping board with
        // a complete salad 
        if (!(mInteractItem is ChoppingBoard) || !((ChoppingBoard)mInteractItem).saladMade)
        {
            mInteractItem = null;
            Hud.CloseMessagePanel();
        }
        

    }

    private InteractableObjectBase mInteractItem = null;

    private void OnTriggerEnter(Collider other)
    {
        InteractableObjectBase item = other.GetComponent<InteractableObjectBase>();

        // If inside a trigger zone with a triggerable item, and the player is able to interact, display the interaction prompt to the user
        if (item != null)
        {
            if (item.CanInteract(heldItem))
            {
                mInteractItem = item;
                Hud.OpenMessagePanel(mInteractItem);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // If the player leaves a trigger zone, hide the interaction prompt
        InteractableObjectBase item = other.GetComponent<InteractableObjectBase>();
        // Only remove the prompt if the item being left is the current item
        if (item == mInteractItem)
        {
            Hud.CloseMessagePanel();
            mInteractItem = null;
        }
    }

    // Remove all item speech bubbles
    protected abstract void removeSpeechBubbles();

    protected abstract void setActiveBubble();
}
