using UnityEngine;

public class PlayerJumpParticles : MonoBehaviour
{
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private GameObject _jumpParticle;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private float _yOffset;

    private void OnEnable() => 
        _playerMovement.Jumped += OnJumped;

    private void OnDisable() => 
        _playerMovement.Jumped -= OnJumped;

    private void OnJumped() => 
        Instantiate(_jumpParticle, new Vector3(_spawnPosition.position.x,_spawnPosition.position.y - _yOffset, _spawnPosition.position.z), Quaternion.identity);
}