using UnityEngine;
using System.Collections;

public class NPCHealth : MonoBehaviour {

	public NavMeshAgent navMeshAgent;
	public float health = 10;

	void Die()
	{
		if (navMeshAgent != null)
			navMeshAgent.enabled = false;
		else
			navMeshAgent = GetComponent<NavMeshAgent> ();

		Invoke ("Die", .5f);
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Attack")
		{
			health -= 2;
			if (health < 0)
			{
				Die ();
			}
		}
	}
}
