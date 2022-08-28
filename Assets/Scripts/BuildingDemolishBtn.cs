using UnityEngine;
using UnityEngine.UI;

public class BuildingDemolishBtn : MonoBehaviour
{
    private Button button;
    [SerializeField] private Building building;

    private void Awake()
    {
        button = transform.Find("button").GetComponent<Button>();

        button.onClick.AddListener(() =>
        {
            BuildingTypeSO buildingType = building.GetComponent<BuildingTypeHolder>().buildingType;

            foreach (ResourceAmount resourceAmount in buildingType.constructionResourceCostArray)
            {
                ResourceManager.Instance.AddResource(resourceAmount.resourceType, Mathf.FloorToInt(resourceAmount.amount * .6f));
            }

            Destroy(building.gameObject);
        });
    }
}
