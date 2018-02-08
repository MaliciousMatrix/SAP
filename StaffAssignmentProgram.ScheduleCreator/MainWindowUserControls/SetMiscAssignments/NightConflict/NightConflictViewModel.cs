using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.ScheduleCreator.MainWindowUserControls.SetMiscAssignments.NightConflict
{
	public class NightConflictViewModel : ViewModelBase
	{
		public NightConflictViewModel(DelegateCommand continueCommand)
		{
			this.continueCommand = continueCommand;
		}

		private DelegateCommand continueCommand;
		private ObservableCollection<string> possibleOptions;

		public ObservableCollection<string> PossibleOptions
		{
			get => possibleOptions;
			set
			{
				possibleOptions = value;
				RaisePropertyChanged();
			}
		}

		private bool conflictResolved = false;

		public bool ConflictResolved
		{
			get => conflictResolved;
			set
			{
				conflictResolved = value;
				RaisePropertyChanged();
				continueCommand.RaiseCanExecuteChanged();
				RaisePropertyChanged(nameof(Color));
				RaisePropertyChanged(nameof(ResolvedStatus));
			}
		}

		private string assignment = null;

		public string Assignment
		{
			get => assignment;
			set
			{
				assignment = value;
				RaisePropertyChanged();
				ConflictResolved = (value != null);
			}
		}

		private DayOfWeek day;

		public DayOfWeek Day
		{
			get => day;
			set
			{
				day = value;
				RaisePropertyChanged();
			}
		}

		public string ResolvedStatus
		{
			get
			{
				return ConflictResolved ? ResolvedState.Resolved.ToString() : ResolvedState.Open.ToString();
			}
		}

		public string Color
		{
			get
			{
				return ConflictResolved ? "	#000000" : "#FF0000";
			}
		}

		private enum ResolvedState
		{
			Resolved,
			Open,
		}

	}
}
