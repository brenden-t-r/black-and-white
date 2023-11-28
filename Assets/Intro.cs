using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class Intro : MonoBehaviour
{
    public bool isIntro;
    public GameObject introTiles;
    public bool canContinue = false;
    private float TILE_HEIGHT = -11.9f;
    private float NUM_INTRO_TILES = 10;

    // Start is called before the first frame update
    void Start()
    {
        isIntro = true;
        List<IEnumerator> routines = new List<IEnumerator>();
        routines.Add(UtilsMono.WaitXSecondsWrapper(1));
        for (int i = 0; i < NUM_INTRO_TILES; i++) {
            routines.Add(getNextTile());
        }
        StartCoroutine(UtilsMono.couroutineSequenceWithPause(routines, 0.5f, canContinue));
    }

    IEnumerator getNextTile() {
        yield return UtilsMono.MoveObjXYOverSeconds(introTiles.transform, TILE_HEIGHT, 0, 0.8f);
    }

    // Update is called once per frame
    void Update()
    {

        if (!isIntro) return;
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            Vector3 end = new Vector3(introTiles.transform.position.x - TILE_HEIGHT, introTiles.transform.position.y, 0);
            StartCoroutine(Utils.StaticUtils.MoveOverSeconds(introTiles.transform, end, 0.8f));
        }
    }

}
