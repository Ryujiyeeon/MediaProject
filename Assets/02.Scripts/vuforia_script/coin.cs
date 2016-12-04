using UnityEngine;
using System.Collections;

public class coin : MonoBehaviour {
    public Camera camera;
    public GameObject cube;
    public Vector3 cube_pos;
    public Vector3 touch_pos;

    int _touched;
    int coin_vis;
    int coin_count;

	// Use this for initialization
	void Start () {
        coin_vis = 1;
        _touched = 0;
        coin_count = 0;
	}
	
	// Update is called once per frame
	void Update () {
        camera.GetComponent<Camera>();
        Transform target = cube.GetComponent<Transform>();
        cube_pos = camera.WorldToScreenPoint(target.position);

        if (Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            Vector2 Input_pos = Input.GetTouch(0).position;
            touch_pos = Input_pos;
            touch_pos.z = 8;

            float x_gap = cube_pos.x - touch_pos.x;
            float y_gap = cube_pos.y - touch_pos.y;
            if (x_gap < 0.0f) x_gap = -x_gap;
            if (y_gap < 0.0f) y_gap = -y_gap;

            if (x_gap < 100.0f && y_gap < 100.0f)
            {
                if (coin_vis == 1)
                {
                    cube.SetActive(false);
                    coin_vis = 0;
                    coin_count++;
                }
                else
                {
                    cube.SetActive(true);
                    coin_vis = 1;
                }
            }
        }
	}
}
