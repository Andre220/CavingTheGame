using UnityEngine;
using System.Collections;

public class JoystickControl : MonoBehaviour {

	public float rotationX;
	public float rotationY;

	public float movX;
	public float movY;
	public float movZ;

	public float speed;
	public bool usedMouse;

	public KeyCode up;
	public KeyCode down;
	public KeyCode left;
	public KeyCode right;

	public Vector3 dir;
	public GUIStyle customText;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		dir = Input.mousePosition;
		dir.x -= Screen.width/2;
		dir.y -= Screen.height/2;

		if (dir.sqrMagnitude > 1)
			dir.Normalize();
		
		if(!usedMouse)
		{
			//analogico da movimentação
			movX = Input.GetAxis("RightVertical") * speed * Time.deltaTime;
			movY = Input.GetAxis("RightHorizontal") * speed * Time.deltaTime;
			//analogico da rotação
			rotationX = Input.GetAxis("LeftVertical") * speed * Time.deltaTime;
			rotationY = Input.GetAxis("LeftHorizontal") * speed * Time.deltaTime;

			// vai fucnionar NAO MEXER
			transform.Rotate(-rotationX, rotationY, 0);
			transform.Translate(movY, 0, movX);

		}else
		{	
			if(Input.GetMouseButton(0))
			{
				movZ = speed*Time.deltaTime;
			}
			else if(Input.GetMouseButton(1))
			{
				movZ = -speed*Time.deltaTime;
			}
			else
			{
				movZ = 0;
			}
			transform.Translate(movX, movY , movZ);
		}	

		
	
	}
	void OnGUI()
	{
		/*GUI.Label (new Rect((Screen.width/2)-100, Screen.height/2, 100, 100), "RightVertical: " + Input.GetAxis("RightVertical"), customText);
		GUI.Label (new Rect((Screen.width/2)-100, (Screen.height/2) + 25, 100, 100), "RightHorizontal: " + Input.GetAxis("RightHorizontal"), customText);
		GUI.Label (new Rect((Screen.width/2)+25, Screen.height/2, 100, 100), "LeftVertical: " + Input.GetAxis("LeftVertical"), customText);
		GUI.Label (new Rect((Screen.width/2)+25, (Screen.height/2) + 25, 100, 100), "LeftHorizontal: " + Input.GetAxis("LeftHorizontal"), customText);*/
	}
}
