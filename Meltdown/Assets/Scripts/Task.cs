using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour
{
    public TaskController controller = FindObjectOfType<TaskController>();
    public virtual void setupTask()
    {

    }

    public virtual void completeTask()
    {

    }
}

public class RubbishTask : Task
{
    public RubbishBin bin;
    public int rubbishStatus = 0;

    public override void setupTask()
    {
        bin = FindObjectOfType<RubbishBin>();
        bin.fillBin();
        rubbishStatus = 3;
    }

    public override void completeTask()
    {
        rubbishStatus--;
        if (rubbishStatus == 0)
        {
            controller.removeTask(TaskTypes.Rubbish);
        }
    }
}

public class SeedTask : Task
{
   //seed task will go here
}
