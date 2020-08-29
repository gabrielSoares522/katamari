using UnityEngine;

[System.Serializable]
public class Category
{
    public GameObject objects;
    public float size;

    public bool check(float s)
    {
        if(s >= this.size)
        {
            for(int i = 0; i < this.objects.transform.childCount; i++)
            {
                this.objects.transform.GetChild(i).GetComponent<Collider>().isTrigger = true;
            }
            return true;
        }
        return false;
    }
}
