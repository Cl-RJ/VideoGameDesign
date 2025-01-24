using UnityEngine;
using TMPro;

public class MissionManager : MonoBehaviour
{
    public AudioSource missionAudio; // Reference to the AudioSource that plays mission audio
    public GameObject missionPanel; // Reference to the MissionPanel UI
    public TextMeshProUGUI missionText; // Reference to the TextMeshProUGUI component

    public float missionDisplayDuration = 5.0f; // How long the mission panel should be displayed

    void Start()
    {
        // Start the mission description sequence at the beginning of the level
        StartMissionDescription();
    }

    void StartMissionDescription()
    {
        // Play the mission audio
        if (missionAudio != null)
        {
            missionAudio.Play();
        }

        // Display the mission panel
        if (missionPanel != null)
        {
            missionPanel.SetActive(true);
        }

        // Set the mission text
        if (missionText == null)
        {
            missionText.text = "blabla";
        }

        // Start coroutine to hide the mission panel after a delay
        StartCoroutine(HideMissionPanelAfterDelay());
    }

    System.Collections.IEnumerator HideMissionPanelAfterDelay()
    {
        // Wait for the duration of missionDisplayDuration
        yield return new WaitForSeconds(missionDisplayDuration);

        // Hide the mission panel
        if (missionPanel != null)
        {
            missionPanel.SetActive(false);
        }
    }
}
