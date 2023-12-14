using UnityEngine;
using System.Collections;

public class Floater : MonoBehaviour {

public float gradoGiro = 15.0f;
public float amplitud = 0.2f;
public float frequencia = 1f;

// variables
Vector3 posOffset = new Vector3 ();
Vector3 tempPos = new Vector3 ();

void Start () {
posOffset = transform.position;
}

void Update () {
//giro
transform.Rotate(new Vector3(0f, Time.deltaTime * gradoGiro, 0f), Space.World);

//posicion
tempPos = posOffset;
tempPos.y += Mathf.Sin (Time.fixedTime * Mathf.PI * frequencia) * amplitud;

transform.position = tempPos;
}
}