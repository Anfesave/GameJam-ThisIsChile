using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomPatient : MonoBehaviour
{
    [SerializeField] private Text nam,age,prof,dise;

    private string[] names = new string[]{"Andrés","Luis","Cris","Miguel","Juan","Pepe","Fernando","Oscar","Leo","Karol","Daniel","Jorge"};
    private string[] dissease = new string[]{"Sano","Cancer pulmonar", "Neumonia","Molestia en el pecho", "Calculos Renales", "Cirrosis", "Sifilis", "Jaqueca", "Dolores Estomacales","Fiebre", "Apendicitis", "Temblores", "Diabetes"};
    private string[] profession = new string[]{"Vendedor","Cajero","Enfermero","Futbolista","Chef","Desempleado","Contador","Programador","Musico","Artista","Profesor","Carabinero"};
    
    void Start() {
        GetRandomName();
        GetRandomAge();
        GetRandomProfession();
        GetRandomDesseise();
    }

    private void GetRandomName(){
        int rndm = Random.Range(0,11);
        string name = names[rndm];

        nam.text = name;
    }

    private void GetRandomAge(){
        //ACA SE DECIDE SI SERA JOVEN O ADULTO EL SPRITE
        int rndm = Random.Range(18,80);
        Debug.Log(rndm);
        int edad = rndm;
        Debug.Log(edad);

        age.text = edad.ToString();

        if(edad <= 49){
            //es joven
        }else if(edad >= 80){
            //es viejo
        }
    }

    private void GetRandomProfession(){
        int rndm = Random.Range(0,11);
        string profe = profession[rndm];

        prof.text = profe;
    }

    private void GetRandomDesseise(){
        int rndm = Random.Range(0,11);
        string desi = dissease[rndm];

        dise.text = desi;
    }

}
