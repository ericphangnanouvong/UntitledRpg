using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public float m_movementSpeed;
    public static Vector3 targetEnemyPosition;
	private Vector3 m_newPosition;
    private bool meleeAttacking = false;
    private bool rangedAttacking = false;
    private float timeBetweenAttacks = 2 ;
    private float attackSpeed = 2;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        timeBetweenAttacks += Time.deltaTime;

        if (Input.GetMouseButton(0))
        {
            if (rangedAttacking == false)
            {
                m_newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                m_newPosition.z = transform.position.z;
                transform.position = Vector2.MoveTowards(this.transform.position, m_newPosition, Time.deltaTime * m_movementSpeed);
            }

            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity);


            if (hit.collider != null)
            {
                if (hit.collider.tag == "Enemy")
                {
                    rangedAttacking = true;
                    if (timeBetweenAttacks > attackSpeed)
                    {
                        targetEnemyPosition = hit.transform.position;
                        Instantiate(Resources.Load("Arrow"), this.transform.position, Quaternion.identity);
                        timeBetweenAttacks = 0;
                    }
                }

                if(hit.collider.tag != "Enemy")
                    rangedAttacking = false;
            }

            if (hit.collider == null)
            {
                rangedAttacking = false;
            }
    
        }
}
}

