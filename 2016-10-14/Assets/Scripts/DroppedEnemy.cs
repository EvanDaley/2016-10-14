using UnityEngine;
using System.Collections;

public class DroppedEnemy : MonoBehaviour {

	public EnemyAI ai;
	public bool hasAdded = false;

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.layer == 11 && hasAdded == false)
		{
			NavMeshAgent navMeshAgent = gameObject.AddComponent<NavMeshAgent> ();
			ai.navMeshAgent = navMeshAgent;
			hasAdded = true;

			navMeshAgent.stoppingDistance = 1f;
		}
	}
}
