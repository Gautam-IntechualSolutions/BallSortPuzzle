using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public GameObject squareBox;
    GameObject abc;
    public List<Material> materialList;
    List<GameObject> tempList = new List<GameObject>();
    int listLength, pos = -2, rePosTempListChildl;
    public List<string> tagName;
    string hitGameObjectname, rePosTemplist;
    bool isRepos = false;

    // Start is called before the first frame update
    void Start()
    {
        int randomBox = 3;
        for (int i = 0; i < randomBox; i++)
        {
            tempList.Add(Instantiate(squareBox, new Vector2(transform.position.x + pos, transform.position.y), Quaternion.identity));
            tempList[i].gameObject.name = "Square" + i;
            listLength = Random.Range(2, 3);
            for (int j = 0; j < listLength; j++)
            {
                int materialColor = Random.Range(0, 2);
                tempList[i].transform.GetChild(j).gameObject.SetActive(true);
                tempList[i].transform.GetChild(j).gameObject.GetComponent<SpriteRenderer>().material = materialList[materialColor];
                tempList[i].transform.GetChild(j).gameObject.tag = tagName[materialColor];
            }
            pos = pos + 2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

        if (Input.GetMouseButtonDown(0) && hit.collider)
        {
            if (!isRepos)
            {
                hitGameObjectname = hit.collider.gameObject.name;
                positionChange(hitGameObjectname);
            }
            else
            {
                reposChange(hit);
            }
        }
    }
    void positionChange(string i)
    {
        for (int j = 3; j >= 0; j--)
        {
            if (GameObject.Find(i).transform.GetChild(j).gameObject.activeInHierarchy)
            {
                Debug.Log(j);
                if (j == 3)
                {
                    int p = j;
                    if ((GameObject.Find(i).transform.GetChild(p).gameObject.tag == GameObject.Find(i).transform.GetChild(p - 1).gameObject.tag) && (GameObject.Find(i).transform.GetChild(p).gameObject.tag == GameObject.Find(i).transform.GetChild(p - 2).gameObject.tag) && (GameObject.Find(i).transform.GetChild(p).gameObject.tag == GameObject.Find(i).transform.GetChild(p - 3).gameObject.tag))
                    {
                        break;
                    }
                    else
                    {
                        rePosTemplist = i;
                        rePosTempListChildl = j;
                        GameObject.Find(i).transform.GetChild(4).gameObject.GetComponent<SpriteRenderer>().material = GameObject.Find(i).transform.GetChild(j).gameObject.GetComponent<SpriteRenderer>().material;
                        GameObject.Find(i).transform.GetChild(4).gameObject.tag = GameObject.Find(i).transform.GetChild(j).gameObject.tag;
                        GameObject.Find(i).transform.GetChild(4).gameObject.SetActive(true);
                        GameObject.Find(rePosTemplist).transform.GetChild(rePosTempListChildl).gameObject.SetActive(false);
                        isRepos = true;
                        break;
                    }
                }
                else
                {
                    rePosTemplist = i;
                    rePosTempListChildl = j;
                    GameObject.Find(i).transform.GetChild(4).gameObject.GetComponent<SpriteRenderer>().material = GameObject.Find(i).transform.GetChild(j).gameObject.GetComponent<SpriteRenderer>().material;
                    GameObject.Find(i).transform.GetChild(4).gameObject.tag = GameObject.Find(i).transform.GetChild(j).gameObject.tag;
                    GameObject.Find(i).transform.GetChild(4).gameObject.SetActive(true);
                    GameObject.Find(rePosTemplist).transform.GetChild(rePosTempListChildl).gameObject.SetActive(false);
                    isRepos = true;
                    break;
                }
                
            }
        }
    }

    void reposChange(RaycastHit2D hit)
    {
        if (isRepos)
        {
            if (hit.collider.name == hitGameObjectname)
            {
                GameObject.Find(rePosTemplist).transform.GetChild(rePosTempListChildl).gameObject.GetComponent<SpriteRenderer>().material = GameObject.Find(rePosTemplist).transform.GetChild(4).gameObject.GetComponent<SpriteRenderer>().material;
                GameObject.Find(rePosTemplist).transform.GetChild(rePosTempListChildl).gameObject.tag = GameObject.Find(rePosTemplist).transform.GetChild(4).gameObject.tag;
                GameObject.Find(rePosTemplist).transform.GetChild(4).gameObject.SetActive(false);
                GameObject.Find(rePosTemplist).transform.GetChild(rePosTempListChildl).gameObject.SetActive(true);
                isRepos = false;
            }
            else if (hit.collider.name != hitGameObjectname)
            {
                string gameObjectHit = hit.collider.name;
                for (int j = 0; j <= 4; j++)
                {
                    if (!GameObject.Find(gameObjectHit).transform.GetChild(j).gameObject.activeInHierarchy)
                    {
                        if (j == 0)
                        {
                            //Debug.Log(j);
                            GameObject.Find(rePosTemplist).transform.GetChild(4).gameObject.SetActive(false);
                            GameObject.Find(gameObjectHit).transform.GetChild(j).gameObject.SetActive(true);
                            GameObject.Find(gameObjectHit).transform.GetChild(j).gameObject.GetComponent<SpriteRenderer>().material = GameObject.Find(rePosTemplist).transform.GetChild(rePosTempListChildl).gameObject.GetComponent<SpriteRenderer>().material;
                            GameObject.Find(gameObjectHit).transform.GetChild(j).gameObject.tag = GameObject.Find(rePosTemplist).transform.GetChild(rePosTempListChildl).gameObject.tag;
                            GameObject.Find(rePosTemplist).transform.GetChild(rePosTempListChildl).gameObject.SetActive(false);
                            isRepos = false;
                            break;
                        }
                        else if (j == 1)
                        {
                            int p = j;
                            if (GameObject.Find(gameObjectHit).transform.GetChild(p - 1).gameObject.tag == GameObject.Find(rePosTemplist).transform.GetChild(rePosTempListChildl).gameObject.tag)
                            {
                                GameObject.Find(rePosTemplist).transform.GetChild(4).gameObject.SetActive(false);
                                GameObject.Find(gameObjectHit).transform.GetChild(j).gameObject.SetActive(true);
                                GameObject.Find(gameObjectHit).transform.GetChild(j).gameObject.GetComponent<SpriteRenderer>().material = GameObject.Find(rePosTemplist).transform.GetChild(rePosTempListChildl).gameObject.GetComponent<SpriteRenderer>().material;
                                GameObject.Find(gameObjectHit).transform.GetChild(j).gameObject.tag = GameObject.Find(rePosTemplist).transform.GetChild(rePosTempListChildl).gameObject.tag;
                                GameObject.Find(rePosTemplist).transform.GetChild(rePosTempListChildl).gameObject.SetActive(false);
                                isRepos = false;
                                break;
                            }
                            else
                            {
                                GameObject.Find(rePosTemplist).transform.GetChild(rePosTempListChildl).gameObject.GetComponent<SpriteRenderer>().material = GameObject.Find(rePosTemplist).transform.GetChild(4).gameObject.GetComponent<SpriteRenderer>().material;
                                GameObject.Find(rePosTemplist).transform.GetChild(4).gameObject.SetActive(false);
                                GameObject.Find(rePosTemplist).transform.GetChild(rePosTempListChildl).gameObject.SetActive(true);
                                GameObject.Find(rePosTemplist).transform.GetChild(rePosTempListChildl).gameObject.tag = GameObject.Find(rePosTemplist).transform.GetChild(4).gameObject.tag;
                                isRepos = false;
                                break;
                            }
                        }
                        else if (j == 2)
                        {
                            int p = j;
                            if (GameObject.Find(gameObjectHit).transform.GetChild(p - 1).gameObject.tag == GameObject.Find(rePosTemplist).transform.GetChild(rePosTempListChildl).gameObject.tag)
                            {
                                GameObject.Find(rePosTemplist).transform.GetChild(4).gameObject.SetActive(false);
                                GameObject.Find(gameObjectHit).transform.GetChild(j).gameObject.SetActive(true);
                                GameObject.Find(gameObjectHit).transform.GetChild(j).gameObject.GetComponent<SpriteRenderer>().material = GameObject.Find(rePosTemplist).transform.GetChild(rePosTempListChildl).gameObject.GetComponent<SpriteRenderer>().material;
                                GameObject.Find(gameObjectHit).transform.GetChild(j).gameObject.tag = GameObject.Find(rePosTemplist).transform.GetChild(rePosTempListChildl).gameObject.tag;
                                GameObject.Find(rePosTemplist).transform.GetChild(rePosTempListChildl).gameObject.SetActive(false);
                                isRepos = false;
                                break;
                            }
                            else
                            {
                                GameObject.Find(rePosTemplist).transform.GetChild(rePosTempListChildl).gameObject.GetComponent<SpriteRenderer>().material = GameObject.Find(rePosTemplist).transform.GetChild(4).gameObject.GetComponent<SpriteRenderer>().material;
                                GameObject.Find(rePosTemplist).transform.GetChild(4).gameObject.SetActive(false);
                                GameObject.Find(rePosTemplist).transform.GetChild(rePosTempListChildl).gameObject.SetActive(true);
                                GameObject.Find(rePosTemplist).transform.GetChild(rePosTempListChildl).gameObject.tag = GameObject.Find(rePosTemplist).transform.GetChild(4).gameObject.tag;
                                isRepos = false;
                                break;
                            }
                        }
                        else if (j == 3)
                        {
                            int p = j;
                            if (GameObject.Find(gameObjectHit).transform.GetChild(p - 1).gameObject.tag == GameObject.Find(rePosTemplist).transform.GetChild(rePosTempListChildl).gameObject.tag)
                            {
                                GameObject.Find(rePosTemplist).transform.GetChild(4).gameObject.SetActive(false);
                                GameObject.Find(gameObjectHit).transform.GetChild(j).gameObject.SetActive(true);
                                GameObject.Find(gameObjectHit).transform.GetChild(j).gameObject.GetComponent<SpriteRenderer>().material = GameObject.Find(rePosTemplist).transform.GetChild(rePosTempListChildl).gameObject.GetComponent<SpriteRenderer>().material;
                                GameObject.Find(gameObjectHit).transform.GetChild(j).gameObject.tag = GameObject.Find(rePosTemplist).transform.GetChild(rePosTempListChildl).gameObject.tag;
                                GameObject.Find(rePosTemplist).transform.GetChild(rePosTempListChildl).gameObject.SetActive(false);
                                isRepos = false;
                                break;
                            }
                            else
                            {
                                GameObject.Find(rePosTemplist).transform.GetChild(rePosTempListChildl).gameObject.GetComponent<SpriteRenderer>().material = GameObject.Find(rePosTemplist).transform.GetChild(4).gameObject.GetComponent<SpriteRenderer>().material;
                                GameObject.Find(rePosTemplist).transform.GetChild(4).gameObject.SetActive(false);
                                GameObject.Find(rePosTemplist).transform.GetChild(rePosTempListChildl).gameObject.SetActive(true);
                                GameObject.Find(rePosTemplist).transform.GetChild(rePosTempListChildl).gameObject.tag = GameObject.Find(rePosTemplist).transform.GetChild(4).gameObject.tag;
                                isRepos = false;
                                break;
                            }
                        }
                        else
                        {
                            GameObject.Find(rePosTemplist).transform.GetChild(rePosTempListChildl).gameObject.GetComponent<SpriteRenderer>().material = GameObject.Find(rePosTemplist).transform.GetChild(4).gameObject.GetComponent<SpriteRenderer>().material;
                            GameObject.Find(rePosTemplist).transform.GetChild(4).gameObject.SetActive(false);
                            GameObject.Find(rePosTemplist).transform.GetChild(rePosTempListChildl).gameObject.SetActive(true);
                            GameObject.Find(rePosTemplist).transform.GetChild(rePosTempListChildl).gameObject.tag = GameObject.Find(rePosTemplist).transform.GetChild(4).gameObject.tag;
                            isRepos = false;
                            break;
                        }
                    }
                    
                }
            }
        }
    }
}