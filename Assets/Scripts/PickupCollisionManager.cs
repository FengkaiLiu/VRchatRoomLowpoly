using UdonSharp;

public class PickupCollisionManager : UdonSharpBehaviour
{
    private int originalLayer;
    public int noPlayerCollisionLayer = 22; // User Layer 22

    void Start()
    {
        originalLayer = gameObject.layer;
    }

    public override void OnPickup()
    {
        gameObject.layer = noPlayerCollisionLayer;
    }

    public override void OnDrop()
    {
        gameObject.layer = originalLayer;
    }
}

