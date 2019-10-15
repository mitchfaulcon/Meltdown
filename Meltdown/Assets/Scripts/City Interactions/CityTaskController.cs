using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityTaskController : TaskController
{

    //public GameObject[] SolarTasks = new GameObject[4];
    //public GameObject[] SignTasks= new GameObject[4];
    //public GameObject[] BikeTasks = new GameObject[4];

    protected override void loadTasks()
    {
        //add different task types to our task dictionary
        //tasks.Add(TaskTypes.Tap, new TapTask());
        //tasks.Add(TaskTypes.Light1, new LightSwitchTask(leftSwitch, TaskTypes.Light1));
        //tasks.Add(TaskTypes.Light2, new LightSwitchTask(rightSwitch, TaskTypes.Light2));
        //tasks.Add(TaskTypes.Salad, new SaladTask());
        //tasks.Add(TaskTypes.Salad2, new SaladTask());
    }

    protected override void setupRepeatingTasks()
    {
        // Continually generate tasks
        InvokeRepeating("checkForNewTask", 1.0f, 0.5f);
    }

    //generates a new task from enum TaskTypes, based on rng
    protected override TaskTypes generateTask()
    {
        int newTask = Random.Range(5, 10);
        Debug.Log(System.Enum.Parse(typeof(TaskTypes), newTask.ToString()).ToString());
        return (TaskTypes)System.Enum.Parse(typeof(TaskTypes), newTask.ToString());
    }


    // Sets all tasks on the Task List UI to hidden (i.e. used to update UI or right at beginning before any tasks have been generated)
    protected override void hideAllUITasks() {
        //foreach (GameObject task in potatoTasks) {
        //    task.SetActive(false);
        //}
        //foreach (GameObject task in tomatoTasks) {
        //    task.SetActive(false);
        //}
        //foreach (GameObject task in carrotTasks) {
        //    task.SetActive(false);
        //}
        //foreach (GameObject task in treeTasks) {
        //    task.SetActive(false);
        //}
        //foreach (GameObject task in recyclingTasks) {
        //    task.SetActive(false);
        //}
    }


    // Updates the Task List UI on the level every time a new task is generated or completed
    protected override void updateUI () {
        //hideAllUITasks();
        //int i = 0;
        //foreach (TaskTypes type in taskList) {
        //    switch (type) {
        //        case TaskTypes.Tree:
        //            treeTasks[i].SetActive(true);
        //            break;
        //        case TaskTypes.Carrot:
        //            carrotTasks[i].SetActive(true);
        //            break;
        //        case TaskTypes.Potato:
        //            potatoTasks[i].SetActive(true);
        //            break;
        //        case TaskTypes.Tomato:
        //            tomatoTasks[i].SetActive(true);
        //            break;
        //        case TaskTypes.Rubbish:
        //            recyclingTasks[i].SetActive(true);
        //            break;
        //    }
        //    i++;
        //}
    }
}
