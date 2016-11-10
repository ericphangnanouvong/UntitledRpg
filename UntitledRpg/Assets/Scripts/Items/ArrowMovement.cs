using UnityEngine;
using System.Collections;

public class ArrowMovement : MonoBehaviour {
    public int arrowSpeed;
    private Vector3 destination;
	// Use this for initialization
	void Start ()
    {
         destination = PlayerMovement.targetEnemyPosition;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 Arrow1Dir = destination - transform.position;
        float Arrow1Angle = Mathf.Atan2(Arrow1Dir.y, Arrow1Dir.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.AngleAxis(Arrow1Angle + 270, Vector3.forward);
        this.transform.position = Vector2.MoveTowards(this.transform.position, PlayerMovement.targetEnemyPosition, Time.deltaTime * arrowSpeed);
        if(this.transform.position == PlayerMovement.targetEnemyPosition)
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<Enemy>().currentHp -= 3;
            other.gameObject.GetComponent<Enemy>().monsterHp.text = "Hp: " + other.gameObject.GetComponent<Enemy>().currentHp + "/" + other.gameObject.GetComponent<Enemy>().maxHealth;
        }
        Destroy(this.gameObject);
    }   
}
