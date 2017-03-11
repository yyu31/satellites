using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
	public static GameManager instance;
	
	public GameObject TilePrefab;//This will be replaced with HexPrefab once it's created
	public GameObject UserPlayerPrefab;
	public GameObject AIPlayerPrefab;
	
	public int mapSize = 11;
	
	List <List<Tile>> map = new List<List<Tile>>();
	List <Player> players = new List<Player>();
	int currentPlayerIndex = 0;
	
	void Awake() {
		instance = this;
	}
	
	// Use this for initialization
	void Start () {		
		generateMap();
		generatePlayers();
	}
	
	// Update is called once per frame
	void Update () {
		
		players[currentPlayerIndex].TurnUpdate();//This will call the move function on the current player based on the tile that was clicked on and given to moveCurrentPlayeR(void OnMouseDown(){ instance.moveCurrentPlayer(tile)}

        //Tile where the player is
        //Call GameManager.instance.moveCurrentPlayer based on (i+1, j), (i-1, j), (i, j+1), (i, j-1) based on keys

        if (Input.GetKeyDown("w"))//Vertical axis is inverted due to map index layout format
        {
            if (players[currentPlayerIndex].currentMapLocation.y - 1 >= 0 && players[currentPlayerIndex].currentMapLocation.y - 1< mapSize)
            {
                instance.moveCurrentPlayer(map[/*x */(int)players[currentPlayerIndex].currentMapLocation.x][/*y - 1*/(int)players[currentPlayerIndex].currentMapLocation.y - 1]);
                players[currentPlayerIndex].currentMapLocation.y -= 1; //Update the current players location attribute
            }
            else
                Debug.Log("Index Y out of range exception!");
        }
        if (Input.GetKeyDown("s"))
        {
            if (players[currentPlayerIndex].currentMapLocation.y + 1 >= 0 && players[currentPlayerIndex].currentMapLocation.y + 1< mapSize)
            {
                instance.moveCurrentPlayer(map[/*x*/(int)players[currentPlayerIndex].currentMapLocation.x][/*y + 1*/(int)players[currentPlayerIndex].currentMapLocation.y + 1]);
                players[currentPlayerIndex].currentMapLocation.y += 1;
            }
            else
                Debug.Log("Index Y out of range exception!");
        }
        if (Input.GetKeyDown("a"))
        {
            if (players[currentPlayerIndex].currentMapLocation.x - 1 >= 0 && players[currentPlayerIndex].currentMapLocation.x - 1< mapSize)
            {
                instance.moveCurrentPlayer(map[/*x - 1*/(int)players[currentPlayerIndex].currentMapLocation.x - 1][/*y*/(int)players[currentPlayerIndex].currentMapLocation.y]);
                players[currentPlayerIndex].currentMapLocation.x -= 1;
            }
            else
                Debug.Log("Index X out of range exception!");
        }
        if (Input.GetKeyDown("d"))
        {
            if (players[currentPlayerIndex].currentMapLocation.x + 1 >= 0 && players[currentPlayerIndex].currentMapLocation.x + 1< mapSize)
            {
                instance.moveCurrentPlayer(/*x + 1*/map[(int)players[currentPlayerIndex].currentMapLocation.x + 1][/*y*/(int)players[currentPlayerIndex].currentMapLocation.y]);
                players[currentPlayerIndex].currentMapLocation.x += 1;
            }
            else
                Debug.Log("Index X out of range exception!");
        }


    }
	
	public void nextTurn() {
		if (currentPlayerIndex + 1 < players.Count) {
			currentPlayerIndex++;
		} else {
			currentPlayerIndex = 0;
		}
	}
	
	public void moveCurrentPlayer(Tile destTile) {
		players[currentPlayerIndex].moveDestination = destTile.transform.position + 1.5f * Vector3.up;
	}
	
	void generateMap() {
		map = new List<List<Tile>>();
		for (int i = 0; i < mapSize; i++) {
			List <Tile> row = new List<Tile>();
			for (int j = 0; j < mapSize; j++) {
				Tile tile = ((GameObject)Instantiate(/*TODO: Create a Hex prefab to replace the TilePrefab*/TilePrefab, new Vector3(i - Mathf.Floor(mapSize/2),0, -j + Mathf.Floor(mapSize/2)), Quaternion.Euler(new Vector3()))).GetComponent<Tile>();
				tile.gridPosition = new Vector2(i, j);
				row.Add (tile);
			}
			map.Add(row);
		}
	}
	
	void generatePlayers() {
		UserPlayer player;
		
		player = ((GameObject)Instantiate(UserPlayerPrefab, new Vector3(0 - Mathf.Floor(mapSize/2),1.5f, -0 + Mathf.Floor(mapSize/2)), Quaternion.Euler(new Vector3()))).GetComponent<UserPlayer>();
		player.currentMapLocation = new Vector2(0,0);//Populate this charcaters current position to this
		players.Add(player);
		
	/*	player = ((GameObject)Instantiate(UserPlayerPrefab, new Vector3((mapSize-1) - Mathf.Floor(mapSize/2),1.5f, -(mapSize-1) + Mathf.Floor(mapSize/2)), Quaternion.Euler(new Vector3()))).GetComponent<UserPlayer>();
		
		players.Add(player);
				
		player = ((GameObject)Instantiate(UserPlayerPrefab, new Vector3(4 - Mathf.Floor(mapSize/2),1.5f, -4 + Mathf.Floor(mapSize/2)), Quaternion.Euler(new Vector3()))).GetComponent<UserPlayer>();
		
		players.Add(player);
		
		AIPlayer aiplayer = ((GameObject)Instantiate(AIPlayerPrefab, new Vector3(6 - Mathf.Floor(mapSize/2),1.5f, -4 + Mathf.Floor(mapSize/2)), Quaternion.Euler(new Vector3()))).GetComponent<AIPlayer>();
		
		players.Add(aiplayer);*/
	}
}
