using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeOutdoorDogNPC : NPCMovement
{
    private ArrayList nodes = new ArrayList();
    private Transform currentNode;

    public GameObject toIgnore;

    // Start is called before the first frame update
    void Start()
    {
        waitTime = 0f;

        // Setup the grid of nodes where the dog can traverse
        nodes.Add(new GridNode(points[0], null, null, points[1], points[8])); // point0
        nodes.Add(new GridNode(points[1], points[0], null, null, points[7])); // point3
        nodes.Add(new GridNode(points[2], points[3], points[7], points[6], null)); // point4
        nodes.Add(new GridNode(points[3], null, points[8], points[2], null)); // point7
        nodes.Add(new GridNode(points[4], points[1], null, null, points[5])); // dogPoint1
        nodes.Add(new GridNode(points[5], points[7], points[4], null, points[6])); // dogPoint2
        nodes.Add(new GridNode(points[6], points[2], points[5], null, null)); // dogPoint3
        nodes.Add(new GridNode(points[7], points[8], points[1], points[5], points[2])); // dogPoint4
        nodes.Add(new GridNode(points[8], null, points[0], points[7], points[3])); // dogPoint5

        currentNode = points[0];
    }

    // Update is called once per frame
    void Update()
    {
        // Check that dog is near or at the point before randomly selecting the next target node
        if (Vector3.Distance(transform.position, currentNode.position) < 1.0f) {
            currentNode = GetCurrentGridNode().GetRandomNode(currentNode);
        }
    }

    void FixedUpdate() {
        MovePlayer(currentNode.position);
        SetRotation(currentNode.position - transform.position);
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "NPC") {
            Physics.IgnoreCollision(toIgnore.GetComponent<Collider>(), playerModel.GetComponent<Collider>());
        }
    }

    private GridNode GetCurrentGridNode() {
        GridNode output = null;

        // Find the current grid node in the array
        foreach (GridNode gridNode in nodes) {
            if (gridNode.IsNode(currentNode)) {
                output = gridNode;
            }
        }

        return output;
    }
}
