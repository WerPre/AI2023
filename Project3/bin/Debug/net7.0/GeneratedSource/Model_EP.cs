// <auto-generated />
#pragma warning disable 1570, 1591

using System;
using Microsoft.ML.Probabilistic;
using Microsoft.ML.Probabilistic.Distributions;
using Microsoft.ML.Probabilistic.Factors;

namespace Models
{
	/// <summary>
	/// Generated algorithm for performing inference.
	/// </summary>
	/// <remarks>
	/// If you wish to use this class directly, you must perform the following steps:
	/// 1) Create an instance of the class.
	/// 2) Set the value of any externally-set fields e.g. data, priors.
	/// 3) Call the Execute(numberOfIterations) method.
	/// 4) Use the XXXMarginal() methods to retrieve posterior marginals for different variables.
	/// 
	/// Generated by Infer.NET 0.4.2301.301 at 13:33 on czwartek, 8 czerwca 2023.
	/// </remarks>
	public partial class Model_EP : IGeneratedAlgorithm
	{
		#region Fields
		/// <summary>True if Changed_numberOfIterations_vint__0_vint__1 has executed. Set this to false to force re-execution of Changed_numberOfIterations_vint__0_vint__1</summary>
		public bool Changed_numberOfIterations_vint__0_vint__1_isDone;
		/// <summary>True if Changed_numberOfIterationsDecreased_Init_vint__0_vint__1 has executed. Set this to false to force re-execution of Changed_numberOfIterationsDecreased_Init_vint__0_vint__1</summary>
		public bool Changed_numberOfIterationsDecreased_Init_vint__0_vint__1_isDone;
		/// <summary>True if Changed_numberOfIterationsDecreased_Init_vint__0_vint__1 has performed initialisation. Set this to false to force re-execution of Changed_numberOfIterationsDecreased_Init_vint__0_vint__1</summary>
		public bool Changed_numberOfIterationsDecreased_Init_vint__0_vint__1_isInitialised;
		/// <summary>True if Changed_vint__0 has executed. Set this to false to force re-execution of Changed_vint__0</summary>
		public bool Changed_vint__0_isDone;
		/// <summary>True if Changed_vint__1 has executed. Set this to false to force re-execution of Changed_vint__1</summary>
		public bool Changed_vint__1_isDone;
		/// <summary>True if Constant has executed. Set this to false to force re-execution of Constant</summary>
		public bool Constant_isDone;
		/// <summary>Field backing the NumberOfIterationsDone property</summary>
		private int numberOfIterationsDone;
		public DistributionStructArray<Gaussian,double> vdouble__0_itemvint__0_index0__B;
		public DistributionStructArray<Gaussian,double> vdouble__0_itemvint__1_index0__B;
		/// <summary>Message to marginal of 'vdouble__0'</summary>
		public DistributionStructArray<Gaussian,double> vdouble__0_marginal_F;
		/// <summary>Messages from uses of 'vdouble__0_use'</summary>
		public DistributionStructArray<Gaussian,double>[] vdouble__0_uses_B;
		/// <summary>Field backing the vint__0 property</summary>
		private int[] vint__0_field;
		/// <summary>Message to marginal of 'vint__0'</summary>
		public PointMass<int[]> vint__0_marginal_F;
		/// <summary>Field backing the vint__1 property</summary>
		private int[] vint__1_field;
		/// <summary>Message to marginal of 'vint__1'</summary>
		public PointMass<int[]> vint__1_marginal_F;
		#endregion

		#region Properties
		/// <summary>The number of iterations done from the initial state</summary>
		public int NumberOfIterationsDone
		{
			get {
				return this.numberOfIterationsDone;
			}
		}

		/// <summary>The externally-specified value of 'vint__0'</summary>
		public int[] vint__0
		{
			get {
				return this.vint__0_field;
			}
			set {
				if ((value!=null)&&(value.Length!=6)) {
					throw new ArgumentException(((("Provided array of length "+value.Length)+" when length ")+6)+" was expected for variable \'vint__0\'");
				}
				this.vint__0_field = value;
				this.numberOfIterationsDone = 0;
				this.Changed_vint__0_isDone = false;
				this.Changed_numberOfIterationsDecreased_Init_vint__0_vint__1_isInitialised = false;
				this.Changed_numberOfIterations_vint__0_vint__1_isDone = false;
			}
		}

