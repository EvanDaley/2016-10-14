using UnityEngine;
using System.Collections;
using Lean.Touch;

public class Targetting : MonoBehaviour {

	public LayerMask possibleTargetsMask;
	public NavmeshPlayer player;
	public WeaponControl weaponControl;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	protected virtual void OnEnable()
	{
		LeanTouch.OnFingerDown += HandleTouch;
	}

	protected virtual void OnDisable()
	{
		LeanTouch.OnFingerDown -= HandleTouch;
	}

	public void HandleTouch(LeanFinger finger)
	{
		if (LeanTouch.GuiInUse)
		{
			// the user touched a button, do nothing
		} else
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (finger.ScreenPosition);
			if (Physics.Raycast (ray, out hit, 100, possibleTargetsMask))
			{
				Attack (hit.point);
			}
		}
	}

	public void Attack(Vector3 target)
	{
		FaceTarget (target);
		weaponControl.TryFireWeapons (target);
	}

	public void FaceTarget(Vector3 target)
	{
		target = new Vector3(target.x, transform.position.y, target.z);
		transform.LookAt (target);
	}
}
