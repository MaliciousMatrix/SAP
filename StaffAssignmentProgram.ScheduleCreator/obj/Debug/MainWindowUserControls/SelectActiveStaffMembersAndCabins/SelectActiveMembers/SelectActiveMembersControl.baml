   M S B A M L   `   `   `  ����  SAP.ScheduleCreator�    {SAP.ScheduleCreator.MainWindowUserControls.SelectActiveStaffMembersAndCabins.SelectActiveMembers.SelectActiveMembersControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      b ^GalaSoft.MvvmLight.Platform, Version=5.4.1.0, Culture=neutral, PublicKeyToken=5f873c45e98af8a1*cmd http://www.galasoft.ch/mvvmlight  5      .��5
      �   � RowDefinitions  5      �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5       � ColumnDefinitions 5      �� 5      $��2* �6   �� 5      $
��Auto �6   .+�5      �� $��1��6   $��3��6   
�������$��1��6;   $	��3,0q�6E   �� 5      $
��Left=�6
   $��0��6B   $��0��6O   $��16(�6_   $
��Bold"�6m   ��6%   �� *
ListName+6m   � 5      $��0��6	   $��1��6   {�.   5      �� 5      $
��Auto �6   �� 5      $��5* �6   �� 5      $��3* �6   .+�5      �� $��Search:��6   $��0��6   �� 5      -   5         ��Name$ StaffSearch��5      $��1��6"   ��62   �� *StaffSearchText+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� 5      -   5         ��Name$ StaffSearchType��5      $��2��6'    �� SelectedValue 67   �� *StaffSearchBy+$ TwoWay=�$ PropertyChanged=�5      � 5!      $��Stretch=�6	   $��Stretch=�6'   $��2��6C   $��0��6P     5"      �� 5#      �� 5$      $
��Auto �6    5&      �� 5'      �� 5(      �� 5)      �� 5*      .+�5,      �� -   5         ��Name$ 
MemberList��5,      $��0��6"   $��0��6/   $��3��6?   $��Stretch=�6S   $��3q�6q   $��Stretch=�6|    �� SelectionMode$ Single=�5/      	 �� SelectedItem	 5-      �� *SelectedMember+$ TwoWay=���5.      �� *SelectableMembers+.  (System.Windows.Interactivity.Interaction
   Triggers
 51      /  )System.Windows.Interactivity.EventTrigger  52         	EventName$ SelectionChanged��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 53      /  )GalaSoft.MvvmLight.Command.EventToCommand     PassEventArgsToCommand .    Command 6   �� *DataContext.SelectionChanged+ �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType" � �� AncestorLevel$ 2��56      57        59      $ MouseDoubleClick��6   . 5:         .  6   �� *DataContext.DoubleClickedItem+ �� $ FindAncestor=�" �$ 2��5=      5>       J� InputBindings 5@      �� 5A      
 �� Key$ Return��6    �� Command 6   �� *StaffSetMemberActive+ �� View 5C      �� 5D      .P�5E      �� $��Active��6    �� CellTemplate 5F   	   �� 5G   
   .R�5H      ��  d� 	IsChecked 6   �� *
IsSelected+5I      5K   	   �� 5L      $
��Name��6    �� Width$	 280��6K    �� DisplayMemberBinding 6%   �� *Name+6K   5X      5Z      �� 5[      $��3��6   $��0��6    $��Center=�6-   .+�5\      �� -   5         ��Name$ StaffSelectAll��5\      $��
Select All��6%   ��6;   �� *	SelectAll+�� 5]      -   5        $ StaffDeselectAll��5]      $��Deselect All��6'   ��6?   �� *
SelectNone+�� 5^      -   5        $ StaffGoToFirst��5^      $��First��6%   ��65   �� *	GoToFirst+�� 5_      -   5        $ StaffGoToLast��5_      $
��Last��6$   ��63   �� *
GoToLast+5`      �� 5a      $	��New��60   $��Stretch=�6>   $��1��6\   $��0��6i   $��Stretch=�6y   $��3q�6�   ��6   �� *CreateNewMember+6�   �� 5b      $
��Edit��6s   $��Stretch=�6�   $��1��6�   $��1��6�   $��Stretch=�6�   $��3q�6�   ��6   ��  �� ElementName$ 
MemberList�� �� Path$ SelectedItem���6T   �� *
EditMember+6�   �� 5c      $��Delete��6t   $��Stretch=�6�   $��1��6�   $��2��6�   $��Stretch=�6�   $��3q�6�   ��6   �� $ 
MemberList��$ SelectedItem���6S   �� *DeleteMember+6�   5d      5e      5f      