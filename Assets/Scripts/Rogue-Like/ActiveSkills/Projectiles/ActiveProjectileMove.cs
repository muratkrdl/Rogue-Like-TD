using UnityEngine;

public class ActiveProjectileMove : MonoBehaviour
{
    [SerializeField] float addForceAmount;

    public void SetAddForce(Vector2 pos)
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<Rigidbody2D>().AddForce(pos.normalized * addForceAmount);
    }

}
