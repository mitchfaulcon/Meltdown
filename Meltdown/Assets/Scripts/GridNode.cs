using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Each GridNode object represents an empty GameObject 
   and stores the adjacent nodes should they exist. 
   The nodes should be arranged in a roughly grid-like
   format with a maximum of 4 adjacent nodes. */
public class GridNode
{
    private ArrayList adjNodes = new ArrayList();
    private Transform node;

    public GridNode(Transform centreNode, Transform northNode, Transform eastNode, Transform southNode, Transform westNode) {
        node = centreNode;
        
        adjNodes.Add(northNode);
        adjNodes.Add(eastNode);
        adjNodes.Add(southNode);
        adjNodes.Add(westNode);
    }


    // Selects a random adjacent node
    public Transform GetRandomNode() {
        int next = Random.Range(0, 4);
        Transform node = (Transform) adjNodes[next];

        if (node == null) {
            return GetRandomNode();
        } else {
            return node;
        }
    }

    public bool IsNode(Transform compareNode) {
        return compareNode == node;
    } 

}
