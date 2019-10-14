using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjectBase : MonoBehaviour
{
    public string Name;

    public Sprite Image;

    public string InteractText = "Press J to interact with object";

    public AudioSource interactSound;

    //public EItemType ItemType;
    void start()
    {
        interactSound = GameObject.FindGameObjectWithTag("AudioSource").GetComponent<AudioSource>();
    }

    public virtual void OnInteractAnimation(Animator animator)
    {
        animator.SetTrigger("tr_pickup");
    }

    public virtual ItemTypes OnInteract()
    {
        // By default, empty the players hands on interact
        return ItemTypes.NONE;
    }

    public virtual bool CanInteract(ItemTypes item)
    {
        // By default, the player can always interact
        return true;
    }

    public void PlayInteractSound()
    {
        // Play the set interactSound if the sound settings enable sound effects. 
        if (GameSettings.sounds == true)
        {
            interactSound.Play();
        }
    }
}

public class ItemCollectorBase : InteractableObjectBase
{
    public ItemTypes item;
    public bool containsItem = false;
    public GameObject alert;

    // Ready tasks, such as filling bin or seed crate
    public void fill()
    {
        containsItem = true;
        alert.SetActive(true);
    }

    // On interaction, empty the item collector and return an item to the player
    public override ItemTypes OnInteract()
    {
        containsItem = false;
        alert.SetActive(false);
        return item;
    }

    // If not holding anything, pickup the stored item, otherwise cannot interact
    public override bool CanInteract(ItemTypes heldItem)
    {
        if (heldItem == ItemTypes.NONE)
        {
            return containsItem;
        }
        return false;
    }
}
