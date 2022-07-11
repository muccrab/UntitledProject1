using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MapCameraController : MonoBehaviour
{
    public GameObject dunCon;
    public string Selected = "r0";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Selected = dunCon.GetComponent<DungeonController>().Selected;
        if (LoadController.Dungeon.ContainsKey(Selected))
            transform.position = new Vector3(LoadController.Dungeon[Selected].posx,LoadController.Dungeon[Selected].posy,-10);
    }
}
