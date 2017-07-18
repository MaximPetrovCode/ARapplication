/**
* Copyright (c) 2015-2016 VisionStar Information Technology (Shanghai) Co., Ltd. All Rights Reserved.
* EasyAR is the registered trademark or trademark of VisionStar Information Technology (Shanghai) Co., Ltd in China
* and other countries for the augmented reality technology developed by VisionStar Information Technology (Shanghai) Co., Ltd.
*/

using UnityEngine;
using EasyAR;
using System.Collections;

namespace EasyARSample
{
    public class DynamicImageTagetBehaviour : ImageTargetBehaviour
    {

        


        private GameObject subGameObject;
        private GameObject subTextObject;

        public string nameOftheObject = TargetOnTheFly.nameOfTheObject;


        protected override void Awake()
        {
            base.Awake();
            TargetFound += OnTargetFound;
            TargetLost += OnTargetLost;
            subGameObject = Instantiate(Resources.Load(nameOftheObject, typeof(GameObject))) as GameObject;
            subGameObject.transform.parent = transform;
            subGameObject.SetActive(false);
        }




        protected override void Start()
        {
            base.Start();
            HideObjects(transform);

        }

        void HideObjects(Transform trans)
        {
            for (int i = 0; i < trans.childCount; ++i)
                HideObjects(trans.GetChild(i));
            if (transform != trans)
                subGameObject.SetActive(false);
        }

        void ShowObjects(Transform trans)
        {
            for (int i = 0; i < trans.childCount; ++i)
                ShowObjects(trans.GetChild(i));
            if (transform != trans)
                subGameObject.SetActive(true);
        }

        void OnTargetFound(ImageTargetBaseBehaviour behaviour)
        {
            subGameObject.SetActive(true);
        }

        void OnTargetLost(ImageTargetBaseBehaviour behaviour)
        {
            subGameObject.SetActive(false);
        }

        
    }
}
