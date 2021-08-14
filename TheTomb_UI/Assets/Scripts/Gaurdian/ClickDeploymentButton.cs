using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDeploymentButton : MonoBehaviour
{
    [SerializeField]
    private GameObject deploymentMenu;
    public void OnClickDeployment()
    {
        deploymentMenu.SetActive(true);
    }
}
