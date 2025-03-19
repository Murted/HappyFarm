using System.Collections;
using UnityEngine;

public class Animal : MonoBehaviour
{
    private IAnimalState cureentState;
    public IdleState IdleState;
    public WalkState WalkState;
    public EatState EatState;
    public float hunger = 100f;
    public AnimalConfig animalConfig;

    private int timeToProduceProduct;
    private bool hasProduct = false;
    private Animator animator;


    private void Start()
    {
        animator = GetComponent<Animator>();
        IdleState = new IdleState(this, animator);
        WalkState = new WalkState(this, animator);
        EatState = new EatState(this, animator);
        cureentState = WalkState;
        cureentState.Enter();
        timeToProduceProduct = animalConfig.timeToProduceProduct;
        StartCoroutine(TimeToProduceProduct());

    }

    private void Update()
    {
        hunger -= animalConfig.hungerRate * Time.deltaTime;
        if (hunger <= animalConfig.hungerThreshold && cureentState != EatState)
        {
            ChangeState(EatState);
        }

        cureentState.Update();
    }

    public void ChangeState(IAnimalState newState)
    {
        cureentState = newState;
        cureentState.Enter();
    }

    public void ProduceProduct()
    {
        if (hasProduct)
        {
            Warehouse.Instance.AddProduct(animalConfig.productType);
            hasProduct = false;
        }
    }

    public void Feed()
    {
        hunger = 100f;
    }

    public Vector3 GetRandomPositionInPen()
    {
        return SpawnZone.Instance.GetRandomPosition();
    }

    public void RotateTowards(Vector3 targetPosition)
    {
        Vector3 direction = targetPosition - transform.position;
        direction.y = 0f;

        if (direction.sqrMagnitude > 0.01f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 1f);
        }
    }

    public IEnumerator TimeToProduceProduct()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeToProduceProduct--;
            if (timeToProduceProduct <= 0)
            {
                hasProduct = true;
                ProduceProduct();
                timeToProduceProduct = animalConfig.timeToProduceProduct;
            }
        }
    }
}