using UnityEngine;

public class gravitySimulation : MonoBehaviour
{
    public Rigidbody2D body1;
    public Rigidbody2D body2;
    public Rigidbody2D body3;

    float massBody1;
    float massBody2;
    float massBody3;

    float constant = 6.67408e-11f;
    void Start()
    {
            float massBody1 = body1.mass;
            float massBody2 = body2.mass;
            float massBody3 = body3.mass;
    }

// Update is called once per frame
    void Update()
    {
        Vector2 vector1 = calculateVector(calculateDistanceVector(body1, body2), massBody1, massBody2, constant);
        Vector2 vector2 = calculateVector(calculateDistanceVector(body2, body3), massBody2, massBody3, constant);
        Vector2 vector3 = calculateVector(calculateDistanceVector(body3, body1), massBody3, massBody1, constant);

        body1.AddForce(vector1, ForceMode2D.Force);
        body2.AddForce(vector1, ForceMode2D.Force);
        body2.AddForce(vector2, ForceMode2D.Force);
        body3.AddForce(vector2, ForceMode2D.Force);
        body3.AddForce(vector3, ForceMode2D.Force);
        body1.AddForce(vector3, ForceMode2D.Force);
    }

    Vector2 calculateDistanceVector(Rigidbody2D body1, Rigidbody2D body2)
    {

        float maxBodyX = Mathf.Max(body1.position.x, body2.position.x);
        float minBodyX = Mathf.Min(body1.position.x, body2.position.x);
        float maxBodyY = Mathf.Max(body1.position.y, body2.position.y);
        float minBodyY = Mathf.Min(body1.position.y, body2.position.y);

        Debug.Log("Max X: " + maxBodyX + ", Min X: " + minBodyX);
        Debug.Log("Max Y: " + maxBodyY + ", Min Y: " + minBodyY);

        float deltaX = body2.position.x - body1.position.x;
        float deltaY = body2.position.y - body1.position.y;

        Vector2 distanceVector = new Vector2(deltaX, deltaY);

        return distanceVector;
    }

    Vector2 calculateVector(Vector2 distance, float bodyMass1, float bodyMass2, float constant)
    {
        float forceX = constant * bodyMass1 * bodyMass2 / distance.x * distance.x;
        float forceY = constant * bodyMass1 * bodyMass2 / distance.y * distance.y;
        Vector2 vetor = new Vector2(forceX, forceY);
        return vetor;
    }
    
}
