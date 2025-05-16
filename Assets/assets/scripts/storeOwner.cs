using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class storeOwner : MonoBehaviour
{
    public Sprite[] nuevoSprite;
    private SpriteRenderer sr;
    public static storeOwner carlos;

    private void Awake()
    {
        carlos = this;
    }

    void Start()
    {

        sr= GetComponent<SpriteRenderer>();

      
    }
    public void ChangeSpriteRandomNoRepeat()
    {
        if (sr == null || nuevoSprite == null || nuevoSprite.Length == 0)
            return;

        Sprite spriteActual = sr.sprite;
        Sprite nuevo = spriteActual;

        // Intentar hasta que el nuevo sprite sea distinto al actual (si hay más de uno)
        if (nuevoSprite.Length > 1)
        {
            while (nuevo == spriteActual)
            {
                nuevo = nuevoSprite[Random.Range(0, nuevoSprite.Length)];
            }
        }

        sr.sprite = nuevo;
    }
}
