   M S B A M L   `   `   `  ����C  ?ChefList, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:ChefListChefList  5          ChefList.MenuManagement   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:ChefList     5      ���#F0F0C9  � 	Resources  5	         RoundedButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius �� Triggers P� Property P� Value��%3  &	        �� 5   
   " ��6+   .�5      ��  � ��$. (pack://application:,,,/Fonts/#Cream DEMO)�6+   �� 5       � ��$ 16(�6)   �� 5       � ��$
 Bold"�6+   �� 5       � �� �#124E786+   �� 5       � ��
 �����6+   �� 5       � ��
 ���� 6,   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��6A   #��z��5   !   #��z��6K   $ 10��5   !   ._�5      �� $��Center=�6/   $��Center=�6L   5      5      5       5      P� 5       �@J�IsMouseOver$
 True��61   . �5      ��  � ��
 �����63   �� 5        � �� �#124E7863   5!      P� 5"       � ��$
 True��6/   . �5#      ��  � ��
 �����63   �� 5$       � ��
 �����63   5%      5'      5(      .��5*      � .+�5+   
   �� $��10q�6   .+�5,      �� $��Gestión del Menú��6   $��24(�60   $
��Bold"�6>   $��0,0,0,20q�6P   ���#124E78$.��(pack://application:,,,/Fonts/#Cream DEMO)�6w   �� 5-      -   5        $��MenuListBox��5-      $��0,0,0,20q�6u   ���#F0F0C9���#124E78$��2q�6�   ��6)   �� *ComidasList+	 �� SelectedItem	 6M   �� *SelectedComida+��5.      �� 5/      .R�50      �� 
 �� Orientation$
 
Horizontal=�6%   $��0,0,0,5q�6>   .+�51      �� $	��100��6@   ���#124E78$.��(pack://application:,,,/Fonts/#Cream DEMO)�6a   ��6(   �� *Nombre+6a   �� 52      $	��150��6E   ���#124E78$.��(pack://application:,,,/Fonts/#Cream DEMO)�6f   ��6(   �� *Descripcion+6f   �� 53      $��80��6P   ���#124E78$.��(pack://application:,,,/Fonts/#Cream DEMO)�6p   ��6(   �� *Precio+ �� StringFormat$ C��6p   �� 54      $	��100��6C   ���#124E78$.��(pack://application:,,,/Fonts/#Cream DEMO)�6d   ��6(   �� *	Categoria+6d   55      56      58      �� 59      $
 
Horizontal=�6   $��Center=�62   .+�5:      �� -   5        $��Añadir��5:      $	��100��6*   $��5q�66   #��[  6Y   �� 5;      -   5        $��Editar��5;      $	��100��6*   $��5q�66   #��[  6�   {�6Z   �� *IsComidaSelected+6�   �� 5<      -   5        $��Eliminar��5<      $	��100��6,   $��5q�68   ���#D74E09#��[  6�   {�6^   �� *IsComidaSelected+6�   5=      5>      5?      5@      