using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
namespace Core.Button
{
    public abstract class BaseButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
    {
        private Vector3 scaler = new Vector3(1, 1, 1);
        private Vector3 normal = new Vector3(1, 1, 1);
        private Vector3 shrinker = new Vector3(0.8f, 0.8f, 1);
        private float target = 1;
        RectTransform rectTransform;

        public bool isCloseButton = false;

        void Start()
        {
            rectTransform = GetComponent<RectTransform>();
            SetupAtStart();
        }

        private void Update()
        {
            rectTransform.localScale = scaler;
        }

        private void FixedUpdate()
        {
            scaler.x = Mathf.Lerp(scaler.x, target, 0.3f);
            scaler.y = Mathf.Lerp(scaler.y, target, 0.3f);
        }

        public void OnPointerDown(PointerEventData e)
        {
            //Debug.Log(e.IsPointerMoving());
            target = 0.8f;
        }

        public void OnPointerUp(PointerEventData e)
        {
            target = 1f;
            if (e.IsPointerMoving()) { return; } //Return if user is swiping
            PlayButtonVFX();
            ButtonAction();
        }

        private void PlayButtonVFX()
        {
            if (isCloseButton)
            {
                Sound.SFXController.sfxInstance.PlayCloseButtonClickSFX();
            }else
            {
                Sound.SFXController.sfxInstance.PlayButtonClickSFX();
            }
        }

        public virtual void SetupAtStart()
        {

        }
        public abstract void ButtonAction();
    }
}

