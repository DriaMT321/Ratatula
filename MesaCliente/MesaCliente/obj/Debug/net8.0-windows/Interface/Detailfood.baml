   M S B A M L   `   `   `  ����F  BMesaCliente, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:MesaCliente.InterfaceMesaCliente.Interface  5      &     MesaCliente.Interface.Detailfood   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:MesaCliente.Interface     5        � 	Resources  5	         RoundedButtonStyle �� 
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
 �����63   5%      5'      5(      .��5*      � $��20q�6   	 � ColumnDefinitions	 5+   
   �� 5,      $��2* �6   �� 5-      $��* �6   
 � RowDefinitions
 5/   
   �� 50      $
��Auto �6   �� 51      $
��Auto �6   �� 52      $
��Auto �6   �� 53      $��* �6   .+�57   
   �� -   5         ��Name$ txtName��57      $��COMIDA��6%   $
��Bold"�63   $��20(�6E   $��0��6S   $��0��6`   $��5q�6p   $��Center=�6{   �� 5:   
   
�������$	��150��6%   $	��150��61   $��0��6>   $��1��6K   $��Center=�6[   $��Center=�6x   �� 5=   
   -   5        $ DescriptionText��5=      $����Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce risus nunc, pulvinar eu diam sed, sodales venenatis odio. Morbi sagittis pretium ligula at pellentesque. Aliquam faucibus convallis ante, vitae placerat orci dictum pulvinar.��6-   $
��Wrap=�5>      $��1��6(   $��0��65   $��2��6E   $��	5,5,200,5q�6Y   �� 5A   
   -   5        $ CategoryText��5A      $��
Categoría��6*   $
��Bold"�6;   $��2��6M   $��0��6Z   $��5q�6j   �� 5D   
   -   5        $ 	PriceText��5D      $��Bs 0.00��6'   $
��Bold"�66   $��20(�6H   $��2��6V   $��1��6c   $��5q�6s   $��Center=�6~   �� 5G   
   -   5         ��Name$ Addbtn��5G      $��Añadir��6!   $��3��62   $��1��6?   $	��100��5H      $��40��6   $��0,10,0,0q�6)   $��Center=�5I      $	��Top=�6.   #��[  5J      6=   5K      5L      