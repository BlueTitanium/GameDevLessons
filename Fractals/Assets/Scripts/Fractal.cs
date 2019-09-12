using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fractal : MonoBehaviour
{
    private static Vector3[] childDirections = {Vector3.up, Vector3.right, Vector3.left, Vector3.forward, Vector3.back};
    private static Quaternion[] childOrientations = {Quaternion.identity, Quaternion.Euler(0f, 0f, -90f), Quaternion.Euler(0f, 0f, 90f), Quaternion.Euler(90f,0f,0f), Quaternion.Euler(-90f,0f,0f)};
    
    public Mesh[] meshes;
    public Material mat;
    public int maxDepth;
    public float childScale;
    public float spawnProbability;
    public float maxRotSpeed;
    public float maxTwist;

    private float rotSpeed;
    private int depth;
    private Material[,] mats;

    //Initialize the materials
    private void InitMats(){
        mats = new Material[maxDepth + 1, 2];
        for(int i = 0; i <= maxDepth; i++){
            float t = i/(maxDepth-1f);
            t *= t;
            mats[i,0] = new Material(mat);
            mats[i,0].color = Color.Lerp(Color.white, Color.yellow,t);
            mats[i,1] = new Material(mat);
            mats[i,1].color = Color.Lerp(Color.white, Color.cyan, t);
        }
        mats[maxDepth, 0].color = Color.magenta;
        mats[maxDepth, 1].color = Color.red;
    }

    // Start is called before the first frame update
    void Start()
    {
        rotSpeed = Random.Range(-maxRotSpeed, maxRotSpeed);
        transform.Rotate(Random.Range(-maxTwist, maxTwist), 0f, 0f);
        if(mats == null) InitMats();
        gameObject.AddComponent<MeshFilter>().mesh = meshes[Random.Range(0, meshes.Length)];
        gameObject.AddComponent<MeshRenderer>().material = mats[depth, Random.Range(0,2)];
        if(depth < maxDepth) StartCoroutine(CreateChildren());
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Rotate(0f, rotSpeed * Time.deltaTime, 0f);        
    }

    //Creates The Children of the Fractal
    private IEnumerator CreateChildren(){
        for(int i = 0; i < childDirections.Length; i++){
            if(Random.value < spawnProbability){
                yield return new WaitForSeconds(Random.Range(.1f,.5f));
                new GameObject("Fractal Child").AddComponent<Fractal>().Init(this,i);
            }
        }
    }

    //Initializes the child with the required properties
    private void Init(Fractal parent, int childIndex){
        meshes = parent.meshes;
        mats = parent.mats;
        maxDepth = parent.maxDepth;
        depth = parent.depth + 1;
        childScale = parent.childScale;
        spawnProbability = parent.spawnProbability;
        maxRotSpeed = parent.maxRotSpeed;
        maxTwist = parent.maxTwist;
        transform.parent = parent.transform;
        transform.localScale = Vector3.one * childScale;
        transform.localPosition = childDirections[childIndex] * (.5f + .5f * childScale);
        transform.localRotation = childOrientations[childIndex];
    }
}
