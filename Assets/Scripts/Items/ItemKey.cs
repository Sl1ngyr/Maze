using UnityEngine;

namespace Items
{
    public class ItemKey : MonoBehaviour
    {
        public void PickUpKey()
        {
            gameObject.SetActive(false);
        }
    }
}