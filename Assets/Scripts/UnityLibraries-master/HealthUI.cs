using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HealthUI : MonoBehaviour {

    public Transform healthSquare, healthIcon;
    public Vector3 endScale;
    bool hasEndScale;

	float durationTween = 1f;
	float scaleOffSet = 0.5f;
	float ratioCritical = 0.3f;

    private void Start()
    {
        gameObject.SetActive(false);
		scaleOffSet = healthSquare.transform.localScale.x;
    }

    public void ReduceHealth(int current, int max)
    {
		DOTween.Clear();
		float ratio = ((float)current / (float)max) * scaleOffSet;
		if(healthSquare.localScale.y < ratioCritical)
        {
            if(!hasEndScale)
            	DOTween.To(() => healthIcon.localScale, scale => healthIcon.localScale = scale, endScale , .4f).SetRelative().SetLoops(-1, LoopType.Yoyo);

            hasEndScale = true;
            //healthSquare.DOScaleY(healthSquare.localScale.y - .1f, 1f).SetEase(Ease.InQuad);
			healthSquare.DOScaleY(ratio, durationTween).SetEase(Ease.InQuad);

        }
        else
        {
            //healthSquare.DOScaleY(healthSquare.localScale.y - .1f, 1f).SetEase(Ease.InQuad).OnComplete(HideGrp);
			healthSquare.DOScaleY(ratio, durationTween).SetEase(Ease.InQuad).OnComplete(HideGrp);
        }
    }

	public void GainHealth(int current, int max)
    {
		DOTween.Clear();
		float ratio = ((float)current / (float)max) * scaleOffSet;
		if (healthSquare.localScale.y > ratioCritical)
        {
            DOTween.To(() => healthIcon.localScale, scale => healthIcon.localScale = scale, Vector3.one, .2f).SetLoops(1, LoopType.Yoyo);
            hasEndScale = false;
           // healthSquare.DOScaleY(healthSquare.localScale.y + .1f, 1f).SetEase(Ease.InQuad);
			healthSquare.DOScaleY(ratio, durationTween).SetEase(Ease.InQuad);
        }
        else
        {
			healthSquare.DOScaleY(ratio, durationTween).SetEase(Ease.InQuad).OnComplete(HideGrp);
			//healthSquare.DOScaleY(healthSquare.localScale.y + .1f, 1f).SetEase(Ease.InQuad).OnComplete(HideGrp);

        }
    }

    void HideGrp()
    {
        gameObject.SetActive(false);
    }
}
