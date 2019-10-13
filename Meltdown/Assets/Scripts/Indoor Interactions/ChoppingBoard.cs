using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoppingBoard : InteractableObjectBase
{
    public bool containsLettuce;
    public bool containsTomato;
    public bool containsAvacado;
    public bool saladMade;
    public ItemTypes playerHolding;

    public override bool CanInteract(ItemTypes item)
    {
        if (!saladMade)
        {
            if (item == ItemTypes.Lettuce)
            {
                InteractText = "Press J to place Lettuce";
                return !containsLettuce;
            }
            else if (item == ItemTypes.Tomatoes)
            {
                InteractText = "Press J to place Tomoatoes";
                return !containsTomato;
            }
            else if (item == ItemTypes.Avacado)
            {
                InteractText = "Press J to place Avacado";
                return !containsAvacado;
            }
            return false;
        }
        else if(item == ItemTypes.NONE)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public override ItemTypes OnInteract()
    {
        if (saladMade == false)
        {
            if (playerHolding == ItemTypes.Tomatoes)
            {
                containsTomato = true;
            }
            else if (playerHolding == ItemTypes.Avacado)
            {
                containsAvacado = true;
            }
            else
            {
                containsLettuce = true;
            }
            if (containsTomato && containsLettuce && containsAvacado)
            {
                saladMade = true;
                InteractText = "Press J to make salad";
                interactSound = this.transform.Find("ChopSound").GetComponent<AudioSource>();
            }
            return ItemTypes.NONE;
        }
        else
        {
            return ItemTypes.Salad;
        }
    }

    public void clearBoard()
    {
        containsAvacado = false;
        containsLettuce = false;
        containsTomato = false;
        saladMade = false;
        GameObject.FindGameObjectWithTag("AudioSource").GetComponent<AudioSource>();
    }
}