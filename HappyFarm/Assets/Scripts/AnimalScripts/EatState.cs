using UnityEngine;

public class EatState : IAnimalState
{
    private Animal _animal;
    private Animator _animator;
    private float _timeSpentEating = 0f;
    private float _eatingTime = 2f;
    private bool _isEating = false;

    public EatState(Animal animal, Animator animator)
    {
        _animal = animal;
        _animator = animator;
    }

    public void Enter()
    {
        MoveToFeedingStation();
        _animal.RotateTowards(_animal.animalConfig.feedingPoint);
        _isEating = true;
        _timeSpentEating = 0f;
        _animator.Play("Walk");
    }

    public void Update()
    {
        if (Vector3.Distance(_animal.transform.position, _animal.animalConfig.feedingPoint) > 4f)
        {
            MoveToFeedingStation();
        }
        else
        {
            if (_isEating)
            {
                _timeSpentEating += Time.deltaTime;
                _animator.Play("Eating");

                if (_timeSpentEating >= _eatingTime)
                {
                    _animal.Feed();
                    _isEating = false;
                    _animal.ChangeState(_animal.WalkState);
                }
            }
        }        
    }

    private void MoveToFeedingStation()
    {
        _animal.transform.position = Vector3.MoveTowards(_animal.transform.position, _animal.animalConfig.feedingPoint, _animal.animalConfig.speed * Time.deltaTime);
    }
}