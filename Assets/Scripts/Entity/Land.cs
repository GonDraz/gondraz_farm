using UnityEngine;

namespace Entity
{
    public class Land : MonoBehaviour
    {
        public enum LandStatus
        {
            Soil,
            Farmland,
            Watered
        }

        [SerializeField] private LandStatus landStatus;

        [SerializeField] private Material soilMat, farmlandMat, wateredMat;

        public GameObject select;
        private Renderer _renderer;

        private void Start()
        {
            _renderer = GetComponent<Renderer>();

            SwitchLandStatus(LandStatus.Soil);

            Select(false);
        }

        public void SwitchLandStatus(LandStatus statusToSwitch)
        {
            landStatus = statusToSwitch;

            var materialToSwitch = soilMat;

            switch (statusToSwitch)
            {
                case LandStatus.Soil:
                    materialToSwitch = soilMat;
                    break;
                case LandStatus.Farmland:
                    materialToSwitch = farmlandMat;
                    break;

                case LandStatus.Watered:
                    materialToSwitch = wateredMat;
                    break;
            }

            _renderer.material = materialToSwitch;
        }

        public void Select(bool toggle)
        {
            select.SetActive(toggle);
        }

        public void Interact()
        {
            SwitchLandStatus(LandStatus.Farmland);
        }
    }
}