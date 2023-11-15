using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectable : MonoBehaviour
{
    private const string PlayerTag = "Player";
    private Transform _transform;
    private SpriteRenderer _renderer;
    [SerializeField]private float disappearSpeed = 1;
    [SerializeField]private float disappearHeight = 1;

    private bool _disappearing;

    private void Start() {
        _transform = transform;
        _renderer = GetComponent<SpriteRenderer>();
        ChunkManager.ChunkDestroyed.AddListener(CheckForDespawn);
    }

    private void Update() {
        if (!_disappearing) return;
        Disapear();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (!other.CompareTag(PlayerTag) || _disappearing) return; //instead of disappearing check we can turn off collider
        _disappearing = true;
        Action();
        Destroy(gameObject);
    }

    protected abstract void Action();

    private void Disapear() {
        _transform.Translate(disappearHeight * disappearSpeed * Time.deltaTime * Vector3.up);
        _renderer.color -= disappearSpeed * Time.deltaTime * new Color(0, 0, 0, 1);
        if (_renderer.color.a > 0) return;
        _disappearing = false; // not needed, but just in case
        Destroy(gameObject);
    }

    private void CheckForDespawn() {
        if (Physics2D.Raycast(_transform.position, Vector2.down, 10)) return;
        Destroy(gameObject);
    }
}
