//using GeneticSharp.Domain;
//using GeneticSharp.Domain.Chromosomes;
//using GeneticSharp.Domain.Crossovers;
//using GeneticSharp.Domain.Fitnesses;
//using GeneticSharp.Domain.Mutations;
//using GeneticSharp.Domain.Populations;
//using GeneticSharp.Domain.Reinsertions;
//using GeneticSharp.Domain.Selections;
//using GeneticSharp.Domain.Terminations;
//using GeneticSharp.Infrastructure.Framework.Commons;
//using System;
//using System.Diagnostics;
//using UnityEngine;

//public class GeneticCtrl : MonoBehaviour, IGeneticAlgorithm
//{
//    public int GenerationsNumber
//    {
//        get
//        {
//            return Population.GenerationsNumber;
//        }
//    } // real-time update

//    public IChromosome BestChromosome
//    {
//        get
//        {
//            return Population.BestChromosome;
//        }
//    } // need to show

//    public TimeSpan TimeEvolving { get; private set; } // real-time update

//    /// <summary>
//    /// The default crossover probability.
//    /// </summary>
//    public const float DefaultCrossoverProbability = 0.75f;

//    /// <summary>
//    /// The default mutation probability.
//    /// </summary>
//    public const float DefaultMutationProbability = 0.1f;

//    #region Fields
//    object SolutionSpace; // select the solution space prefab;

//    IPopulation Population; // real-time update
//    IFitness Fitness; // self dialog
//    ISelection Selection; // selection animation;

//    ICrossover Crossover; // crossover animation;
//    float CrossoverProbability;

//    IMutation Mutation; // mutation animation;
//    float MutationProbability;

//    IReinsertion Reinsertion;
//    ITermination Termination;

//    private bool m_stopRequested;
//    private readonly object m_lock = new object();
//    private GeneticAlgorithmState m_state;
//    private readonly Stopwatch m_stopwatch = new Stopwatch();

//    public GeneticAlgorithmState State
//    {
//        get => m_state;
//        private set
//        {
//            var shouldStop = GeneticAlgorithmState.Stopped != null && m_state != value && value == GeneticAlgorithmState.Stopped;

//            m_state = value;

//            if(shouldStop)
//                Stopped.Invoke(this, EventArgs.Empty);

//            // need to update scence;
//        }
//    }
//    #endregion

//    #region Events
//    /// <summary>
//    /// Occurs when generation ran.
//    /// </summary>
//    public event EventHandler GenerationRan;

//    /// <summary>
//    /// Occurs when termination reached.
//    /// </summary>
//    public event EventHandler TerminationReached;

//    /// <summary>
//    /// Occurs when stopped.
//    /// </summary>
//    public event EventHandler Stopped;

//    /// <summary>
//    /// Occurs when EvolveOneGeneration;
//    /// </summary>
//    public event EventHandler EvolveOneRan;
//    #endregion

//    #region Animation & Controller
//    // Start is called before the first frame update
//    void Start()
//    {

//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }
//    #endregion

//    void GAInit(IPopulation population,
//                          IFitness fitness,
//                          ISelection selection,
//                          ICrossover crossover,
//                          IMutation mutation)
//    {

//        ExceptionHelper.ThrowIfNull("population", population);
//        ExceptionHelper.ThrowIfNull("fitness", fitness);
//        ExceptionHelper.ThrowIfNull("selection", selection);
//        ExceptionHelper.ThrowIfNull("crossover", crossover);
//        ExceptionHelper.ThrowIfNull("mutation", mutation);

//        Population = population;
//        Fitness = fitness;
//        Selection = selection;
//        Crossover = crossover;
//        Mutation = mutation;
//        Reinsertion = new ElitistReinsertion();
//        Termination = new GenerationNumberTermination(1);

//        CrossoverProbability = DefaultCrossoverProbability;
//        MutationProbability = DefaultMutationProbability;
//        TimeEvolving = TimeSpan.Zero;
//        //State = GeneticAlgorithmState.NotStarted;
//        //TaskExecutor = new LinearTaskExecutor();
//        //OperatorsStrategy = new DefaultOperatorsStrategy();
//    }

//    void GAStart()
//    {
//        lock(m_lock)
//        {
//            State = GeneticAlgorithmState.Started;
//            m_stopwatch.Restart();
//            Population.CreateInitialGeneration();
//            // show Population;

//            m_stopwatch.Stop();
//            TimeEvolving = m_stopwatch.Elapsed;
//        }

//        Resume();
//    }

//    // unity operator
//    void CreatePopulationElement() // a searies of population
//    {

//    }

//    void ShowGeneration() // a generation of a population
//    {
//    }

//    void CreateChromosome(IChromosome chromosome) // a popular
//    {
//        // package genes into a group / cube or something
//        CreateGenes(chromosome.GetGenes());
//    }

    

//    void CreateGenes(Gene[] genes) // the genes of a popular
//    {
//        // xyc coordinate; 0 to infinite

//        // x show genes
//        // y show different popular
//        // z show generation

//        int n = genes.Length;
//        for(int i = 0; i < n; i++)
//        {
//            // create a genes in scene;
            
//        }
//    }

//    public void Resume()
//    {

//    }
//}
