using UnityEngine;

public class ActiveProjectile : MonoBehaviour
{
    [SerializeField] float extraRot;

    [SerializeField] SpriteRenderer spriteRenderer;

    Vector2 lookPos;

    bool isWaiting = false;

    public bool IsWaiting
    {
        get => isWaiting;
        set => isWaiting = value;
    }

    public Vector2 GetLookPos
    {
        get => lookPos;
    }

    public void SetMoveableProjectile(Vector2 direction, Vector3 pos, bool hasLookAt)
    {
        spriteRenderer.enabled = true;
        GetComponent<BoxCollider2D>().enabled = true;
        isWaiting = false;
        transform.position = pos;
        if(GetComponentInChildren<TrailRenderer>() != null)
        {
            GetComponentInChildren<TrailRenderer>().Clear();
        }

        lookPos = direction;

        if(hasLookAt)
        {
            LookAt();
        }

        if(TryGetComponent<ActiveProjectileMove>(out var component))
        {
            component.SetAddForce(lookPos);
        }
    }

    void LookAt()
    {
        Vector2 offset = lookPos - Vector2.zero;
        offset.Normalize();
        float rot_z = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z + extraRot);
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag(TagManager.BARIER) && !isWaiting)
        {
            AnimEvent_SetTrueIsWaiting();
        }
    }

    public void SetFalseIsWaiting()
    {
        spriteRenderer.enabled = true;
        isWaiting = false;
    }

    public void AnimEvent_SetTrueIsWaiting()
    {
        spriteRenderer.enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        isWaiting = true;
    }

}
