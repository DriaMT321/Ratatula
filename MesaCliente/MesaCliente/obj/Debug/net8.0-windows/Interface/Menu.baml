   M S B A M L   `   `   `  ����F  BMesaCliente, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:MesaCliente.InterfaceMesaCliente.Interface  5           MesaCliente.Interface.Menu   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:MesaCliente.Interface     5        � 	Resources  5	         RoundedButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius  ButtonBackground  ButtonForeground �� Triggers P� Property P� Value��%i  &	        �� 5   
   " ��6+   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��6A   #��z��5   !   #��z��6K   $ 10��5   !   ._�5      �� $��Center=�6/   $��Center=�6L   5      5      5      �� 5       � ��# �  6+   �� 5       � ��# �  6+   �� 5       � ��$
 Bold"�6+   �� 5       � ��$ Center=�6;   �� 5       � ��$ Center=�69    5      P� 5       �@J�IsMouseOver$
 True��61   . �5      ��  � �� �#f0f0c963   �� 5       � �� �#d74e0963   5       5"      5#      .��5$      � 	 � ColumnDefinitions	 5%   
   �� 5&      $	��200 �6   �� 5'      $��* �6   .+�5+   
   �� $��0��6   
�������$��1q�64   ���#DFDFCE._�5,      � 
 � RowDefinitions
 5-      �� 5.      $
��Auto �6$   �� 5/      $
��Auto �6$   �� 50      $��* �6$   .+�54      ��  �� Orientation$ 
Horizontal=�6   $��0��66   $��10q�6C   .+�55      �� $
��MENU��6    $
��Bold"�6,   $��16(�6>   $��Center=�6L   �� 56      $��20��6   $��20��6(   $��10,0,0,0q�64   
�������
������ $��Center=�58      $��Center=�6:   #��[  59      5:      �� 5=      -   5        $��Filtrar��5=      $��
79,9,19,11q�6D   $	��100��6X   #��[  6d   �� 5@      -   5         ��Name$ filtroPanel��5@      $ Vertical=�62   $��1��6I   $��10q�6V   $y�	Collapsed=�6b   .+�5A      �� $��Filtros��6    $
��Bold"�6/   $��14(�6A   $��0,0,0,10q�6O   	� 5B      -   5        $
��Sopa��5B   "    	� 	GroupName$ CategoryFilter��61   6L   	� 5C      -   5        $��Segundo��5C   "   $ CategoryFilter��64   6O   	� 5D      -   5        $��Bebida��5D   "   $ CategoryFilter��63   6N   	� 5E      -   5        $��Postre��5E   "   $ CategoryFilter��63   6N   	� 5F      -   5        $
��Todo��5F   "   $ CategoryFilter��61    d� 	IsChecked$
 TrueY�6L   6]   5G      �� 5J      -   5         ��Name$ scrollViewer��5J      $��2��65   $
��Auto=�6B   .��5K      �� -	   5        $ comidasStackPanel��5K   !   5M      5N      5O      5P      �� 5S   
   -
   5         ��Name$ detailsContentControl��5S      $��1��68   
�������6H   5T      5U      