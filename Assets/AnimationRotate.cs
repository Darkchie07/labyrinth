using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

[CreateAssetMenu(fileName = "Animation Scale", menuName = "Custom Asset/Animation/Rotate")]
public class AnimationRotate : BaseAnimation
{
    public override void Animate(Transform visual)
    {
        base.Animate(visual);
        var seq = DOTween.Sequence();
        
        seq.Append(visual.DOLocalRotate(new Vector3(visual.eulerAngles.x, 180, visual.eulerAngles.z), duration/2));
        seq.Append(visual.DOLocalRotate(new Vector3(visual.eulerAngles.x, 360, visual.eulerAngles.z), duration/2));
        seq.SetLoops(-1);
    }
}
