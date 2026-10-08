using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public GameObject MenuCanvas;
    bool MenuOpen = false;
    public GameObject playerCapsule;
    public GameObject PlayerFollowCamera;

    private void Start()
    {
        MenuCanvas.SetActive(false);
       
    }

        public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {

            SetPause();  
        }
        
    }

    public void SetPause() 
        {
        if (!MenuOpen)
        {
           
            MenuCanvas.SetActive(true);
            Time.timeScale = 0.0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            if (playerCapsule != null && playerCapsule == isActiveAndEnabled)
            {
                playerCapsule.SetActive(false);
            }
            if(PlayerFollowCamera != null && playerCapsule == isActiveAndEnabled)
            {
                PlayerFollowCamera.SetActive(false);
            }

        }

        else
        {
            
            MenuCanvas.SetActive(false);
            Time.timeScale = 1.0f;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = false;
            if (playerCapsule != null && PlayerFollowCamera == isActiveAndEnabled)
            {
                playerCapsule.SetActive(true);
            }
            if (PlayerFollowCamera != null && PlayerFollowCamera == isActiveAndEnabled)
            {
                PlayerFollowCamera.SetActive(true);
            }
        }

        MenuOpen = !MenuOpen;

        } 


    public void Restart()
    {
        Debug.Log("Restart");
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    public void exit()
    {
        Application.Quit();
    }

}
