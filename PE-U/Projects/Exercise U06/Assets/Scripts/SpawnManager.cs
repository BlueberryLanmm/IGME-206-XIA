using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnManager : Singleton<SpawnManager>
{
    private const int Elephant = 0;
    private const int Turtle = 1;
    private const int Snail = 2;
    private const int Octopus = 3;
    private const int Kangaroo = 4;

    [SerializeField]
    private List<Sprite> animalSprites;
    [SerializeField]
    private GameObject animalPrefab;

    private int animalNumber;
    [SerializeField]
    private List<GameObject> animals;
    
    private SpriteRenderer animalRenderer;

    // (Optional) Prevent non-singleton constructor use.
    protected SpawnManager() { }

    // Start is called before the first frame update
    void Start()
    {
        animalRenderer = animalPrefab.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn()
    {
        //Randomize the total animal number.
        animalNumber = Mathf.Max(3, (int)Gaussian(15, 8));

        //Spawn all the creature and store them in a list.
        for (int i = 0; i < animalNumber; i++)
        {
            animals.Add(SpawnCreature());
        }
    }

    public void CleanUp()
    {
        for (int i = 0; i < animals.Count; i++)
        {
            GameObject.Destroy(animals[i]);
        }

        animals.Clear();
    }

    private GameObject SpawnCreature()
    {
        //Determine the spawn position
        float angle = Random.Range(0, 2 * Mathf.PI);
        float radius = Gaussian(0, 2);

        Vector2 spawnPosition = new Vector2(
            radius * Mathf.Cos(angle),
            radius * Mathf.Sin(angle));

        //Create and store a new animal.
        GameObject newAnimal = GameObject.Instantiate(
            animalRenderer.gameObject,
            spawnPosition,
            Quaternion.identity);

        //Get the sprite renderer of the new animal.
        SpriteRenderer newSpriteRenderer =
            newAnimal.GetComponent<SpriteRenderer>();

        //Determine the spawn sprite and color.
        try
        {
            //Define a float index to randomize the animal sprite.
            float index = Random.Range(0, 1f);

            if (index < 0.25f)
            {
                newSpriteRenderer.sprite = animalSprites[Elephant];
            }
            else if (index < 0.45f)
            {
                newSpriteRenderer.sprite = animalSprites[Turtle];
            }
            else if (index < 0.6f)
            {
                newSpriteRenderer.sprite = animalSprites[Snail];
            }
            else if (index < 0.7f)
            {
                newSpriteRenderer.sprite = animalSprites[Octopus];
            }
            else
            {
                newSpriteRenderer.sprite = animalSprites[Kangaroo];
            }

            //newSpriteRenderer.sprite =
            //    animalSprites[Random.Range(0, animalSprites.Count)];
        }
        catch
        { }

        newSpriteRenderer.color = Random.ColorHSV(0, 1, 1, 1, 1, 1, 1, 1);

        //Instantiate the animal and return the instantiated animal.
        return newAnimal;
    }

    /// <summary>
    /// Gaussian function to generate a distance conforming to Gaussian distribution.
    /// </summary>
    /// <param name="mean">The average distance</param>
    /// <param name="stdDev">The standard deviation of distance</param>
    /// <returns>A randomized distance conforming to Gaussian distribution</returns>
    private float Gaussian(float mean, float stdDev)
    {
        float val1 = Random.Range(0f, 1f);
        float val2 = Random.Range(0f, 1f);

        float gaussValue =
        Mathf.Sqrt(-2.0f * Mathf.Log(val1)) *
        Mathf.Sin(2.0f * Mathf.PI * val2);

        return mean + stdDev * gaussValue;
    }

}
