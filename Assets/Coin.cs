using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Coin : MonoBehaviour
{
    [SerializeField] private Transform visual;
    [SerializeField] private CoinData coinData;
    [SerializeField] private BaseAnimation baseAnimation;

    private void Start()
    {
        visual.GetComponent<MeshRenderer>().material = coinData.material;
        if(baseAnimation != null)
            baseAnimation.Animate(visual);
    }
    
    // public void Animate()
    // {
    //     var seq = DOTween.Sequence();
    //     
    //     seq.Append(visual.DOLocalRotate(new Vector3(visual.eulerAngles.x, 180, 0), 0.5f));
    //     seq.Append(visual.DOLocalRotate(new Vector3(visual.eulerAngles.x, 360, 0), 0.5f));
    //     seq.SetLoops(-1);
    // }
}
