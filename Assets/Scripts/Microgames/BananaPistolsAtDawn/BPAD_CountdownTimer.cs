using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BPAD {
    public class BPAD_CountdownTimer : MonoBehaviour {

        public int timer, chosenTimerValue;

        // Start is called before the first frame update
        void Start() {
            timer = 0;

            chosenTimerValue = Random.Range(5, 10);

            StartCoroutine(IterateTimer());
        }

        IEnumerator IterateTimer() {
            while (timer < chosenTimerValue) {
                yield return new WaitForSeconds(1);

                timer++;
            }

            EventManager.instance.BPAD_DisplayAlert();

            yield break;
        }
    }
}

