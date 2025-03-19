using UnityEngine;

public class WalkState : IAnimalState
{
    private Animal _animal;
    private Animator _animator;
    private Vector3 _targetPosition;

    public WalkState(Animal animal, Animator animator)
    {
        _animal = animal;
        _animator = animator;
    }

    public void Enter()
    {
        SetRandomTargetPosition();
        _animator.Play("Walk");
    }

    public void Update()
    {
        MoveToTarget();
    }

    private void SetRandomTargetPosition()
    {
        _targetPosition = _animal.GetRandomPositionInPen();
        _animal.RotateTowards(_targetPosition);
    }

    private void MoveToTarget()
    {
        _animal.transform.position = Vector3.MoveTowards(_animal.transform.position, _targetPosition, _animal.animalConfig.speed * Time.deltaTime);

        if (_animal.transform.position == _targetPosition)
        {
            _animal.ChangeState(_animal.IdleState);
        }
    }
}