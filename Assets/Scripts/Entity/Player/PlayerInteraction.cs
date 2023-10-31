using UnityEngine;

namespace Entity.Player
{
    public class PlayerInteraction : MonoBehaviour
    {
        private Land _selectedLand;

        private void Update()
        {
            if (Physics.Raycast(transform.position, Vector3.down, out var hit, 1)) OnInteractableHit(hit);
        }

        private void OnInteractableHit(RaycastHit hit)
        {
            var other = hit.collider;
            if (other.CompareTag("Land"))
            {
                var land = other.GetComponent<Land>();
                SelectLand(land);
                return;
            }

            if (_selectedLand != null)
            {
                _selectedLand.Select(false);
                _selectedLand = null;
            }
        }

        private void SelectLand(Land land)
        {
            if (_selectedLand != null) _selectedLand.Select(false);

            _selectedLand = land;
            land.Select(true);
        }

        public void Interact()
        {
            if (_selectedLand != null)
            {
                _selectedLand.Interact();
                return;
            }

            Debug.Log("Not on any land!");
        }
    }
}