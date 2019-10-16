using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinSelectScript : MonoBehaviour
{
    public Material defaultSkin;
    public SkinnedMeshRenderer displaySkin;
    public GameObject displayModel;
    public Material[] skins;

    private int currentSkin = 0;
    private float rotateSpeed = 70f;
    private bool rotateLeft = false;
    private bool rotateRight = false;

    // Start is called before the first frame update
    void Start()
    {
        //Make sure skin is not null
        if (GameSettings.playerSkin == null)
        {
            GameSettings.playerSkin = defaultSkin;
        }
        displaySkin.material = GameSettings.playerSkin;
    }

    private void Update()
    {
        if (rotateLeft)
        {
            RotateLeft();
        }
        if (rotateRight)
        {
            RotateRight();
        }
    }

    public void PreviousSkin()
    {
        currentSkin--;

        //Wrap around if index drops below 0
        if (currentSkin < 0)
        {
            currentSkin = skins.Length - 1;
        }

        updateModel();
    }

    public void NextSkin()
    {
        currentSkin++;

        //Wrap around if index goes above length of array
        if (currentSkin >= skins.Length)
        {
            currentSkin = 0;
        }

        updateModel();
    }

    private void updateModel()
    {
        //Change selected model to new index
        GameSettings.playerSkin = skins[currentSkin];
        displaySkin.material = GameSettings.playerSkin;
    }

    public void StartLeftRotation()
    {
        rotateLeft = true;
    }

    public void StopLeftRotation()
    {
        rotateLeft = false;
    }

    public void StartRightRotation()
    {
        rotateRight = true;
    }

    public void StopRightRotation()
    {
        rotateRight = false;
    }

    private void RotateLeft()
    {
        displayModel.transform.Rotate(0f, rotateSpeed * Time.deltaTime, 0f);
    }

    private void RotateRight()
    {
        displayModel.transform.Rotate(0f, -rotateSpeed * Time.deltaTime, 0f);
    }
}
