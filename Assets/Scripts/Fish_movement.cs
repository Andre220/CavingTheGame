using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Fish_movement : MonoBehaviour 
{
	private List<GameObject> wayPointsList;
	private Transform Player;
	public float speed;

	// Use this for initialization
	void Start () 
	{
		Player = GameObject.FindGameObjectWithTag("Player").transform;
		wayPointsList = new List<GameObject>();

		GameObject [] wayPoints = GameObject.FindGameObjectsWithTag("WayPoint");

		//Player.renderer.material.color = Color.blue;
		//transform.renderer.material.color = Color.red;

		foreach(GameObject newWayPoint in wayPoints) 
		{
			wayPointsList.Add(newWayPoint);

		
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Follow();

		GameObject wayPoint = null;
		
		if (Physics.Linecast(transform.position, Player.transform.position))
		{
			wayPoint = FindbetterWay();
		} 
		else
		{
			wayPoint = GameObject.FindGameObjectWithTag("Player");
			Debug.Log("ae porra");
		}
		
		Vector3 Dir = (wayPoint.transform.position - transform.position).normalized;
		transform.position += Dir * Time.deltaTime * speed;
		transform.rotation = Quaternion.LookRotation(Dir);
	}
	GameObject FindbetterWay ()
	{
		GameObject betterWay = null;
		float distanceToBetterWay = Mathf.Infinity;
		
		foreach(GameObject go in wayPointsList) 
		{
			float distToWayPoint = Vector3.Distance(transform.position, go.transform.position);
			float distWayPointToTarget = Vector3.Distance(go.transform.position, Player.position);
			float distToTarget = Vector3.Distance(transform.position, Player.position);
			bool wallBetween = Physics.Linecast(transform.position, go.transform.position);
			
			if ((distToWayPoint < distanceToBetterWay) && (distToTarget > distWayPointToTarget)  && (!wallBetween))
			{
				distanceToBetterWay = distToWayPoint;
				betterWay = go;
			} else 
			{
				bool wayPointToTargerCollision = Physics.Linecast(go.transform.position, Player.position);
				if(!wayPointToTargerCollision)
				{
					betterWay = go;
				}
				
			}
		}
		return betterWay;
	}
	/*void Follow ()
	{
		GameObject wayPoint = null;

		if (Physics.Linecast(transform.position, Player.transform.position))
		{
			wayPoint = FindbetterWay();
		} 
		else
		{
			wayPoint = Player;//GameObject.FindGameObjectWithTag("Player");
			Debug.Log("ae porra");
		}

		Vector3 Dir = (wayPoint.transform.position - transform.position).normalized;
		transform.position += Dir * Time.deltaTime * speed;
		transform.rotation = Quaternion.LookRotation(Dir);
	}
	GameObject FindbetterWay () 
	{
		GameObject betterWay = null;
		float distanceToBetterWay = Mathf.Infinity;

		foreach(GameObject go in wayPointsList) 
		{
			float distToWayPoint = Vector3.Distance(transform.position, go.transform.position);
			float distWayPointToTarget = Vector3.Distance(go.transform.position, Player.transform.position);
			float distToTarget = Vector3.Distance(transform.position, Player.transform.position);
			bool wallBetween = Physics.Linecast(transform.position, go.transform.position);

			if ((distToWayPoint < distanceToBetterWay) && (distToTarget > distWayPointToTarget)  && (!wallBetween))
			{
				distanceToBetterWay = distToWayPoint;
				betterWay = go;
			} else 
			{
				bool wayPointToTargerCollision = Physics.Linecast(go.transform.position, Player.transform.position);
					if(!wayPointToTargerCollision)
					{
						betterWay = go;
					}

			}

		}
		return betterWay;

	}*/
}