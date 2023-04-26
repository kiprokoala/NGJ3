using UnityEngine;
using UnityEngine.Tilemaps;

public class GenerateTiles : MonoBehaviour
{
    public Tilemap tilemap_ground;
    public Tilemap tilemap_buildings;
    
    public Tile ground;
    public Tile window;
    public Tile wall;

    public Tile up_left_door;
    public Tile up_right_door;
    public Tile down_left_door;
    public Tile down_right_door;
    void Start()
    {
        //Pour avoir le sol continu (100 est juste une valeur de test, à modifier lors de la génération)
        for (int i = -12; i < 100; i++)
        {
            for (int j = -6; j <= -2; j++)
            {
                tilemap_ground.SetTile(new Vector3Int(i, j, 0), ground);
                if (i % 11 == 0) { generateBuilding(i); }
            }
        }
    }

    //Un bâtiment de référence, mais peut être modifié pour d'autres besoins
    void generateBuilding(int beginning)
    {
        for (int i = beginning; i < beginning + 10; i++)
        {
            for (int j = -1; j <= 8; j++)
            {
                //On remplit tout le bâtiment de la brique de base
                tilemap_buildings.SetTile(new Vector3Int(i, j, 0), wall);
            }
        }

        //Construction de la porte
        tilemap_buildings.SetTile(new Vector3Int(beginning + 4, -1, 0), down_left_door);
        tilemap_buildings.SetTile(new Vector3Int(beginning + 4, 0, 0), up_left_door);
        tilemap_buildings.SetTile(new Vector3Int(beginning + 5, 0, 0), up_right_door);
        tilemap_buildings.SetTile(new Vector3Int(beginning + 5, -1, 0), down_right_door);

        //Les fenêtres (sinon ça faisait 16 lignes, j'ai décidé de le raccourcir)
        int[] positions_x = { beginning + 1, beginning + 2, beginning + 7, beginning + 8 };
        int[] positions_y = { 1, 2, 5, 6 };
        foreach(int pos_x in positions_x)
        {
            foreach(int pos_y in positions_y)
            {
                tilemap_buildings.SetTile(new Vector3Int(pos_x, pos_y, 0), window);
            }
        }
    }
}
