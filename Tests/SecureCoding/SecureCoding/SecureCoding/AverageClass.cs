using System;
using System.Diagnostics.Contracts;
using System.Linq;

namespace SecureCoding
{
    public class AverageClass
    {
        public float AverageScores(float[] scores)
        {
            Contract.Requires<ArgumentException>(scores != null && scores.Length > 0, "Input array must not be null or empty.");

            Contract.Ensures(Contract.Result<float>() > 0, "The result must be positive.");

            return scores.Average();
        }

    }
}
