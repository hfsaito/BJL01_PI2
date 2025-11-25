using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;


namespace Assets.App.Investigation.Buildings
{
    public class BuildingLight : MonoBehaviour
    {
        private readonly int MIN_LIGHTS_ON = 2;
        private readonly int MAX_LIGHTS_ON = 5;
        private int countLightsOn = 0;
        private List<GameObject> children;

        private readonly float MIN_RANDOM_UPDATE = 5f;
        private readonly float MAX_RANDOM_UPDATE = 15f;

        void Start()
        {
            children = new List<GameObject>();
            foreach (Transform child in transform)
            {
                children.Add(child.gameObject);
                child.gameObject.SetActive(false);
            }
            children = Shuffle(children);

            countLightsOn = Random.Range(MIN_LIGHTS_ON, MAX_LIGHTS_ON + 1);
            for (var i = 0; i < countLightsOn; i++)
            {
                children[i].SetActive(true);
            }

            StartCoroutine(RandomUpdate());
        }


        private bool turnOnOrOff;
        private IEnumerable<GameObject> filteredChildren;
        private int targetIndex;
        private GameObject targetChild;
        private IEnumerator RandomUpdate()
        {
            WaitForSeconds randomUpdateDelta = new(Random.Range(MIN_RANDOM_UPDATE, MAX_RANDOM_UPDATE));
            yield return randomUpdateDelta;

            turnOnOrOff = countLightsOn <= MIN_LIGHTS_ON ||
                countLightsOn < MAX_LIGHTS_ON &&
                Random.value > .5f;
            filteredChildren = children.Where(child => child.activeSelf != turnOnOrOff);
            targetIndex = Random.Range(0, filteredChildren.Count());
            targetChild = filteredChildren.ElementAt(targetIndex);
            targetChild.SetActive(turnOnOrOff);
            countLightsOn += turnOnOrOff ? 1 : -1;

            yield return StartCoroutine(RandomUpdate());
        }


        private List<T> Shuffle<T>(List<T> targetList)
        {
            var resultList = new List<T>();
            var auxList = new List<T>(targetList);
            while (auxList.Count > 0)
            {
                var index = Random.Range(0, auxList.Count);
                resultList.Add(auxList[index]);
                auxList.RemoveAt(index);
            }
            return resultList;
        }
    }
}
