using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YenidenBaslatma : MonoBehaviour
{
    public static int oyuncu1Puani = 0;
    public static int oyuncu2Puani = 0;
    public void Restart()
    {
        oyuncu1Puani = 0;
        oyuncu2Puani = 0;
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");
    }
}
