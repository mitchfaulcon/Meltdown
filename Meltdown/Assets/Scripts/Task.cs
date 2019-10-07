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

//Task to remove rubbish from main bin into the 3 special bins
public class RubbishTask : Task
{
    public RubbishBin bin;
    private HomeOutDoorBinNPC npc;
    public int rubbishStatus = 0;

    //gets npc to walk to rubbish bin, at which point it will fill the bin
    public override void setupTask()
    {
        npc = FindObjectOfType<HomeOutDoorBinNPC>();
        npc.StartTask(this);
    }

    //get bin to fill with rubbish, and track how much rubbish it has
    public void FillBin() {
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

//Task for planting and watering the different seed types
public class SeedTask : Task
{
    private SeedBox seedBox;
    private TaskTypes seedType;
    public SeedTask(SeedBox seedBox, TaskTypes type)
    {
        this.seedBox = seedBox;
        seedType = type;
    }

    public override void setupTask()
    {
        seedBox.fillSeedBox();
    }

    public override void completeTask()
    {
        controller.removeTask(seedType);
    }


}
