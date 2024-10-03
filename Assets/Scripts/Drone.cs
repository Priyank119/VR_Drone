using UnityEngine;
//using UnityEngine.XR.Interaction.Toolkit.Filtering;

public class Drone : MonoBehaviour
{
    public HandController _HandController;
    public GameObject droneCamera;
    public GameObject playerCamera;
    int camIndex;
    public float speed = 5f;
    public float droneMaxHight = 10f;

    //set camera index and switch camera
    public void switchCamera()
    {
        if (camIndex == 0)
        {
            droneCamera.tag = "MainCamera";
            playerCamera.tag = "Untagged";
            camIndex = 1;
        }
        else if (camIndex == 1)
        {
            playerCamera.tag = "MainCamera";
            droneCamera.tag = "Untagged";
            camIndex = 0;
        }
    }

    //drone going to takeoff and taking height
    private void takeOff()
    {
        if (transform.position.z >= 0 && transform.position.z <= droneMaxHight)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, _HandController.getRightTriggerValue * speed, 0);
        }
    }

    //drone movement in X and Z Axis
    private void movement()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(_HandController.getRightThumbValue.x, 0, _HandController.getRightThumbValue.y);
    }

    //drone going to lend
    private void Lending()
    {
        if (transform.position.z > 0 && transform.position.z <= droneMaxHight)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, _HandController.getRightTriggerValue * speed * -1f, 0);
        }
    }

    private void Update()
    {
        movement();
        takeOff();
        Lending();
    }
}