		/// <summary>The externally-specified value of 'vint__1'</summary>
		public int[] vint__1
		{
			get {
				return this.vint__1_field;
			}
			set {
				if ((value!=null)&&(value.Length!=6)) {
					throw new ArgumentException(((("Provided array of length "+value.Length)+" when length ")+6)+" was expected for variable \'vint__1\'");
				}
				this.vint__1_field = value;
				this.numberOfIterationsDone = 0;
				this.Changed_vint__1_isDone = false;
				this.Changed_numberOfIterationsDecreased_Init_vint__0_vint__1_isInitialised = false;
				this.Changed_numberOfIterations_vint__0_vint__1_isDone = false;
			}
		}

		#endregion

		#region Methods
		/// <summary>Computations that depend on the observed value of numberOfIterations and vint__0 and vint__1</summary>
		/// <param name="numberOfIterations">The number of times to iterate each loop</param>
		private void Changed_numberOfIterations_vint__0_vint__1(int numberOfIterations)
		{
			if (this.Changed_numberOfIterations_vint__0_vint__1_isDone) {
				return ;
			}
			DistributionStructArray<Gaussian,double> vdouble__0_F;
			Gaussian vdouble__0_F_reduced;
			// Create array for 'vdouble__0' Forwards messages.
			vdouble__0_F = new DistributionStructArray<Gaussian,double>(5);
			// Message to 'vdouble__0' from GaussianFromMeanAndVariance factor
			vdouble__0_F_reduced = GaussianFromMeanAndVarianceOp.SampleAverageConditional(6.0, 9.0);
			for(int index1 = 0; index1<5; index1++) {
				vdouble__0_F[index1] = vdouble__0_F_reduced;
				vdouble__0_F[index1] = vdouble__0_F_reduced;
			}
			// Create array for 'vdouble__0_marginal' Forwards messages.
			this.vdouble__0_marginal_F = new DistributionStructArray<Gaussian,double>(5);
			DistributionStructArray<Gaussian,double> vdouble__0_use_B;
			// Create array for 'vdouble__0_use' Backwards messages.
			vdouble__0_use_B = new DistributionStructArray<Gaussian,double>(5);
			for(int index1 = 0; index1<5; index1++) {
				vdouble__0_use_B[index1] = Gaussian.Uniform();
			}
			DistributionStructArray<Gaussian,double>[] vdouble__0_uses_F;
			// Create array for 'vdouble__0_uses' Forwards messages.
			vdouble__0_uses_F = new DistributionStructArray<Gaussian,double>[2];
			// Create array for 'vdouble__0_uses' Forwards messages.
			vdouble__0_uses_F[1] = new DistributionStructArray<Gaussian,double>(5);
			for(int index1 = 0; index1<5; index1++) {
				vdouble__0_uses_F[1][index1] = Gaussian.Uniform();
			}
			DistributionStructArray<Gaussian,double> vdouble__0_uses_F_1__marginal;
			vdouble__0_uses_F_1__marginal = GetItemsOp<double>.MarginalInit<DistributionStructArray<Gaussian,double>>(vdouble__0_uses_F[1]);
			DistributionStructArray<Gaussian,double> vdouble__0_itemvint__1_index0__F;
			// Create array for 'vdouble__0_itemvint__1_index0_' Forwards messages.
			vdouble__0_itemvint__1_index0__F = new DistributionStructArray<Gaussian,double>(6);
			for(int index0 = 0; index0<6; index0++) {
				vdouble__0_itemvint__1_index0__F[index0] = Gaussian.Uniform();
			}
			// Create array for replicates of 'vdouble11_F'
			Gaussian[] vdouble11_F = new Gaussian[6];
			for(int index0 = 0; index0<6; index0++) {
				vdouble11_F[index0] = Gaussian.Uniform();
			}
			// Create array for 'vdouble__0_uses' Forwards messages.
			vdouble__0_uses_F[0] = new DistributionStructArray<Gaussian,double>(5);
			for(int index1 = 0; index1<5; index1++) {
				vdouble__0_uses_F[0][index1] = Gaussian.Uniform();
			}
			DistributionStructArray<Gaussian,double> vdouble__0_uses_F_0__marginal;
			vdouble__0_uses_F_0__marginal = GetItemsOp<double>.MarginalInit<DistributionStructArray<Gaussian,double>>(vdouble__0_uses_F[0]);
			DistributionStructArray<Gaussian,double> vdouble__0_itemvint__0_index0__F;
			// Create array for 'vdouble__0_itemvint__0_index0_' Forwards messages.
			vdouble__0_itemvint__0_index0__F = new DistributionStructArray<Gaussian,double>(6);
			for(int index0 = 0; index0<6; index0++) {
				vdouble__0_itemvint__0_index0__F[index0] = Gaussian.Uniform();
			}
			// Create array for replicates of 'vdouble8_F'
			Gaussian[] vdouble8_F = new Gaussian[6];
			for(int index0 = 0; index0<6; index0++) {
				vdouble8_F[index0] = Gaussian.Uniform();
			}
			// Create array for replicates of 'vdouble12_F'
			Gaussian[] vdouble12_F = new Gaussian[6];
			for(int index0 = 0; index0<6; index0++) {
				vdouble12_F[index0] = Gaussian.Uniform();
			}
			// Create array for replicates of 'vdouble12_B'
			Gaussian[] vdouble12_B = new Gaussian[6];
			for(int index0 = 0; index0<6; index0++) {
				vdouble12_B[index0] = Gaussian.Uniform();
			}
			// Create array for replicates of 'vdouble8_use_B'
			Gaussian[] vdouble8_use_B = new Gaussian[6];
			for(int index0 = 0; index0<6; index0++) {
				vdouble8_use_B[index0] = Gaussian.Uniform();
			}
			// Create array for replicates of 'vdouble11_use_B'
			Gaussian[] vdouble11_use_B = new Gaussian[6];
			for(int index0 = 0; index0<6; index0++) {
				vdouble11_use_B[index0] = Gaussian.Uniform();
			}
			for(int iteration = this.numberOfIterationsDone; iteration<numberOfIterations; iteration++) {
				// Message to 'vdouble__0_uses' from Replicate factor
				vdouble__0_uses_F[1] = ReplicateOp_NoDivide.UsesAverageConditional<DistributionStructArray<Gaussian,double>>(this.vdouble__0_uses_B, vdouble__0_F, 1, vdouble__0_uses_F[1]);
				vdouble__0_uses_F_1__marginal = GetItemsOp<double>.Marginal<DistributionStructArray<Gaussian,double>,Gaussian>(vdouble__0_uses_F[1], this.vdouble__0_uses_B[1], vdouble__0_uses_F_1__marginal);
				// Message to 'vdouble__0_uses' from Replicate factor
				vdouble__0_uses_F[0] = ReplicateOp_NoDivide.UsesAverageConditional<DistributionStructArray<Gaussian,double>>(this.vdouble__0_uses_B, vdouble__0_F, 0, vdouble__0_uses_F[0]);
				vdouble__0_uses_F_0__marginal = GetItemsOp<double>.Marginal<DistributionStructArray<Gaussian,double>,Gaussian>(vdouble__0_uses_F[0], this.vdouble__0_uses_B[0], vdouble__0_uses_F_0__marginal);
				for(int index0 = 0; index0<6; index0++) {
					// Message to 'vdouble__0_itemvint__1_index0_' from GetItems factor
					vdouble__0_itemvint__1_index0__F[index0] = GetItemsOp<double>.ItemsAverageConditional<DistributionStructArray<Gaussian,double>,Gaussian>(this.vdouble__0_itemvint__1_index0__B[index0], vdouble__0_uses_F[1], vdouble__0_uses_F_1__marginal, this.vint__1, index0, vdouble__0_itemvint__1_index0__F[index0]);
					// Message to 'vdouble11' from GaussianFromMeanAndVariance factor
					vdouble11_F[index0] = GaussianFromMeanAndVarianceOp.SampleAverageConditional(vdouble__0_itemvint__1_index0__F[index0], 1.0);
					// Message to 'vdouble__0_itemvint__0_index0_' from GetItems factor
					vdouble__0_itemvint__0_index0__F[index0] = GetItemsOp<double>.ItemsAverageConditional<DistributionStructArray<Gaussian,double>,Gaussian>(this.vdouble__0_itemvint__0_index0__B[index0], vdouble__0_uses_F[0], vdouble__0_uses_F_0__marginal, this.vint__0, index0, vdouble__0_itemvint__0_index0__F[index0]);
					// Message to 'vdouble8' from GaussianFromMeanAndVariance factor
					vdouble8_F[index0] = GaussianFromMeanAndVarianceOp.SampleAverageConditional(vdouble__0_itemvint__0_index0__F[index0], 1.0);
					// Message to 'vdouble12' from Difference factor
					vdouble12_F[index0] = DoublePlusOp.AAverageConditional(vdouble8_F[index0], vdouble11_F[index0]);
					// Message to 'vdouble12' from IsPositive factor
					vdouble12_B[index0] = IsPositiveOp_Proper.XAverageConditional(Bernoulli.PointMass(true), vdouble12_F[index0]);
					// Message to 'vdouble8_use' from Difference factor
					vdouble8_use_B[index0] = DoublePlusOp.SumAverageConditional(vdouble12_B[index0], vdouble11_F[index0]);
					// Message to 'vdouble__0_itemvint__0_index0_' from GaussianFromMeanAndVariance factor
					this.vdouble__0_itemvint__0_index0__B[index0] = GaussianFromMeanAndVarianceOp.MeanAverageConditional(vdouble8_use_B[index0], 1.0);
					// Message to 'vdouble11_use' from Difference factor
					vdouble11_use_B[index0] = DoublePlusOp.BAverageConditional(vdouble8_F[index0], vdouble12_B[index0]);
					// Message to 'vdouble__0_itemvint__1_index0_' from GaussianFromMeanAndVariance factor
					this.vdouble__0_itemvint__1_index0__B[index0] = GaussianFromMeanAndVarianceOp.MeanAverageConditional(vdouble11_use_B[index0], 1.0);
				}
				// Message to 'vdouble__0_uses' from GetItems factor
				this.vdouble__0_uses_B[0] = GetItemsOp<double>.ArrayAverageConditional<Gaussian,DistributionStructArray<Gaussian,double>>(this.vdouble__0_itemvint__0_index0__B, this.vint__0, this.vdouble__0_uses_B[0]);
				// Message to 'vdouble__0_uses' from GetItems factor
				this.vdouble__0_uses_B[1] = GetItemsOp<double>.ArrayAverageConditional<Gaussian,DistributionStructArray<Gaussian,double>>(this.vdouble__0_itemvint__1_index0__B, this.vint__1, this.vdouble__0_uses_B[1]);
				this.OnProgressChanged(new ProgressChangedEventArgs(iteration));
			}
			// Message to 'vdouble__0_use' from Replicate factor
			vdouble__0_use_B = ReplicateOp_NoDivide.DefAverageConditional<DistributionStructArray<Gaussian,double>>(this.vdouble__0_uses_B, vdouble__0_use_B);
			for(int index1 = 0; index1<5; index1++) {
				this.vdouble__0_marginal_F[index1] = Gaussian.Uniform();
				// Message to 'vdouble__0_marginal' from Variable factor
				this.vdouble__0_marginal_F[index1] = VariableOp.MarginalAverageConditional<Gaussian>(vdouble__0_use_B[index1], vdouble__0_F_reduced, this.vdouble__0_marginal_F[index1]);
			}
			this.Changed_numberOfIterations_vint__0_vint__1_isDone = true;
		}

