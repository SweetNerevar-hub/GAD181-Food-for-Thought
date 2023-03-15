using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FoodFallFrenzy {

    public class FFF_Food : MonoBehaviour {

        int fallSpeed, lifeSpan;

        private void Start() {
            EventManager.instance.OnCollectFood_FFF += DestroyFood;

            fallSpeed = 5;
            lifeSpan = 5;

            StartCoroutine(FoodLifeSpan(lifeSpan));
        }

        private void Update() {
            transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);
        }

        private void DestroyFood(bool playerOne, GameObject food) {
            Destroy(food);
        }

        IEnumerator FoodLifeSpan(int lifeSpan) {
            while (lifeSpan > 0) {
                lifeSpan--;

                yield return new WaitForSeconds(1);
            }

            DestroyFood(false, gameObject);
        }

        private void OnDisable() {
            EventManager.instance.OnCollectFood_FFF -= DestroyFood;
        }
    }
}