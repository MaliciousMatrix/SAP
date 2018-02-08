using SAP.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SAP.ScheduleCreator.MainWindowUserControls.SetMiscAssignments.NightConflict
{
	public class ResolveEveningConflictsViewModel : ViewModelBase
	{
		public ResolveEveningConflictsViewModel(StaffMemberViewModel member, List<EveningJob>[] possibleSelections)
		{
			Continue = new DelegateCommand(ExecuteContinue, CanExcecuteContinue);
			NightConflicts = new ObservableCollection<NightConflictViewModel>();
			staffMemberViewModel = member;
			RaisePropertyChanged(nameof(Name));
			for (int i = 0; i < 6; i++)
			{
				if (possibleSelections[i].Count < 2) continue;
				NightConflicts.Add(new NightConflictViewModel(Continue)
				{
					PossibleOptions = new ObservableCollection<string>(possibleSelections[i].Select(x => x.ToString())),
					Day = (DayOfWeek)i,
				});
			}
		}

		private StaffMemberViewModel staffMemberViewModel;

		private ObservableCollection<NightConflictViewModel> nightConflicts;

		public ObservableCollection<NightConflictViewModel> NightConflicts
		{
			get => nightConflicts;
			set
			{
				nightConflicts = value;
				RaisePropertyChanged();
			}
		}

		public string Name
		{
			get => staffMemberViewModel.Name;
		}

		private DelegateCommand cont;
		public DelegateCommand Continue
		{
			get => cont;
			set
			{
				cont = value;
				RaisePropertyChanged();
			}
		}

		private void ExecuteContinue(object obj)
		{
			OnClosingRequest();
		}

		private bool CanExcecuteContinue(object obj)
		{
			foreach (var conflict in NightConflicts)
			{
				if (conflict.ConflictResolved == false)
				{
					TextVisible = Visibility.Visible;
					return false;
				}
			}
			TextVisible = Visibility.Hidden;
			return true;
		}

		private Visibility textVisible = Visibility.Visible;
		public Visibility TextVisible
		{
			get => textVisible;
			set
			{
				textVisible = value;
				RaisePropertyChanged();
			}
		}

	}
}
