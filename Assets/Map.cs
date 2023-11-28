using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using Utils;

public class Map : MonoBehaviour
{
    public float speed = 100;
    public Transform obj;
    public GameObject musicController;
    public GameObject tileTwo;
    public GameObject cardSlots;

    public Camera mainCamera;
    private int SCROLL_SPEED = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private bool canContinue = true;
    private int currentTile = 0;
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log("lets go");
            if (!canContinue) return;
            if (currentTile == 0) {
                StartGame();
            }
        }
        if (currentTile == 2) {
            if (Input.GetKeyDown(KeyCode.A)) {
                canContinue = false;
                musicController.GetComponent<Music>().playSound(Music.Sounds.MUSIC_AUX_GUITAR);
                Transform card = tileTwo.transform.GetChild(0).GetChild(0);
                assignCard(card, 1);
                Transform target = Camera.main.transform;
                cardSlots.transform.parent = target;
                MoveToNextPageNow();
            } else if (Input.GetKeyDown(KeyCode.D)) {
                canContinue = false;
                musicController.GetComponent<Music>().playSound(Music.Sounds.MUSIC_AUX_GUITAR);
                Transform card = tileTwo.transform.GetChild(0).GetChild(1);
                assignCard(card, 1);
                Transform target = Camera.main.transform;
                cardSlots.transform.parent = target;
                MoveToNextPageNow();

            }
        }
        if (currentTile >= 2) {
            if (Input.GetKeyDown(KeyCode.Z)) {
                backToBeginning();
            }
        }
    }

    private void StartGame() {
        canContinue = false;
        musicController.GetComponent<Music>().playMusic2();
        List<IEnumerator> list = new List<IEnumerator>();
        list.Add(MoveToNextPage());
        list.Add(MoveToNextPage());
        StartCoroutine(UtilsMono.couroutineSequenceWithPause(list, SCROLL_SPEED, canContinue));
    }

    private void assignCard(Transform card, int slot) {
        Debug.Log(card.name);
        Transform cardSlot = cardSlots.transform.GetChild(slot - 1);
        SpriteRenderer spriteRendererCard = card.GetComponent<SpriteRenderer>();
        SpriteRenderer spriteRendererCardSlot = cardSlot.GetComponent<SpriteRenderer>();
        spriteRendererCardSlot.sprite = spriteRendererCard.sprite;
    }

    private void MoveToNextPageNow()
    {
        Vector3 end = new Vector3(obj.transform.position.x, obj.transform.position.y + 22f);
        currentTile = currentTile + 1;
        StartCoroutine(Utils.StaticUtils.MoveOverSeconds(obj, end, SCROLL_SPEED));
    }

    private IEnumerator MoveToNextPage()
    {
        Vector3 end = new Vector3(obj.transform.position.x, obj.transform.position.y + 22f);
        currentTile = currentTile + 1;
        yield return StartCoroutine(Utils.StaticUtils.MoveOverSeconds(obj, end, SCROLL_SPEED));
    }

    private void backToBeginning() {
        Vector3 end = new Vector3(obj.transform.position.x, 0, 0);
        cardSlots.transform.parent = obj.transform;
        cardSlots.transform.position = new Vector3(0, 0, 0);
        StartCoroutine(Utils.StaticUtils.MoveOverSeconds(obj.transform, end, 3f));
        currentTile = 0;
        canContinue = true;
    }

}
