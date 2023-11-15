using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public class ChunkManager : MonoBehaviour
{
    [SerializeField]private GameObject chunkPrefab;
    [SerializeField]private float chunkSize; // maybe better make this automatically get but...
    [SerializeField]private int chunksAround;
    private Transform _player;
    public static UnityEvent ChunkDestroyed = new();

    private int _currentChunkIndex;
    private readonly List<GameObject> _chunks = new();

    private CollectableManager _collectableManager;

    private void Start() {
        _player = Boot.Instance.player.transform;
        _collectableManager = GetComponent<CollectableManager>();
        InitChunkGeneration();
    }

    private void FixedUpdate() {

        var index = GetChunkIndex(_player.position);
        
        if (index == _currentChunkIndex) return;

        var indexDifference = index - _currentChunkIndex;
        GenerateChunks(indexDifference);

        _currentChunkIndex = index;
    }

    private int GetChunkIndex(Vector3 pos) {
        return Mathf.FloorToInt(pos.x / chunkSize);
    }

    private void GenerateChunks(int indexDifference) {
        var sign = System.Math.Sign(indexDifference);

        for (int i = 1; i <= Mathf.Abs(indexDifference); i++) {
            var instance = CreateChunkAtIndex(_currentChunkIndex + (i + chunksAround) * sign);
            if (sign == 1) {
                _chunks.Add(instance);
                Destroy(_chunks[0]);
                _chunks.RemoveAt(0);
            }
            else {
                _chunks.Insert(0, instance);
                Destroy(_chunks[^1]);
                _chunks.RemoveAt(_chunks.Count - 1);
            }
        }
    }

    private void InitChunkGeneration() {
        for (int i = chunksAround * -1; i <= chunksAround; i++) {
            var instance = CreateChunkAtIndex(i);
            _chunks.Add(instance);
        }
    }

    private GameObject CreateChunkAtIndex(int index) {
        var chunk = Instantiate(chunkPrefab, index * chunkSize * Vector3.right, Quaternion.identity);
        _collectableManager.Put();
        return chunk;
    }
}
