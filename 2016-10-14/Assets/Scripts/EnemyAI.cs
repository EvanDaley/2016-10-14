using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	public Tag myTag;
	public NavMeshAgent navMeshAgent;
	public float checkTargetCooldown;
	public float checkTargetInterval = 2f;
	
	void Update () 
	{
		if (navMeshAgent != null && Time.time > checkTargetCooldown)
		{
			checkTargetCooldown = Time.time + checkTargetInterval;

			Tag target = Tracker.Instance.GetClosestEnemy (myTag);

			if (target != null && navMeshAgent.enabled)
				navMeshAgent.SetDestination (target.transform.position);
		}
	}
}
