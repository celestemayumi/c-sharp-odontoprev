using Microsoft.ML.Data;

namespace c_sharp_odontoprev.Models
{
    public class PredML
    {
        [ColumnName("PredictedLabel")]
        public bool VaiFaltar { get; set; }

        public float Probabilidade { get; set; }

        public float Score { get; set; }
    }
}
