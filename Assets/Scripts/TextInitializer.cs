using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextInitializer : MonoBehaviour
{
    public Text winText;

    // Start is called before the first frame update
    void Start()
    {
        winText.gameObject.SetActive(false);
    }
}
