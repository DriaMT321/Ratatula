   M S B A M L   `   `   `  ����F  BMesaCliente, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:MesaClienteMesaCliente  5   	       MesaCliente.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:MesaCliente     5   	     � Title$
  Mesa��5   	   $	��600��6   $
��1000��6#   ���#F0F0C9 � 	Resources 5
         RoundedButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius �� Triggers P� Property	 P� Value  SelectedButtonStyle
 �� BasedOn��%7  &	        &	 �    7   �� 5   
   " ��6+   .�5      ��  � ��$- 'pack://application:,,,/Font/#Cream DEMO)�6+   �� 5       � ��$ 20(�6)   �� 5       � ��$
 Bold"�6+   �� 5       � ��
 ���� 6+   �� 5       � ��
 �����6+   �� 5       � ��
 ���� 6,   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��6A   #��z��5   !   #��z��6K   $ 10��5   !   ._�5      �� $��Center=�6/   $��Center=�6L   5      5      5       5      P� 5       �@J�IsMouseOver$
	 True��61   . �5       ��  � ��
 �����63   �� 5!       � �� �#6E0E0A63   5"      5$      �� 5&   
   " ��6,   8
   .�5'      ��  � ��
 �����6+   �� 5(       � �� �#6E0E0A6+   5)      5*      .��5+      �  � RowDefinitions 5,   
   �� 5-      $��* �6   �� 5.      $
��Auto �6   .+�51   
   �� -   5         ��Name$ MainContent��51      $��0��6.   
�������6;   �� 53   
   ���#6E0E0A$ 20��6&    �� Padding$ 10q�68   $��1��6E   $��Center=�6R   ._�54      ��  �� Orientation$ 
Horizontal=�6   .+�55      �� -   5         ��Name$ Homebtn��55      $��Inicio��6*   $	��200��6;   $��40��6G   #��[  56      �� 57      -   5        $ Menubtn��57      $
��Menu��6*   $	��200��69   $��40��6E   #��[  58      �� 59      -   5        $ 	Pedidobtn��59      $��Pedido��6,   $	��200��6=   $��40��6I   #��[  5:      �� 5;      -   5        $ Pagarbtn��5;      $��Pagar��6+   $	��200��6;   $��40��6G   #��[  5<      5=      5>      5?      5@      