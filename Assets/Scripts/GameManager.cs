using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Entropy.Isdle
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        public Camera Camera { get => _cam; }
        private Camera _cam;

        private void Awake()
        {
            if(Instance == null) { Instance = this; }
            else { Destroy(gameObject); }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                DebugPrintInfo();
            }
        }
        [Button]
        public void DebugPrintInfo()
        {
            Debug.Log(GetNormalizedMouseDirection(Vector3.zero));
        }

        public Vector2 GetMouseDirection(Vector3 pos)
        {
            if (_cam == null) { _cam = Camera.main; }

            Vector3 mousePos = Input.mousePosition;
            mousePos.z = -10;
            return (_cam.ScreenToWorldPoint(mousePos) - pos);
        }
        public Vector2 GetNormalizedMouseDirection(Vector3 pos) => GetMouseDirection(pos).normalized;
        public Vector2 GetCardinalMouseDirection(Vector3 pos)
        {
            Vector2 mouseDir = GetNormalizedMouseDirection(pos);
            float quadrant = Mathf.RoundToInt(4 * Mathf.Atan2(mouseDir.y, mouseDir.x) / (2 * Mathf.PI) + 4) % 4;

            //mouseDir.x = Mathf.Ceil(mouseDir.x + 1) - 1;
            //mouseDir.y = Mathf.Ceil(mouseDir.y + 1) - 1;
            //if (mouseDir.x == 0) { mouseDir.x = -1; }
            //if (mouseDir.y == 0) { mouseDir.y = -1; }
            return mouseDir;
        }
    }
}