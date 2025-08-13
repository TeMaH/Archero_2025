using System;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public event Action<PlayerModel> OnPlayerEnteredEvent;

    [SerializeField] GameObject openState;
    [SerializeField] GameObject closeState;

    bool currentState = false;
    public bool CurrentState 
    {
        get => currentState;
        private set 
        {
            if (currentState == value)
            {
                return;
            }
            currentState = value;
            openState.SetActive(currentState);
            closeState.SetActive(!currentState);
        }  
    }

    public void SwitchState(bool state)
    { 
        CurrentState = state;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!CurrentState || !other.gameObject.CompareTag("Player"))
        {
            return;
        }
        if (other.TryGetComponent(out PlayerModel player))
        {
            OnPlayerEnteredEvent?.Invoke(player);
        }
    }
}
