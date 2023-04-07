using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class map1 : MonoBehaviour
{
    [SerializeField] Camera cameraP;
    [SerializeField] GameObject UiPause;
    private float CodeWin = 3001;
    [SerializeField] GameObject UiNum1, UiNum2, UiNum3, UiNum4;
    [SerializeField] GameObject UiInput;

    void FixedUpdate()
    {
        Ray ray = cameraP.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        int LayerCollect = 1 << 8;

        if(Physics.Raycast(ray, out RaycastHit raycastHit, 2, LayerCollect))
        {
            

            if (Input.GetKeyDown(KeyCode.Mouse0) && raycastHit.collider.tag == "Num1")
            {
                UiNum1.SetActive(true);
                UiNum2.SetActive(false);
                UiNum3.SetActive(false);
                UiNum4.SetActive(false);
            }
            else if (Input.GetKeyDown(KeyCode.Mouse0) && raycastHit.collider.tag == "Num2")
            {
                UiNum1.SetActive(false);
                UiNum2.SetActive(true);
                UiNum3.SetActive(false);
                UiNum4.SetActive(false);
            }
            else if (Input.GetKeyDown(KeyCode.Mouse0) && raycastHit.collider.tag == "Num3")
            {
                UiNum1.SetActive(false);
                UiNum2.SetActive(false);
                UiNum3.SetActive(true);
                UiNum4.SetActive(false);
            }
            else if (Input.GetKeyDown(KeyCode.Mouse0) && raycastHit.collider.tag == "Num4")
            {
                UiNum1.SetActive(false);
                UiNum2.SetActive(false);
                UiNum3.SetActive(false);
                UiNum4.SetActive(true);
            }
            else if (Input.GetKeyDown(KeyCode.Mouse0) && raycastHit.collider.tag == "compu")
            {
                Time.timeScale = 0;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                UiInput.SetActive(true);
            }

            while (UiInput.activeInHierarchy == true)
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    UiInput.SetActive(false);
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                }
            }
        }
        //pause Menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UiPause.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
        }
    }
    public void ResumGame()
    {
        UiPause.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void LoadMenu(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
