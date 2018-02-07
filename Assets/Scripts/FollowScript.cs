using UnityEngine;
using System.Collections;

public class FollowScript : MonoBehaviour 
{

	public GameObject Pivot;

	// Use this for initialization
	void Start () 
	{
		Pivot = GameObject.Find("Pivot");
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position = new Vector3(Pivot.transform.position.x,transform.position.y,Pivot.transform.position.z);
		//transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
	}
}
