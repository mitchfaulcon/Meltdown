using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutdoorTaskController : TaskController
{

    public GameObject[] potatoTasks = new GameObject[4];
    public GameObject[] treeTasks = new GameObject[4];
    public GameObject[] tomatoTasks = new GameObject[4];
    public GameObject[] carrotTasks = new GameObject[4];
    public GameObject[] recyclingTasks = new GameObject[4];
    

    public SeedBox carrotBox;
    public SeedBox potatoBox;
    public SeedBox treeBox;
    public SeedBox tomatoBox;

    protected override void loadTasks()
    {
        //add different task types to our task dictionary
        tasks.Add(TaskTypes.Rubbish, new RubbishTask());
        tasks.Add(TaskTypes.Carrot, new SeedTask(carrotBox, TaskTypes.Carrot));
        tasks.Add(TaskTypes.Tree, new SeedTask(treeBox, TaskTypes.Tree));
        tasks.Add(TaskTypes.Potato, new SeedTask(potatoBox, TaskTypes.Potato));
        tasks.Add(TaskTypes.Tomato, new SeedTask(tomatoBox, TaskTypes.Tomato));
    }

    protected override void setupRepeatingTasks()
    {
        // Continually generate tasks
        InvokeRepeating("checkForNewTask", 1.0f, 0.5f);
        InvokeRepeating("generateRubbishTask", 1.0f, 0.5f);
    }

    void generateRubbishTask()
    {
        int rand = Random.Range(1, 25);
        if (rand == 1 && taskList.Count<4)
        {
            //Checks if rubbish task is already active, if not, starts the rubbish task
            TaskTypes task = TaskTypes.Rubbish;
            if (!taskList.Contains(task))
            {
                taskList.Add(task);
                updateUI();
                tasks[task].setupTask();
            }
            
        }
    }

    //generates a new task from enum TaskTypes, based on rng
    protected override TaskTypes generateTask()
    {
        int newTask = Random.Range(0, 4);
        return (TaskTypes)System.Enum.Parse(typeof(TaskTypes), newTask.ToString());
    }

    // Sets all tasks on the Task List UI to hidden (i.e. used to update UI or right at beginning before any tasks have been generated)
    protected override void hideAllUITasks() {
        foreach (GameObject task in potatoTasks) {
            task.SetActive(false);
        }
        foreach (GameObject task in tomatoTasks) {
            task.SetActive(false);
        }
        foreach (GameObject task in carrotTasks) {
            task.SetActive(false);
        }
        foreach (GameObject task in treeTasks) {
            task.SetActive(false);
        }
        foreach (GameObject task in recyclingTasks) {
            task.SetActive(false);
        }
    }


    // Updates the Task List UI on the level every time a new task is generated or completed
    protected override void updateUI () {
        hideAllUITasks();
        int i = 0;
        foreach (TaskTypes type in taskList) {
            switch (type) {
                case TaskTypes.Tree:
                    treeTasks[i].SetActive(true);
                    break;
                case TaskTypes.Carrot:
                    carrotTasks[i].SetActive(true);
                    break;
                case TaskTypes.Potato:
                    potatoTasks[i].SetActive(true);
                    break;
                case TaskTypes.Tomato:
                    tomatoTasks[i].SetActive(true);
                    break;
                case TaskTypes.Rubbish:
                    recyclingTasks[i].SetActive(true);
                    break;
            }
            i++;
        }
    }
}
