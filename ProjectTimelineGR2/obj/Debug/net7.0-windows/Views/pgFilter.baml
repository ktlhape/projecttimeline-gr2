   M S B A M L   `   `   `  ����M  IProjectTimelineGR2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:ProjectTimelineGR2.ViewsProjectTimelineGR2.Views  5      '    !ProjectTimelineGR2.Views.pgFilter   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:ProjectTimelineGR2.Views     5        N� Title$  pgFilter��5	      .��5      � 
������� � RowDefinitions 5   
   �� 5      $
��131* �6   �� 5      $
��319* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��
dgvDisplay��5      $��1��6%   $��15q�62      AutoGenerateColumns$ False��6>   $��18(�6Z      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 Code��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 63   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6=   �� *Code+  5      $ Project Name��6%   $ * 6;    6E   �� *ProjectName+  5      $ 
Start Date��6%   $ * 69    6C   �� *	StartDate+ �� StringFormat$ {0:dd-MM-yyyy}��  5      $ End Date��6%   $ * 67    6A   �� *	EndDate+$ {0:dd-MM-yyyy}��  5      $ Duration��6%   $ * 67    6A   �� *
Duration+  5      $ Estimated Cost��6%   $ * 6=    6G   �� *EstimatedCost+$ C��5      �� 5   
   $��
Filter By:��6   $��20(�6%   $
��Left=�63   $��	47,36,0,0q�6N   $	��Top=�6a   �� 5   
   -   5        $��	cmbFilter��5      $��18(�6$   $
��Left=�62   $��
146,43,0,0q�6M   $	��Top=�6a   $	��138��6y   .@�5      �� $��All Projects��6   �� 5      $��Get Project��6   �� 5      $��	Completed��6   �� 5      $��	Six weeks��6   �� 5       $��Between dates��6   5!      5#      5$      