using UnityEngine;
using System.Collections;

public class WeaponControl : MonoBehaviour {

	public GameObject rightHand;
	public GameObject leftHand;
	public Gun rightGun;
	public Gun leftGun;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void EquipRight(Gun gun)
	{
		rightGun = gun;
		gun.transform.SetParent (rightHand.transform);
		gun.transform.position = rightHand.transform.position;
		gun.transform.rotation = rightHand.transform.rotation;
	}

	public void EquipLeft(Gun gun)
	{
		leftGun = gun;
		gun.transform.SetParent (leftHand.transform);
		gun.transform.position = leftHand.transform.position;
		gun.transform.rotation = leftHand.transform.rotation;
	}

	public void TryFireWeapons(Vector3 target)
	{
		if(rightGun != null)
			rightGun.TryFire (target);
		if(leftGun != null)
			leftGun.TryFire (target);
	}
}
