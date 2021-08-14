using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    public GameObject ExitTarget;
    public GameObject ExitPopUp;
    public void OnClickExit()
    {
        ExitTarget.SetActive(false);
        if(ExitPopUp != null)
        ExitPopUp.SetActive(false);
    }


    // Start is called before the first frame update
    void Start()
    {
        ExitPopUp = GameObject.Find("PopUp");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
