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
        HomeOutDoorBinNPC npc = FindObjectOfType<HomeOutDoorBinNPC>();
        npc.SetTask(this);
        npc.SetWalking(true);
    }

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
