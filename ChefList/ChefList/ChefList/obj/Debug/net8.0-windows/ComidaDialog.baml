   M S B A M L   `   `   `  ����  ChefList    ChefList.ComidaDialog   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Comida��5   	   $	��220��6   $	��400��6%   ���#F0F0C9 � 	Resources 5         RoundedButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius �� Triggers P� Property	 P� Value��%3  &	        �� 5   
   " ��6+   .�5      ��  � ��$. (pack://application:,,,/Fonts/#Cream DEMO)�6+   �� 5	       � ��$ 16(�6)   �� 5
       � ��$
 Bold"�6+   �� 5       � �� �#124E786+   �� 5       � ��
 �����6+   �� 5       � ��
 ���� 6,   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��6A   #��z��5   !   #��z��6K   $ 10��5   !   ._�5      �� $��Center=�6/   $��Center=�6L   5      5      5       5      P� 5       �@J�IsMouseOver$
	 True��61   . �5      ��  � ��
 �����63   �� 5       � �� �#124E7863   5      P� 5       � ��$
	 True��6/   . �5      ��  � ��
 �����63   �� 5        � ��
 �����63   5!      5#      5$      .��5&      � $��10q�6   
 � RowDefinitions
 5'   
   �� 5(      $
��Auto �6   �� 5)      $
��Auto �6   �� 5*      $
��Auto �6   �� 5+      $
��Auto �6   �� 5,      $��* �6    � ColumnDefinitions 5.   
   �� 5/      $
��Auto �6   �� 50      $��* �6   .+�53   
   �� $��Nombre:��6   $��0��6#   $��0��60   $��Center=�6@   ���#124E786[   �� 54   
   $��0��61   $��1��6>   $��5q�6N   ���#F0F0C9���#124E78���#124E78��6   �� *Comida.Nombre+6�   �� 56   
   $��Descripción:��6   $��1��6(   $��0��65   $��Center=�6E   ���#124E786`   �� 57   
   $��1��66   $��1��6C   $��5q�6S   ���#F0F0C9���#124E78���#124E78��6   �� *Comida.Descripcion+6�   �� 59   
   $��Precio:��6   $��2��6#   $��0��60   $��Center=�6@   ���#124E786[   �� 5:   
   $��2��61   $��1��6>   $��5q�6N   ���#F0F0C9���#124E78���#124E78��6   �� *Comida.Precio+6�   �� 5<   
   $��Categoría:��6   $��3��6&   $��0��63   $��Center=�6C   ���#124E786^   �� 5=   
   $��3��6   $��1��6    $��24��60   $��5q�6<   ���#F0F0C9���#124E78���#124E78 �� SelectedValuePath$ Content��5>   `   ��6   �� *
Categorias+ �� SelectedItem 66   �� *Comida.Categoria+6`   �� 5@   
    �� Orientation$ 
Horizontal=�6   $��4��6.   $��0��6;   $��2��6K   $��Center=�6_   $��10q�6|   .+�5A      �� -   5        $��Aceptar��5A      $	��100��6'   $��5q�63    �� 	IsDefault$
 True��6>   #��[  6j   �� 5B      $��Cancelar��6   $	��100��6(   $��5q�64    �� IsCancel$
 True��6?   ���#D74E09#��[  6d   5C      5D      5E      