using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCameraFollow : MonoBehaviour 
{
	[SerializeField]
	private Camera mainCamera;


	private Vector3 startingPosition;
	public Transform followTarget;
	private Vector3 targetPos;
	public float moveSpeed;

	public bool isDeploy;

	void Start()
	{ 
		startingPosition = transform.position;
		isDeploy = false;
	}

	void Update () 
	{
		if(!isDeploy)
		{
			targetPos = new Vector3(followTarget.position.x, followTarget.position.y, transform.position.z);
			Vector3 velocity = (targetPos - transform.position) * moveSpeed;
			transform.position = Vector3.SmoothDamp (transform.position, targetPos, ref velocity, 1.0f, Time.deltaTime);
			mainCamera.orthographicSize = 3.5f;
		}
		else
        {
			transform.position = new Vector3(0,0,-5);
			mainCamera.orthographicSize = 6.5f;
        }
	}
}

