using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoppingBoard : InteractableObjectBase
{
    public bool containsLettuce;
    public bool containsTomato;
    public bool containsAvocado;
    public bool saladMade;
    public ItemTypes playerHolding;

    public override bool CanInteract(ItemTypes item)
    {
        // Change interaction text based on curently held vegetable
        playerHolding = item;
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
            else if (item == ItemTypes.Avocado)
            {
                InteractText = "Press J to place Avocado";
                return !containsAvocado;
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
        // Either add an ingredient to the board, or make the complete salad
        playSound();
        if (saladMade == false)
        {
            if (playerHolding == ItemTypes.Tomatoes)
            {
                this.transform.Find("ChoppingBoard").gameObject.transform.Find("Tomato").gameObject.SetActive(true);
                containsTomato = true;
            }
            else if (playerHolding == ItemTypes.Avocado)
            {
                this.transform.Find("ChoppingBoard").gameObject.transform.Find("Avocado").gameObject.SetActive(true);
                containsAvocado = true;
            }
            else
            {
                this.transform.Find("ChoppingBoard").gameObject.transform.Find("Salad").gameObject.SetActive(true);
                containsLettuce = true;
            }
            if (containsTomato && containsLettuce && containsAvocado)
            {
                saladMade = true;
                InteractText = "Press J to make salad";
                interactSound = this.transform.Find("ChopSound").GetComponent<AudioSource>();
            }
            return ItemTypes.NONE;
        }
        else
        {
            clearBoard();
            return ItemTypes.Salad;
        }
    }

    public void clearBoard()
    {
        // Remove all ingredients from the board
        containsAvocado = false;
        containsLettuce = false;
        containsTomato = false;
        saladMade = false;
        this.transform.Find("ChoppingBoard").gameObject.transform.Find("Avocado").gameObject.SetActive(false);
        this.transform.Find("ChoppingBoard").gameObject.transform.Find("Tomato").gameObject.SetActive(false);
        this.transform.Find("ChoppingBoard").gameObject.transform.Find("Salad").gameObject.SetActive(false);
        interactSound = GameObject.FindGameObjectWithTag("AudioSource").GetComponent<AudioSource>();
    }
}