		/// <summary>Computations that depend on the observed value of numberOfIterationsDecreased and must reset on changes to vint__0 and vint__1</summary>
		/// <param name="initialise">If true, reset messages that initialise loops</param>
		private void Changed_numberOfIterationsDecreased_Init_vint__0_vint__1(bool initialise)
		{
			if (this.Changed_numberOfIterationsDecreased_Init_vint__0_vint__1_isDone&&((!initialise)||this.Changed_numberOfIterationsDecreased_Init_vint__0_vint__1_isInitialised)) {
				return ;
			}
			for(int index1 = 0; index1<5; index1++) {
				this.vdouble__0_uses_B[0][index1] = Gaussian.Uniform();
				this.vdouble__0_uses_B[1][index1] = Gaussian.Uniform();
			}
			for(int index0 = 0; index0<6; index0++) {
				this.vdouble__0_itemvint__1_index0__B[index0] = Gaussian.Uniform();
				this.vdouble__0_itemvint__0_index0__B[index0] = Gaussian.Uniform();
			}
			this.Changed_numberOfIterationsDecreased_Init_vint__0_vint__1_isDone = true;
			this.Changed_numberOfIterationsDecreased_Init_vint__0_vint__1_isInitialised = true;
		}

		/// <summary>Computations that depend on the observed value of vint__0</summary>
		private void Changed_vint__0()
		{
			if (this.Changed_vint__0_isDone) {
				return ;
			}
			// Create array for 'vint__0_marginal' Forwards messages.
			this.vint__0_marginal_F = new PointMass<int[]>(this.vint__0);
			// Message to 'vint__0_marginal' from DerivedVariable factor
			this.vint__0_marginal_F = DerivedVariableOp.MarginalAverageConditional<PointMass<int[]>,int[]>(this.vint__0, this.vint__0_marginal_F);
			this.Changed_vint__0_isDone = true;
		}

