using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevels : MonoBehaviour
{
    public void ChoseMap2()
    {
        SceneManager.LoadScene("MAP2");
    }

        public void ChoseMap3()
    {
        SceneManager.LoadScene("MAP3");
    }
}
