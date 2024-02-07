using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class HoldButtonDetector : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public float holdTime = 3f; // Basýlý tutma süresi (saniye)
    private bool pointerDown = false;
    private float pointerDownTimer = 0f;

    public UnityEvent onHold;


    public void OnPointerDown(PointerEventData eventData)
    {
        PlayerSkills playerSkills = FindAnyObjectByType<PlayerSkills>();
        playerSkills.PowerShootCharging();
        pointerDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        PlayerSkills playerSkillss = FindAnyObjectByType<PlayerSkills>();
        playerSkillss.PowerShootRelease();
        Reset();
        
    }

    private void Update()
    {
        if (pointerDown)
        {
            pointerDownTimer += Time.deltaTime;

            if (pointerDownTimer >= holdTime)
            {
                if (onHold != null)
                    onHold.Invoke();

                Reset();
            }
        }
    }

    private void Reset()
    {
        pointerDown = false;
        pointerDownTimer = 0f;
    }
}
