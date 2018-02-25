using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAP.Common;

namespace SAP.ScheduleCreator.MainWindowUserControls.GenerationSettings
{
	public class GenerationSettingsViewModel : ScreenViewModelBase
	{
		private static GenerationSettingsViewModel _instance;
		public static GenerationSettingsViewModel Instance
		{
			get
			{
				if (_instance == null)
					_instance = new GenerationSettingsViewModel();
				return _instance;
			}
		}

		private GenerationSettingsViewModel()
		{
			name = "Generation Settings";
			Init();
		}

		public override void Initialize(ScheduleCreationInfo scheduleCreationInfo)
		{
			base.Initialize(scheduleCreationInfo);
			InitDefaultUIValues();

		}
		private void InitDefaultUIValues()
		{
			//AssignHalfOff = true;
			TakePreferencesIntoAccount = true;
			NumberOnDishes = "1";
			NumberOnCampfire = "4";
			NumberOnQuietCabin = "2";
			NumberOnPowerUp = "2";
			NumberOnTradingPost = "2";
			NumberOnGrace = "1";
			//StaffTypeOnEveningDishes = "P-Staff";
		}

		public override void Resolve()
		{
			scheduleCreationInfo.NumberOnCampfire = new int[7]
			{
				numberOnCampfire, // Sunday
				numberOnCampfire, // Monday
				numberOnCampfire, // Tuesday
				numberOnCampfire, // Wednesday
				numberOnCampfire, // Thursday
				numberOnCampfire, // Friday
				0,
			};

			scheduleCreationInfo.NumberOnQuiteCabin = new int[7]
			{
				numberOnQuietCabin, // Sunday
				numberOnQuietCabin, // Monday
				numberOnQuietCabin, // Tuesday
				numberOnQuietCabin, // Wednesday
				numberOnQuietCabin, // Thursday
				numberOnQuietCabin, // Friday
				0,
			};

			scheduleCreationInfo.NumberOnDishes = new int[7,3]
			{
				{ // Sunday
					0,
					0,
					numberOnDishes,
				},
				{ // Monday
					numberOnDishes,
					numberOnDishes,
					numberOnDishes,
				},
				{ // Tuesday
					numberOnDishes,
					numberOnDishes,
					numberOnDishes,
				},
				{ // Wednesday
					numberOnDishes,
					numberOnDishes,
					numberOnDishes,
				},
				{ // Thursdsay
					numberOnDishes,
					numberOnDishes,
					numberOnDishes,
				},
				{ // Friday
					numberOnDishes,
					numberOnDishes,
					numberOnDishes,
				},
				{ // Saturday
					numberOnDishes,
					0,
					0,
				},
			};

			scheduleCreationInfo.NumberOnGrace = new int[7]
			{
				0,
				_numberOnGrace,
				_numberOnGrace,
				_numberOnGrace,
				_numberOnGrace,
				_numberOnGrace,
				0
			};

			scheduleCreationInfo.NumberOnTradingPost = new int[7]
			{
				0,
				_numberOnTradingPost,
				_numberOnTradingPost,
				_numberOnTradingPost,
				_numberOnTradingPost,
				_numberOnTradingPost,
				0
			};

			scheduleCreationInfo.NumberOnPowerUp = new int[7]
			{
				0,
				_numberOnPowerup,
				_numberOnPowerup,
				_numberOnPowerup,
				_numberOnPowerup,
				_numberOnPowerup,
				0
			};

			scheduleCreationInfo.NumberOnFlagLowering = new int[7]
			{
				_numberOnFlagLowering,
				_numberOnFlagLowering,
				_numberOnFlagLowering,
				_numberOnFlagLowering,
				_numberOnFlagLowering,
				_numberOnFlagLowering,
				0
			};

			scheduleCreationInfo.NumberOnFlagRaising = new int[7]
			{
				0,
				_numberOnFlagRaising,
				_numberOnFlagRaising,
				_numberOnFlagRaising,
				_numberOnFlagRaising,
				_numberOnFlagRaising,
				_numberOnFlagRaising
			};
		}

		private bool _takePreferencesIntoAccount;
		public bool TakePreferencesIntoAccount
		{
			get => _takePreferencesIntoAccount;
			set
			{
				_takePreferencesIntoAccount = value;
				RaisePropertyChanged();
			}
		}

		private int numberOnDishes;
		public string NumberOnDishes
		{
			get
			{
				return numberOnDishes.ToString();
			}
			set
			{
				int val = numberOnDishes;
				Int32.TryParse(value, out val);
				numberOnDishes = val;
				RaisePropertyChanged();
			}
		}

		private int numberOnCampfire;
		public string NumberOnCampfire
		{
			get
			{
				return numberOnCampfire.ToString();
			}
			set
			{
				int val = numberOnCampfire;
				Int32.TryParse(value, out val);
				numberOnCampfire = val;
				RaisePropertyChanged();
			}
		}

		private int numberOnQuietCabin;
		public string NumberOnQuietCabin
		{
			get
			{
				return numberOnQuietCabin.ToString();
			}
			set
			{
				int val = numberOnQuietCabin;
				Int32.TryParse(value, out val);
				numberOnQuietCabin = val;
				RaisePropertyChanged();
			}
		}

		private int _numberOnPowerup;
		public string NumberOnPowerUp
		{
			get => _numberOnPowerup.ToString();
			set
			{
				int val = _numberOnPowerup;
				Int32.TryParse(value, out val);
				_numberOnPowerup = val;
				RaisePropertyChanged();
			}
		}

		private int _numberOnTradingPost;
		public string NumberOnTradingPost
		{
			get => _numberOnTradingPost.ToString();
			set
			{
				int val = _numberOnTradingPost;
				Int32.TryParse(value, out val);
				_numberOnTradingPost = val;
				RaisePropertyChanged();
			}
		}

		private int _numberOnGrace;
		public string NumberOnGrace
		{
			get => _numberOnGrace.ToString();
			set
			{
				int val = _numberOnGrace;
				Int32.TryParse(value, out val);
				_numberOnGrace = val;
				RaisePropertyChanged();
			}
		}

		// TODO: should these be exposed?
		private int _numberOnFlagLowering = 1;
		private int _numberOnFlagRaising = 1;
	}
}
