   M S B A M L   `   `   `  ����M  IProjectTimelineGR2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:ProjectTimelineGR2.ViewsProjectTimelineGR2.Views  5      .    (ProjectTimelineGR2.Views.pgAssignProject   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:ProjectTimelineGR2.Views     5        N� Title$  pgAssignProject��5	      .��5      � 
������� � RowDefinitions 5   
   �� 5      $	��77* �6   �� 5      $
��244* �6   �� 5      $
��129* �6   .+�5   
   �� $��0��6   $��Select project:��6   $
��Left=�67   $��57,0,0,0q�6R   $��Center=�6d   �� 5   
   -   5        $��
cmbProject��5      $��0��6%   $
��Left=�62   $��
183,30,0,0q�6M   $	��Top=�6a   $	��208��6y    �� DisplayMemberPath$ ProjectName��5   +    �� SelectedValuePath$
 Code��5      ��5      �� 5      &   System.Windows.Controls.DataGrid  5   
   -   5        $��dgvEmployees��5       $��1��6      AutoGenerateColumns$ False��64      SelectionUnit$ FullRow=�6P      SelectionMode$ Extended=�6h      RowHeaderTemplate 5      �� 5      .R�5      �� 5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 * 6D   
   Header$
 Employee No��6N   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *
EmployeeNo+6N     5      $	 * 6C   $
 	Firstname��6M    6%   �� *	Firstname+6M     5      $	 * 6B   $
 Lastname��6L    6%   �� *
Lastname+6L     5      $	 * 6A   $

 Type��6K    6%   �� *	EmpType+6K   5!      �� 5"   
   -   5         ��Name$ 	btnAssign��5"      $��ASSIGN��6$   $
��Left=�65   $��	99,50,0,0q�6P   $��2��6c   $	��Top=�6p   $��78��6�   6�   5$      5%      