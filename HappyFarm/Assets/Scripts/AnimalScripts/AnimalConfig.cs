using UnityEngine;

[CreateAssetMenu(fileName = "AnimalConfig", menuName = "Config/AnimalConfig")]
public class AnimalConfig : ScriptableObject
{
    public float speed = 2f;
    public float hungerThreshold = 50f;
    public float hungerRate = 1f;
    public int timeToProduceProduct = 10;
    public ProductType productType;
    public Vector3 feedingPoint;
}