using System;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private const string StartPoint = "StartPoint";

    private DeathMenu _deathMenu;

    public event Action Died;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out DeathTrigger deathTrigger))
        {
            Died?.Invoke();

            gameObject.SetActive(false);
            _deathMenu.Open(() =>
            {
                transform.position = GameObject.FindGameObjectWithTag(StartPoint).transform.position;
                gameObject.SetActive(true);
                _deathMenu.Close();
            });
        }
    }

    public void Init(DeathMenu deathMenu) 
    { 
        _deathMenu = deathMenu;
    }
}
