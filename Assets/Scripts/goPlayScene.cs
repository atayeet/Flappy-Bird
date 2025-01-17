using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class goPlayScene : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene("PlayScene");
    }
}
