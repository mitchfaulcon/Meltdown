using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskController : MonoBehaviour
{
    public List<TaskTypes> taskList = new List<TaskTypes>();
    //equivalent to map
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
    

    // Start is called before the first frame update
    void Start()
    {
        hideAllUITasks();
        tasks.Add(TaskTypes.Rubbish, new RubbishTask());
        tasks.Add(TaskTypes.Carrot, new SeedTask(carrotBox, TaskTypes.Carrot));
        tasks.Add(TaskTypes.Tree, new SeedTask(treeBox, TaskTypes.Tree));
        tasks.Add(TaskTypes.Potato, new SeedTask(potatoBox, TaskTypes.Potato));
        tasks.Add(TaskTypes.Tomato, new SeedTask(tomatoBox, TaskTypes.Tomato));

        // Initial Task
        TaskTypes task = generateTask();
        taskList.Add(task);
        updateUI();
        Debug.Log("starting new task of: " + task.ToString());
        tasks[task].setupTask();

        // Continually generate tasks
        InvokeRepeating("launchTask", 1.0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void launchTask()
    {
        int rand = Random.Range(1,25);
        if (rand == 1)
        {
            if (taskList.Count < 3){
                //generates a new task for the player that isn't currently in their task list
                TaskTypes task = generateTask();
                while (taskList.Contains(task)){
                    task = generateTask();
                }
                //adds task to current task list, then calls the tasks setup method.
                taskList.Add(task);
                updateUI();
                Debug.Log("starting new task of: " + task.ToString());
                tasks[task].setupTask();
                //code to make call to add to HUD could go here
            }
        }

    }

    public void taskComplete(TaskTypes type)
    {
        tasks[type].completeTask();
        Debug.Log("Completed task: " + type.ToString());
    }

    private TaskTypes generateTask()
    {
        int newTask = Random.Range(0, 7);
        if (newTask > 4) { newTask = 4; } //allows x3 chance of getting rubbish task vs any individual seed
        return (TaskTypes)System.Enum.Parse(typeof(TaskTypes), newTask.ToString());
    }

    public void removeTask(TaskTypes task)
    {
        taskList.Remove(task);
        updateUI();
    }

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
