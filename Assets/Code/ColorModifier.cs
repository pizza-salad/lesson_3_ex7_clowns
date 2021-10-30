using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorModifier : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 originalScale;
    void Start()
    {
        print("Game started!");
        originalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver(){
        
        if(Input.GetMouseButtonDown(1)){
            recolor(true);
        }else{
            if(Input.GetMouseButtonDown(0)){
                recolor(false);
            }
        }
    }
    private void OnMouseEnter() {
        transform.localScale = originalScale * 1.1f;
    }
    private void OnMouseExit() {
        transform.localScale = originalScale;
    }
    private void recolor(bool allRandom){
        ArrayList obj_list = get_objects(transform);
        Color c = new Color(Random.Range(0.0f,1.0f),Random.Range(0.0f,1.0f),Random.Range(0.0f,1.0f));
        foreach(Transform o in obj_list){
            string name = o.gameObject.name;
            if(name.Contains("eye") || name.Contains("mouth")){
                continue;
            }
            SpriteRenderer s = o.gameObject.GetComponent<SpriteRenderer>();
            if(s){
                if (allRandom) c = new Color(Random.Range(0.0f,1.0f),Random.Range(0.0f,1.0f),Random.Range(0.0f,1.0f));
                s.color = c;
            }
        }
    }
    private ArrayList get_objects(Transform transform){
        ArrayList objs = new ArrayList();
        objs.Add(transform);
        for(int i = 0;i< transform.childCount; i++){
            objs.AddRange(get_objects(transform.GetChild(i)));
        }
        return objs;

    }
}
