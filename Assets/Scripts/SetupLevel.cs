using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupLevel : MonoBehaviour {
    // Start is called before the first frame update

    public SpriteRenderer background;
    public int gridWidth, gridHeight;
    void Start() {
        background.size = new Vector2(gridWidth, gridHeight);
        Debug.Log(background.size);
    }

    // Update is called once per frame
    void Update() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            Debug.Log(hit.transform.name);
            Debug.Log("hit");
        }
    }
}
