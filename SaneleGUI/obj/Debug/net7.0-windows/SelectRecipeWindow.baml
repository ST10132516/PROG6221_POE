   M S B A M L   `   `   `  ����D  @SaneleGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:SaneleGUI	SaneleGUI  5   	   "    SaneleGUI.SelectRecipeWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:SaneleGUI     5   	     � Title$  Select Recipe��5   	   $	��450��6   $	��800��6,   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��Select a Recipe:��6   $��10q�6+   �� 5   
   -   5         ��Name$ 
cmbRecipes��5      $	��300��6'   $��10q�6b   $��1��6n   �� 5   
   -   5        $��Show Details��5      $��10q�6E   $��2��6Q   �� 5   
   $5��/Enter factor to scale recipe by (0.5, 2, or 3):��6   $��10q�6J   $��3��6V   �� 5   
   -   5         ��Name$ txtScalingFactor��5      $	��300��6,   $��10q�6m   $��4��6y   �� 5   
   -   5        $��Scale Recipe��5      $��10q�6E   $��5��6Q   �� 5   
   -   5        $��Add to Menu��5      $��10q�6B   $��7��6N   �� 5   
   -   5        $��Create Menu��5      $��10q�6C   $��8��6O   5!      5"      