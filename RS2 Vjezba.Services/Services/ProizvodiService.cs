using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;
using RS2_Vjezba.Services.Database;
using RS2_Vjezba.Services.ProductStateMachine;
using RS2_Vjezbe.Models;
using RS2_Vjezbe.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS2_Vjezba.Services.Services
{
    public class ProizvodiService : CRUDService<RS2_Vjezbe.Models.Proizvodi,Database.Proizvodi , RS2_Vjezbe.Models.ProizvodiSearchObject , ProizvodiInsertRequest , ProizvodiUpdateRequest>, IProizvodiService
    {
        public BaseState BaseState { get; set; }
        public ProizvodiService(eProdajaContext context, IMapper mapper , BaseState baseState)
            : base(context, mapper)
        {
            BaseState = baseState;
        }

        public override RS2_Vjezbe.Models.Proizvodi Insert(ProizvodiInsertRequest insert)
        {
            var state = BaseState.CreateState("Initial");

            return state.Insert(insert);
        }

        public override RS2_Vjezbe.Models.Proizvodi Update(int id, ProizvodiUpdateRequest update)
        {
            var product = Context.Proizvodis.Find(id);

            var state = BaseState.CreateState(product.StateMachine);

            state.CurrentEntity = product;

            state.Update(update);

            return GetById(id);

            //return base.Update(id, update);
        }

        public RS2_Vjezbe.Models.Proizvodi Activate(int id)
        {
            var product = Context.Proizvodis.Find(id);

            var state = BaseState.CreateState(product.StateMachine);

            state.CurrentEntity = product;

            state.Activate();

            return GetById(id);

        }

        public RS2_Vjezbe.Models.Proizvodi Hide(int id)
        {
            var product = Context.Proizvodis.Find(id);

            var state = BaseState.CreateState(product.StateMachine);

            state.CurrentEntity = product;

            state.Hide();

            return GetById(id);

        }

        public void Delete(int id)
        {
            var product = Context.Proizvodis.Find(id);

            var state = BaseState.CreateState(product.StateMachine);

            state.CurrentEntity = product;

            state.Delete();
        }

        public List<string> AllowedActions(int id)
        {
            var product = Context.Proizvodis.Find(id);

            var state = BaseState.CreateState(product.StateMachine);

            var list = state.AllowedActions();

            return list;
        }

        public override IQueryable<Database.Proizvodi> AddFilter(IQueryable<Database.Proizvodi> query, ProizvodiSearchObject search = null)
        {
            if (!string.IsNullOrEmpty(search.Naziv))
            {

                query = query.Where(x => x.Naziv.Contains(search.Naziv));
            }

            if (!string.IsNullOrEmpty(search.Sifra))
            {

                query = query.Where(x => x.Sifra == search.Sifra);
            }

            return query;
        }

        static object isLocked = new object();
        static MLContext mlContext = null;
        static ITransformer model = null;
        public List<RS2_Vjezbe.Models.Proizvodi> Recommend(int id)
        {
            lock (isLocked)
            {
                if (mlContext == null)
                {
                    mlContext = new MLContext();

                    var tmpData = Context.Narudzbes.Include("NarudzbaStavkes").ToList();

                    var data = new List<ProductEntry>();

                    foreach (var x in tmpData)
                    {
                        if (x.NarudzbaStavkes.Count > 1)
                        {
                            var distinctItemId = x.NarudzbaStavkes.Select(y => y.ProizvodId).ToList();

                            distinctItemId.ForEach(y =>
                            {
                                var relatedItems = x.NarudzbaStavkes.Where(z => z.ProizvodId != y);

                                foreach (var z in relatedItems)
                                {
                                    data.Add(new ProductEntry()
                                    {
                                        ProductID = (uint)y,
                                        CoPurchaseProductID = (uint)z.ProizvodId,
                                    });
                                }
                            });
                        }
                    }


                    var traindata = mlContext.Data.LoadFromEnumerable(data);


                    //STEP 3: Your data is already encoded so all you need to do is specify options for MatrxiFactorizationTrainer with a few extra hyperparameters
                    //        LossFunction, Alpa, Lambda and a few others like K and C as shown below and call the trainer.
                    MatrixFactorizationTrainer.Options options = new MatrixFactorizationTrainer.Options();
                    options.MatrixColumnIndexColumnName = nameof(ProductEntry.ProductID);
                    options.MatrixRowIndexColumnName = nameof(ProductEntry.CoPurchaseProductID);
                    options.LabelColumnName = "Label";
                    options.LossFunction = MatrixFactorizationTrainer.LossFunctionType.SquareLossOneClass;
                    options.Alpha = 0.01;
                    options.Lambda = 0.025;
                    // For better results use the following parameters
                    options.NumberOfIterations = 100;
                    options.C = 0.00001;


                    var est = mlContext.Recommendation().Trainers.MatrixFactorization(options);

                    model = est.Fit(traindata);
                }

            }


            List<Database.Proizvodi> allItems = Context.Proizvodis.ToList();

            var predictionResult = new List<Tuple<Database.Proizvodi, float>>();

            foreach (var item in allItems)
            {
                var predictionEngine = mlContext.Model.CreatePredictionEngine<ProductEntry, Copurchase_prediction>(model);
                var prediction = predictionEngine.Predict(new ProductEntry()
                {
                    ProductID = (uint)id,
                    CoPurchaseProductID = (uint)item.ProizvodId
                });

                predictionResult.Add(new Tuple<Database.Proizvodi, float>(item, prediction.Score));
            }

            var finalResult = predictionResult.OrderByDescending(x => x.Item2)
                .Select(x => x.Item1).Take(3).ToList();

            return _mapper.Map<List<RS2_Vjezbe.Models.Proizvodi>>(finalResult);
        }

        public class Copurchase_prediction
        {
            public float Score { get; set; }
        }

        public class ProductEntry
        {
            [KeyType(count: 10)]
            public uint ProductID { get; set; }

            [KeyType(count: 10)]
            public uint CoPurchaseProductID { get; set; }

            public float Label { get; set; }
        }
    }
}
