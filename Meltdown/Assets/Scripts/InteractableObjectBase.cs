using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjectBase : MonoBehaviour
{
    public string Name;

    public Sprite Image;

    public string InteractText = "Press J to interact with object";

    //public EItemType ItemType;

    public virtual void OnInteractAnimation(Animator animator)
    {
        animator.SetTrigger("tr_pickup");
    }

    public virtual ItemTypes OnInteract()
    {
        return ItemTypes.NONE;
    }

    public virtual bool CanInteract(ItemTypes item)
    {
        return true;
    }
}

public class ItemCollectorBase : InteractableObjectBase
{
    public ItemTypes item;
    public bool containsItem = false;

    public void fill()
    {
        containsItem = true;
    }

    public override ItemTypes OnInteract()
    {
        containsItem = false;
        return item;
    }

    public override bool CanInteract(ItemTypes heldItem)
    {
        if (heldItem == ItemTypes.NONE)
        {
            return containsItem;
        }
        return false;
    }
}
