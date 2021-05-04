using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class WeaponDrop : MonoBehaviour
{
    protected static WeaponDrop instance;
    public GameObject[] rareWeapons;
    public GameObject[] normalWeapons;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    public static WeaponDrop GetInstance()
    {
        return instance;
    }

    public bool Drop(Vector2 position, WeaponSubType subType)
    {
        GameObject drop = null;
        Weapon weapon;
        int i;
        for (i = 0; i < rareWeapons.Length && i < normalWeapons.Length; i++)
        {
            weapon = normalWeapons[i].GetComponent<Pickable>().item;
            if (weapon && weapon.subType == subType)
            {
                drop = Instantiate(normalWeapons[i], position, Quaternion.identity);
            }

            weapon = rareWeapons[i].GetComponent<Pickable>().item;
            if (weapon && weapon.subType == subType)
            {
                drop = Instantiate(rareWeapons[i], position, Quaternion.identity);
            }
        }

        if (i < rareWeapons.Length)
        {
            for (int j = i; j < rareWeapons.Length; j++)
            {
                weapon = rareWeapons[j].GetComponent<Pickable>().item;
                if (weapon && weapon.subType == subType)
                {
                    drop = Instantiate(rareWeapons[j], position, Quaternion.identity);
                }
            }
        }
        else if (i < normalWeapons.Length)
        {
            for (int j = i; j < normalWeapons.Length; j++)
            {
                weapon = normalWeapons[j].GetComponent<Pickable>().item;
                if (weapon && weapon.subType == subType)
                {
                    drop = Instantiate(normalWeapons[i], position, Quaternion.identity);
                }
            }
        }

        if (drop != null)
        {
            drop.transform.position = position;
            return true;
        }

        return false;
    }

    public void DropNormal(Vector2 position)
    {
        int i = (int)(Random.value * normalWeapons.Length);
        GameObject drop = Instantiate(normalWeapons[i]);
        if (drop != null)
        {
            drop.transform.position = position;
        }
    }

    public void DropRare(Vector2 position)
    {
        int i = (int)(Random.value * rareWeapons.Length);
        GameObject drop = Instantiate(rareWeapons[i]);
        if (drop != null)
        {
            drop.transform.position = position;
        }
    }
}