using UnityEngine;
using System.Collections;

public class RayCast : MonoBehaviour {


	public GameObject MouseHit;
	public GameObject Player;
	// Use this for initialization
	void Start () {
	
	

	}
	
	// Update is called once per frame
	void Update () {
		
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast (ray, out hit))
		{	
			//Player.GetComponent<MoveTowards> ().enabled = true;

			MouseHit.SetActive(true);	
			MouseHit.transform.position = hit.point;

			//Accelerate The Player

			MoveTowards MoveScript = Player.GetComponent<MoveTowards> ();
			MoveScript.speed = Mathf.Lerp (MoveScript.speed, MoveScript.MaxSpeed, Time.deltaTime * MoveScript.acceleration);

			Debug.Log ("Cursor On");
		} 

		else 
		
		{
			Debug.Log("Cursor Off");
			MouseHit.SetActive(false);

			//Decelerate the Player

			MoveTowards MoveScript = Player.GetComponent<MoveTowards> ();
			MoveScript.speed = Mathf.Lerp (MoveScript.speed, 0, Time.deltaTime * MoveScript.acceleration);



			//Player.GetComponent<MoveTowards> ().enabled = false;
		}
			//Instantiate (MouseHit, hit.point, Quaternion.identity);
	}
		


}
