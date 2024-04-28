using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    public float fadeOutTime = 1f;
    
    void Start()
    {
        StartCoroutine(DoFadeOut(GetComponent<SpriteRenderer>()));
    }


    IEnumerator DoFadeOut(SpriteRenderer _sprite)
    {
        Color tmpclr = _sprite.color;
        
        while(tmpclr.a > 0)
        {
            tmpclr.a -= Time.deltaTime / fadeOutTime;
            _sprite.color = tmpclr;


            yield return null;
        }

        _sprite.color = tmpclr;
    }

}
