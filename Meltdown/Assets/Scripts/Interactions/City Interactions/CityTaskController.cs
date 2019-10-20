using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityTaskController : TaskController
{

    public GameObject[] solarTasks = new GameObject[4];
    public GameObject[] signTasks= new GameObject[4];
    public GameObject[] bikeTasks = new GameObject[4];

    public ResourceCollector solarShop;
    public ResourceCollector signShop;
    public BikeShop bikeShop;

    public bool readyForBikeTask;

    protected override void loadTasks()
    {
        //add different task types to our task dictionary
        tasks.Add(TaskTypes.Solar, new SolarTask(solarShop));
        tasks.Add(TaskTypes.Bike, new BikeTask(bikeShop, this));
        tasks.Add(TaskTypes.Sign, new SignTask(signShop));
    }

    protected override void setupRepeatingTasks()
    {
        // Continually generate tasks
        InvokeRepeating("checkForNewTask", 1.0f, 0.5f);
    }

    protected override void checkForNewTask()
    {
        //update time count, and if it reaches the time set to generate a new task at, do so.
        if ((!taskList.Contains(TaskTypes.Bike) && readyForBikeTask) || taskList.Count < maxTasks)
        {
            timeCount += 0.5f;
            if (timeCount >= newTaskTime)
            {
                addTask();
            }
        }

    }

    //generates a new task from enum TaskTypes, based on rng
    protected override TaskTypes generateTask()
    {
        int newTask = Random.Range(10, 13);
        TaskTypes generatedTask = (TaskTypes)System.Enum.Parse(typeof(TaskTypes), newTask.ToString());

        //Ensure bike task does not get generated if bikeNPC is not at start point
        if (!CityBikeNPC.atInitialPoint && generatedTask.Equals(TaskTypes.Bike))
        {
            while (generatedTask.Equals(TaskTypes.Bike))
            {
                newTask = Random.Range(10, 13);
                generatedTask = (TaskTypes)System.Enum.Parse(typeof(TaskTypes), newTask.ToString());
            }
        }
        return generatedTask;
    }


    // Sets all tasks on the Task List UI to hidden (i.e. used to update UI or right at beginning before any tasks have been generated)
    protected override void hideAllUITasks() {
        foreach (GameObject task in solarTasks) {
            task.SetActive(false);
        }
        foreach (GameObject task in signTasks) {
            task.SetActive(false);
        }
        foreach (GameObject task in bikeTasks) {
            task.SetActive(false);
        }
    }


    // Updates the Task List UI on the level every time a new task is generated or completed
    protected override void updateUI () {
        hideAllUITasks();
        int i = 0;
        foreach (TaskTypes type in taskList) {
            switch (type) {
                case TaskTypes.Solar:
                    solarTasks[i].SetActive(true);
                    break;
                case TaskTypes.Sign:
                    signTasks[i].SetActive(true);
                    break;
                case TaskTypes.Bike:
                    bikeTasks[i].SetActive(true);
                    break;
            }
            i++;
        }
    }

    public void readyForBike()
    {
        readyForBikeTask = !readyForBikeTask;
    }
}
