using UnityEngine;

enum ObjectType {Character} // Stuff to save

public class SavableObject : MonoBehaviour
{
    protected string save;
    private ObjectType _objectType;
    
    private void Start()
    {
        
    }

    public virtual void Save(int id)
    {
        
    }

    public virtual void Load(string[] values)
    {
        
    }

    public void DestroySavable()
    {
        
    }
    
}
