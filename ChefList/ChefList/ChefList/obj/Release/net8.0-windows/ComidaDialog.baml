   M S B A M L   `   `   `  ����   ChefList    ChefList.ComidaDialog   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  Comida��$	��220��$	��400�����#F0F0C9 � 	Resources    RoundedButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius �� Triggers P� Property	 P� Value��%�  &	        �� " ��.���  � ��$. (pack://application:,,,/Fonts/#Cream DEMO)���  � ��$ 16(���  � ��$
 Bold"���  � �� �#124E78��  � ��
 �������  � ��
 ���� ��  � �� �� " ��.R��� #��z��#��z��#��z��#��z��$ 10��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver$
	 True��. ���  � ��
 �������  � �� �#124E78P�  � ��$
	 True��. ���  � ��
 �������  � ��
 �����.��� $��10q�
 � RowDefinitions
 �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��* � � ColumnDefinitions �� $
��Auto ��� $��* �.+��� $��Nombre:��$��0��$��0��$��Center=����#124E78�� $��0��$��1��$��5q����#F0F0C9���#124E78���#124E78���� *Comida.Nombre+�� $��Descripción:��$��1��$��0��$��Center=����#124E78�� $��1��$��1��$��5q����#F0F0C9���#124E78���#124E78���� *Comida.Descripcion+�� $��Precio:��$��2��$��0��$��Center=����#124E78�� $��2��$��1��$��5q����#F0F0C9���#124E78���#124E78���� *Comida.Precio+�� $��Categoría:��$��3��$��0��$��Center=����#124E78�� $��3��$��1��$��24��$��5q����#F0F0C9���#124E78���#124E78 �� SelectedValuePath$ Content������ *
Categorias+ �� SelectedItem �� *Comida.Categoria+��  �� Orientation$ 
Horizontal=�$��4��$��0��$��2��$��Center=�$��10q�.+��� -   $��Aceptar��$	��100��$��5q� �� 	IsDefault$
 True��#��[  �� $��Cancelar��$	��100��$��5q� �� IsCancel$
 True�����#D74E09#��[  