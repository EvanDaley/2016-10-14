using UnityEngine;
using System.Collections;

public class NavmeshPlayer : MonoBehaviour {

	public int previousWaypoint;
	public NavMeshAgent agent;
	private int movementStatus = 0;


	void Start()
	{
		agent.updateRotation = false;
	}

	public void SetCycle(int status)
	{
		movementStatus = status;
		UpdatePath ();
	}

	void UpdatePath()
	{
		if (movementStatus == 0)
		{
			agent.SetDestination (transform.position);
		}
		else if (movementStatus == 1)
		{
			Waypoint nextPos = WaypointManager.Instance.FindNextWaypointForward (previousWaypoint);
			if(nextPos != null)
				agent.SetDestination (nextPos.transform.position);
		}
		else if (movementStatus == 2)
		{
			Waypoint nextPos = WaypointManager.Instance.FindNextWaypointBackward (previousWaypoint);
			if(nextPos != null)
				agent.SetDestination (nextPos.transform.position);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 10)
		{
			Waypoint waypoint = other.GetComponent<Waypoint> ();
			if (waypoint != null)
			{
				if(movementStatus == 1 && previousWaypoint < waypoint.value)
					previousWaypoint = waypoint.value;

				if(movementStatus == 2 && previousWaypoint > waypoint.value)
					previousWaypoint = waypoint.value;
			}
			
			UpdatePath ();
		}
	}

	void Update()
	{
		// look toward position that we are shooting at
		//FaceTarget (Vector3.zero);
	}
}

