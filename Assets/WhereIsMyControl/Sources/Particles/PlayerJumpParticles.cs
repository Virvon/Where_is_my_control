using UnityEngine;

public class PlayerJumpParticles : MonoBehaviour
{
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private ParticleSystem _jumpParticle;
    [SerializeField] private PlayerMovement _playerMovement;

    private void OnEnable() => 
        _playerMovement.Jumped += OnJumped;

    private void OnDisable() => 
        _playerMovement.Jumped -= OnJumped;

    private void OnJumped() => 
        Instantiate(_jumpParticle, _spawnPosition.position, Quaternion.identity);
}