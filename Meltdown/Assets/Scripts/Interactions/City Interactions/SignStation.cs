using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignStation : InteractableObjectBase
{
    public GameObject alert;
    public override bool CanInteract(ItemTypes item)
    {
        if(item == ItemTypes.Supplies)
        {
            return true;
        }
        return false;
    }

    public override ItemTypes OnInteract()
    {
        alert.SetActive(false);
        if (GameSettings.sounds)
        {
            interactSound.Play();
        }
        return ItemTypes.Sign;
    }

    public void setAlert()
    {
        alert.SetActive(true);
    }
}
