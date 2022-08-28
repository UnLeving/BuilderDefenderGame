using UnityEngine;
using UnityEngine.UI;

public class BuildingRepairBtn : MonoBehaviour
{
    private Button button;
    [SerializeField] private HealthSystem healthSystem;
    [SerializeField] private ResourceTypeSO goldResourceType;

    private void Awake()
    {
        button = transform.Find("button").GetComponent<Button>();

        button.onClick.AddListener(() =>
        {
            int missingHealth = healthSystem.GetHealthAmountMax() - healthSystem.GetHealthAmount();
            int repairCost = missingHealth / 2;
            ResourceAmount[] resourceAmountCost = new ResourceAmount[] { new ResourceAmount { resourceType = goldResourceType, amount = repairCost } };

            if (ResourceManager.Instance.CanAfford(resourceAmountCost))
            {
                healthSystem.HealFull();

                ResourceManager.Instance.SpendResources(resourceAmountCost);
            }
            else
            {
                TooltipUI.Instance.Show("Cannot afford repair cost!", new TooltipUI.TooltipTimer { timer = 2f });
            }
        });
    }
}
