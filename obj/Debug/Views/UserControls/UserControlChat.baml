   M S B A M L   `   `   `  ����>  :Bot, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Bot.Views.UserControlsBot.Views.UserControls  5      ,    &Bot.Views.UserControls.UserControlChat   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:Bot.Views.UserControls     5        � DataContext  5	      �� *Chat+   Locator �� Source# [   � 	Resources 5
       �� 
TargetType �� Triggers �� Binding �� ElementName �� Path �� Value	 �� Property
 �� Value��%�   '��       �� 5   
   " ��6    5      �� 5       6   �� $ cb��$
 IsMy� True5      .a�5      �� 	 � ��$
 Right=�6<   �� 5      	 � ��

 �����63   5      5      5      .��5      �� $��Bottom=�6   .+�5   
   �� $	��540��6   
���   ���. .��5      �� ��6   �� *
Messages+��5      �� 5      .R�5      � $	��400��6   ��5      �� 5    "    5!   &   �� 5"   *    66   �� *IsMy+ True6O   .a�5#   .   �� 	 � ��$
 Right=�6Y   5%   +   �� 5&   *    66   �� *IsMy+	 False6O   .a�5'   .   �� 	 � ��$

 Left=�6Y   5(   +   5*   #   .+�5,      �� $��10 12 30 12q�6'   ��5-   "   �� 5.   &    5/   *   �� 50   .    6:   �� *IsMy+ True6S   .a�51   2   �� 	 � ��

 �����6V   �� 52   2   	 �@��CornerRadius$
 
15 15 0 15��6X   53   /   �� 54   .    6:   �� *IsMy+	 False6S   .a�55   2   �� 	 � ��

 ��  �6V   �� 56   2   	 �@��CornerRadius$
 
20 20 20 0��6X   57   /   59   '   ._�5;   "   �� $��15q�6,   $
��Wrap=�68   
���������6M   �� *Text+6c   5<      �� 5=      $
��Left=�6B   
�������$��Bottom=�6p   $��10(�6�   $��10 -2q�6�   ��6(   �� *
DateTime+6�   5?      5@      5C      5G      5H      5K      