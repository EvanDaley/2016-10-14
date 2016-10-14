using UnityEngine;
using System.Collections;

public class NavMeshShip : MonoBehaviour {

	public NavMeshAgent navMeshAgent;
	public GameObject target1;
	public GameObject target2;

	public GameObject [] spawnList;
	public GameObject escapeHatch;

	void Start () 
	{
		navMeshAgent.SetDestination (target1.transform.position);
	}
	
	void Update () 
	{
		if (navMeshAgent.remainingDistance < .1f)
		{
			Invoke ("Leave", 1f);
		}
	}


	void Leave()
	{
		navMeshAgent.SetDestination (target2.transform.position);
	}
}
