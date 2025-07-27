using UnityEngine;

public class InventoryButtonScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // //hide button at first
        // gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void openInventory()
    {
        // Load the inventory scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("InventoryScene");
    }
}
