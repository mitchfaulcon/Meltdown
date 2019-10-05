using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeOutdoorDogNPC : NPCMovement
{
    private ArrayList nodes = new ArrayList();
    private Transform nextNode;
    private Transform currentNode;
    private Transform prevNode;
    public GameObject toIgnore;

    // Start is called before the first frame update
    void Start()
    {
        waitTime = 0f;
        walking = true;

        // Setup the grid of nodes where the dog can traverse
        nodes.Add(new GridNode(points[0], new Transform[] {points[1], points[8]})); // point0
        nodes.Add(new GridNode(points[1], new Transform[] {points[0], points[7]})); // point3
        nodes.Add(new GridNode(points[2], new Transform[] {points[3], points[7], points[6]})); // point4
        nodes.Add(new GridNode(points[3], new Transform[] {points[8], points[2]})); // point7
        nodes.Add(new GridNode(points[4], new Transform[] {points[1], points[5]})); // dogPoint1
        nodes.Add(new GridNode(points[5], new Transform[] {points[7], points[4], points[6]})); // dogPoint2
        nodes.Add(new GridNode(points[6], new Transform[] {points[2], points[5]})); // dogPoint3
        nodes.Add(new GridNode(points[7], new Transform[] {points[8], points[1], points[5], points[2]})); // dogPoint4
        nodes.Add(new GridNode(points[8], new Transform[] {points[0], points[7], points[3]})); // dogPoint5

        nextNode = points[1]; // Start at point3
        currentNode = null;
        prevNode = null;
    }

    // Update is called once per frame
    void Update()
    {
        // Check that dog is near or at the point before randomly selecting the next target node
        if (Vector3.Distance(transform.position, nextNode.position) < 1.0f) {
            prevNode = currentNode;
            currentNode = nextNode;
            nextNode = GetCurrentGridNode().GetRandomNode(prevNode);    
        }
    }

    void FixedUpdate() {
        MovePlayer(nextNode.position);
        SetRotation(nextNode.position - transform.position);
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
            if (gridNode.IsNode(nextNode)) {
                output = gridNode;
            }
        }

        return output;
    }
}
