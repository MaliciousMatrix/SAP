   M S B A M L   `   `   `  ����N  JSAP.ScheduleCreator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�Uclr-namespace:SAP.ScheduleCreator.MainWindowUserControls.AssignStaffToCabinsAndPStaffGSAP.ScheduleCreator.MainWindowUserControls.AssignStaffToCabinsAndPStaff  5      q    kSAP.ScheduleCreator.MainWindowUserControls.AssignStaffToCabinsAndPStaff.AssignStaffToCabinsAndPStaffControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      glocalUclr-namespace:SAP.ScheduleCreator.MainWindowUserControls.AssignStaffToCabinsAndPStaff     5      .��5	      � .+�5
      �� $��0��6   $��0��6   $��3��6*   $��Stretch=�6>   $��3q�6\   $��Stretch=�6g     �� SelectionMode$  Single=�5      ��5      �� *ActiveStaffMembers+ J� InputBindings 5       �� View 5      �� 5      .P�5      �� $
��Name��6    �� Width$	 250��6J    �� DisplayMemberBinding 6$   �� *Name+6J   �� 5      $��Assigned Cabin��6   $	 250��6.    �� CellTemplate 5      �� 5   	   .R�5   
   �� $��Stretch=�6    �� DisplayMemberPath$
 Name��5   
   ��5   
   ��  �� Path$ DataContext.ActiveCabins� �� RelativeSource �� 	 �� Mode$	 FindAncestor=�
 �� AncestorType"
 >� �� SelectedItem 5   
   �� *AssignedCabin+ �� Mode$ TwoWay=�5   
   5   
   5      �� 5      $��P-Staff Assignment��6   $	 250��62    5      �� 5    	   .R�5!   
   �� $��Stretch=�6   $
 Name��5%   
   ��5"   
   �� $! DataContext.ActiveWorkAreas� �� $	 FindAncestor=�"
 >� 5$   
   �� *PStaffAssignment+5%   
   5&   
   5(      5)      5+      5,      5-      