using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FoodFallFrenzy {
    public class FFF_SpawnFood : MonoBehaviour {

        public GameObject[] spawnPoints;
        public GameObject[] food;

        public int gameTimer;

        private void Start() {
            gameTimer = 30;

            StartCoroutine(FoodSpawnerTimer());
        }

        void SpawnFood() {
            int spawnPoint = Random.Range(0, spawnPoints.Length);
            int randomFood = Random.Range(0, food.Length);

            Instantiate(food[randomFood], spawnPoints[spawnPoint].transform.position, Quaternion.identity);
        }

        IEnumerator FoodSpawnerTimer() {
            while(gameTimer > 0) {
                gameTimer--;
                SpawnFood();

                yield return new WaitForSeconds(1);
            }

            Debug.Log("Game Over!");

            yield return null;
        }
    }
}

