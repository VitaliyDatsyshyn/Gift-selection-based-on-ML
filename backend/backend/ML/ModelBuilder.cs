using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.ML
{
    public class ModelBuilder
    {
        public static void Build(string pathToTrainingDataset, string pathToModel)
        {
            //var mlContext = new MLContext();
            //var trainingDataView = mlContext.Data.LoadFromTextFile<DatasetStructure>(pathToTrainingDataset, hasHeader: true);
            //var dataProcessPipeline = mlContext.Transforms.Conversion.MapValueToKey(outputColumnName: "KeyColumn", inputColumnName: nameof(DatasetStructure.Label))
            //    .Append(mlContext.Transforms.Text.FeaturizeText("Feature", nameof(DatasetStructure.Text))
            //    .AppendCacheCheckpoint(mlContext));

            //var trainer = mlContext.MulticlassClassification.Trainers.SdcaMaximumEntropy(labelColumnName: "KeyColumn", featureColumnName: "Feature")
            //    .Append(mlContext.Transforms.Conversion.MapKeyToValue(outputColumnName: nameof(DatasetStructure.Label), inputColumnName: "KeyColumn"));

            //var trainingPipeline = dataProcessPipeline.Append(trainer);
            //ITransformer trainedModel = trainingPipeline.Fit(trainingDataView);
            //mlContext.Model.Save(trainedModel, trainingDataView.Schema, pathToModel);
        }
    }
}
