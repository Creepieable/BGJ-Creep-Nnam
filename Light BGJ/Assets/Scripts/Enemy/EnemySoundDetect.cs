using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySoundDetect : MonoBehaviour {

    public float loudness;
    public LayerMask layer;
    private Collider2D player;

    public float minTimeToMakeaSound;
    public float maxTimeToMakeaSound;
    private float timeToMakeaSound;
    private float timer;

    [Range(0,10)]
    public float minOffset;
    [Range(0,10)]
    public float maxOffset;

    [Tooltip("List of Prefabs to instatiate near enemy position.")]
    public GameObject[] effects;

    private bool done;

	// Update is called once per frame
	void Update () {

        player = Physics2D.OverlapCircle(transform.position, loudness, layer);

        if (player != null)
        {
            if (player.tag == "Player")
            {
                if (timer > timeToMakeaSound)
                {
                    Vector3 randOffset = new Vector3(RandomOffset(), RandomOffset(), transform.position.z);
                    Quaternion randRot = new Quaternion(transform.rotation.x, transform.rotation.y, Random.rotation.z, transform.rotation.w);
                    GameObject instance = Instantiate(effects[Random.Range(0, effects.Length)], transform.position + randOffset, randRot) as GameObject;

                    Destroy(instance, 5f);

                    timer = 0;
                    timeToMakeaSound = Random.Range(minTimeToMakeaSound, maxTimeToMakeaSound);
                }
                else
                {
                    timer += Time.deltaTime;
                }
            }
        }
	}

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, loudness);
    }

    float RandomOffset()
    {
        float rnd = Random.Range(minOffset, maxOffset);

        if (Random.Range(0, 1) == 1)
        {
            rnd -= rnd * 2;
        }

        return rnd;
    }
}
