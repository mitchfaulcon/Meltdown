using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskController : MonoBehaviour
{
    public List<TaskTypes> taskList = new List<TaskTypes>();
    public RubbishBin bin;
    public int rubbishStatus = 0;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("launchTask", 1.0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void launchTask()
    {
        int rand = Random.Range(1,30);
        if (rand == 1)
        {
            if (!(taskList.Contains(TaskTypes.Rubbish)))
            {
                taskList.Add(TaskTypes.Rubbish);
                bin = FindObjectOfType<RubbishBin>();
                bin.fillBin();
                rubbishStatus += 3;
            }
        }

    }

    public void taskComplete(TaskTypes type)
    {
        if (type == TaskTypes.Rubbish)
        {
            rubbishStatus--;
            if (rubbishStatus == 0)
            {
                taskList.Remove(TaskTypes.Rubbish);
            }
        }
    }
}
