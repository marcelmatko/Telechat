   M S B A M L   `   `   `  ����C  ?Telechat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Telechat.WindowsTelechat.Windows  5   	   (    "Telechat.Windows.EditContactWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:Telechat.Windows     5   	   $	��274��5	   	   $	��291��5
   	     � 
ResizeMode$  NoResize=�5   	    � Title 5   	   �� *SelectedContact.Name+.��5      � ���#0e1621.+�5   
   �  � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6     � ColumnDefinitions 5      �� 5      �� 5      .+�5      �� -   5        $��2��5      $��9��5      ���#17212b$��63,16,63,-47q�5!      $	��200��5"      $��Save changes��5#      
�������5%      �� 5&      $��2��6   
�������$
��Name��5(      �� 5)      -   5        $��contactName��5,      $��2��5*      $��1��5+      ���#17212b
����������#292B2F$��2q�50      $��2q�51      ��5)      �� *SelectedContact.Name+ �� Mode$ TwoWay=�51      �� 52      $��2��6   
�������$��Username��54      $��2��55      �� 56      -   5        $��contactUsername��59      $��2��57      $��3��58      ���#17212b
����������#292B2F$��2q�5=      $��2q�5>      ��56      �� *SelectedContact.Username+$ TwoWay=�5>      �� 5?      $��4��6   $��1��5@      $��3��5A      .+�5B      �� 
�������.��6+   Status63   �� 5C      -   5        $��statusComboBox��5D      $	��120��5C       �� SelectedValue 5E      �� *SelectedContact.Status+$ TwoWay=�5F      �� 5G      $��0��6   $��0��5H      $��5��5I      $��
2, 0, 2, 0q�5J      $��1q�5K      ���#17212b._�5M      �  5N      �� 5O      �� 5P      $
��auto �6(   .+�5R      ��  �� Orientation$ 
Horizontal=�6!   $��Center=�5S   !   $��Center=�5T   !   .+�5U      �� -   5        $��contactImage��5U       $	��100��5W       $	��100��5X       $
��Fill=�5Y       ��5V       �� *SelectedContact.ImageSource+$ TwoWay=�5Y       5Z      �� 5[      -   5        $��2��5[      $��0��5\      $��2,0,2,0q�5]      ���#17212b$��0q�5_      $��Choose image��5`      
�������$��Center=�5c      $��30��5d      5e      5f      5g      5h      5i      