		/// <summary>Computations that depend on the observed value of vint__1</summary>
		private void Changed_vint__1()
		{
			if (this.Changed_vint__1_isDone) {
				return ;
			}
			// Create array for 'vint__1_marginal' Forwards messages.
			this.vint__1_marginal_F = new PointMass<int[]>(this.vint__1);
			// Message to 'vint__1_marginal' from DerivedVariable factor
			this.vint__1_marginal_F = DerivedVariableOp.MarginalAverageConditional<PointMass<int[]>,int[]>(this.vint__1, this.vint__1_marginal_F);
			this.Changed_vint__1_isDone = true;
		}

		/// <summary>Computations that do not depend on observed values</summary>
		private void Constant()
		{
			if (this.Constant_isDone) {
				return ;
			}
			// Create array for 'vdouble__0_uses' Backwards messages.
			this.vdouble__0_uses_B = new DistributionStructArray<Gaussian,double>[2];
			// Create array for 'vdouble__0_uses' Backwards messages.
			this.vdouble__0_uses_B[0] = new DistributionStructArray<Gaussian,double>(5);
			// Create array for 'vdouble__0_uses' Backwards messages.
			this.vdouble__0_uses_B[1] = new DistributionStructArray<Gaussian,double>(5);
			// Create array for 'vdouble__0_itemvint__1_index0_' Backwards messages.
			this.vdouble__0_itemvint__1_index0__B = new DistributionStructArray<Gaussian,double>(6);
			// Create array for 'vdouble__0_itemvint__0_index0_' Backwards messages.
			this.vdouble__0_itemvint__0_index0__B = new DistributionStructArray<Gaussian,double>(6);
			bool vbool0_reduced = default(bool);
			vbool0_reduced = true;
			Constrain.Equal<bool>(true, vbool0_reduced);
			this.Constant_isDone = true;
		}

