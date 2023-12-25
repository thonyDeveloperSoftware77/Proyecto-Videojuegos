// Nivel.cs
using UnityEngine;

public struct Nivel
{
    public int numeroNivel;
    public float segundos;
    public int numMorado;
    public int numRosa;
    public int numAzul;
    public int numNegro;

    public Nivel(int numeroNivel, float segundos, int numMorado, int numRosa, int numAzul, int numNegro)
    {
        this.numeroNivel = numeroNivel;
        this.segundos = segundos;
        this.numMorado = numMorado;
        this.numRosa = numRosa;
        this.numAzul = numAzul;
        this.numNegro = numNegro;
    }
}
