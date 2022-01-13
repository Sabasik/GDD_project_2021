using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_color : MonoBehaviour
{
    SpriteRenderer sprite;

    Color[] colors = new Color[5];

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        int color = Random.Range(0, 5);

        colors[0] = Color.red;
        colors[1] = Color.blue;
        colors[2] = Color.green;
        colors[3] = Color.cyan;
        colors[4] = Color.magenta;
        
        sprite.color = colors[color];

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
