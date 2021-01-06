using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDialog : MonoBehaviour
{
    public Animator anim;
    public GameObject dialog;
    public AnimHandler handler;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfFinished();
    }

    public void CheckIfFinished()
    {

        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
           
                Debug.Log("finished anims");
                handler.HideUi();
                dialog.gameObject.SetActive(true);
          
        }

    }
}
