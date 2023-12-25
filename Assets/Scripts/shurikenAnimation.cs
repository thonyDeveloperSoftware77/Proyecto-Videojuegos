using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;
using System.IO;

public class shurikenAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var llora = "Assets/DragonBones/Demos/Resources/SHURIKEN";
        string projectPath = "Assets/DragonBones/Demos/Resources/SHURIKEN"; // Ruta relativa desde "Assets"
        string materialPath = Path.Combine(projectPath, "Shuriken_tex_UI_Mat.mat");

        // Crea un nuevo material y lo guarda en la ruta especificada
        var newMaterial = new UnityEngine.Material(Shader.Find("Standard")); // Puedes ajustar el shader según sea necesario
        UnityEditor.AssetDatabase.CreateAsset(newMaterial, materialPath);
        // Crea el material para el archivo de textura
        string texturePath = Path.Combine(projectPath, "Shuriken_tex.png"); // Nombre del archivo de textura
        var texture = UnityEditor.AssetDatabase.LoadAssetAtPath<Texture2D>(texturePath);
        var materialForTexture = new Material(Shader.Find("Standard"));
        materialForTexture.mainTexture = texture;
        UnityEditor.AssetDatabase.CreateAsset(materialForTexture, texturePath.Replace(".png", "_Mat.mat"));

        // Crea el material para el archivo de esqueleto
        string skeletonPath = Path.Combine(projectPath, "Shuriken_ske.json"); // Nombre del archivo de esqueleto
        var materialForSkeleton = new Material(Shader.Find("Standard")); // Puedes ajustar el shader según sea necesario
        UnityEditor.AssetDatabase.CreateAsset(materialForSkeleton, skeletonPath.Replace(".json", "_Mat.mat"));


    }

    // Update is called once per frame
    void Update()
    {
    }
}
