using UnityEngine;

public class FireController : MonoBehaviour
{
    [SerializeField] private Animator _gunAnimator;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] GameObject _laserPrefab;
    [SerializeField] Transform _laserSpawnPoint;

    public void FireLesser()
    {
        _gunAnimator.SetTrigger("Fire");
        _audioSource.Play();
        GameObject laserBean = Instantiate(_laserPrefab, _laserSpawnPoint.position, _laserSpawnPoint.rotation);
        Debug.Log("Fire Lesser");
    }
}
