using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HomeIndoorRoutes
{
    LightSwitchRight = 0,
    LightSwitchLeft = 1,
    Sink = 2,
    Stool = 3,
    Couch = 4
}
static class RouteMethods
{
    public static HomeIndoorRoutes GetRoute(int num) {
        switch (num) {
            case 0:
                return HomeIndoorRoutes.LightSwitchLeft;
            case 1:
                return HomeIndoorRoutes.LightSwitchRight;
            case 2:
                return HomeIndoorRoutes.Sink;
            case 3:
                return HomeIndoorRoutes.Stool;
            default:
                return HomeIndoorRoutes.Couch;
        }
    } 
}
