using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class HealtCount : MonoBehaviour 
{
	public List<Sprite> HealtSprite;//Lista com os sprites da barra de vida
	public float HealtValue;//Valor da vida
	public Image renderer;

	public static HealtCount instance;
	
	// Use this for initialization
	void Start () 
	{
		HealtValue = 3;
		renderer = gameObject.GetComponent<Image>();
		instance = this;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.I))
		{
			HealtValue -=1;
		}

		if (HealtValue == 3)
			renderer.sprite = HealtSprite [0];
		if (HealtValue == 2)
			renderer.sprite = HealtSprite [1];
		if (HealtValue == 1)
			renderer.sprite = HealtSprite [2];
		if (HealtValue == 0)
			renderer.enabled = false;
	}
}
