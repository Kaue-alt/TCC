using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FalaVelho : ScriptableObject
{
    [TextArea(1, 11)]
    public string falinha;
    public Resposta[] respostinha;
}