		/// <summary>Update all marginals, by iterating message passing the given number of times</summary>
		/// <param name="numberOfIterations">The number of times to iterate each loop</param>
		/// <param name="initialise">If true, messages that initialise loops are reset when observed values change</param>
		private void Execute(int numberOfIterations, bool initialise)
		{
			if (numberOfIterations!=this.numberOfIterationsDone) {
				if (numberOfIterations<this.numberOfIterationsDone) {
					this.numberOfIterationsDone = 0;
					this.Changed_numberOfIterationsDecreased_Init_vint__0_vint__1_isDone = false;
				}
				this.Changed_numberOfIterations_vint__0_vint__1_isDone = false;
			}
			this.Changed_vint__1();
			this.Changed_vint__0();
			this.Constant();
			this.Changed_numberOfIterationsDecreased_Init_vint__0_vint__1(initialise);
			this.Changed_numberOfIterations_vint__0_vint__1(numberOfIterations);
			this.numberOfIterationsDone = numberOfIterations;
		}

		/// <summary>Update all marginals, by iterating message-passing the given number of times</summary>
		/// <param name="numberOfIterations">The total number of iterations that should be executed for the current set of observed values.  If this is more than the number already done, only the extra iterations are done.  If this is less than the number already done, message-passing is restarted from the beginning.  Changing the observed values resets the iteration count to 0.</param>
		public void Execute(int numberOfIterations)
		{
			this.Execute(numberOfIterations, true);
		}

		/// <summary>Get the observed value of the specified variable.</summary>
		/// <param name="variableName">Variable name</param>
		public object GetObservedValue(string variableName)
		{
			if (variableName=="vint__0") {
				return this.vint__0;
			}
			if (variableName=="vint__1") {
				return this.vint__1;
			}
			throw new ArgumentException("Not an observed variable name: "+variableName);
		}

		/// <summary>Get the marginal distribution (computed up to this point) of a variable</summary>
		/// <param name="variableName">Name of the variable in the generated code</param>
		/// <returns>The marginal distribution computed up to this point</returns>
		/// <remarks>Execute, Update, or Reset must be called first to set the value of the marginal.</remarks>
		public object Marginal(string variableName)
		{
			if (variableName=="vint__1") {
				return this.Vint__1Marginal();
			}
			if (variableName=="vint__0") {
				return this.Vint__0Marginal();
			}
			if (variableName=="vdouble__0") {
				return this.Vdouble__0Marginal();
			}
			throw new ArgumentException("This class was not built to infer "+variableName);
		}

