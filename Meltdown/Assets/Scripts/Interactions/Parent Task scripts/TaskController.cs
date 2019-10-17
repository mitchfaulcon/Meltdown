using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TaskController : MonoBehaviour
{
    public static List<TaskTypes> taskList = new List<TaskTypes>();
    
    public Dictionary<TaskTypes, Task> tasks = new Dictionary<TaskTypes, Task>();

    protected float timeCount = 0.0f;
    protected float newTaskTime = 0.0f;
    public static int maxTasks = 4;
    

    // Start is called before the first frame update
    void Start()
    {
        taskList.Clear();
        updateUI();
        hideAllUITasks();

        //add different task types to our task dictionary
        loadTasks();

        // Generate initial Task
        TaskTypes task = generateTask();
        generateTaskTime();
        taskList.Add(task);
        updateUI();
        tasks[task].setupTask();

        // Continually generate tasks
        setupRepeatingTasks();
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected virtual void checkForNewTask()
    {
        //update time count, and if it reaches the time set to generate a new task at, do so.
        if (taskList.Count < maxTasks)
        {
            timeCount += 0.5f;
            if (timeCount >= newTaskTime)
            {
                addTask();
            }
        }

    }

    // Add a task to the task list
    protected void addTask()
    {
         TaskTypes task = generateTask();
         while (taskList.Contains(task))
         {
            task = generateTask();
         }
         taskList.Add(task);
         updateUI();
         tasks[task].setupTask();

         generateTaskTime();
    }

    protected abstract void loadTasks();

    protected abstract void setupRepeatingTasks();

    public void taskComplete(TaskTypes type)
    {
        tasks[type].completeTask();
    }

    //resets count for time til new task, and generates a new time for when next task should be made
    protected virtual void generateTaskTime() 
    {
        timeCount = 0.0f;
        newTaskTime = Random.Range(5.0f, 12.0f);
    }

    //generates a new task from enum TaskTypes, based on rng
    protected abstract TaskTypes generateTask();

    public void removeTask(TaskTypes task)
    {
        taskList.Remove(task);
        updateUI();

        if (taskList.Count < 1) {
            addTask();
        }
    }

    // Sets all tasks on the Task List UI to hidden (i.e. used to update UI or right at beginning before any tasks have been generated)
    protected abstract void hideAllUITasks();


    // Updates the Task List UI on the level every time a new task is generated or completed
    protected abstract void updateUI();
}
