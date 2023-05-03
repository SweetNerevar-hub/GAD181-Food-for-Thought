using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FoodFallFrenzy {
    public class FFF_SpawnFood : MonoBehaviour {

        public GameObject[] spawnPoints;
        public GameObject[] food;

        [SerializeField] List<int> previousSpawns = new List<int>();

        int gameTimer;

        private void Start() {
            gameTimer = 120;

            StartCoroutine(FoodSpawnerTimer());
        }

        void SpawnFood() {
            int spawnPoint = Random.Range(0, spawnPoints.Length);
            int randomFood = Random.Range(0, food.Length);

            #region PreviousSpawns List Manager

            // This is a spawn system that emulates grabbing marbles from a bag
            // When a certain spawn location has been used, remove it from the pool of useable locations
            // When there are no more unique spawn locations, make them all avaliable again, and repeat

            // If the PreviousSpawns list contains an integer that corresponds to the randomly chose spawn location integer
            // Then don't spawn the food and restart the function
            if (previousSpawns.Contains(spawnPoint)) {
                SpawnFood();

                return;
            }

            // Otherwise add that integer to the list and spawn the food
            else previousSpawns.Add(spawnPoint);

            // If all the spawn locations have been used up
            // Then clear the list and start fresh
            if (previousSpawns.Count == spawnPoints.Length) previousSpawns.Clear();
            #endregion

            Instantiate(food[randomFood], spawnPoints[spawnPoint].transform.position, Quaternion.identity);
        }

        IEnumerator FoodSpawnerTimer() {
            while(gameTimer > 0) {
                gameTimer--;
                SpawnFood();

                yield return new WaitForSeconds(0.5f);
            }

            yield return new WaitForSeconds(5);

            EventManager.instance.FFF_DisplayWinner();
        }
    }
}

// For Faster Gameplay -- Have this be tested
// gameTimer = 120
// time between food spawns is 0.5
// and in the Food script, set fallspeed higher

