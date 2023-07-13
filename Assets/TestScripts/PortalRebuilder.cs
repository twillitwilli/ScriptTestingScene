using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalRebuilder : MonoBehaviour
{
    private void Start()
    {
        BossDeath.bossDied += RepairPortal;
    }

    public void RepairPortal()
    {
        Animator portalAnimator = GetComponent<Animator>();
        portalAnimator.Play("RepairPortal");
    }
}
