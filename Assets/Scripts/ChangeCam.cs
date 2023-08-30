using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCam : MonoBehaviour
{
    
   public Camera UICam;
   public Camera MainCam;

   void Start()
   {
       UICam.enabled = true;
       MainCam.enabled = false;
   }

   public void changeCamera()
   {
       UICam.enabled = !UICam.enabled;
       MainCam.enabled = !MainCam.enabled;
   }

    
}
