   M S B A M L   `   `   `  ����  SAP.ScheduleCreatorg    aSAP.ScheduleCreator.MainWindowUserControls.SetMiscAssignments.Assignment.EveningAssignmentControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      b ^GalaSoft.MvvmLight.Platform, Version=5.4.1.0, Culture=neutral, PublicKeyToken=5f873c45e98af8a1*cmd http://www.galasoft.ch/mvvmlight  5      .��5
      �   � ColumnDefinitions  5      �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5      �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5      �� $��16(�6
   $
��Bold"�6   $��2��6*   ��6>   �� *Day+�� 5      $��1��6   $��2��6    d� 	IsChecked 6+   �� *IsManagement+y�6N   �� *ManagementCheckBoxVisibility+.��6�   Is Management6�   �� 5      $��2��6   $��2��6   $��3q�6.    �� SelectionMode$ Single=�5   (   ��5   9   �� *ComboBoxValues+{�5      �� *
NeedsStaff+ �� SelectedIndex 6?   �� *IndexSelected+ �� Mode$ TwoWay=� �� View 5      �� 5      .P�5      ��  �� Width$	 130��6   $��Members��6"    �� CellTemplate 5      �� 5   	   .R�5   
   �� 	 �� DisplayMemberPath$
	 Name��5"   
   ��5   
   �� *DataContext.ActiveMembers+
 �� RelativeSource
 ��  �� Mode$ FindAncestor=� �� AncestorType" >� �� AncestorLevel$ 1�� �� SelectedItem 5"   #   �� *Member+$ TwoWay=�5,      5-   
   5/      50      52      �� 53      $��0��6)   $��3��69   ��6   �� *	AddMember+{�6F   �� *
NeedsStaff+.��6g   Add6l   �� 54      $��1��6�   $��3��6�   {�6   �� *
NeedsStaff+��6,   ��  �� ElementName$ SundayQuietCabin�� �� Path$ SelectedItem���6y   �� *DeleteMember+.��6�   Delete6�   55      56      