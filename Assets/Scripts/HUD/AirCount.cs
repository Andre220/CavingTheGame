using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

//O jogo tem duraçao de 5 horas/G, onde, cada hora correspondem a 1 minuto/R, logo, 5 minutos de jogo, e cada segundo equivale a 1 minuto.
//Cada galao tem 30 Min/G
//Unidades:
// Min/Game - Minutos no game
// Seg/Real - segundos na vida real
// Galao = 30seg/R ou 30Min/G

public class AirCount : MonoBehaviour 
{
	public List<Sprite> AirSprite;//Lista com os sprites da barra de oxigenio

	public List<GameObject> AirTube; // Lista com os gameobjects que contabilizam quantos galoes existem

	public Image renderer;
	
	public float TubeValue;//Valor do galao
	public float CountHour;//Conta as horas in game
	public int MaxAirTube;//Contador que define o valor maximo de galoes que podem ser carregados pelo player. No caso, 2.
	public int AirTubeCount;//Contador que mostra a qntd atual de Tubos de ar.

	// Use this for initialization
	void Start () 
	{
		CountHour = 300f;//Sao 300 segundos, logo, 5 minutos.
		TubeValue = 30;//Sao 30 segundos, logo, 30 minutos dentro do jogo.
		MaxAirTube = 4;// Posso carregar unica e exclusivamente 2 tubos de ar por vez, totalizando cerca de 1 hora.
		AirTubeCount = 4;//Começamos o jogo com 2 tubos de ar.
		renderer = gameObject.GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		CountHour -= Time.deltaTime;
		TubeValue -= Time.deltaTime;

		if (TubeValue < 0 && AirTubeCount == 4)
		{
			TubeValue = 30;
			renderer.sprite = AirSprite [0];
			AirTubeCount -= 1;
			AirTube[3].GetComponent<Image>().enabled = false;
		}
		
		if (TubeValue < 0 && AirTubeCount == 3)
		{
			TubeValue = 30;
			renderer.sprite = AirSprite [0];
			AirTubeCount -= 1;
			AirTube[2].GetComponent<Image>().enabled = false;
		}

		if (TubeValue < 0 && AirTubeCount == 2)
		{
			TubeValue = 30;
			renderer.sprite = AirSprite [0];
			AirTubeCount -= 1;
			AirTube[1].GetComponent<Image>().enabled = false;
		}

		if (TubeValue < 0 && AirTubeCount == 1)
		{
			TubeValue = 30;
			renderer.sprite = AirSprite [0];
			AirTubeCount -= 1;
			AirTube[0].GetComponent<Image>().enabled = false;
		}

		if (TubeValue < 0 && AirTubeCount == 0)
		{
			TubeValue = 30;
			renderer.sprite = AirSprite [0];
			AirTubeCount -= 1;
			Debug.Log ("Player morreu");
		}

		//ifs para testar quanto de ar existe no galao, e caso seja menor que um valor predeterminado, o mostrador diminui seu valor.
		if (TubeValue > 0)
			renderer.sprite = AirSprite [15];
		if (TubeValue > 1.875f)
			renderer.sprite = AirSprite [14];
		if (TubeValue > 3.75f)
			renderer.sprite = AirSprite [13];
		if (TubeValue > 5.625)
			renderer.sprite = AirSprite [12];
		if (TubeValue > 7.5f)
			renderer.sprite = AirSprite [11];
		if (TubeValue > 9.375f)
			renderer.sprite = AirSprite [10];
		if (TubeValue > 11.25f)
			renderer.sprite = AirSprite [9];
		if (TubeValue > 13.125f)
			renderer.sprite = AirSprite [8];
		if (TubeValue > 15)
			renderer.sprite = AirSprite [7];
		if (TubeValue > 16.875f)
			renderer.sprite = AirSprite [6];
		if (TubeValue > 18.75f)
			renderer.sprite = AirSprite [5];
		if (TubeValue > 20.625f)
			renderer.sprite = AirSprite [4];
		if (TubeValue > 22.5f)
			renderer.sprite = AirSprite [3];
		if (TubeValue > 24.375f)
			renderer.sprite = AirSprite [2];
		if (TubeValue > 26.25f)
			renderer.sprite = AirSprite [1];
		if (TubeValue > 28.125f)
			renderer.sprite = AirSprite [0];
	}
}
