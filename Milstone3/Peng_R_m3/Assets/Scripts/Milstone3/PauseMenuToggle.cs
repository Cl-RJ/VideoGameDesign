using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuToggle : MonoBehaviour
{
    private CanvasGroup canvasGroup;

    private void Awake() {
        canvasGroup = this.GetComponent<CanvasGroup>();
        if (canvasGroup == null) {
            Debug.LogError("Cannot get CanvasGroup.");
        }
    }

    void Update() {
        if (Input.GetKeyUp(KeyCode.Escape)) {
            if (canvasGroup.interactable) {
                Time.timeScale = 1f;
                canvasGroup.interactable = false;
                canvasGroup.blocksRaycasts = false;
                canvasGroup.alpha = 0f;
            } else {
                Time.timeScale = 0f;
                canvasGroup.interactable = true;
                canvasGroup.blocksRaycasts = true;
                canvasGroup.alpha = 1f;
            }
        }
    }
    
    
    
}