		/// <summary>Get the marginal distribution (computed up to this point) of a variable, converted to type T</summary>
		/// <typeparam name="T">The distribution type.</typeparam>
		/// <param name="variableName">Name of the variable in the generated code</param>
		/// <returns>The marginal distribution computed up to this point</returns>
		/// <remarks>Execute, Update, or Reset must be called first to set the value of the marginal.</remarks>
		public T Marginal<T>(string variableName)
		{
			return Distribution.ChangeType<T>(this.Marginal(variableName));
		}

		/// <summary>Get the query-specific marginal distribution of a variable.</summary>
		/// <param name="variableName">Name of the variable in the generated code</param>
		/// <param name="query">QueryType name. For example, GibbsSampling answers 'Marginal', 'Samples', and 'Conditionals' queries</param>
		/// <remarks>Execute, Update, or Reset must be called first to set the value of the marginal.</remarks>
		public object Marginal(string variableName, string query)
		{
			if (query=="Marginal") {
				return this.Marginal(variableName);
			}
			throw new ArgumentException(((("This class was not built to infer \'"+variableName)+"\' with query \'")+query)+"\'");
		}

		/// <summary>Get the query-specific marginal distribution of a variable, converted to type T</summary>
		/// <typeparam name="T">The distribution type.</typeparam>
		/// <param name="variableName">Name of the variable in the generated code</param>
		/// <param name="query">QueryType name. For example, GibbsSampling answers 'Marginal', 'Samples', and 'Conditionals' queries</param>
		/// <remarks>Execute, Update, or Reset must be called first to set the value of the marginal.</remarks>
		public T Marginal<T>(string variableName, string query)
		{
			return Distribution.ChangeType<T>(this.Marginal(variableName, query));
		}

		private void OnProgressChanged(ProgressChangedEventArgs e)
		{
			// Make a temporary copy of the event to avoid a race condition
			// if the last subscriber unsubscribes immediately after the null check and before the event is raised.
			EventHandler<ProgressChangedEventArgs> handler = this.ProgressChanged;
			if (handler!=null) {
				handler(this, e);
			}
		}

		/// <summary>Reset all messages to their initial values.  Sets NumberOfIterationsDone to 0.</summary>
		public void Reset()
		{
			this.Execute(0);
		}

		/// <summary>Set the observed value of the specified variable.</summary>
		/// <param name="variableName">Variable name</param>
		/// <param name="value">Observed value</param>
		public void SetObservedValue(string variableName, object value)
		{
			if (variableName=="vint__0") {
				this.vint__0 = (int[])value;
				return ;
			}
			if (variableName=="vint__1") {
				this.vint__1 = (int[])value;
				return ;
			}
			throw new ArgumentException("Not an observed variable name: "+variableName);
		}

		/// <summary>Update all marginals, by iterating message-passing an additional number of times</summary>
		/// <param name="additionalIterations">The number of iterations that should be executed, starting from the current message state.  Messages are not reset, even if observed values have changed.</param>
		public void Update(int additionalIterations)
		{
			this.Execute(checked(this.numberOfIterationsDone+additionalIterations), false);
		}

		/// <summary>
		/// Returns the marginal distribution for 'vdouble__0' given by the current state of the
		/// message passing algorithm.
		/// </summary>
		/// <returns>The marginal distribution</returns>
		public DistributionStructArray<Gaussian,double> Vdouble__0Marginal()
		{
			return this.vdouble__0_marginal_F;
		}

		/// <summary>
		/// Returns the marginal distribution for 'vint__0' given by the current state of the
		/// message passing algorithm.
		/// </summary>
		/// <returns>The marginal distribution</returns>
		public PointMass<int[]> Vint__0Marginal()
		{
			return this.vint__0_marginal_F;
		}

		/// <summary>
		/// Returns the marginal distribution for 'vint__1' given by the current state of the
		/// message passing algorithm.
		/// </summary>
		/// <returns>The marginal distribution</returns>
		public PointMass<int[]> Vint__1Marginal()
		{
			return this.vint__1_marginal_F;
		}

		#endregion

		#region Events
		/// <summary>Event that is fired when the progress of inference changes, typically at the end of one iteration of the inference algorithm.</summary>
		public event EventHandler<ProgressChangedEventArgs> ProgressChanged;
		#endregion

	}

}
