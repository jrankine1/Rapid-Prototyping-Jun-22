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

    private void Update()
    {
        NoteMove();
    }
    public void NoteMove()
    {
        if (hasStarted == true)
        {
            transform.position -= new Vector3(beatTempo * Time.deltaTime, 0f, 0f);

        }
        if (hasStarted == false)
        {
            gameObject.transform.localPosition = new Vector3(0f, 0f, 0f);
            Debug.Log("Game is done");
        }
    }

   

    
}
