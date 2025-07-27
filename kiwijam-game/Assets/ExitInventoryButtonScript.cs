using UnityEngine;

public class ExitInventoryButtonScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void buttonPressed()
    {
        // Load the main game scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }
}
