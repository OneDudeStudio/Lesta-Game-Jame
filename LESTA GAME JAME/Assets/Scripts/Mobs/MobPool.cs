using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

public class MobPool : MonoBehaviour
{
    [SerializeField] private List<Mob> _mobs;
    [SerializeField] private List<Transform> _spawnPoints;

    // mobs count > spawn points count
    private bool[] _isMobUsed;

    private const int _cooldownInMilliseconds = 1000;
    private float _lastSpawnTime;

    private void Start()
    {
        _isMobUsed = new bool[_mobs.Count];

        foreach (var mob in _mobs)
        {
            mob.Died += WaitAndRespawnCitizen;
        }
        
        SpawnCitizens();
    }

    private void SpawnCitizens()
    {
        // mobs count >= spawn points count
        for (var i = 0; i < _spawnPoints.Count; i++)
        {
            _isMobUsed[i] = true;
            
            SpawnCitizen(_mobs[i], _spawnPoints[i].position);
        }
    }

    private async void WaitAndRespawnCitizen(Mob mob)
    {
        mob.gameObject.SetActive(false);
        await Task.Delay(_cooldownInMilliseconds);

        var spawnPosition = GetSpawnPosition();
        SpawnCitizen(mob, spawnPosition);
    }

    private void SpawnCitizen(Mob mob, Vector3 position)
    {
        var citizenIndex = _mobs.IndexOf(mob);
        _isMobUsed[citizenIndex] = true;
        
        mob.transform.position = position;
        mob.gameObject.SetActive(true);
        
        mob.RestartMovement();
    }

    private Vector3 GetSpawnPosition()
    {
        var randomPointIndex = Random.Range(0, _spawnPoints.Count);
        return _spawnPoints[randomPointIndex].position;
    }
}
