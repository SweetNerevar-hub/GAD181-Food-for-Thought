using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FoodFallFrenzy {
    public class FFF_SpawnFood : MonoBehaviour {

        public GameObject[] spawnPoints;
        public GameObject[] food;

        // Update is called once per frame
        void Update() {
            if (Input.GetKeyDown(KeyCode.T)) {
                SpawnFood();
            }
        }

        void SpawnFood() {
            int spawnPoint = Random.Range(0, spawnPoints.Length);
            int randomFood = Random.Range(0, food.Length);

            Instantiate(food[randomFood], spawnPoints[spawnPoint].transform.position, Quaternion.identity);
        }
    }
}

