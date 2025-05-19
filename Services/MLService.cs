using c_sharp_odontoprev.Models;
using Microsoft.ML;
using Microsoft.ML.Data;

namespace c_sharp_odontoprev.Services
{
    public class MLService
    {
        private readonly MLContext _mlContext;
        private ITransformer _modelo;
        private PredictionEngine<InputML, PredML> _predictionEngine;
        private readonly string _dataPath = Path.Combine(Environment.CurrentDirectory, "Data", "consultas_fake.csv");
        private readonly string _modelPath = Path.Combine(Environment.CurrentDirectory, "Data", "model.zip");

        public MLService()
        {
            _mlContext = new MLContext();

            if (File.Exists(_modelPath))
            {
              
                _modelo = _mlContext.Model.Load(_modelPath, out _);
                _predictionEngine = _mlContext.Model.CreatePredictionEngine<InputML, PredML>(_modelo);
            }
            else
            {
                TreinarModelo();
            }
        }

        public void TreinarModelo()
        {
            var dataView = _mlContext.Data.LoadFromTextFile<InputML>(
                path: _dataPath,
                hasHeader: true,
                separatorChar: ',');

            var pipeline = _mlContext.Transforms.Categorical.OneHotEncoding(new[]
                {
                    new InputOutputColumnPair("EspecialidadeEncoded", nameof(InputML.Especialidade)),
                    new InputOutputColumnPair("DiaSemanaEncoded", nameof(InputML.DiaSemana)),
                    new InputOutputColumnPair("HorarioEncoded", nameof(InputML.Horario))
                })
                .Append(_mlContext.Transforms.Concatenate("Features",
                    "Idade", "HistoricoFaltas", "TempoAntecedenciaDias",
                    "EspecialidadeEncoded", "DiaSemanaEncoded", "HorarioEncoded"))
                .Append(_mlContext.BinaryClassification.Trainers.SdcaLogisticRegression(labelColumnName: "Faltou", featureColumnName: "Features"));

            _modelo = pipeline.Fit(dataView);

            _mlContext.Model.Save(_modelo, dataView.Schema, _modelPath);

            _predictionEngine = _mlContext.Model.CreatePredictionEngine<InputML, PredML>(_modelo);
        }

        public PredML Prever(InputML input)
        {
            if (_predictionEngine == null)
                _predictionEngine = _mlContext.Model.CreatePredictionEngine<InputML, PredML>(_modelo);

            return _predictionEngine.Predict(input);
        }
    }
}
