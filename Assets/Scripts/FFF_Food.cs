using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FoodFallFrenzy {

    public class FFF_Food : MonoBehaviour {

        int fallSpeed;

        private void Start() {
            EventManager.instance.OnCollectFood_FFF += DestroyFood;

            fallSpeed = 5;
        }

        private void Update() {
            transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);
        }

        private void DestroyFood(bool playerOne) {
            Destroy(gameObject);
        }

        private void OnDisable() {
            EventManager.instance.OnCollectFood_FFF -= DestroyFood;
        }
    }
}