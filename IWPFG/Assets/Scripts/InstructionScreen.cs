using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionScreen : MonoBehaviour
{
    public GameObject hintScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseHint()
    {
        hintScreen.gameObject.SetActive(false);
        SceneManager.LoadScene(1);
    }
}
