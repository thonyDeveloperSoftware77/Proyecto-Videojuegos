using DragonBones;
using UnityEngine;

public class DragonBonesRenderer : MonoBehaviour
{
    public string skeletonPath = "Assets/DragonBones/Demos/Resources/SHURIKEN/Shuriken_ske.json"; // Ruta al archivo .json del esqueleto
    public string textureAtlasPath = "Assets/DragonBones/Demos/Resources/SHURIKEN/Shuriken_tex.json"; // Ruta al archivo .json del atlas de textura

    void Start()
    {
        UnityFactory.factory.LoadDragonBonesData(skeletonPath); // Carga los datos del esqueleto

        UnityFactory.factory.LoadTextureAtlasData(textureAtlasPath, "Shuriken"); // Carga los datos del atlas de textura

        var armatureComponent = UnityFactory.factory.BuildArmatureComponent("Armature"); // Construye el componente del armature

        // Configura la posición, rotación, escala u otras propiedades si es necesario
        armatureComponent.transform.localPosition = Vector3.zero;
        armatureComponent.transform.localScale = Vector3.one;

        // Añade el componente del armature al GameObject actual o a un padre deseado
        armatureComponent.gameObject.transform.SetParent(transform, false);

        // Puedes reproducir una animación aquí si es necesario
        armatureComponent.animation.Play("nivel4");
    }
}
