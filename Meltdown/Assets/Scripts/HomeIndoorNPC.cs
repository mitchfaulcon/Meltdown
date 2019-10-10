using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeIndoorNPC : NPCMovement
{

    private List<Transform[]> routes = new List<Transform[]>();
    public Transform[] lightSwitchRight;
    public Transform[] lightSwitchLeft;
    public Transform[] sink;
    public Transform[] plateAB;
    public Transform[] plateCD;

    private Transform prevPoint;

    void Start()
    {
        prevPoint = null;

        // Add all routes to list to be randomly selected from
        routes.Add(lightSwitchRight);
        routes.Add(lightSwitchLeft);
        routes.Add(sink);
        routes.Add(plateAB);
        routes.Add(plateCD);
    }

    void Update()
    {
        
    }
}
