using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DicePlayer : MonoBehaviour
{
    private Animator anim;
    private bool animComplete = false;

    private void Start() {
        anim = GetComponent<Animator>();
        anim.speed = 0;
    }

    private void OnTriggerEnter(Collider c) {
        if (c.attachedRigidbody != null) {
            BallCollector bc = c.attachedRigidbody.gameObject.GetComponent<BallCollector>();
            if (bc != null && anim != null) {
                anim.speed = 1;
            }
        }
    }

    private void OnTriggerExit(Collider c) {
        if (c.attachedRigidbody != null) {
            BallCollector bc = c.attachedRigidbody.gameObject.GetComponent<BallCollector>();
            if (bc != null && anim != null) {
                StartCoroutine(StopAnimation(anim));
            }
        }
    }

    private IEnumerator StopAnimation(Animator anim) {
        while (!animComplete) {
            yield return null;
        }
        anim.speed = 0;
    }

    public void setAnimation(int state) {
        animComplete = (state == 1);
    }
}
