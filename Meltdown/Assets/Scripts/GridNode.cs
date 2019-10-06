using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Each GridNode object represents an empty GameObject 
   and stores the adjacent nodes should they exist. 
   The nodes should be arranged in a roughly grid-like
   format with a maximum of 4 adjacent nodes. */
public class GridNode
{
    private Transform[] adjNodes;
    private Transform node;

    public GridNode(Transform centreNode, Transform[] adjacentNodes) {
        node = centreNode;
        adjNodes = adjacentNodes;
    }


    // Selects a random adjacent node that isn't the previously traversed node
    public Transform GetRandomNode(Transform prevNode) {
        int next = Random.Range(0, adjNodes.Length);
        Transform node = adjNodes[next];

        if (node == prevNode) {
            // If the selected node is the previous node, try again.
            return GetRandomNode(prevNode);
        } else {
            return node;
        }
    }

    public bool IsNode(Transform compareNode) {
        return compareNode == node;
    } 

}
