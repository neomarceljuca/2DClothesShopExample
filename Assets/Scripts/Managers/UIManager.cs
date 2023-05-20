using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;

    // Get the singleton instance
    public static UIManager Instance
    {
        get
        {
            // If the instance doesn't exist, find it in the scene
            if (instance == null)
            {
                instance = FindObjectOfType<UIManager>();

                // If it still doesn't exist, create a new GameObject and add the script to it
                if (instance == null)
                {
                    GameObject obj = new GameObject("UIManager");
                    instance = obj.AddComponent<UIManager>();
                }
            }

            return instance;
        }
    }

    // Optional: Add any other variables or methods related to the UI manager

    private void Awake()
    {
        // Ensure there's only one instance of the UI manager
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Optional: Add any other initialization or setup code for the UI manager

    // Example method to show how the UI manager can be used
    public void ShowPanel(string panelName)
    {
        // Implementation code for showing a specific UI panel
    }
}