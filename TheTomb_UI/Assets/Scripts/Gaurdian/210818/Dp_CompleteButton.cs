using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dp_CompleteButton : MonoBehaviour
{
    private BasicCameraFollow camera;

    [SerializeField]
    private GameObject[] onObject;
    [SerializeField]
    private GameObject[] offObject;

    private void Awake()
    {
        camera = GameObject.Find("MainCamera").GetComponent<BasicCameraFollow>();
    }

    public void OnClickDeployment()
    {
        if (onObject != null)
        {
            for (int i = 0; i < offObject.Length; i++)
            {
                offObject[i].SetActive(true);
            }
        }
        if (offObject != null)
        {
            for (int i = 0; i < offObject.Length; i++)
            {
                offObject[i].SetActive(false);
            }
        }
        camera.isDeploy = false;
    }

}
