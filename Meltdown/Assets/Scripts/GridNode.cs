using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
