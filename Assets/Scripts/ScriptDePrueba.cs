using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptDePrueba : MonoBehaviour
{

    public int livesCharacter = 3;
    public int livesCharacter2 = 4;
    public float numeroDecimal = 4.5f;
    public string nameCharacter = "Mario";
    public bool interruptor = true;
    public int[] arrayNumeros;
    private int[] arrayNumeros2 = new int[6];
    private int[] arrayNumeros3 = {7, 8, 3, 9};
    private string [] arrayStrings = new string[7];
    private string [] arrayStrings2 = {"Hola", "adios"};

    private int[,] array2Dimensiones = new int[4, 2];
    

    public List<string> stringList;

    private List<int> intList = new List<int>(7);
    private List<int> intList2 = new List<int>() {7, 9, 6, 78, 25, 0, 2};


    // Start is called before the first frame update
    void Start()
    {
      /*
      Debug.Log(arrayNumeros[0]);
      arrayNumeros2[0] = 4;

      Debug.Log(array2Dimensiones[0, 1]);

      

      intList2.Add(10);
      intList2.RemoveAt(2);
      intList2.Remove(78);
      intList2.Insert(5, 888);

       /* livesCharacter = 10;
        numeroDecimal = 7.54f;
        nameCharacter = "Luigy";
        interruptor = false;

        int suma = livesCharacter + livesCharacter2;
        Debug.Log(suma);
        string sumaTextos = nameCharacter + "Warrio";
        Debug.Log(sumaTextos);

      Debug.Log(nameCharacter);
      Debug.Log(livesCharacter);
      Debug.Log(numeroDecimal);  */


     /* for (int i = 0; i < 5; i++)
      {
        Debug.Log("srfedgr");

      }
      

      int i = 0;
      while ( i < 5)
      {
        Debug.Log("i");
        i++;

      }

      do
      {
        Debug.Log(i);
        i++;
      }while (i < 5);*/

      foreach (int numero in arrayNumeros3)
      {
        Debug.Log(numero);

      }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}