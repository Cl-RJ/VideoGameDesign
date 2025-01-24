using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;  // Import TMP namespace

public class LoginManager : MonoBehaviour
{
    // Use TMP_InputField for TextMeshPro input fields
    public TMP_InputField usernameInput;
    public TMP_InputField passwordInput;
    public Button loginButton;
    
    private void Start()
    {
        // Attach the Login method to the button's onClick event
        loginButton.onClick.AddListener(OnLoginButtonClicked);
    }

    private void OnLoginButtonClicked()
    {
        string username = usernameInput.text;
        string password = passwordInput.text;

        // Basic validation check (you can expand this with actual server checks)
        if (username == "player" && password == "1234")
        {
            Debug.Log("Login successful!");
            SceneManager.LoadScene("Demo 2");  // Load the main game scene
        }
        else
        {
            Debug.Log("Login failed. Check your username or password.");
        }
    }
}
