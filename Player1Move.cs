﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Move : TacticsMove {
    public bool moving = false;

	// Use this for initialization
	void Start () {
        moving = false;
	}
	
	// Update is called once per frame
	void Update () {
        Debug.DrawRay(transform.position, transform.forward);

        if (!moving) {
            //FindSelectableTiles();
            //CheckMouse();
            FindPath();
        } else {
            //Move();
        }
    }

    void CheckMouse() {
        if (Input.GetMouseButtonUp(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                GameObject now;
                for (now = hit.collider.gameObject; now.tag != "Tile"; now = now.transform.parent.gameObject) {}
                MoveToTile(now);
            }
        }
    }
}