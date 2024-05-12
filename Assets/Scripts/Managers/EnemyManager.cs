using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _crationRadius;
    [SerializeField] private ChapterSettings _chapterSettings;

    private List<Enemy> _enemyList = new List<Enemy>();

    public void StartNewWave(int wave)
    {
        StopAllCoroutines();

        var enemyWavesArray = _chapterSettings.EnemyWavesArray;

        for (int i = 0; i < enemyWavesArray.Length; i++)
        {
            if (enemyWavesArray[i].NumberPerSecond[wave] > 0)
            {
                StartCoroutine(CreateEnemyInSeconds(enemyWavesArray[i].Enemy, enemyWavesArray[i].NumberPerSecond[wave]));
            }
        }
    }

    public void RemoveEnemy(Enemy enemy)
    {
        _enemyList.Remove(enemy);
    }

    private IEnumerator CreateEnemyInSeconds(Enemy enemy, float enemyPerSecond)
    {
        var creationPeriod = new WaitForSeconds(1f / enemyPerSecond);

        while (true)
        {
            yield return creationPeriod;

            Create(enemy);
        }
    }

    private void Create(Enemy enemy)
    {
        Vector2 randomPoint = Random.insideUnitCircle.normalized;
        Vector3 position = new Vector3(randomPoint.x, 0, randomPoint.y) * _crationRadius + _playerTransform.position;

        Enemy newEnemy = Instantiate(enemy, position, Quaternion.identity);
        newEnemy.Initialize(_playerTransform, this);
        _enemyList.Add(newEnemy);
    }

    public Enemy[] GetNearest(Vector3 point, int number)
    {
        _enemyList = _enemyList.OrderBy(x => Vector3.Distance(point, x.transform.position)).ToList();

        int returnNumber = Mathf.Min(number, _enemyList.Count);
        Enemy[] enemies= new Enemy[returnNumber];

        for (int i = 0; i < returnNumber; i++)
        {
            enemies[i] = _enemyList[i];
        }

        return enemies;
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Handles.color = Color.red;
        Handles.DrawWireDisc(_playerTransform.position, Vector3.up, _crationRadius);
    }
#endif
}