using UnityEngine;
using System.Collections;
using System.Collections.Generic;


enum Criatura{fishOgre, spiderCrab, pistolShrimp};

public class NavMesh : MonoBehaviour 
{	
	public GameObject Player;
	public GameObject destiny;

	public UnityEngine.AI.NavMeshAgent enemy;
	public float timer;
	public Vector3 destination;
	public int numList;
	public float distancePlayer;
	private List<GameObject> wayPointsList;

	//Variaveis de combate
	public float AttackCount;//Contagem regressiva, que quando menor que 0, libera o ataque da criatura;
	public float AttackInitialCount;//Variavel que armazena o valor inicial do AttackCount, assim, quando ele for menor que zero e a criatura atacar, igualamos AttackCount a esta variavel, e a contagem regressiva continua

	//armazenando a distancia entre o player e o Obj do script
	public float realDistancePlayer;
	public bool aleatoryWaker;

	bool wathsWayPontsIs;

	Criatura actions = Criatura.fishOgre;

	void Start () 
	{
		AttackInitialCount = AttackCount;
		//criando Lista de gameObject
		wayPointsList = new List<GameObject>();

		if(gameObject.CompareTag("Fish Ogre"))
		{
			actions = Criatura.fishOgre;
			enemy = transform.parent.gameObject.GetComponentInParent<UnityEngine.AI.NavMeshAgent>();
			GameObject [] wayPoints = GameObject.FindGameObjectsWithTag("WayPoint");
			foreach(GameObject newWayPoint in wayPoints) 
			{
				wayPointsList.Add(newWayPoint);
			}
		}
			else if(gameObject.CompareTag("Spider Crab"))
			{
				actions = Criatura.spiderCrab;
				enemy = GetComponent<UnityEngine.AI.NavMeshAgent>();
				GameObject [] wayPoints = GameObject.FindGameObjectsWithTag("WayPoint");
				foreach(GameObject newWayPoint in wayPoints) 
				{
					wayPointsList.Add(newWayPoint);
				}
			}
				else if(gameObject.CompareTag("Pistol Shrimp"))
				{
					actions = Criatura.pistolShrimp;
					enemy = GetComponent<UnityEngine.AI.NavMeshAgent>();
					GameObject [] wayPoints = GameObject.FindGameObjectsWithTag("WayPointOfThePistolShrimp");
					foreach(GameObject newWayPoint in wayPoints) 
					{
						wayPointsList.Add(newWayPoint);
					}
				}

		destination = enemy.destination;
		Player = GameObject.FindGameObjectWithTag("Player");
	}
	
	void Update () 
	{	
		AttackCount -= Time.deltaTime;
		//Attack ();

		realDistancePlayer = Vector3.Distance(transform.position, Player.transform.position);
		if(!wathsWayPontsIs)/*caso o script esteja num pistolShip essa varialvel se tornara verdadeira, 
			logo o tempo nao tera mais contagem, uma vez que, o pistolShip procura um abrigo, ou inves de andar aliatoriamente como os demais*/
		{
			timer -= Time.deltaTime;
		}
		FollowAndAleatoryWaker();
	}
	void FollowAndAleatoryWaker()//o nome e beem sugestivo ¬¬
	{
		//aqui testo se o player está dentro da area de detecção e se ele nao e PistolShip
		if(distancePlayer > realDistancePlayer && !gameObject.CompareTag("Pistol Shrimp"))
		{
			//se sim o objScript persegue o player
			destiny = Player;
			aleatoryWaker = false;
			Attack ();

		} 	//caso ele seja o pistolShip, ele atendera a condiçao especial, que no caso e: so ataque quando estiver no seu destino
			else if(distancePlayer > realDistancePlayer && gameObject.CompareTag("Pistol Shrimp") && Vector3.Distance(transform.position, destiny.transform.position) > 10.0f)
			{
				//Coloque aqui o ataque do PistolShip
			}
				else
				{
					// caso ele não seja um pistolShip ou nao tenha chegado ao destino lerá-se-a a lista e selecionará um dos wayPoints para se locomover até o mesmo
					for (int i = 0; i < wayPointsList.Count; i++)
					{
						destiny = wayPointsList[numList];
					}
					aleatoryWaker = true;
				}

		switch(actions)
		{
			case Criatura.fishOgre:
				
				Vector3 PosNavMesh = transform.parent.gameObject.transform.position;//posiçao do navMesh
				Vector3 originalPos = new Vector3(PosNavMesh.x, PosNavMesh.y + 5.0f, PosNavMesh.z);//posiçao original do peixe em relaçao ao navMesh
				float distMeshForNavMesh = Vector3.Distance(transform.position, PosNavMesh);// calcula a distancia do peixe para o navMesh
				
				//aqui vejo se aliatorio esta desligado, que se for o caso, o peixe atacara o player sem se destancear do nav mesh
				if(!aleatoryWaker && distMeshForNavMesh < 6.0f)
				{
					transform.position = Vector3.Slerp(transform.position, Player.transform.position, Time.deltaTime);
				}
				else//se ele ficar muito longe, ele retorna para o navmesh
				{
					 transform.position = Vector3.Slerp(transform.position, originalPos, Time.deltaTime);
				}
				if(timer < 0)
				{
					//aqui eu Randomizo qual é o wayPoints para qual ele deve ir e o tempo que tem até o mesmo, depois disso ele ira para outro
					numList = Random.Range(0, 107);
					timer = Random.Range(0.0f, 90.0f);
				}
			break;
				
			case Criatura.pistolShrimp:
				if(timer < 0 && !wathsWayPontsIs)
				{
					//aqui eu Randomizo qual é o wayPoint que ele tem quer ir, que sera a mesma ate o fim
						numList = Random.Range(0, 11);
						wathsWayPontsIs = true;
				}
			break;
				
			case Criatura.spiderCrab:
			//Debug.Log ("Eu sou um SpiderCrab biroleiby!");
			break;
		}
		
		//aqui eu faço com que o objScript persiga o "destiny" que pode ser tanto o player como um WayPoint
		if(Vector3.Distance(destination, destiny.transform.position) > 1.0f)
		{
			destination = destiny.transform.position;
			enemy.destination = destination;
		}
	}

	void Attack()
	{
		if(realDistancePlayer < 3 && AttackCount <= 0)
		{
			if(actions == Criatura.spiderCrab)
			{
				this.gameObject.transform.rotation = Quaternion.LookRotation(Player.transform.localPosition);
			}

			switch(actions)
			{
				case Criatura.spiderCrab:
					this.AttackCount = AttackInitialCount;
					this.GetComponent<Animation>().Play("Atacar");
					HealtCount.instance.HealtValue -=1;
				break;
				case Criatura.fishOgre:
					this.AttackCount = AttackInitialCount;
					this.GetComponent<Animation>().Play("Mordendo");
					HealtCount.instance.HealtValue -=1;
				break;
				case Criatura.pistolShrimp:
					this.AttackCount = AttackInitialCount;
					this.GetComponent<Animation>().Play("Shot");
					HealtCount.instance.HealtValue -=1;
				break;
			}
		}
	}
}