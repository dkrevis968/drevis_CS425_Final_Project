using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
    public Text winText;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.SetActive(false);
            col.gameObject.transform.position = new Vector3(100f, 100f, 100f);
            winText.gameObject.SetActive(true);
        }
    }
}
