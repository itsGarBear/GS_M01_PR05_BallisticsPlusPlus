using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zone : MonoBehaviour
{
    public Text text;
    public GameManager gm;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            text.text = "Homerun!";
            text.color = Color.white;
        }

        if (other.gameObject.layer == 13)
        {
            PlayerOut();
        }
        Destroy(this.gameObject);
        gm.Invoke("ResetScene", 1f);
    }
    

    public void PlayerOut()
    {
        text.text = "Out!";
        text.color = Color.red;
    }
}
