using UnityEngine;

namespace Assets.Scripts
{
    public class PositionHelper
    {
        public Vector3 GenerateStartingPosition()
        {
            float positive_or_negative = (Random.Range(0, 2) * 2 - 1);
            Vector3 position = new Vector3((float)Random.Range(0, 31) / 10f * positive_or_negative, -6f, 0f);
            return position;
        }
    }
}
