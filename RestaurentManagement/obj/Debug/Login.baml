   M S B A M L   `   `   `  ����O  KRestaurentManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:RestaurentManagementRestaurentManagement  5           RestaurentManagement.Login   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:RestaurentManagement     5        N� Title$  Login��5	      .��5      � ��5   
   �� 5       �� ImageSource$ 	Login.jpg��6    � ColumnDefinitions 5   
   �� 5      $��20 �6   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��20 �6    � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��20 �6   .+�5   
   �� -   5        $��StackPanel1��5   M   $��1��6   $��0��6%   $
��Left=�62   $	��Top=�6`   5       �� 5!   
   -   5        $��StackPanel2��5!   P   $��2��6   $��1��6%   $��Stretch=�62    �� Orientation$ Vertical=�6c   $��Stretch=�6z   .+�5"      �� $��45(�6   $��Center=�6&   $��Center=�6C   $��
44,0,44,15q�6^   ���	#FF5EBF92Restaurant Management6�   5#      �� 5$   
   -   5        $��StackPanel3��5$   M   $��3��6   $��0��6%   $
��Left=�62   $	��Top=�6`   5&      �� 5'   
   -   5        $��StackPanel4��5'   M   $��1��6   $��2��6%   $
��Left=�62   $	��Top=�6`   $��2��6x   .+�5(      �  5)      �� 5*      $��* �6'   63   �� 5+      $��* �6'   63    5-      �� 5.      $��* �6$   61   �� 5/      $��* �6$   61   �� 50      $��* �6$   61   .+�52      �� -   5         ��Name$ lbl_username��52      $��0��6.   $��0��6;   $��Username��6K   $
��Left=�6^   $��Center=�6y   
�������$��16(�6�   �� 53      -   5         ��Name$ 	txt_email��53      $
��Left=�6-   $��0��6H   $��1��6U   $��25��6e    �� TextWrapping$
 Wrap=�6q   $��Center=�6�   $	��220��6�   $��Center=�6�   �� 55      -   5        $ lbl_password��55      $��1��6.   $��0��6;   $��Password��6K   $
��Left=�6^   $��Center=�6y   
�������$��16(�6�   G� 56      -   5         G�Name$ txt_password��56      $
��Left=�64   $��1��6O   $��1��6\   $��25��6l   $��Center=�6x   $	��220��6�   $��Center=�6�   �� 58      -	   5        $��Sign In��58      $��Right=�6+   $��1q�6G   $	��Top=�6[   $��75��6s   $��2��6~   $��1��6�   ���	#FFB5DAC9
�������
�������6�   59      5:      5;      5<      