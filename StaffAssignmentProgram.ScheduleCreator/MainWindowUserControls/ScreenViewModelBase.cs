using SAP.Common;
using System;

namespace SAP.ScheduleCreator.MainWindowUserControls
{
	public abstract class ScreenViewModelBase : ViewModelBase
	{
		protected void Init()
		{
			RaisePropertyChanged(nameof(Name));

			Advance = new DelegateCommand(ExecuteAdvance, CanExecuteAdvance);
			Retreat = new DelegateCommand(OnExecuteRetreat, CanExecuteRetreat);
		}

		protected ScheduleCreationInfo scheduleCreationInfo;
		public virtual void Initialize(ScheduleCreationInfo scheduleCreationInfo)
		{
			this.scheduleCreationInfo = scheduleCreationInfo;
		}
		public abstract void Resolve();

		protected string name = null;
		public string Name
		{
			get
			{
				if (name == null)
					throw new Exception("Failed to find a name for this tab item.");
				return name;
			}
		}

		protected int _screenNumber;
		public int ScreenNumber
		{
			get => _screenNumber;
			set
			{
				_screenNumber = value;
				RaisePropertyChanged();
			}
		}

		private DelegateCommand advance;
		public DelegateCommand Advance
		{
			get => advance;
			protected set
			{
				advance = value;
				RaisePropertyChanged();
			}
		}

		private DelegateCommand retreat;
		public DelegateCommand Retreat
		{
			get => retreat;
			protected set
			{
				retreat = value;
				RaisePropertyChanged();
			}
		}

		#region Advance

		protected virtual void PreExecuteAdvance(object obj)
		{

		}

		private void ExecuteAdvance(object obj)
		{
			PreExecuteAdvance(obj);
			StandardAdvance(obj);
			PostExecuteAdvance(obj);
		}

		protected virtual void PostExecuteAdvance(object obj)
		{

		}

		protected virtual bool CanExecuteAdvance(object obj)
		{
			return true;
		}

		#endregion Advance

		#region Retreat 

		protected virtual void PreExecuteRetreat(object obj)
		{

		}

		protected void OnExecuteRetreat(object obj)
		{
			PreExecuteRetreat(obj);
			StandardRetreat(obj);
			PostExecuteRetreat(obj);
		}

		protected virtual void PostExecuteRetreat(object obj)
		{

		}

		protected virtual bool CanExecuteRetreat(object obj)
		{
			// Eventually this should be true. Ideally, there isn't a time in which we cannot go back. 
			// Switch out view models for screens?
			return false;
		}

		#endregion Retreat

		public static Action<object> StandardAdvance { get; set; }
		public static Action<object> StandardRetreat { get; set; }

	}
}
