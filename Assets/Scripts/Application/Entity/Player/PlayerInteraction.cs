using UnityEngine;

namespace Application.Entity.Player
{
    public class PlayerInteraction : MonoBehaviour
    {
        Land selectedLand = null;

        void Update()
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, 1))
            {
                OnInteractableHit(hit);
            }
        }

        void OnInteractableHit(RaycastHit hit)
        {
            Collider other = hit.collider;
            if (other.tag == "Land")
            {
                Land land = other.GetComponent<Land>();
                SelectLand(land);
                return;
            }

            if (selectedLand != null)
            {
                selectedLand.Select(false);
                selectedLand = null;
            }
        }

        void SelectLand(Land land)
        {
            //Set the previously selected land to false (If any)
            if (selectedLand != null)
            {
                selectedLand.Select(false);
            }

            //Set the new selected land to the land we're selecting now. 
            selectedLand = land;
            land.Select(true);
        }

        public void Interact()
        {
            //Check if the player is selecting any land
            if (selectedLand != null)
            {
                selectedLand.Interact();
                return;
            }

            Debug.Log("Not on any land!");
        }
    }
}