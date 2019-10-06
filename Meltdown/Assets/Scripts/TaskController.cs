using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskController : MonoBehaviour
{
    public List<TaskTypes> taskList = new List<TaskTypes>();
    // equivalent to map
    public GameObject[] potatoTasks = new GameObject[4];
    public GameObject[] treeTasks = new GameObject[4];
    public GameObject[] tomatoTasks = new GameObject[4];
    public GameObject[] carrotTasks = new GameObject[4];
    public GameObject[] recyclingTasks = new GameObject[4];
    

    public Dictionary<TaskTypes, Task> tasks = new Dictionary<TaskTypes, Task>();
    public SeedBox carrotBox;
    public SeedBox potatoBox;
    public SeedBox treeBox;
    public SeedBox tomatoBox;
    private float timeCount = 0.0f;
    private float newTaskTime = 0.0f;
    

    // Start is called before the first frame update
    void Start()
    {
        hideAllUITasks();

        //add different task types to our task dictionary
        tasks.Add(TaskTypes.Rubbish, new RubbishTask());
        tasks.Add(TaskTypes.Carrot, new SeedTask(carrotBox, TaskTypes.Carrot));
        tasks.Add(TaskTypes.Tree, new SeedTask(treeBox, TaskTypes.Tree));
        tasks.Add(TaskTypes.Potato, new SeedTask(potatoBox, TaskTypes.Potato));
        tasks.Add(TaskTypes.Tomato, new SeedTask(tomatoBox, TaskTypes.Tomato));

        // Generate initial Task
        TaskTypes task = generateTask();
        generateTaskTime();
        taskList.Add(task);
        updateUI();
        tasks[task].setupTask();

        // Continually generate tasks
        InvokeRepeating("checkForNewTask", 1.0f, 0.5f);
        InvokeRepeating("generateRubbishTask", 1.0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void checkForNewTask()
    {
        //update time count, and if it reaches the time set to generate a new task at, do so.
        timeCount += 0.5f;
        if(timeCount >= newTaskTime)
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
    }

    void generateRubbishTask()
    {
        int rand = Random.Range(1, 25);
        if (rand == 1)
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

    public void taskComplete(TaskTypes type)
    {
        tasks[type].completeTask();
    }

    //resets count for time til new task, and generates a new time for when next task should be made
    private void generateTaskTime() 
    {
        timeCount = 0.0f;
        newTaskTime = Random.Range(8.0f, 14.0f);
    }

    //generates a new task from enum TaskTypes, based on rng
    private TaskTypes generateTask()
    {
        int newTask = Random.Range(0, 4);
        return (TaskTypes)System.Enum.Parse(typeof(TaskTypes), newTask.ToString());
    }

    public void removeTask(TaskTypes task)
    {
        taskList.Remove(task);
        updateUI();
    }

    // Sets all tasks on the Task List UI to hidden (i.e. used to update UI or right at beginning before any tasks have been generated)
    private void hideAllUITasks() {
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
    private void updateUI () {
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
