   M S B A M L   `   `   `  ����F  BMesaCliente, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:MesaCliente.InterfaceMesaCliente.Interface  5      !    MesaCliente.Interface.Pagar   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:MesaCliente.Interface     5        � 	Resources  5	         RoundedButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius �� Triggers P� Property P� Value��%:  &	        �� 5   
   " ��6+   .�5      ��  � ��$- 'pack://application:,,,/Font/#Cream DEMO)�6+   �� 5       � ��$ 16(�6)   �� 5       � ��$
 Bold"�6+   �� 5       � �� �#f2bb056+   �� 5       � �� �#6e0e0a6+   �� 5       � ��
 ���� 6,   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��6A   #��z��5   !   #��z��6K   $ 10��5   !   ._�5      �� $��Center=�6/   $��Center=�6L   5      5      5       5      P� 5       �@J�IsMouseOver$
 True��61   . �5      ��  � �� �#6e0e0a63   �� 5        � �� �#f2bb0563   5!      P� 5"       � ��$
 True��6/   . �5#      ��  � ��
 �����63   �� 5$       � ��
 �����63   5%      5'      5(      .��5*      � 	 � ColumnDefinitions	 5+   
   �� 5,      $��* �6   �� 5-      $
��Auto �6   .+�51   
   �� $��0��6   $
��Auto=�6'   $��Disabled=�6J   .��52      �� ���#f2bb05$ 10��6*   $��10q�6<   ._�53      �� -   5        
 ��Name$
 
leftCanvas��53      
������ 54      55      56      �� 59   
   $��1��6   $��Center=�6%   $��Center=�6@   $��10q�6]   .+�5;      �� $,��&pack://application:,,,/Images/logo.png��6   $	��100��6D   $	��100��6P   $��0,0,0,10q�6]   �� 5=      -   5         ��Name$ totalTextBlock��5=      $��Total: Bs 0.00��60   $��16(�6F   $
��Bold"�6T   ���#d74e09$��0,0,0,10q�6{   �� 5>      -   5         ��Name$ endServicebtn��5>      $��Terminar Servicio��6,   $	��200��6H   $��40��6T   #��[  5?      6A   5@      5A      5B      