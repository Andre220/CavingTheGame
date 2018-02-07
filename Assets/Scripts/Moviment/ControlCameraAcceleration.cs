
using UnityEngine;
using System.Collections;

/*
Replace this camera with the Durovis Dive camera to work on an actual Cardboard.
*/
public class ControlCameraAcceleration : MonoBehaviour 
{
  	public float lookSpeed;
	public float areaCentral;

	public Vector3 dir; // o sensor (mouse/acceleration)
	public Vector3 ana;
	public Vector3 amanda;

	public bool usedMouse;

	public GUIStyle customText;

  void Update () 
	{
		if (dir.sqrMagnitude > 1)
			dir.Normalize();

		//para testar na unity
		if(usedMouse)
		{
			dir = Input.mousePosition;
			dir.x -= Screen.width/2;
			dir.y -= Screen.height/2;

			ana.x = dir.x;
			ana.y = -dir.y;
		}else//para compilar
		{
			dir = Input.acceleration;
			ana.x = -dir.x;
			ana.y = dir.y;
		}

		if(ana != amanda)//Caso o vector3 Ana(Dir) seja diferente do vector3 amanda(vector 3 que segue a ana) - a logica da ana e amanda, testa se o player parou de se mover, caso sim, a camera para de se mover, caso não, ela continua seu movimento
		{
			if(dir.x < -areaCentral || dir.x > areaCentral)// rotacionando a camera no eixo X - traduçao - estamos olhando para cima e para baixo (caso acceleration.x esteja a esquerda da area central ou esteja a direita da area central )
			{				
				transform.RotateAround(transform.position, new Vector3(0, ana.x,0), lookSpeed * Time.deltaTime);
			}
			

			if(dir.y < -areaCentral || dir.y > areaCentral )
			{			
				transform.RotateAround(transform.position, new Vector3(ana.y, 0,0), lookSpeed * Time.deltaTime);
			}
		}

		amanda = Vector3.Slerp(amanda, ana,Time.deltaTime);//amanda seguindo ana - caso amanda esteja na mesma posiçao que ana, a camera para de se mover (o player parou)
	
  }
	void OnGUI()
	{
		GUI.Label (new Rect((Screen.width/2)-100, Screen.height/2, 100, 100), "ANA.X: " + ana.x, customText);
		GUI.Label (new Rect((Screen.width/2)-100, (Screen.height/2) + 25, 100, 100), "ANA.Y: " + ana.y, customText);
		GUI.Label (new Rect((Screen.width/2)+25, Screen.height/2, 100, 100), "AMANDA.X: " + amanda.x, customText);
		GUI.Label (new Rect((Screen.width/2)+25, (Screen.height/2) + 25, 100, 100), "AMANDA.Y: " + amanda.y, customText);
	}
}
