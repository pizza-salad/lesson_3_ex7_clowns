using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorModifier : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 originalScale;
    ArrayList colors = new ArrayList(){Color.white, Color.magenta, Color.red, Color.blue, Color.green, Color.yellow };
    public int currentColor = 0;
    void Start()
    {
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
        transform.localScale = originalScale * 1.2f;
    }
    private void OnMouseExit() {
        transform.localScale = originalScale;
    }
    private void recolor(bool all){
        if (all){
            GameObject clown = GameObject.FindWithTag("clown");
            
            ArrayList obj_list = get_objects(clown);
            foreach(GameObject g in obj_list){
                string name = g.name;
                if(!g.tag.Equals("colorable") || name.Equals(this.gameObject.name)){
                    continue;
                }
                SpriteRenderer s = g.GetComponent<SpriteRenderer>();
                if(s){
                    s.color = (Color)colors[this.currentColor];
                    g.GetComponent<ColorModifier>().currentColor = this.currentColor;
                }
            }
        }else{
            this.currentColor = ++this.currentColor % this.colors.Count;
            this.transform.gameObject.GetComponent<SpriteRenderer>().color = (Color)colors[this.currentColor];
        }
    }
    private ArrayList get_objects(GameObject clown){
        ArrayList objs = new ArrayList();
        objs.Add(clown);
        for(int i = 0;i< clown.transform.childCount; i++){
            objs.AddRange(get_objects(clown.transform.GetChild(i).gameObject));
        }
        return objs;

    }
}
