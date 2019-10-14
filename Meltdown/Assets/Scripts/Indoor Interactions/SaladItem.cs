using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaladItem : ItemCollectorBase
{
    public int quantity = 0;

    public override void fill()
    {
        quantity++;
        containsItem = true;
        this.transform.Find("Vegetable").gameObject.SetActive(true);
        alert.SetActive(true);
    }

    public override ItemTypes OnInteract()
    {
        playSound();
        quantity--;
        if(quantity == 0)
        {
            this.transform.Find("Vegetable").gameObject.SetActive(false);
            containsItem = false;
            alert.SetActive(false);
        }
        return item;
    }
}
