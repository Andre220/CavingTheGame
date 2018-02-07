using UnityEngine;
using System.Collections;

public class IA : MonoBehaviour {
	public Transform Player;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		distanceControl();
	}
	void distanceControl()
	{
		float distancePlayer = Vector3.Distance(transform.position, Player.position);
		if(distancePlayer < 100 && distancePlayer > 2) {
			followPlayer(true);
		} else {
			followPlayer(false);
		}
	}
	void followPlayer (bool enabled)
	{
		if(enabled) 
		{
			Vector3 Direcao = (Player.position - transform.position).normalized;
			transform.position += Direcao * Time.deltaTime * 5;
			Quaternion newRotation = Quaternion.LookRotation(Direcao);
			transform.rotation = newRotation;
		} else {
			return;
		}
	}
}
