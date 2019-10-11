using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleItem : InteractableObjectBase
{
    public bool on;
    private ItemTypes playerHolding;
    public bool isLight;
    public TaskTypes task;
    public TaskController taskControl;

    // Start is called before the first frame update
    private void Start()
    {
        taskControl = FindObjectOfType<TaskController>();
    }

    public override ItemTypes OnInteract()
    {
        Debug.Log("Turning off light");
        on = false;
        if (isLight)
        {
            //code here to disable light in room
        }
        else
        {
            this.transform.Find("Water").gameObject.SetActive(false);
            this.transform.Find("SinkWater").gameObject.SetActive(false);
        }
        taskControl.taskComplete(task);
        return playerHolding;
    }

    // Update is called once per frame
    public override bool CanInteract(ItemTypes item)
    {
        return on;
    }

    public void fill()
    {
        on = true;
        if(task == TaskTypes.Tap)
        {
            this.transform.Find("Water").gameObject.SetActive(true);
            this.transform.Find("SinkWater").gameObject.SetActive(true);
        }
        else
        {
            //set light on here
        }
    }
}
