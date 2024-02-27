using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class CoinCountScrips : MonoBehaviour
{
    public TextMeshProUGUI CoinCountText;
    int Count = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CoinCountText.text = Count.ToString();
    }

    public void Addcount()
    {
        Count++;
    }
}
