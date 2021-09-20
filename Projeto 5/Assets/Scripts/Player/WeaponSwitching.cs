using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    public int selectedWeapon = 0;
    public Animator animPlayer;
    private bool canSwitch = true;

    // Start is called before the first frame update
    void Start()
    {
        SelectedWeapon();
    }

    // Update is called once per frame
    void Update()
    {

        if(Time.timeScale == 0){
            canSwitch = false;
        }
        else
        {
            canSwitch = true;
        }

        int previousSelectedWeapon = selectedWeapon;
        if (canSwitch)
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0f && !animPlayer.GetCurrentAnimatorStateInfo(0).IsTag("Attacking"))
            {
                if (selectedWeapon >= transform.childCount - 1)
                    selectedWeapon = 0;
                else
                    selectedWeapon++;
            }

            if (Input.GetAxis("Mouse ScrollWheel") < 0f && !animPlayer.GetCurrentAnimatorStateInfo(0).IsTag("Attacking"))
            {
                if (selectedWeapon <= 0)
                    selectedWeapon = transform.childCount - 1;
                else
                    selectedWeapon--;
            }

            if (previousSelectedWeapon != selectedWeapon)
            {
                SelectedWeapon();
            }
        }
    }

    void SelectedWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }
}
