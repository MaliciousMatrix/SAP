using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.ScheduleCreator.MainWindowUserControls.SelectActiveStaffMembersAndCabins.SelectActiveMembers
{
	public class SelectActiveMembersViewModel<T> : ViewModelBase where T : ISelectable
	{
		public SelectActiveMembersViewModel(string listName, ObservableCollection<T> members, Action<T> deleteMemberFunction, Func<T> createNewMemberFunction, Func<T, T> editMemberFunction)
		{
			_listName = listName;
			SelectableMembers = members;
			InitDelegateCommands();

			_deleteMemberFunction = deleteMemberFunction;
			_createNewMemberFunction = createNewMemberFunction;
			_editMemberFunction = editMemberFunction;
		}

		private string _listName;
		public string ListName
		{
			get => _listName;
			set
			{
				_listName = value;
				RaisePropertyChanged();
			}
		}

		private ObservableCollection<T> _selectableMembers;
		public ObservableCollection<T> SelectableMembers
		{
			get => _selectableMembers;
			set
			{
				_selectableMembers = value;
				RaisePropertyChanged();
			}
		}

		private T _selectedMember;
		public T SelectedMember
		{
			get => _selectedMember;
			set
			{
				_selectedMember = value;
				RaisePropertyChanged();

				EditMember.RaiseCanExecuteChanged();
				DeleteMember.RaiseCanExecuteChanged();
			}
		}

		private void InitDelegateCommands()
		{
			CreateNewMember = new DelegateCommand(ExecuteCreateNewMember, CanExecuteCreateNewMember);
			EditMember = new DelegateCommand(ExecuteEditMember, CanExecuteEditMember);
			DeleteMember = new DelegateCommand(ExecuteDeleteMember, CanExecuteDeleteMember);

			// There really isn't a good reason to have CanExecutes on these. Performing them takes almost 
			// no processing power and would probably take more to check to see if we can. 
			SelectAll = new DelegateCommand(ExecuteSelectAll);
			SelectNone = new DelegateCommand(ExecuteSelectNone);
			GoToFirst = new DelegateCommand(ExecuteGoToFirst);
			GoToLast = new DelegateCommand(ExecuteGoToLast);
		}

		#region Select All 

		private DelegateCommand _selectAll;
		public DelegateCommand SelectAll
		{
			get => _selectAll;
			set
			{
				_selectAll = value;
				RaisePropertyChanged();
			}
		}

		private void ExecuteSelectAll(object obj)
		{
			// Don't ask why LINQ doesn't work here. 
			foreach (var member in SelectableMembers)
			{
				member.IsSelected = true;
			}
		}

		#endregion Select All 

		#region Select None 

		private DelegateCommand _selectNone;
		public DelegateCommand SelectNone
		{
			get => _selectNone;
			set
			{
				_selectNone = value;
				RaisePropertyChanged();
			}
		}

		private void ExecuteSelectNone(object obj)
		{
			// LINQ doesn't work here either. 
			foreach (var member in SelectableMembers)
			{
				member.IsSelected = false;
			}
		}

		#endregion Select None

		#region Go To First

		private DelegateCommand _goToFirst;
		public DelegateCommand GoToFirst
		{
			get => _goToFirst;
			set
			{
				_goToFirst = value;
				RaisePropertyChanged();
			}
		}

		private void ExecuteGoToFirst(object obj)
		{
			SelectedMember = _selectableMembers.First();
		}

		#endregion Go To First

		#region Go To Last

		private DelegateCommand _goToLast;
		public DelegateCommand GoToLast
		{
			get => _goToLast;
			set
			{
				_goToLast = value;
				RaisePropertyChanged();
			}
		}

		private void ExecuteGoToLast(object obj)
		{
			SelectedMember = _selectableMembers.Last();
		}

		#endregion Go To Last

		#region Create new member

		private Func<T> _createNewMemberFunction;

		private DelegateCommand _createNewMember;
		public DelegateCommand CreateNewMember
		{
			get => _createNewMember;
			set
			{
				_createNewMember = value;
				RaisePropertyChanged();
			}
		}

		private void ExecuteCreateNewMember(object obj)
		{
			T newMember = _createNewMemberFunction();

			if (newMember == null) return;

			_selectableMembers.Add(newMember);
			RaisePropertyChanged(nameof(SelectableMembers));

			SelectedMember = newMember;
			SelectedMember.IsSelected = true;
		}

		private bool CanExecuteCreateNewMember(object obj)
		{
			// This should always return true. I cannot think of a reason it shouldn't. 
			return true;
		}

		#endregion Create new member 

		#region Delete Member 

		private DelegateCommand _deleteMember;
		public DelegateCommand DeleteMember
		{
			get => _deleteMember;
			set
			{
				_deleteMember = value;
				RaisePropertyChanged();
			}
		}

		private Action<T> _deleteMemberFunction;

		private void ExecuteDeleteMember(object obj)
		{
			T member = SelectedMember;
			SelectedMember = default(T); // null but T could be non nullable and I don't care enough to figure out how to change that. 
			SelectableMembers.Remove(member);
			_deleteMemberFunction(member);
		}

		private bool CanExecuteDeleteMember(object obj)
		{
			return CanExecuteEditMember(obj);
		}

		#endregion Delete Member 

		#region Edit Selected Member

		private DelegateCommand _editMember;
		public DelegateCommand EditMember
		{
			get => _editMember;
			set
			{
				_editMember = value;
				RaisePropertyChanged();
				RaisePropertyChanged(nameof(DoubleClickedItem));
			}
		}

		private Func<T, T> _editMemberFunction;

		private void ExecuteEditMember(object obj)
		{
			T editedMember = _editMemberFunction(SelectedMember);

			if (editedMember == null) return;

			SelectedMember.UpdateExposedISelectableMembers();
		}

		private bool CanExecuteEditMember(object obj)
		{
			return SelectedMember != null;
		}

		public DelegateCommand DoubleClickedItem
		{
			get => EditMember;
		}

		#endregion Edit Selected Member

	}
}
