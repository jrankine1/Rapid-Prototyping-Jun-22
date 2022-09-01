using UnityEngine;

public class Beatscroller : MonoBehaviour
{
    public float beatTempo;

    public bool hasStarted;

    public AudioSource music;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
       
       if(hasStarted == true)
        {
            transform.position -= new Vector3(beatTempo * Time.deltaTime, 0f, 0f);
            
        }
        
        
    }

    
}
