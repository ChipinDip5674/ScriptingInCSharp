using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public SimpleFloatData healthData;

    public void ReduceHealth(float amount)
    {
        if (healthData != null)
        {
            healthData.UpdateValue(amount);
        }
    }
}