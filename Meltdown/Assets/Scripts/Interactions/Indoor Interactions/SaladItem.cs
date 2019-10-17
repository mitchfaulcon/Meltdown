using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaladItem : ItemCollectorBase
{
    public int quantity = 0;

    // Fill vegetable and enable alert
    public override void fill()
    {
        quantity++;
        containsItem = true;
        alert.SetActive(true);
    }

    // Provide the player with the correct ingredient and remove the alert if appropriate
    public override ItemTypes OnInteract()
    {
        playSound();
        quantity--;
        if(quantity == 0)
        {
            containsItem = false;
            alert.SetActive(false);
        }
        return item;
    }
}
