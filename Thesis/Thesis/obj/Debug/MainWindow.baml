   M S B A M L   `   `   `  ����A  =Thesis, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ThesisThesis  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	       Thesis.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Thesis     5   	   9System&clr-namespace:System;assembly=mscorlib     5   	     � Icon$  leap_icon_01p_icon.ico��5	   	    � Title$ Leap Motion Data Process��5
   	   $	��504��6*   $��707.267��67   ���	#FFECECEC � 
ResizeMode$ CanMinimize=�6^    � WindowStartupLocation$ CenterScreen=�6w   $��Microsoft YaHei UI Light)�6�   .��5      �  � ColumnDefinitions 5   
   �� 5      .+�5   
   �� -   5         ��Name$ 
tabControl��5      $	��475��6)   $
��auto��66   $��0��6C   ���	#FFFBFBFB���	#FF252526 J� RenderTransformOrigin$ 0.497,0.494&�6   $	��Top=�6�   .@�5      �� -   5         ��Name$ tb_main��5      $��Patients��6'   $��23��69   $	��Top=�6E   $��Microsoft YaHei UI Light)�6]   $��16(�6�    �� 
IsSelected . .��5      � $��0,0,0,-2q�6    5      �� 5      �� 5      $��0* �6+   .+�5      �� -   5        	 ��Name$	 tb_fname��5      $��35��60   $��396,33,14,0q�6<   
 �� TextWrapping$

 Wrap=�6Q   $	��Top=�6e   
�������$��16(�6�   �� 5      -   5        $	 tb_lname��5      $��38��60   $��396,73,14,0q�6<   $

 Wrap=�6Q   $	��Top=�6e   
�������$��16(�6�   �� 5      -   5        $	 
tb_address��5      $��37��62   $��396,116,14,0q�6>   $

 Wrap=�6T   $	��Top=�6h   
�������$��16(�6�   �� 5      -   5        $	 tb_tel��5      $��36��6.   $��396,159,14,0q�6:   $

 Wrap=�6P   $	��Top=�6d   
����������	#FFABADB3$��16(�6�   (  "System.Windows.Controls.DatePicker  5      -   5          Name$ dp_birth��5   !   $��396,201,14,0q�63   $	��Top=�6I      SelectedDateFormat$ Short=�6a   
�������   FirstDayOfWeek$ Monday=�6�   $��31��6�   
���   �$��16(�6�      Text$
 Date��6�   ��6|   Z� 6�   �� 5      -   5         ��Name$ lb_id��5      $�� ��6+   $
��Left=�66   $��227,187,0,0q�6Q   $	��Top=�6f   $y�Hidden=�6~   $��26��6�   $	��186��6�   $ 0.5,0.5&�6�   z�5      V� 5      .~�5   "   T�  T� Y$ -0.001Q�65   5       5"      �� 5%      -	   5         ��Name$ lbox_patients��5%      $	��352��65   $��10,30,437,0q�6B   $	��Top=�6W   
�������
���   �$��Microsoft YaHei UI Light)�6�   $��16(�6�   $ 0.5,0.5&�6  ��6�   Z� z�5&      V� 5'      .~�5(   "   �� �� 5)   "   �� 5*   "   T� 5+   "   $ 0.496Q�65   5,      5.      �� 5/      -
   5        $ lb_fname��5/      $��
First Name��6.   $��275,33,304,0q�6C   $	��Top=�6Y   $��35��6q   ���	#FFBBBBBB$��Microsoft YaHei UI Light)�6�   $��16(�6�   �� 50      -   5        $ lb_lname��50      $��	Last Name��6.   $��275,73,299,0q�6B   $	��Top=�6X   $��38��6p   ���	#FFBBBBBB$��Microsoft YaHei UI Light)�6�   $��16(�6�   �� 51      -   5        $ 
lb_address��51      $��Address��60   $��275,117,304,0q�6B   $	��Top=�6Y   $��36��6q   ���	#FFBBBBBB$��Microsoft YaHei UI Light)�6�   $��16(�6�   �� 52      -   5        $ 
l_patients��52      $��Patients��60   $
��Left=�6C   $��81,0,0,0q�6^   $	��Top=�6p   $��78��6�   $��16(�6�   $��30��6�   $ 0.5,0.5&�6�   ���	#FFBBBBBB$��Microsoft YaHei UI Light)�6�   $y�Hidden=�6   ��6�   Z� 6   �� 53      -   5        $ lb_address_Copy1��53      $��	Telephone��66   $��275,159,304,0q�6J   $	��Top=�6a   $��35��6y   ���	#FFBBBBBB$��Microsoft YaHei UI Light)�6�   $��16(�6�   �� 54      -   5         ��Name$ 
btn_modify��54      $��Modify��61   $��593,236,14,0q�6B   $	��Top=�6X   $��31��6�   $��Microsoft YaHei UI Light)�6�   $��16(�6�   �� 55      -   5         ��Name$ cbox_new��55      $��New patient��61   $��281,243,282,0q�6G   $	��Top=�6^   $��19��6�   ���	#FFBBBBBB$��Microsoft YaHei UI Light)�6�   $��16(�6�   $
��Bold"�6�   �� 56      -   5         ��Name$ cb_sex��56      $
��Left=�6/   $��396,237,0,0q�6J   $	��Top=�6_   $	��192��6w    �� SelectedIndex$ 0��6�   $��31��6�   $��16(�6�   $y�Hidden=�6�   .@�57      ��men��6-   ��58      	women��6/   59      �� 5:      -   5        $ 
btn_delete��5:      $��Delete��61   $��593,272,14,0q�6B   $	��Top=�6X   $��30��6�   $��Microsoft YaHei UI Light)�6�   $��16(�6�   �� 5;      -   5        $	 	tb_search��5;      $
��Left=�61   $��33��6L   $��
10,387,0,0q�6X   $

 Wrap=�6l   $	��Top=�6�   $	��170��6�   
���   �
�������$��16(�6  ��6�   Z� 6  �� 5<      -   5        $ 
btn_search��5<      $��Search��61   $
��Left=�6B   $��185,387,0,25q�6]   $��62��6s   $��Microsoft YaHei UI Light)�6�   $��16(�6�   �� 5=      -   5        $ lb_date��5=      $��Date of Birth��6-   $��275,199,299,0q�6E   $	��Top=�6\   $��28��6t   ���	#FFBBBBBB$��Microsoft YaHei UI Light)�6�   $��16(�6�   �� 5>      -   5         ��Name$ image��5>      $��281,302,95,30q�6+   $��/img/leap.png��6B   5?      5@      �� 5D      -   5        $ 
tb_replays��5D      $��Replays��6*   $
��Left=�6;   $��80��6V   ���	#FFECEDEE
���   �$��Microsoft YaHei UI Light)�6�   {�.  $��16(�6�   .��5E      � -   5         �Name$ grid_playback��5E       J� IsHitTestVisible . $y�Visible=�6F    5F      �� 5G       � RowDefinitions 5I      �� 5J      $
��301* �6(   �� 5K      $��9* �6(   .+�5M      �� -   5        $ lb_patient_name��5M      $��Patient��65   $��Center=�6G   $��151,11,150,369q�6k   $��22(�6�   ���	#FFBBBBBB$ 0,0.5&�6�    � LayoutTransform 5N      V� 5O      .~�5P   "   T�  T� X$ 2Q�65   5Q      z�5S      V� 5T      .~�5U   "   T� $ -0.664Q�65   5V      5X      &   System.Windows.Controls.DataGrid  5Y      -   5          Name$ 
dg_replays��5Y      $
��Left=�63      AutoGenerateColumns .  $��
10,85,0,31q�6j   $	��432��6~   ���	#FFD8D7D7   GridLinesVisibility$ 
Horizontal=�6�      HorizontalGridLinesBrush �	#FF424242$��16(�6�       
IsReadOnly  . $! �� IsSynchronizedWithCurrentItem$! FalseY�6M  " �� AlternationCount$" 2��6s  #   AlternatingRowBackground# �	#FFAAA7A7$   RowBackground$ �	#FFDCDADA% �� IsTextSearchEnabled% . &   SelectionMode$& Single=�6�   . $
��Bold"�6  '   EnableRowVirtualization' .  (   MinColumnWidth$( 30Q�6C  )   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$) * 6W  ��6�   Z� *   Columns* 5Z      0  *System.Windows.Controls.DataGridTextColumn  5[      ,  &System.Windows.Controls.DataGridColumn+   Header$
+ Name��61   1  +System.Windows.Controls.DataGridBoundColumn,   Binding, 6?   �� *	File_name+  5\      $+ Recorded at��61   , 6F   �� *Record_date+5_      �� 5`      -   5        $ 
lb_replays��5`      $��Replays��60   $��11,0,577,342q�6B   $��Bottom=�6X   $��20(�6s   ���	#FFBBBBBB$��35��6�   $ 0,0.5&�6�    5a      V� 5b      .~�5c   "   �� �� 5d   "   �� 5e   "   T� 5f   "   $ 2Q�65   5g      z�5i      V� 5j      .~�5k   "   �� �� 5l   "   - �� AngleY$- 0.171Q�60   �� 5m   "   T� 5n   "   $ -0.664Q�65   5o      5q      �� 5r      -   5        $ 
btn_record��5r      $��Record��61   $��460,321,146,0q�6B   $	��Top=�6Y   $��32��6q   6}   �� 5s      -   5        $ btn_playback��5s      $��Playback��63   $��596,321,10,0q�6F   $	��Top=�6\   $��32��6t   6�   �� 5t      -   5        $	 tb_filename��5t      $��32��63   $��460,120,10,0q�6?   $

 Wrap=�6U   $	��Top=�6i   �� 5u      -   5        $ lb_filename��5u      $��Record name��61   $��460,85,90,0q�6G   $	��Top=�6\   ���	#FFBBBBBB$��20(�6�   $ 0.5,0.5&�6�   �� 5v      -    5        $ 
lb_details��5v      $��Details��60   $��460,157,115,0q�6B   $	��Top=�6Y   ���	#FFBBBBBB$��20(�6�   $ 0.425,2.486&�6�   �� 5w      -!   5        $	 
tb_details��5w      $	��115��62   $��460,192,10,0q�6?   $

 Wrap=�6U   $	��Top=�6i   �� 5x      -"   5        $ btn_delete_replay��5x      $��Delete��68   $��460,358,146,0q�6I   $	��Top=�6`   $��32��6x   6�   �� 5y      -#   5        $ btn_statistics��5y      $��
Statistics��65   $��596,358,10,0q�6J   $	��Top=�6`   $��32��6x   6�   5z      5{      5|      5}      5~      