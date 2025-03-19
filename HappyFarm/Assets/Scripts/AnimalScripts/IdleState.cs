using UnityEngine;

public class IdleState : IAnimalState
{
    private Animal _animal;
    private Animator _animator;
    private float _idleTime;

    public IdleState(Animal animal, Animator animator)
    {
        _animal = animal;
        _animator = animator;
    }

    public void Enter()
    {
        _idleTime = Random.Range(2f, 4f);
        _animator.Play("Idle");
    }

    public void Update()
    {
        _idleTime -= Time.deltaTime;
        if (_idleTime <= 0f)
        {
            _animal.ChangeState(_animal.WalkState);
        }
    }
}