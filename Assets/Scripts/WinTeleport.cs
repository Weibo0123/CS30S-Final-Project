using UnityEngine;
using UnityEngine.SceneManagement;

public class WinTeleport : MonoBehaviour
{
#if UNITY_EDITOR
    public UnityEditor.SceneAsset sceneAsset; // Drag your scene here in the Inspector
#endif

    [HideInInspector]
    public string sceneName;

    private void OnValidate()
    {
#if UNITY_EDITOR
        if (sceneAsset != null)
            sceneName = sceneAsset.name; // Automatically get the scene name
#endif
    }
    bool teleport = false;

    void Update()
    {
        // Check if Space is pressed
        if (teleport)
        {
            if (!string.IsNullOrEmpty(sceneName))
            {
                SceneManager.LoadScene(sceneName); // Load the specific scene
            }
            else
            {
                Debug.LogWarning("Scene not assigned in the Inspector!");
            }
        }
    }

    void OiggerEnter2D(Collider2D collision)
    {
        teleport = true;
    }
}
