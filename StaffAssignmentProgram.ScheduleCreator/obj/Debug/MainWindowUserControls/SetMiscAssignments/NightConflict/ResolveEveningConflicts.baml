   M S B A M L   `   `   `  ����N  JSAP.ScheduleCreator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�Yclr-namespace:SAP.ScheduleCreator.MainWindowUserControls.SetMiscAssignments.NightConflictKSAP.ScheduleCreator.MainWindowUserControls.SetMiscAssignments.NightConflict  5   	   i    cSAP.ScheduleCreator.MainWindowUserControls.SetMiscAssignments.NightConflict.ResolveEveningConflicts   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   klocalYclr-namespace:SAP.ScheduleCreator.MainWindowUserControls.SetMiscAssignments.NightConflict     5   	     � Title$  Resolve Evening Conflicts��5   	   $	��300��6+   $	��424��68   .��5	      �  � RowDefinitions 5
      �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6    � ColumnDefinitions 5      �� 5      $��2* �6   �� 5      $��* �6   .+�5      � $��0��6	   $��0��6    5      �� 5      $
��Auto �6   �� 5      $��* �6   .+�5      �� $��0��6   $��0��6   $��3q�6(   $��16(�63   $
��Bold"�6A   .��6S   Staff Member:6b   �� 5      $��0��6   $��1��6   $��3q�6(   $��16(�6L   $
��Left=�6Z   ��63   �� *Name+6Z   5      �� 5      -   5         ��Name$ ConflictList��5      $��1��6#   $��0��60   $��3��6@   $��Stretch=�6T   $��3q�6r   $��Stretch=�6}   ��5      �� *NightConflicts+ J� InputBindings 5      �� 5      
 �� Key$ Return��6    �� Command 6   �� *StaffSetMemberActive+ �� View 5!      �� 5"      .P�5$      �� $	��Day��6    �� Width$	 110��6#   	 �� CellTemplate	 5%      �� 5&   	   .R�5'   
   �� ��6   �� *Day+5(   
   5*      �� 5,      $��Selected Activity��6   $	 200��61   	 5-      �� 5.   	   .R�5/   
   �� $��Stretch=�6   $	��188��52   
   ��50   
   �� *PossibleOptions+
 �� SelectedItem
 51   
   �� *
Assignment+ �� Mode$ TwoWay=�52   
   53   
   55      �� 57      $��Status��6   $ 84��6&   	 58      �� 59   	   .R�5:   
   �� ��6   �� *ResolvedStatus+��63   �� *Color+5;   
   5=      5?      5A      �� 5C      $��2��6
   $��0��6   
���  ��y�6'   �� *TextVisible+.��6[   #!Resolve all conflicts to continue6~   �� 5D      $��2��6   $��1��6   $��3q�6(   ��63   �� *
Continue+.��6P   
Continue6Z   5F      5G      