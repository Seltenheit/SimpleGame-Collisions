using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject playerPrefab;

    Player player;

    void Start()
    {
        //GameObject playerObject = GameObject.Find("Player");
        //player = playerObject.GetComponent<Player>();
        // GameObject.FindGameObjectWithTag("Player");
        player = FindObjectOfType<Player>();
        player.OnPlayerDeath += GameOver;
    }


    void Update()
    {
        DrawHealthBar(player.health);

        if(Input.GetKeyUp(KeyCode.Space))
        {
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-10f, 10f), 0, Random.Range(-10f, 10f));
            Vector3 randomSpawnRotation = Vector3.up * Random.Range(0, 360);

            GameObject newPlayer = (GameObject) Instantiate(playerPrefab, randomSpawnPosition, Quaternion.Euler(randomSpawnRotation));


        }
    }

    private void DrawHealthBar(float playerHealth)
    {
        throw new System.NotImplementedException();
    }

    public void GameOver()
    {
        throw new System.NotImplementedException();
    }
}
