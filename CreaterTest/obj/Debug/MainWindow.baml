   M S B A M L   `   `   `  ����F  BCreaterTest, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:CreaterTestCreaterTest  5   	       CreaterTest.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:CreaterTest     5   	   U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5          � Title$  OMPEC��5	   	   $	��450��6   $	��900��6$    � WindowState$ 	Maximized=�60   .��5
      �  � ColumnDefinitions 5   
   �� 5      $
��0.3* �6   6.   �� 5      6!    � RowDefinitions 5   
   �� 5      6   �� 5      6   .+�5   
   �� $��2��6   .+�5      �� $��60��6   .+�5      �� $��60��6   $��Меню��6$   
���   �$��Center=�6F   $��Center=�6j   $��22(�6�   6�   5      �� 5      .@�5      �� -   5        $	��196��5      .��5      ��  �� Orientation$ 
Horizontal=�6!   $
��10 0q�6:   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Create=�62   $��30��6@   $��30��6K   $��Center=�6W   $��5q�6r   
���   �6}   �� 5      $��Добавить тест��6$   $��7q�69   
���   �$��16(�6W   $��Center=�6e   5      5      �� 5      -   5        $	��196��5      .��5      �� $ 
Horizontal=�6!   $
��10 0q�6:   .+�5         $ 	EventEdit=�62   $��30��6C   $��30��6N   $��Center=�6Z   $��5q�6u   
���   �6�   �� 5!      $ ��Редактировать��6$   $��7q�69   
���   �$��16(�6W   $��Center=�6e   5"      5#      �� 5$      -   5        $	��196��5$      .��5%      �� $ 
Horizontal=�6!   $
��10 0q�6:   .+�5&        $ EditOffOutline=�62   $��30��6H   $��30��6S   $��Center=�6_   $��5q�6z   
���   �6�   �� 5'      $��Удалить��6$   $��7q�63   
���   �$��16(�6Q   $��Center=�6_   5(      5)      5*      �� 5+      -   5         ��Name$ tbStroka��5+      $��23��6*    �� TextWrapping$
 Wrap=�66   $��TextBox��6J   5,      &   System.Windows.Controls.DataGrid  5-   
   -   5        $��dgView��5-   z   $��1��6   $��2��6#   $��10q�64   
�������
���   �
���   �$y�Visible=�6�   5.      �� 5/   
   -   5         ��Name$ qwfgsdg��5/   �   $��1��6   $
��Left=�6$   $��147,171,0,0q�6?   
�������
���   �$y�	Collapsed=�6{   $
��Wrap=�6�   $��	TextBlock��6�   $	��Top=�6�   	 J� RenderTransformOrigin$	 0.5,0.5&�6�   $	��147��6   $��2��6  $	��261��6  z�50      V� 51      .~�52      �� �� 53      �� 54      
 �� Angle$

 0.45Q�6&   T� 55      56      58      59      5:      