   M S B A M L   `   `   `  ����D  @SaneleGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:SaneleGUI	SaneleGUI  5   	       SaneleGUI.MainWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:SaneleGUI     5   	     � Title$  Recipe Manager��5   	   $	��450��6    $	��800��6-    � 	Resources 5	         MenuButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius��%�  &	        �� 5
   
   " ��6(   .�5      ��  � �� �	#FF2E75B56+   �� 5       � ��
 �����6+   �� 5       � ��$ 18(�6)   �� 5       � ��$
 Bold"�6+   �� 5       � ��$ 0 0 0 10q�6'   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   $��0q�6K   $ 5��6_   ._�5      �� $��Center=�6/   $��Center=�6L   5      5      5      5      5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5"   
   �� $$��Welcome to the Recipe Manager!��6   $��24(�6:   $
��Bold"�6H   $��	0 20 0 10q�6Z   $��Center=�6m   �� 5$   
   $��1��6   $��Center=�6"   $��Center=�6?   .+�5%      �� -   5        $��Create Recipe��5%      $	��150��6-   $��50��69   $��0 0 0 10q�6E   #��[  6W   6�   �� 5&      -   5        $��Select Recipe��5&      $	��150��6-   $��50��69   $��0 0 0 10q�6E   #��[  6W   6�   5'      �� 5)   
   -   5        $��2��5)      $
��Exit��6   $	��100��6-   $��30��69   $��	0 10 10 0q�6E   $��Right=�6X   #��[  6t   6�   5*      5+      