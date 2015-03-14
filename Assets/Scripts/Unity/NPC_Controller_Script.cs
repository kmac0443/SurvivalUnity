using UnityEngine;
using System.Collections;

public class NPC_Controller_Script : MonoBehaviour {

	bool facingRight = true;
	Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> () as Animator;
		StartCoroutine ("RandomMovement");
	}

	private IEnumerator RandomMovement()
	{
		while (true) {
			yield return new WaitForSeconds((float)(Random.Range(2, 5)));
			int move = Random.Range (0, 4);
			switch(move)
			{
				case 0:
					animator.SetTrigger("Move_Forward");
					break;
				case 1:
					if(!facingRight) {
						Flip ();
					}
					animator.SetTrigger("Move_Left");
					break;
				case 2:
					if(facingRight){
						Flip ();
					}
					animator.SetTrigger("Move_Right");
					break;
					
				case 3:
					animator.SetTrigger("Move_Back");
					break;
				case 4:
					Debug.Log ("Whoops");
					break;
			}
		}
	}

	void Flip() 
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
