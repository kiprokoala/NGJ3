using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GenerateTiles : MonoBehaviour
{
    public int ground_height = 10;
    public int actual_x = -22;

    public Tilemap tilemap_ground;
    public Tilemap tilemap_buildings;

    public Tile ground;
    public Tile window;

    public Tile[] tiles;

    public Tile down_left_door;
    public Tile down_right_door;
    public Tile up_right_door;
    public Tile up_left_door;

    public GameObject checkpoint;
    public GameObject enemy;

    public static GenerateTiles instance;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    void Start()
    {
        //Pour la génération de base
        for (int i = 0; i < 5; i += 1)
        {
            GenerateLandscape();
        }
    }

    public void GenerateLandscape()
    {
        generateGround();
        generateBuilding();
        if (actual_x > 0)
        {
            Instantiate(checkpoint, new Vector3(actual_x, 5, 0), Quaternion.identity);
            Instantiate(enemy, new Vector3(actual_x + 3, 2, 0), Quaternion.identity);
            Instantiate(enemy, new Vector3(actual_x + 2, 6, 0), Quaternion.identity);
        }
        actual_x += 11;
    }

    //Génération du sol de hauteur 6
    //Si le sol doit être augmenté, la valeur dans le mouvement doit aussi être modifié
    public void generateGround()
    {
        for (int i = actual_x; i < actual_x + 11; i++)
        {
            for (int j = 0; j <= ground_height; j++)
            {
                tilemap_ground.SetTile(new Vector3Int(i, j, 0), ground);
            }
        }
    }

    //Un bâtiment de référence, mais peut être modifié pour d'autres besoins
    public void generateBuilding()
    {
        //Aléatoire de la couleur du bât
        System.Random random = new System.Random();
        Tile _wall = tiles[random.Next(0, tiles.Length)];

        for (int i = actual_x; i < actual_x + 10; i++)
        {
            for (int j = ground_height; j <= ground_height + 10; j++)
            {
                //On remplit tout le bâtiment de la brique de base
                tilemap_buildings.SetTile(new Vector3Int(i, j, 0), _wall);
            }
        }

        //Construction de la porte
        tilemap_buildings.SetTile(new Vector3Int(actual_x + 4, ground_height + 1, 0), down_left_door);
        tilemap_buildings.SetTile(new Vector3Int(actual_x + 5, ground_height + 1, 0), down_right_door);
        tilemap_buildings.SetTile(new Vector3Int(actual_x + 5, ground_height + 2, 0), up_right_door);
        tilemap_buildings.SetTile(new Vector3Int(actual_x + 4, ground_height + 2, 0), up_left_door);

        //Les fenêtres (sinon ça faisait 16 lignes, j'ai décidé de le raccourcir)
        int[] positions_x = { actual_x + 1, actual_x + 2, actual_x + 7, actual_x + 8 };
        int[] positions_y = { ground_height + 3, ground_height + 4, ground_height + 7, ground_height + 8 };
        foreach (int pos_x in positions_x)
        {
            foreach (int pos_y in positions_y)
            {
                tilemap_buildings.SetTile(new Vector3Int(pos_x, pos_y, 0), window);
            }
        }
    }
}
