   M S B A M L   `   `   `  ����C  ?ChefList, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:ChefListChefList  5          ChefList.Facturas   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:ChefList     5      .��5	      � .+�5
   
   �� -   5        $��FacturaListBox��5
      $��10q�6L   $��0q�6X   
������ ��6(   �� *FacturaList+  � 	Resources  5       �� 
TargetType �� Property �� Value �� 
TargetType ��Name �� CornerRadius �� Padding � ColumnDefinitions	 �� Orientation
 �� StringFormat �� Triggers P� Property P� Value �� 
TargetName��%M  '��       �� 5      " ��6   .�5      ��  � �� 5      �� 5      " ��6.   .R�5   "   �� $ border��6)   
�������$��1q�6L   $ 10��6`   $ 10q�6r   $��5q�6   
�������._�5   &   �  5   *   �� 5   .   $
��Auto �6?   �� 5   .   $��* �6?   �� 5   .   $
��Auto �6?   .+�5   *   �� $	 
Horizontal=�65   $��0��6N   $��Center=�6^   .+�5   .   �� $
��ID: ��68   $
��Bold"�6D   ���#124E78$.��(pack://application:,,,/Fonts/#Cream DEMO)�6k   �� 5   .   ���#124E78$.��(pack://application:,,,/Fonts/#Cream DEMO)�6a   ��68   �� *Id+6a   5   +   �� 5   *   $	 
Horizontal=�65   $��1��6N   $
��Left=�6^   $��10,0,0,0q�6y   .+�5   .   �� $��Nombre: ��68   $
��Bold"�6H   ���#124E78$.��(pack://application:,,,/Fonts/#Cream DEMO)�6o   �� 5    .   ���#124E78$.��(pack://application:,,,/Fonts/#Cream DEMO)�6k   ��68   �� *NombreComida+6k   5!   +   �� 5#   *   $	 
Horizontal=�65   $��2��6N   $��Right=�6^   $��10,0,0,0q�6z   .+�5$   .   �� $��Precio: ��68   $
��Bold"�6H   ���#124E78$.��(pack://application:,,,/Fonts/#Cream DEMO)�6o   �� 5%   .   ���#124E78$.��(pack://application:,,,/Fonts/#Cream DEMO)�6u   ��68   �� *Precio+$
 C��6u   �� 5&   .   $��Fecha: ��68   $
��Bold"�6G   $��10,0,0,0q�6Y   ���#124E78$.��(pack://application:,,,/Fonts/#Cream DEMO)�6�   �� 5'   .   ���#124E78$.��(pack://application:,,,/Fonts/#Cream DEMO)�6�   ��68   �� *	FechaHora+$
 {0:dd/MM/yyyy HH:mm}��6�   5(   +   5)   '   5*   #    5+   "   P� 5,   &    �@J�IsMouseOver$
 True��6E   . �5-   *   �� $ border��61    � �� �#DCE7756[   5.   '   P� 5/   &    �@��
IsSelected$
 True��6D   . �50   *   �� $ border��61    � �� �#A5D6A76[   51   '   53      55      56      57      ��58      �� 59      .R�5:      �  5;      �� 5<      $
��Auto �6/   �� 5=      $��* �6/   �� 5>      $
��Auto �6/   .+�5B      �� $	 
Horizontal=�6%   $��0��6>   $��Center=�6N   .+�5C      �� $
��ID: ��6(   $
��Bold"�64   ���#124E78$.��(pack://application:,,,/Fonts/#Cream DEMO)�6[   �� 5D      ���#124E78$.��(pack://application:,,,/Fonts/#Cream DEMO)�6Q   ��6(   �� *Id+6Q   5E      �� 5G      $	 
Horizontal=�6%   $��1��6>   $
��Left=�6N   $��10,0,0,0q�6i   .+�5H      �� $��Nombre: ��6(   $
��Bold"�68   ���#124E78$.��(pack://application:,,,/Fonts/#Cream DEMO)�6_   �� 5I      ���#124E78$.��(pack://application:,,,/Fonts/#Cream DEMO)�6[   ��6(   �� *NombreComida+6[   5J      �� 5L      $	 
Horizontal=�6%   $��2��6>   $��Right=�6N   $��10,0,0,0q�6j   .+�5M      �� $��Precio: ��6(   $
��Bold"�68   ���#124E78$.��(pack://application:,,,/Fonts/#Cream DEMO)�6_   �� 5N      ���#124E78$.��(pack://application:,,,/Fonts/#Cream DEMO)�6e   ��6(   �� *Precio+$
 C��6e   �� 5O      $��Fecha: ��6(   $
��Bold"�67   $��10,0,0,0q�6I   ���#124E78$.��(pack://application:,,,/Fonts/#Cream DEMO)�6p   �� 5P      ���#124E78$.��(pack://application:,,,/Fonts/#Cream DEMO)�6}   ��6(   �� *	FechaHora+$
 {0:dd/MM/yyyy HH:mm}��6}   5Q      5R      5S      5U      5V      5W      