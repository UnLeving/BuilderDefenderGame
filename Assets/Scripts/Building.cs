using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{

    private BuildingTypeSO buildingType;
    private HealthSystem healthSystem;
    private Transform buildingDemolishBtn;
    private Transform buildingRepairBtn;

    private void Awake()
    {
        buildingDemolishBtn = transform.Find("pfBuildingDemolishBtn");
        buildingRepairBtn = transform.Find("pfBuildingRepairBtn");

        buildingDemolishBtn?.gameObject.SetActive(false);
        buildingRepairBtn?.gameObject.SetActive(false);
    }

    private void Start()
    {
        buildingType = GetComponent<BuildingTypeHolder>().buildingType;

        healthSystem = GetComponent<HealthSystem>();

        healthSystem.SetHealthAmountMax(buildingType.healthAmountMax, true);

        healthSystem.OnDied += HealthSystem_OnDied;
        healthSystem.OnHeal += HealthSystem_OnHeal;
        healthSystem.OnDamaged += HealthSystem_OnDamaged;
    }

    private void HealthSystem_OnDamaged(object sender, System.EventArgs e)
    {
        buildingRepairBtn?.gameObject.SetActive(true);

        SoundManager.Instance.PlaySound(SoundManager.Sound.BuildingDamaged);

        CinemachineShake.Instance.ShakeCamera(7f, .15f);
        ChromaticAberrationEffect.Instance.SetWeight(1f);
    }

    private void HealthSystem_OnHeal(object sender, System.EventArgs e)
    {
        if (healthSystem.IsFullHealth())
        {
            buildingRepairBtn?.gameObject.SetActive(false);
        }
    }

    private void HealthSystem_OnDied(object sender, System.EventArgs e)
    {
        Destroy(gameObject);

        Instantiate(Resources.Load<Transform>("pfBuildingDestroyedParticles"), transform.position, Quaternion.identity);

        SoundManager.Instance.PlaySound(SoundManager.Sound.BuildingDestroyed);

        CinemachineShake.Instance.ShakeCamera(10f, .2f);
        ChromaticAberrationEffect.Instance.SetWeight(1f);
    }

    private void OnMouseEnter()
    {
        buildingDemolishBtn?.gameObject.SetActive(true);
        buildingRepairBtn?.gameObject.SetActive(true);
    }

    private void OnMouseExit()
    {
        buildingDemolishBtn?.gameObject.SetActive(false);
        buildingRepairBtn?.gameObject.SetActive(false);
    }
}
