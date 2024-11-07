using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : Singleton<SpawnManager>
{
    [SerializeField]
    private List<Sprite> animalSprites;
    [SerializeField]
    private GameObject animal;
    
    private SpriteRenderer animalRenderer;

    // (Optional) Prevent non-singleton constructor use.
    protected SpawnManager() { }

    // Start is called before the first frame update
    void Start()
    {
        animalRenderer = animal.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Spawn()
    {
        //Make sure there is at least one animal sprite.
        animalRenderer.sprite = animalSprites[Random.Range(0, animalSprites.Count)];
    }
}
