using UnityEngine;
using System.Collections;

/*
 * Have this object (the camera) follow another object (the player).
 * 
 * The radius setting determines how far the tracked object can move before
 * the tracking object adjusts.
 */
public class FollowObject : MonoBehaviour {
	/* The tag of the object to follow */
	public Transform target;

	/* How far back the tracking object (camera) sits from the scene */
	public Vector3 offset = new Vector3(0, 0, -1);

	/* The radius in which the player can move before the camera adjusts */
	public float radius = 1.0f;
	

	void Update() {
		Vector3 difference = transform.position - target.position;
		difference.z = 0;

		if (difference.magnitude > radius) {
			transform.position = target.position + offset + difference.normalized * radius;
		}
	}

	void OnValidate() {
		if (target == null) {
			GameObject player = GameObject.Find("Player");
			if (player != null) target = player.transform;
		}

		if (target != null) Update();
	}
}
