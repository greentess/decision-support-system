   M S B A M L   `   `   `  ����B  >WpfApp3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp3WpfApp3  5          WpfApp3.Window11   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp3     5        � Title$'  !Окно управляющего��5      $
��1176��6!   $	��593��6.    � WindowStartupLocation$ CenterScreen=�6;    � 
ResizeMode$ NoResize=�6`   .��5
      � -   5        $
��graf��5
   "   ���	#FFE6CACB$��0,0,2,-3q�6.    � ColumnDefinitions 5   
   �� 5      $	��553 �6   �� 5      $	��597 �6   �� 5      $��0 �6   .+�5   
   �� -   5        $��Segoe UI Light)�5      $��16(�6-   $��Очистить��6;   $��12,491,357,25q�6j   �� 5   
   $��16(�6   $��Segoe UI Light)�6   $7��1Расходуемая часть бюджета:��6;   $��133,116,121,386q�6`   $��1��6y   �� 5   
   -   5        $��40��5      $��Segoe UI Light)�6   $	��Top=�69   $��295,84,10,0q�6p   $��16(�6�   $!��Загрузить файл��6�   
����������	#FF5D4F48���	#FF5D4F486�   �� 5   
   -   5        $��16(�5      $	��Top=�6   $��Segoe UI Semibold)�67   $��0,319,480,0q�6u   $��33��6�   $��Рассчитать��6�   
����������	#FF78574A$
��Bold"�6�   $��1��6�   �� 5   
   -   5        $	��max��5   <   $��Segoe UI Light)�6   $��16(�6.   $
��Left=�6G   $��32��6b   $��	85,89,0,0q�6n    �� TextWrapping$
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $��61��6�   �� 5   
   -   5        $��Segoe UI Light)�5      $��16(�6-   $$��Справка о методе��6;   $��10,10,370,505q�6p   �� 5   
   $��Segoe UI Light)�6   $��16(�6,   $��Бюджет:��6:   $��12,89,421,417q�6L   �� 5    
   $��Segoe UI Light)�6   $��16(�6,   $��тыс. руб.��6:   $��146,89,267,417q�6N   �� 5"   
   -   5        $��OptMax��5"   N    �� 
IsReadOnly . $��Segoe UI Light)�6$   $��16(�6@   $
��Left=�6\   $��30��6w   $��347,117,0,0q�6�   $
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $��96��6�   $��1��6�   �� 5#   
   $��16(�6   $��Segoe UI Light)�6   $5��/Полученная сумма охватов:��6;   $��133,79,106,420q�6_   $��1��6w   �� 5$   
   -   5         ��Name$ OptPP��5$   N    . $��Segoe UI Light)�6$   $��16(�6@   $
��Left=�6]   $��29��6x   $��
347,82,0,0q�6�   $
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $��96��6�   $��1��6�   �� 5%   
   $��Segoe UI Light)�6   $��16(�6,   $��тыс. руб.��6:   $��448,116,32,392q�6N   $��1��6f   &   System.Windows.Controls.DataGrid  5&   
   -	   5        $$��optimized_reklama_listDataGrid��5&   [      AutoGenerateColumns .  $��15(�6/   $��Segoe UI Light)�6=   $��131,181,0,95q�6�   ���	#FF7C5E52���	#FF5F4840���	#FFC9F0C7$��1��6�   $��2��6�      Columns 5'      0  *System.Windows.Controls.DataGridTextColumn  5(      ,  &System.Windows.Controls.DataGridColumn	   CanUserResize	 .  
   Header$	
 №��6T      Width5  /System.Windows.Controls.DataGridLengthConverter$ 30 6_   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *num+6_     5)      	 . $-
 'Наименование рекламы��6T   $	 180 6r    6%   �� *name+6r     5*      	 .  $!
 Стоимость (т.р.)��6R   $	 110 6l    6%   �� *w+6l     5+      	 .  $
 Охваты (чел.)��6Q   $	 140 6h    6%   �� *p+6h   5-      �� 5.   
   -
   5        $��Segoe UI Light)�5.      $��16(�6-   $��
Выход��6;   $��392,10,10,505q�6e   �� 5/   
   -   5        $
��save��5/      $��Segoe UI Light)�6   $��16(�69   $$��Сохранить в файл��6G   $��133,491,257,25q�6|   $��1��6�   �� 51   
   -   5        $
��Left=�51      $	��322��60   $��
12,150,0,0q�6=   $	��Top=�6Q   $	��531��6i   .@�52      �� -   5        $
��tab1��52      $&�� Входящие в бюджет��6"   $��0,0,0,-2q�6=   $
��Bold"�6O   $��Segoe UI Light)�6a   $	��200��6}   $��Center=�6�   $��30��6�   ���	#FF3B6637 � Cursor$
 Hand��6�   $y�Hidden=�6�   4  .System.Windows.Automation.AutomationProperties   Name$
 tabs��6�   ��53      �� 54       �� EndPoint$	 0,1&�6*    �� 
StartPoint$	 0,0&�69   .��55      �  � Color$ 	#FFDEDEDE��6'    � Offset$ 0Q�69   � 56      $ 	#FFC1C7BB��6'   $ 1Q�69   57      .��59      �  5:      �� 5;      .+�5=      �� $��Segoe UI Semibold)�6   $��15(�6;   $c��]Список вариантов рекламы, укладывающейся в бюджет:��6I   $��Italic$�6�   $
��Bold"�6�   $��42,10,59,237q�6�     5>      -   5        $��reklama_listDataGrid��5>   �   $	��467��6     .     CanUserAddRows . $��15(�6a   $��Segoe UI Light)�6o   ���	#FF7C5E52���	#FF5F4840���	#FFD8D8D8$	��Top=�6  $	��225��6.  $
��Left=�6;  $	��463��6V  $��	27,47,0,0q�6e  $	��476��6x  ��6�   �� *GridCollection+ 5?        5@      	 .  -   5        num��$	
 №��5@   l   $ 30 6w    61   �� *num+6w     5A      	 . -   5        name��$-
 'Наименование рекламы��5A   n   $	 180 6�    61   �� *name+6�     5B      	 .  -   5        w��$!
 Стоимость (т.р.)��5B   i   $	 110 6�    61   �� *w+6�     5C      	 .  -   5        p��$
 Охваты (чел.)��5C   i   $	 140 6�    61   �� *p+6�   5E      5F      5J      �� 5K      -   5        $
��tab2��5K      $
��Bold"�6"   $��Segoe UI Light)�64   $+��%Не входящие в бюджет��6P   $��Center=�6n   $��30��6�   $	��200��6�   $��0q�6�   ���	#FF892E2E$
 Hand��6�   $y�Hidden=�6�   ��5L      �� 5M      $	 0,1&�6*   $	 0,0&�69   .��5N      � $ 	#FFE89D9D��6'   $ 0Q�69   � 5O      $ 	#FFF09696��6'   $ 1Q�69   � 5P      $ 	#FFEC9898��6'   $ 0.612Q�69   5Q      .��5S      �  5T      �� 5U      .+�5W      �� $��Segoe UI Semibold)�6   $��15(�6;   $h��bСписок вариантов рекламы, не укладывающейся в бюджет:��6I   $��44,10,10,212q�6�   $��Italic$�6�   $
��Bold"�6�    J� RenderTransformOrigin$ 0.5,0.5&�6�     5Y      -   5          Name$ NONreklama_listDataGrid��5Y   �      
IsReadOnly .  .   . $��15(�6d   $��Segoe UI Light)�6r   $	��467��6�   ���	#FF7C5E52���	#FF5F4840���	#FFFFAEAE$	��Top=�6  $	��220��6  $
��Left=�6*  $	��463��6E  $��	23,51,0,0q�6T  $	��481��6g   5Z        5[      	 .  -   5        num1��$	
 №��5[   m   $ 30 6x    61   �� *num+6x     5\      	 . -   5        	name1��$-
 'Наименование рекламы��5\   o   $	 180 6�    61   �� *name+6�     5]      	 .  -   5        w1��$!
 Стоимость (т.р.)��5]   j   $	 110 6�    61   �� *w+6�     5^      	 .  -   5        p1��$
 Охваты (чел.)��5^   j   $	 140 6�    61   �� *p+6�   5`      5a      5c      5f      �� 5g   
   $��Segoe UI Light)�6   $��16(�6,   $��чел.��6:   $��448,84,32,424q�6I   $��1��6`   5h      5k      