using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndoorPlayerInteraction : PlayerInteraction
{
    //public GameObject holdingBottle;
    //public GameObject holdingRubbish;
    //public GameObject holdingCompost;
    //public GameObject holdingTomato;
    //public GameObject holdingTree;
    //public GameObject holdingPotato;
    //public GameObject holdingCarrot;
    //public GameObject holdingCan;


    // Remove all item speech bubbles
    protected override void removeSpeechBubbles()
    {
        //holdingBottle.SetActive(false);
        //holdingRubbish.SetActive(false);
        //holdingCompost.SetActive(false);
        //holdingTomato.SetActive(false);
        //holdingTree.SetActive(false);
        //holdingPotato.SetActive(false);
        //holdingCarrot.SetActive(false);
        //holdingCan.SetActive(false);
    }

    protected override void setActiveBubble()
    {
        //if (heldItem == ItemTypes.Recyclables)
        //{
        //    holdingBottle.SetActive(true);

        //}
        //else if (heldItem == ItemTypes.RubbishBag)
        //{
        //    holdingRubbish.SetActive(true);
        //}
        //else if (heldItem == ItemTypes.BananaSkin)
        //{
        //    holdingCompost.SetActive(true);
        //}
        //else if (heldItem == ItemTypes.TomatoSeeds)
        //{
        //    holdingTomato.SetActive(true);
        //}
        //else if (heldItem == ItemTypes.TreeSappling)
        //{
        //    holdingTree.SetActive(true);
        //}
        //else if (heldItem == ItemTypes.PotatoSeeds)
        //{
        //    holdingPotato.SetActive(true);
        //}
        //else if (heldItem == ItemTypes.CarrotSeeds)
        //{
        //    holdingCarrot.SetActive(true);
        //}
        //else if (heldItem == ItemTypes.WaterBucket)
        //{
        //    holdingCan.SetActive(true);
        //}
    }
}
