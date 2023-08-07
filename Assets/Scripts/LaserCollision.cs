using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LaserCollision : MonoBehaviour
{
    [SerializeField] private GameObject _explosionPrefab;
    [SerializeField] private GameObject _pointCanvas;

    private float _astroidDistanceFromPlayer;
    private int _extraPoint;
    private int _displayPoint;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Asteroid"))
        {
            Destroy(collision.gameObject);
            Instantiate(_explosionPrefab, collision.transform.position, collision.transform.rotation);

            _astroidDistanceFromPlayer = Vector3.Distance(this.transform.position , new Vector3(104.716f, 1.357f, 77.142f));
            _extraPoint = (int)_astroidDistanceFromPlayer;
            _displayPoint = 100 + _extraPoint;

            if (GameManager._currentGameState.Equals(GameState.Play))
            {
                GameObject displayAstroidScore = Instantiate(_pointCanvas, transform.position, Quaternion.identity);

                displayAstroidScore.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = _displayPoint.ToString();

                displayAstroidScore.transform.localScale = new Vector3(transform.localScale.x * (_astroidDistanceFromPlayer / 150),                                                                     transform.localScale.y * (_astroidDistanceFromPlayer / 150), 
                                                                       transform.localScale.z * (_astroidDistanceFromPlayer / 150));
                GameManager.instance.PlayerScoreUpdate(_extraPoint);
            }

            
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
