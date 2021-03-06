﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(CanvasGroup))]
public class CanvasFader : MonoBehaviour {

    public CanvasGroup grp;
    public float speed = 0.2f;
    public bool overrideInteractivity;
    public bool visibleOnStart = true;
    public bool isVisible;
    public TweenCallback onComplete;

    void Awake()
    {
        AttributeGrp();
    }

	void Start(){
        AttributeGrp();

        if (!visibleOnStart){
			grp.alpha = 0f;

			if(overrideInteractivity){
				grp.interactable = false;
				grp.blocksRaycasts = false;
			}
		} else {
			/*grp.alpha = 1f;

			if(overrideInteractivity){
				grp.interactable = true;
				grp.blocksRaycasts = true;
			}*/
		}
	}

    void AttributeGrp() {
        if (grp == null) {
            grp = GetComponent<CanvasGroup>();
        }

    }

    public void FadeIn(float delay = 0f, float speedOverride=0f){
		isVisible = true;

		DOTween.Kill(grp);
		grp.DOFade(1f, speedOverride > 0f ? speedOverride : speed).SetDelay(delay);

		if(overrideInteractivity){
			grp.interactable = true;
			grp.blocksRaycasts = true;
		}
	}

	public void FadeIn(int loopAmount, float delay = 0f, float speedOverride = 0f)
	{
		isVisible = true;

		DOTween.Kill(grp);
		grp.DOFade(1f, speedOverride > 0f ? speedOverride : speed).SetDelay(delay).SetLoops(loopAmount, LoopType.Yoyo);

		if(overrideInteractivity)
		{
			grp.interactable = true;
			grp.blocksRaycasts = true;
		}
	}

	public void FadeTo(float alpha, float delay = 0f){
		isVisible = true;

		DOTween.Kill(grp);
		grp.DOFade(alpha, speed).SetDelay(delay);

		if(overrideInteractivity){
			grp.interactable = true;
			grp.blocksRaycasts = true;
		}
	}

    public void FadeTo(float alpha,bool keepOverride,float delay = 0f)
    {
        isVisible = true;

        DOTween.Kill(grp);
        grp.DOFade(alpha, speed).SetDelay(delay);

        if (overrideInteractivity && keepOverride)
        {
            grp.interactable = true;
            grp.blocksRaycasts = true;
        }
        else
        {
            grp.interactable = false;
            grp.blocksRaycasts = false;
        }
    }

    public void FadeOut(float delay = 0f, float speedOverride = 0f){
		isVisible = false;

		DOTween.Kill(grp);
		grp.DOFade(0f, speedOverride > 0f ? speedOverride : speed).SetDelay(delay);

		if(overrideInteractivity){
			grp.interactable = false;
			grp.blocksRaycasts = false;
		}
	}

	public void Show(){
        AttributeGrp();

        isVisible = true;

        DOTween.Kill(grp);
        grp.alpha = 1f;

		if(overrideInteractivity){
			grp.interactable = true;
			grp.blocksRaycasts = true;
		}
	}

	public void Hide(){
        AttributeGrp();

        isVisible = false;

		DOTween.Kill(grp);
		grp.alpha = 0f;

		if(overrideInteractivity){
			grp.interactable = false;
			grp.blocksRaycasts = false;
		}
	}

	public void GlitchIn(float delay = 0f){
		isVisible = true;

		DOTween.Kill(grp);
		grp.DOFade(1f, 0.05f).SetDelay(delay).SetLoops(3, LoopType.Yoyo).OnComplete(onComplete != null ? onComplete : null);
	
		if(overrideInteractivity){
			grp.interactable = true;
			grp.blocksRaycasts = true;
		}

        onComplete = null;
	}

	public void GlitchOut(float delay = 0f){
		isVisible = false;

		DOTween.Kill(grp);
		grp.DOFade(0f, 0.05f).SetDelay(delay).SetLoops(3, LoopType.Yoyo);
	
		if(overrideInteractivity){
			grp.interactable = false;
			grp.blocksRaycasts = false;
		}
	}

	public void Lock(){
		grp.interactable = false;
		grp.blocksRaycasts = false;
	}

	public void Unlock(){
		if(isVisible){
			grp.interactable = true;
			grp.blocksRaycasts = true;
		}
	}
}
