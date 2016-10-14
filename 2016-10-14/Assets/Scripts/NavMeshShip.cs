using UnityEngine;
using System.Collections;

public class NavMeshShip : MonoBehaviour {
	
	public GameObject escapeHatch;
	public NavMeshAgent navMeshAgent;
	public GameObject target1;
	public GameObject target2;

	public GameObject [] spawnList;
	private bool hasSpawned = false;

	void Start () 
	{
		navMeshAgent.SetDestination (target1.transform.position);
	}
	
	void Update () 
	{
		if (navMeshAgent.remainingDistance < .1f)
		{

			if (hasSpawned == false)
			{
				Invoke ("Leave", 3f);
				DropUnits ();

			}
		}
	}

	void DropUnits()
	{
		foreach(GameObject spawn in spawnList)
		{
			hasSpawned = true;

			//GameObject instance = 
			GameObject.Instantiate (spawn, escapeHatch.transform.position, transform.rotation);
			
		}
	}

	void Leave()
	{
		navMeshAgent.SetDestination (target2.transform.position);
	}
}
