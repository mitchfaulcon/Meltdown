using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeIndoorNPC : NPCMovement
{
    private static int NUM_TASKS = 5;
    public Transform starting;
    public Transform standing;
    public Transform top;
    public Transform lightSwitchRight;
    //public Transform lightSwitchRight2;
    //public Transform lightSwitchRight3;
    public Transform lightSwitchLeft;
    //public Transform lightSwitchLeft2;
    //public Transform lightSwitchLeft3;
    public Transform bottom;
    public Transform sink;
    public Transform stoolJunction;
    public Transform stool1;
    public Transform stool2;
    public Transform stool3;
    public Transform stool4;
    
    private List<Transform> stools = new List<Transform>();

    private HomeIndoorRoutes prevRoute;
    private HomeIndoorRoutes curRoute;

    private Transform dest;

    public TaskController taskController;

    public bool placeHolderFull;

    public bool served; // Boolean to check if the player has served the NPC a salad
    private bool couchSwitch;
    private float couchTimer = 0.0f;

    private bool stoolReached;
    private bool couchReached;
    void Start()
    {
        // Set the default starting point to the couch
        prevRoute = HomeIndoorRoutes.Couch; 
        curRoute = HomeIndoorRoutes.Couch;
        dest = starting;
        points = new Transform[] {starting};

        SetWalking(true);
        placeHolderFull = false;
        served = false;
        couchSwitch = false;

        // Purpose of reached boolean is because unity changes the value
        // of the vector distance between player and point. It may pass
        // the "if" condition in one frame but fail the next. Therefore we
        // add a boolean to trigger it independent of whether the "if" condition
        // is passed.
        stoolReached = false;
        couchReached = false;

        stools.Add(stool1);
        stools.Add(stool2);
        stools.Add(stool3);
        stools.Add(stool4);

        //taskController = FindObjectOfType<TaskController>();
    }

    void Update()
    {
        // If the player has reached the destination
        if (Vector3.Distance(transform.position, dest.position) < 1.0f) {
            // If the NPC is at one of the stools, stop moving
            if (curRoute == HomeIndoorRoutes.Stool) {
                stoolReached = true;
            } else if (couchSwitch) {
                couchReached = true;  
            } else {
                NextRoute();
            }            
        }

        if (stoolReached) {
            // Start walking once the NPC has been served a salad
            if (served) {
                SetWalking(true);
                NextRoute();
                served = false;
                stoolReached = false;
            } else {
                SetWalking(false);
            }
        }

        if (couchReached) {
            SetWalking(false);
            couchTimer += Time.deltaTime;
                    
            if (couchTimer > 5.0f) {
                couchTimer = 0.0f;
                      
                couchSwitch = false;
                couchReached = false;
                SetWalking(true);
            }               
        }

        Wait();
    }

    public void serve() {
        served = true;
    }

    private void NextRoute() {
        HomeIndoorRoutes destination;
        // Set the route to the couch if the task list is full, otherwise select a random route
        if (placeHolderFull) {
        destination = HomeIndoorRoutes.Couch;
        } else {
            destination = RandomRoute();
        }

        points = ConstructRoute(destination);
    }

    private HomeIndoorRoutes RandomRoute() {
        // Get a random route
        HomeIndoorRoutes nextRoute = RouteMethods.GetRoute(Random.Range(0, NUM_TASKS));

        // If the next route is the same as the last, retry
        if (nextRoute == prevRoute) {
            return RandomRoute();
        } else {
            prevRoute = curRoute;
            curRoute = nextRoute;

            // Set the destination point
            switch(curRoute) {
                case HomeIndoorRoutes.LightSwitchLeft: 
                    dest = lightSwitchLeft;
                    break;
                case HomeIndoorRoutes.LightSwitchRight:
                    dest = lightSwitchRight;
                    break;
                case HomeIndoorRoutes.Sink:
                    dest = sink;
                    break;
                case HomeIndoorRoutes.Couch:
                    dest = starting;
                    couchSwitch = true;
                    break;
            }
            return curRoute;
        }
    }

    // We know that RNG selected to have the NPC sit on a stool.
    // This method randomly selects which stool.
    private Transform RandomStool() {
        int num = Random.Range(0, stools.Count);
        Transform stool = stools[num];

        // Set the dest depending on which stool was randomly selected
        switch(num) {
            case 0:
                dest = stool1;
                break;
            case 1:
                dest = stool2;
                break;
            case 2:
                dest = stool3;
                break;
            case 3:
                dest = stool4;
                break;
        }

        return stool;
    }

    // Method which exhausts all possible path options for the NPC
    // Depending on which route the NPC just completed
    private Transform[] ConstructRoute(HomeIndoorRoutes nextRoute) {
        spot = 0;

        // All possible previous routes will have a switch/case statement
        // which will contain all next routes.
        switch(prevRoute) {
        case HomeIndoorRoutes.LightSwitchLeft: 
            switch (nextRoute) {
                case HomeIndoorRoutes.LightSwitchRight:
                    return new Transform[] {lightSwitchRight};
                    break;
                case HomeIndoorRoutes.Stool:
                    return new Transform[] {RandomStool()};
                    break;
                case HomeIndoorRoutes.Sink:
                    return new Transform[] {stoolJunction, sink};
                    break;
                case HomeIndoorRoutes.Couch:
                    return new Transform[] {top, standing, starting};
                    break;
            }
            break;
        case HomeIndoorRoutes.LightSwitchRight: 
            switch(nextRoute) {
                case HomeIndoorRoutes.LightSwitchLeft:
                    return new Transform[] {lightSwitchLeft};
                    break;
                case HomeIndoorRoutes.Stool:
                    return new Transform[] {RandomStool()};
                    break;
                case HomeIndoorRoutes.Sink:
                    return new Transform[] {top, bottom, sink};
                    break;
                case HomeIndoorRoutes.Couch:
                    return new Transform[] {standing, starting};
                    break;
            }
            break;
        case HomeIndoorRoutes.Stool: 
            switch(nextRoute) {
                case HomeIndoorRoutes.LightSwitchLeft:
                    return new Transform[] {lightSwitchLeft};
                    break;
                case HomeIndoorRoutes.LightSwitchRight:
                    return new Transform[] {lightSwitchRight};;
                    break;
                case HomeIndoorRoutes.Sink:
                    return new Transform[] {stoolJunction, sink};
                    break;
                case HomeIndoorRoutes.Couch:
                    return new Transform[] {stoolJunction, bottom, standing, starting};
                    break;
            }
            break;
        case HomeIndoorRoutes.Sink: 
            switch(nextRoute) {
                case HomeIndoorRoutes.LightSwitchLeft:
                    return new Transform[] {stoolJunction, lightSwitchLeft};
                    break;
                case HomeIndoorRoutes.LightSwitchRight:
                    return new Transform[] {bottom, top, lightSwitchRight};
                    break;
                case HomeIndoorRoutes.Stool:
                    return new Transform[] {stoolJunction, RandomStool()};
                    break;
                case HomeIndoorRoutes.Couch:
                    return new Transform[] {stoolJunction, bottom, standing, starting};
                    break;
            }
            break;
        case HomeIndoorRoutes.Couch:
            switch(nextRoute) {
                case HomeIndoorRoutes.LightSwitchLeft:
                    return new Transform[] {standing, top, lightSwitchLeft};
                    break;
                case HomeIndoorRoutes.LightSwitchRight:
                    return new Transform[] {standing, top, lightSwitchRight};
                    break;
                case HomeIndoorRoutes.Stool:
                    return new Transform[] {standing, bottom, stoolJunction, RandomStool()};
                    break;
                case HomeIndoorRoutes.Sink:
                    return new Transform[] {standing, bottom, stoolJunction, sink};
                    break;
            }
            break;
        }

        // For compilation's sake. "prevRoute" should always have a value
        return new Transform[] {dest};
    }
}
