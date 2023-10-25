using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Camera WaiterCam;
    public Camera ChefCam;
    public Camera ManagerCam;
    SwitchingCharacter switching;
    // Start is called before the first frame update
    void Start()
    {
        switching = GetComponent<SwitchingCharacter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
